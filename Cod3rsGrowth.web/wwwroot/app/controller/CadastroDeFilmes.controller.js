sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador",
    "cod3rsgrowth/app/model/validador",
    "sap/m/MessageBox",
    "sap/m/Dialog",
	"sap/m/Button",
	"sap/m/Text",
    "sap/m/library",
    "sap/ui/core/library"
], function(BaseController, JSONModel, Repositorio, Formatador, Validador,  MessageBox, Dialog, Button, Text, mobileLibrary, coreLibrary) {
	"use strict";

    const INDICE_ZERO = 0;
	const STRING_VAZIA = "";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.CadastroDeFilmes";
    const ROTA_CADASTRO = "CadastroDeFilmes";
    const MENSAGEM_CONFIRMACAO_DIALOG = "OK";
    const ROTA_EDICAO = "EdicaoDeFilmes";

	return BaseController.extend(ROTA_CONTROLLER, {
        ID_FILME : null,

		onInit: function() {	
            this
			.getRouter()
			.getRoute(ROTA_CADASTRO)
			.attachPatternMatched(async () => {
                this._alterarParaCadastro();
				return this._aoCoincidirRotaCadastro();
			}, this);

            this
			.getRouter()
			.getRoute(ROTA_EDICAO)
			.attachPatternMatched(async (evento) => {
                this._alterarParaEdicao();
				return this._aoCoincidirRotaEdicao(evento);
			}, this);
		},

        _aoCoincidirRotaEdicao: function(evento) {
            const argumentoDoEvento = "arguments";
            const nomeModelo = "filmeEditar";

            let view = this.getView();
            let id = evento.getParameter(argumentoDoEvento).id;

            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
                ]);
                Repositorio.obterPorId(view, id, nomeModelo).then(() => {
                    this._preencherCamposEdicao();
                })
            });
        },

        _aoCoincidirRotaCadastro: function() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
                ]);
            });
        },

        _obterIndiceGenero: function(Genero){
            const modeloGenerosNome = "Generos";

			let generos = this.getView().getModel(modeloGenerosNome).getData();
			for (let i = INDICE_ZERO; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

        _obterIndiceClassificacao: function(Classificacao){
	        const modeloClassificacaoNome = "Classificacoes";
			let classificacoes = this.getView().getModel(modeloClassificacaoNome).getData();
			for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
				if(classificacoes[i].descricao == Classificacao){
					return i;
				}
			}
		},

        _aoClicarEmCadastrar: async function(){

            const mensagemCadastroNaoConcluido = "Cadastro não realizado";
            const modeloFilmeCadastrado = "FilmeCadastrado";
            const messageBoxTitulo = "Erro de Validação";
            const mensagemFilmeCadastrado = "Filme cadastrado com sucesso!";

            let view = this.getView();
            let validacaoDeEntradas = Validador.validarTodos(view);

            if(validacaoDeEntradas != STRING_VAZIA){
                let mensagemDeErro = this._criarDialog(messageBoxTitulo, validacaoDeEntradas);
                return mensagemDeErro.open();
            }

            let modeloFilme = this._criarModeloFilmeCadastrado();

            view.setModel(modeloFilme, modeloFilmeCadastrado);
            let dadosFilme = modeloFilme.getJSON();
            let resultado = await Repositorio.cadastrarFilme(dadosFilme);

            if(!resultado.ok){
                let mensagemDeErro = this._criarDialog(mensagemCadastroNaoConcluido, resultado.Title);
                return mensagemDeErro.open();
            }
            let filmeCriado = await resultado.json();
            let mensagemDeSucesso = new Dialog({
                type: mobileLibrary.DialogType.Message,
                title: MENSAGEM_CONFIRMACAO_DIALOG,
                state: coreLibrary.ValueState.Information,
                content: new Text({ text: mensagemFilmeCadastrado }),
                beginButton: new Button({
                    type: mobileLibrary.ButtonType.Emphasized,
                    text: MENSAGEM_CONFIRMACAO_DIALOG,
                    press: function () {
                        this._voltarParaDetalhes(filmeCriado.id);
                    }.bind(this)
                })
            });
            return mensagemDeSucesso.open();
        },

        _aoClicarEmEditar: async function(){
            const mensagemEdicaoNaoConcluida = "Cadastro não realizado";
            const modeloFilmeEditado = "FilmeEditado";
            const messageBoxTitulo = "Erro de Validação";
            const mensagemFilmeEditado = "Filme editado com sucesso!";

            let view = this.getView();
            let validacaoDeEntradas = Validador.validarTodos(view);

            if(validacaoDeEntradas != STRING_VAZIA){
                let mensagemDeErro = this._criarDialog(messageBoxTitulo, validacaoDeEntradas);
                return mensagemDeErro.open();
            }

            let modeloFilme = this._criarModeloFilmeEditado();

            view.setModel(modeloFilme, modeloFilmeEditado);
            let dadosFilme = modeloFilme.getJSON();
            let resultado = await Repositorio.editar(dadosFilme);

            if(!resultado.ok){
                let mensagemDeErro = this._criarDialog(mensagemEdicaoNaoConcluida, resultado.Title);
                return mensagemDeErro.open();
            }

            let mensagemDeSucesso = new Dialog({
                type: mobileLibrary.DialogType.Message,
                title: MENSAGEM_CONFIRMACAO_DIALOG,
                state: coreLibrary.ValueState.Information,
                content: new Text({ text: mensagemFilmeEditado }),
                beginButton: new Button({
                    type: mobileLibrary.ButtonType.Emphasized,
                    text: MENSAGEM_CONFIRMACAO_DIALOG,
                    press: function () {
                        this._voltarParaDetalhes(this.ID_FILME);
                    }.bind(this)
                })
            });
            this._limparCampos();
            return mensagemDeSucesso.open();
        },

        _criarModeloFilmeCadastrado: function(){
            const inputGeneroId = "generoFilmeInput";
            const inputClassificacaoId = "classificacaoFilmeInput";
            const inputTituloId = "tituloFilmeInput";
            const inputDiretorId = "diretorFilmeInput";
            const inputNotaId = "notaFilmeInput";
            const inputDuracaoId = "duracaoFilmeInput";
            const inputDataId = "dataDeLancamentoInput";

            let titulo = this.byId(inputTituloId).getValue();
            let diretor = this.byId(inputDiretorId).getValue();
            let genero = this.byId(inputGeneroId).getValue();
            let data = this.byId(inputDataId).getDateValue();
            let classificacao = this.byId(inputClassificacaoId).getValue();
            let nota = this.byId(inputNotaId).getValue();
            let duracao = this.byId(inputDuracaoId).getValue();

            let dataFormatada = data;
            let generoFormatado = this._obterIndiceGenero(genero);
            let classificacaoFormatada = this._obterIndiceClassificacao(classificacao);
            let notaFormatada = parseFloat(nota);
            let duracaoFormatada = parseInt(duracao);

            let ModeloFilme = new JSONModel({
                titulo: titulo.trim(),
                dataDeLancamento: dataFormatada,
                genero: generoFormatado,
                emCartaz: false,
                nota: notaFormatada,
                duracao: duracaoFormatada,
                disponivelNoPlano: false,
                diretor: diretor.trim(),
                classificacao: classificacaoFormatada,
                atores: null
            });

            return ModeloFilme
        },

        _criarModeloFilmeEditado: function(){
            const inputGeneroId = "generoFilmeInput";
            const inputClassificacaoId = "classificacaoFilmeInput";
            const inputTituloId = "tituloFilmeInput";
            const inputDiretorId = "diretorFilmeInput";
            const inputNotaId = "notaFilmeInput";
            const inputDuracaoId = "duracaoFilmeInput";
            const inputDataId = "dataDeLancamentoInput";

            let titulo = this.byId(inputTituloId).getValue();
            let diretor = this.byId(inputDiretorId).getValue();
            let genero = this.byId(inputGeneroId).getValue();
            let data = this.byId(inputDataId).getDateValue();
            let classificacao = this.byId(inputClassificacaoId).getValue();
            let nota = this.byId(inputNotaId).getValue();
            let duracao = this.byId(inputDuracaoId).getValue();

            let dataFormatada = data;
            let generoFormatado = this._obterIndiceGenero(genero);
            let classificacaoFormatada = this._obterIndiceClassificacao(classificacao);
            let notaFormatada = parseFloat(nota);
            let duracaoFormatada = parseInt(duracao);

            let ModeloFilme = new JSONModel({
                id: this.ID_FILME,
                titulo: titulo,
                dataDeLancamento: dataFormatada,
                genero: generoFormatado,
                emCartaz: false,
                nota: notaFormatada,
                duracao: duracaoFormatada,
                disponivelNoPlano: false,
                diretor: diretor,
                classificacao: classificacaoFormatada,
                atores: null
            });

            return ModeloFilme
        },

        _criarDialog: function(titulo, mensagem){
            let dialog = new Dialog({
                type: mobileLibrary.DialogType.Message,
                title: titulo,
                state: coreLibrary.ValueState.Information,
                content: new Text({ text: mensagem }),
                beginButton: new Button({
                    type: mobileLibrary.ButtonType.Emphasized,
                    text: MENSAGEM_CONFIRMACAO_DIALOG,
                    press: function () {
                        dialog.close();
                    }.bind(this)
                })
            });

            return dialog;
        },

        aoClicarEmVoltar: function(){
            const viewTelaDeListagem = "ListaDeFilmes";
            this._limparCampos();
            return this.irParaRotaCorrespondente(viewTelaDeListagem);
        },

        _voltarParaDetalhes: function(id){
            const rotaDetalhes = "DetalhesDeFilmes"
			return this.irParaRotaCorrespondente(rotaDetalhes, id.toString());
        },

        _alterarParaEdicao: function(){
            const chaveI18nFormularioTitulo = "EdicaoDeFilmes.Formulario.Titulo";
            const chaveI18nPaginaTitulo = "EdicaoDeFilmes.Pagina.Titulo";
            const chaveI18nBotaoTexto = "EdicaoDeFilmes.Botao.Texto";
            const idFormulario = "FormCadastro";
            const idBotao = "botaoCadastrar";

            let view = this.getView();
            let formularioTitulo = this.retornarTextoI18nCorrespondente(chaveI18nFormularioTitulo);
            let paginaTitulo = this.retornarTextoI18nCorrespondente(chaveI18nPaginaTitulo);
            let textoBotaoEditar = this.retornarTextoI18nCorrespondente(chaveI18nBotaoTexto);

            let botao = this.byId(idBotao);
            this.byId(idFormulario).setTitle(formularioTitulo);
            view.getContent()[INDICE_ZERO].setTitle(paginaTitulo);
            botao.setText(textoBotaoEditar);      
        },

        _alterarParaCadastro: function(){
            const idInputTitulo = "tituloFilmeInput";
            const chaveI18nFormularioTitulo = "CadastroDeFilmes.Formulario.Titulo";
            const chaveI18nPaginaTitulo = "CadastroDeFilmes.Pagina.Titulo";
            const chaveI18nBotaoTexto = "CadastroDeFilmes.BotaoDeCadastrar.Texto";
            const idFormulario = "FormCadastro";
            const idBotao = "botaoCadastrar";

            this._limparCampos();
            let view = this.getView();
            let formularioTitulo = this.retornarTextoI18nCorrespondente(chaveI18nFormularioTitulo);
            let paginaTitulo = this.retornarTextoI18nCorrespondente(chaveI18nPaginaTitulo);
            let textoBotaoEditar = this.retornarTextoI18nCorrespondente(chaveI18nBotaoTexto);

            let botao = this.byId(idBotao);
            this.byId(idFormulario).setTitle(formularioTitulo);
            view.getContent()[INDICE_ZERO].setTitle(paginaTitulo);
            botao.setText(textoBotaoEditar);

            let inputTitulo = this.byId(idInputTitulo);
            inputTitulo.setEditable(true);

            this.ID_FILME = null;
        },

        aoClicarNoBotao: function(){
            if(!this.ID_FILME){
                return this._aoClicarEmCadastrar();
            }
            return this._aoClicarEmEditar();
        },

        _preencherCamposEdicao: function(){
            const nomeModeloDetalhe = "filmeEditar";
            const idInputTitulo = "tituloFilmeInput";
            const idInputGenero = "generoFilmeInput";
            const idInputData = "dataDeLancamentoInput";
            const idInputDiretor = "diretorFilmeInput";
            const idInputClassificacao = "classificacaoFilmeInput";
            const idInputNota = "notaFilmeInput";
            const idInputDuracao = "duracaoFilmeInput";

            let view = this.getView();
            let modelo = view.getModel(nomeModeloDetalhe).getData();

            let inputTitulo = this.byId(idInputTitulo);
            let inputGenero = this.byId(idInputGenero);
            let inputData = this.byId(idInputData);
            let inputDiretor = this.byId(idInputDiretor);
            let inputClassificacao = this.byId(idInputClassificacao);
            let inputNota = this.byId(idInputNota);
            let inputDuracao = this.byId(idInputDuracao);

            inputTitulo.setValue(modelo.titulo);
            inputTitulo.setEditable(false);
            
            let generoSelecionado = inputGenero.mAggregations.items[modelo.genero];
			inputGenero.setSelectedItem(generoSelecionado);

            let dataFormatada = Formatador.formatarData(modelo.dataDeLancamento);
            inputData.setValue(dataFormatada);

            inputDiretor.setValue(modelo.diretor);

            let classificacaoSelecionada = inputClassificacao.mAggregations.items[modelo.classificacao];
			inputClassificacao.setSelectedItem(classificacaoSelecionada);

            inputNota.setValue(modelo.nota);
            inputDuracao.setValue(modelo.duracao);

            this.ID_FILME = modelo.id;
        },

        _limparCampos: function(){
            const idInputTitulo = "tituloFilmeInput";
            const idInputGenero = "generoFilmeInput";
            const idInputData = "dataDeLancamentoInput";
            const idInputDiretor = "diretorFilmeInput";
            const idInputClassificacao = "classificacaoFilmeInput";
            const idInputNota = "notaFilmeInput";
            const idInputDuracao = "duracaoFilmeInput";
            const estadoEntradaValida = "None";

            let inputTitulo = this.byId(idInputTitulo);
            let inputGenero = this.byId(idInputGenero);
            let inputData = this.byId(idInputData);
            let inputDiretor = this.byId(idInputDiretor);
            let inputClassificacao = this.byId(idInputClassificacao);
            let inputNota = this.byId(idInputNota);
            let inputDuracao = this.byId(idInputDuracao);

            inputTitulo.setValue();
            inputDiretor.setValue();
            inputNota.setValue();
            inputDuracao.setValue();
            inputGenero.clearSelection();
            inputClassificacao.clearSelection();
            inputData.setValue();

            inputTitulo.setValueState(estadoEntradaValida);
            inputDiretor.setValueState(estadoEntradaValida);
            inputNota.setValueState(estadoEntradaValida);
            inputDuracao.setValueState(estadoEntradaValida);
            inputGenero.setValueState(estadoEntradaValida);
            inputClassificacao.setValueState(estadoEntradaValida);
            inputData.setValueState(estadoEntradaValida);
        }
	});
});