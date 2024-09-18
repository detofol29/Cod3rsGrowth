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

	return BaseController.extend(ROTA_CONTROLLER, {

		onInit: function() {			
            this
			.getRouter()
			.getRoute(ROTA_CADASTRO)
			.attachPatternMatched(async () => {
				return this._aoCoincidirRota();
			}, this);
		},

        _aoCoincidirRota: function() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.carregarDadosFilme(STRING_VAZIA, view),
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
					Repositorio.obterModeloFiltro(view)
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

        aoClicarEmCadastrar: async function(){

            const mensagemCadastroNaoConcluido = "Cadastro não realizado";
            const modeloFilmeCadastrado = "FilmeCadastrado";
            const messageBoxTitulo = "Erro de Validação";
            const mensagemFilmeCadastrado = "Filme cadastrado com sucesso!";


            let view = this.getView();
            let validacaoDeEntradas = Validador.validarTodos(view);

            if(validacaoDeEntradas != true){
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

            let mensagemDeSucesso = new Dialog({
                type: mobileLibrary.DialogType.Message,
                title: MENSAGEM_CONFIRMACAO_DIALOG,
                state: coreLibrary.ValueState.Information,
                content: new Text({ text: mensagemFilmeCadastrado }),
                beginButton: new Button({
                    type: mobileLibrary.ButtonType.Emphasized,
                    text: MENSAGEM_CONFIRMACAO_DIALOG,
                    press: function () {
                        this.aoClicarEmVoltar();
                    }.bind(this)
                })
            });

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

            let view = this.getView();
            let titulo = view.byId(inputTituloId).getValue();
            let diretor = view.byId(inputDiretorId).getValue();
            let genero = view.byId(inputGeneroId).getValue();
            let data = view.byId(inputDataId).getDateValue();
            let classificacao = view.byId(inputClassificacaoId).getValue();
            let nota = view.byId(inputNotaId).getValue();
            let duracao = view.byId(inputDuracaoId).getValue();

            let dataFormatada = data;
            let generoFormatado = this._obterIndiceGenero(genero);
            let classificacaoFormatada = this._obterIndiceClassificacao(classificacao);
            let notaFormatada = parseFloat(nota);
            let duracaoFormatada = parseInt(duracao);

            let ModeloFilme = new JSONModel({
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
            return this.irParaRotaCorrespondente(viewTelaDeListagem);
        }
	});
});