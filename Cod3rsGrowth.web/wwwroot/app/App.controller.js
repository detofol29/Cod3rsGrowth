sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
    
    const CAMINHO_APP = "cod3rsgrowth.app.App";
    return Controller.extend(CAMINHO_APP, {
      
      aoClicarBotao() {
         var otextosTraduziveis = this.getView().getModel("i18n").getResourceBundle();
         var sMensagem = otextosTraduziveis.getText("textoBotaoClicado");
         this.byId("botaoTeste").setText(sMensagem);
      },

      onChangeLanguage(oEvent) {
         var itemSelecionado = oEvent.getParameter("selectedItem").getKey();
         sap.ui.getCore().getConfiguration().setLanguage(itemSelecionado);
      },
    }); 
 });
