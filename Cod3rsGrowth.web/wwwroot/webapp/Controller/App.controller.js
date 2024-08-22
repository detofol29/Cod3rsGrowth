sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
 
    return Controller.extend("ui5.walkthrough.controller.App", {
       aoClicarBotao() {
            this.byId("botaoTeste").setText("Botão clicado!");
       }
    }); 
 });