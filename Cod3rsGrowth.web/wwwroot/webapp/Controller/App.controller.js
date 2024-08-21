sap.ui.define([
    "sap/ui/core/mvc/Controller"
], (Controller) => {
    "use strict";

    return Controller.extend("App.controller", {
        onInit(){

        },

        aoCLicar(){
            this.byId("BotaoDeTeste").setText("O botão foi clicado");
        }
    });
});