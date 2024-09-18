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

        _aoCoincidirRota: function(evento) {
            const argumentoDoEvento = "arguments";
            let view = this.getView();
            let idFilme = evento.getParameter(argumentoDoEvento).id;
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
                    Repositorio.obterPorId(view, idFilme)
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
            const nomeModeloFilmeSelecionado = "filmeDetalhe";
            const viewTelaDeEditar = "EdicaoDeFilmes";

            let idFilme = this.getView().getModel(nomeModeloFilmeSelecionado).getData().id;
            return this.irParaRotaCorrespondente(viewTelaDeEditar);
        },
	});
});