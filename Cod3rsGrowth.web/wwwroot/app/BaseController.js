sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";

	return Controller.extend("cod3rsgrowth.app.BaseController", {

		retornarTextoI18nCorrespondente(chave) {
			var textosTraduziveis = this.getView().getModel("i18n").getResourceBundle();
			var mensagem = textosTraduziveis.getText(chave);
			return mensagem;
		}
	});
});