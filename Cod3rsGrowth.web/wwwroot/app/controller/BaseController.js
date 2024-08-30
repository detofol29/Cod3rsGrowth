sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], (Controller, History, UIComponent) => {
	"use strict";

	return Controller.extend("cod3rsgrowth.app.controller.BaseController", {

		retornarTextoI18nCorrespondente(chave) {
			var textosTraduziveis = this.getView().getModel("i18n").getResourceBundle();
			var mensagem = textosTraduziveis.getText(chave);
			return mensagem;
		},

		getRouter() {
            return UIComponent.getRouterFor(this);
        },

        irParaRotaCorrespondente(rota) {
            return this
					.getRouter()
					.navTo(rota, {}, true);
        }
	});
});