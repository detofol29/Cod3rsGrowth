sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

    const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.BaseController";
    const ROTA_I18N = "i18n";
    const MENSAGEM_ERRO = "erro";
    
	return Controller.extend(ROTA_CONTROLLER, {

		retornarTextoI18nCorrespondente: function(chave) {
			let textosTraduziveis = this.getView().getModel(ROTA_I18N).getResourceBundle();
			let mensagem = textosTraduziveis.getText(chave);
			return mensagem;
		},

		processarAcao: function(action) {
            try {
                const result = action();
                return result;
            }
            catch (error) {
                console.log(MENSAGEM_ERRO);
            }
        },
 
        getRouter: function() {
            return UIComponent.getRouterFor(this);
        },
       
        getModel: function(name) {
            return this.getView().getModel(name);
        },

        irParaRotaCorrespondente: function(rota, id) {
            return this
					.getRouter()
					.navTo(rota, {id: id}, true);
        }
	});
});