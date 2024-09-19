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

    const STRING_VAZIA = "";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.DetalhesDeFilmes";
    const ROTA_DETALHES = "DetalhesDeFilmes";    

	return BaseController.extend(ROTA_CONTROLLER, {

		onInit: function() {			
            this
			.getRouter()
			.getRoute(ROTA_DETALHES)
			.attachPatternMatched(async (evento) => {
				return this._aoCoincidirRota(evento);
			}, this);
		},

        formatador: Formatador,

        FILME_ID : null,

        _aoCoincidirRota: function(evento) {
            const argumentoDoEvento = "arguments";
            let view = this.getView();
            this.FILME_ID = evento.getParameter(argumentoDoEvento).id;

            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
                    Repositorio.obterPorId(view, this.FILME_ID)
                ]);
            });
        },

        aoClicarEmVoltar: function(){
            const viewTelaDeLista = "ListaDeFilmes";
            return this.irParaRotaCorrespondente(viewTelaDeLista);
        },

        obterDisponivel: function(Disponivel) {
			let chaveI18n = Formatador.formatarDisponivel(Disponivel);
			return this.retornarTextoI18nCorrespondente(chaveI18n);
		},

        aoClicarEmEditar: function(){
            const viewTelaDeEditar = "EdicaoDeFilmes";
            return this.irParaRotaCorrespondente(viewTelaDeEditar);
        },

        aoClicarEmRemover: function(){
            const nomeModeloDetalhe = "filmeDetalhe";
            const propriedadeTitulo = "/titulo";

            let filmeTitulo = this.getModel(nomeModeloDetalhe).getProperty(propriedadeTitulo);
            let dialogConfirmacao = this._criarDialogConfirmacao(filmeTitulo, this.FILME_ID);

            return dialogConfirmacao;
        },

        _exibirDialogSucesso: function(){
            let dialogSucesso = this._criarDialogSucesso();
            return dialogSucesso.open();
        },

        _criarDialogSucesso: function(){
            const viewTelaDeListagem = "ListaDeFilmes";
            const titulo = "Concluido!";
            const mensagem = "O filme foi removido com sucesso!";
            const textoBotao = "Ok";
            const tipoDeDialog = mobileLibrary.DialogType.Message;
            const estadoDoDialog = coreLibrary.ValueState.Success;
            const tipoDeBotao = mobileLibrary.ButtonType.Emphasized;

            let botaoDialog = new Button({
                type: tipoDeBotao,
                text: textoBotao,
                press: function () {
                    dialog.close();
                    this.irParaRotaCorrespondente(viewTelaDeListagem);
                }.bind(this)
            });

            let textoDoDialog = new Text({ text: mensagem });

            let dialog = new Dialog({
                type: tipoDeDialog,
                title: titulo,
                state: estadoDoDialog,
                content: textoDoDialog,
                beginButton: botaoDialog
            });

            return dialog;
        },

        _criarDialogConfirmacao: function(titulo, id){
            const dialogTipo = mobileLibrary.DialogType.Message;
            const dialogEstado = coreLibrary.ValueState.Information;
            const mensagemDoDialog = "Deseja realmente excluir o filme " + titulo + "?";
            const textoBotaoConfirmar = "Sim";
            const textoBotaoRetornar = "Não";
            const tituloDoDialog = "Confirmação";

            let dialogMensagem = new Text({ text: mensagemDoDialog });

            let dialogBotaoConfirmar = new Button({
                type: mobileLibrary.ButtonType.Emphasized,
                text: textoBotaoConfirmar,
                press: function () {
                    dialogConfirmacao.close();
                    Repositorio.remover(id.toString());
                    this._exibirDialogSucesso();
                }.bind(this)
            });

            let dialogBotaoRetornar = new Button({
                text: textoBotaoRetornar,
                press: function () {
                    dialogConfirmacao.close();
                }.bind(this)
            });

            let dialogConfirmacao = new Dialog({
                type: dialogTipo,
                title: tituloDoDialog,
                state: dialogEstado,
                content: dialogMensagem,
                beginButton: dialogBotaoConfirmar,
                endButton: dialogBotaoRetornar
            });

            return dialogConfirmacao.open();
        }
	});
});