sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], (Controller, History, UIComponent) => {
	"use strict";

	return Controller.extend("cod3rsgrowth.app.controller.BaseController", {

		retornarTextoI18nCorrespondente(chave) {
			let textosTraduziveis = this.getView().getModel("i18n").getResourceBundle();
			let mensagem = textosTraduziveis.getText(chave);
			return mensagem;
		},

		processarAcao(action) {
            try {
                const result = action();
                return result;
            }
            catch (error) {
                console.log("erro");
            }
        },
 
        getRouter() {
            return UIComponent.getRouterFor(this);
        },
       
        getModel(name) {
            return this.getView().getModel(name);
        },

        irParaRotaCorrespondente(rota) {
            return this
					.getRouter()
					.navTo(rota, {}, true);
        }
	});
});