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
    const MAIOR_INDICE_NUMERICO = 9;
    const NOTA_MAXIMA_PERMITIDA = 10;
    const DURACAO_MINIMA_PERMITIDA = 1;
    const DURACAO_MAXIMA_PERMITIDA = 1000;
	const STRING_VAZIA = "";
    const SALTO_DE_LINHA = "\n";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.CadastroDeFilmes";
    const ROTA_CADASTRO = "CadastroDeFilmes";
    const MODELO_GENEROS_NOME = "Generos";
	const MODELO_CLASSIFICACAO_NOME = "Classificacoes";
    const MODELO_FILME_CADASTRADO = "FilmeCadastrado";
    const INPUT_GENERO_ID = "generoFilmeInput";
    const INPUT_CLASSIFICACAO_ID = "classificacaoFilmeInput";
    const INPUT_TITULO_ID = "tituloFilmeInput";
    const INPUT_DIRETOR_ID = "diretorFilmeInput";
    const INPUT_NOTA_ID = "notaFilmeInput";
    const INPUT_DURACAO_ID = "duracaoFilmeInput";
    const INPUT_DATA_ID = "dataDeLancamentoInput";
    const MENSAGEM_GENERO_VAZIO = "O Campo Gênero não pode estar vazio!";
    const MENSAGEM_GENERO_INVALIDO = "Selecione um Gênero válido!";
    const MENSAGEM_CLASSIFICACAO_VAZIO = "O campo Classificação não pode estar vazio!";
    const MENSAGEM_CLASSIFICACAO_INVALIDA = "Selecione uma classificação válida!";
    const MENSAGEM_TITULO_VAZIO = "O campo Título não pode estar vazio!";
    const MENSAGEM_DIRETOR_VAZIO = "O campo Diretor não pode estar vazio!";
    const MENSAGEM_DIRETOR_COM_NUMEROS = "O campo Diretor não pode conter números!";
    const MENSAGEM_NOTA_VAZIO = "O campo nota não pode estar vazio!";
    const MENSAGEM_NOTA_INVALIDA = "A nota deve estar no intervalo [0-10]!";
    const MENSAGEM_DURACAO_VAZIO = "O campo Duração não pode estar vazio!";
    const MENSAGEM_DURACAO_INVALIDA = "A duração deve estar no intervalo entre 1 e 1000 minutos!";
    const MENSAGEM_DATA_VAZIA = "O campo Data não pode estar vazio!";
    const MENSAGEM_DATA_SUPERIOR = "A data de lançamento não pode ser superior a data atual!";
    const MENSAGEM_DATA_INFERIOR = "A data de lançamento não pode ser inferior a data do primeiro filme!";
    const MENSAGEM_CADASTRO_NAO_CONCLUIDO = "Cadastro não realizado";
    const MENSAGEM_CONFIRMACAO_DIALOG = "OK";
    const MENSAGEM_FILME_CADASTRADO = "Filme cadastrado com sucesso!";
    const DATA_LIMITE = '12 28 1895';
    const VIEW_TELA_DE_LISTAGEM = "ListaDeFilmes";
    const MESSAGE_BOX_TITULO = "Erro de Validação";


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
			let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
			for (let i = INDICE_ZERO; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

        _obterIndiceClassificacao: function(Classificacao){
			let classificacoes = this.getView().getModel(MODELO_CLASSIFICACAO_NOME).getData();
			for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
				if(classificacoes[i].descricao == Classificacao){
					return i;
				}
			}
		},

        aoClicarEmCadastrar: async function(event){
            let view = this.getView();
            let validacaoDeEntradas = Validador.validarTodos(view);

            if(validacaoDeEntradas != true){
                let mensagemDeErro = this._criarDialog(MESSAGE_BOX_TITULO, validacaoDeEntradas);
                return mensagemDeErro.open();
            }

            let titulo = view.byId(INPUT_TITULO_ID)._lastValue;
            let diretor = view.byId(INPUT_DIRETOR_ID)._lastValue;
            let genero = view.byId(INPUT_GENERO_ID)._lastValue;
            let data = view.byId(INPUT_DATA_ID).getDateValue();
            let classificacao = view.byId(INPUT_CLASSIFICACAO_ID)._lastValue;
            let nota = view.byId(INPUT_NOTA_ID)._lastValue;
            let duracao = view.byId(INPUT_DURACAO_ID)._lastValue;

            //Formatacoes
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

            view.setModel(ModeloFilme, MODELO_FILME_CADASTRADO);
            let dadosFilme = ModeloFilme.getJSON();
            let resultado = await Repositorio.cadastrarFilme(dadosFilme);

            if(!resultado.ok){
                let mensagemDeSucesso = this._criarDialog(MENSAGEM_CADASTRO_NAO_CONCLUIDO, resultado.Title);
                return mensagemDeSucesso.open();
            }

            let mensagemDeSucesso = new Dialog({
                type: mobileLibrary.DialogType.Message,
                title: MENSAGEM_CONFIRMACAO_DIALOG,
                state: coreLibrary.ValueState.Information,
                content: new Text({ text: MENSAGEM_FILME_CADASTRADO }),
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
            return this.irParaRotaCorrespondente(VIEW_TELA_DE_LISTAGEM);
        }
	});
});