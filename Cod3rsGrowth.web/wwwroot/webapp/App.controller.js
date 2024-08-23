sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
    
    const CAMINHO_APP = "cod3rsgrowth.webapp.App";
    return Controller.extend(CAMINHO_APP, {
      
       aoClicarBotao() {
         const oPacoteInter = this.getView().getModel("i18n").getResourceBundle();
         const sMsg = oPacoteInter.getText("textoBotaoClicado");
         this.byId("botaoTeste").setText(sMsg);
       },

       onChangeLanguage: function (oEvent){
         var selectedItem = oEvent.getParameter("selectedItem").getKey();
         sap.ui.getCore().getConfiguration().setLanguage(selectedItem);
      },
    }); 
 });
