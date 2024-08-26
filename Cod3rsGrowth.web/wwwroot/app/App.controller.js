sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
    
    var sCaminhoApp = "cod3rsgrowth.app.App";
    return Controller.extend(sCaminhoApp, {
      aoClicarBotao() {
         var oTextosTraduziveis = this.getView().getModel("i18n").getResourceBundle();
         var sMensagem = oTextosTraduziveis.getText("textoBotaoClicado");
         this.byId("botaoTeste").setText(sMensagem);
      },

      onChangeLanguage(oEvent) {
         var oItemSelecionado = oEvent.getParameter("selectedItem").getKey();
         sap.ui.getCore().getConfiguration().setLanguage(oItemSelecionado);
      },
    }); 
 });