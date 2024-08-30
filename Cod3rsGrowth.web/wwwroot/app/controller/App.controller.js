sap.ui.define([
   "cod3rsgrowth/app/controller/BaseController"
], (BaseController) => {
   "use strict";
    
   const CAMINHO_APP = "cod3rsgrowth.app.controller.App";
   return BaseController.extend(CAMINHO_APP, {

      aoClicarBotao() {
			var textoParaBotaoClicado = this.retornarTextoI18nCorrespondente("Botao.TextoClicado");
         var idBotao = this.retornarTextoI18nCorrespondente("Botao.Id");
         
			this
            .byId(idBotao)
            .setText(textoParaBotaoClicado);
		}
   });
});