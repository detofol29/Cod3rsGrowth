sap.ui.define([
   "cod3rsgrowth/app/BaseController"
], (BaseController) => {
   "use strict";
    
   const CAMINHO_APP = "cod3rsgrowth.app.App";
   return BaseController.extend(CAMINHO_APP, {

      aoClicarBotao() {
			var textoParaBotaoClicado = this.retornarTextoI18nCorrespondente("Botao.TextoClicado");
         var idBotao = this.retornarTextoI18nCorrespondente("Botao.Id");
			this.byId(idBotao).setText(textoParaBotaoClicado);
		}
   });
});