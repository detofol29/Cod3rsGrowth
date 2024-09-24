sap.ui.define([
   "cod3rsgrowth/app/controller/BaseController"
], function(BaseController) {
   "use strict";
    
   const CAMINHO_APP = "cod3rsgrowth.app.controller.App";
   const CHAVE_I18N_BOTAO_TEXTO_CLICADO = "Botao.TextoClicado";
   const CHAVE_I18N_BOTAO_ID = "Botao.Id";
   
   return BaseController.extend(CAMINHO_APP, {

      aoClicarBotao: function() {
			let textoParaBotaoClicado = this.retornarTextoI18nCorrespondente(CHAVE_I18N_BOTAO_TEXTO_CLICADO);
         let idBotao = this.retornarTextoI18nCorrespondente(CHAVE_I18N_BOTAO_ID);
         
			this
            .byId(idBotao)
            .setText(textoParaBotaoClicado);
		}
   });
});