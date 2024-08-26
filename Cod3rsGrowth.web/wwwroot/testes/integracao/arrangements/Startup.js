sap.ui.define([
    "sap/ui/test/Opa5"
],(Opa5) => {
    "use strict";
    
    return Opa5.extend("cod3rsgrowth.testes.integracao.arrangements.Startup", {
        iStartMyApp() {
            return this.iStartMyAppInAFrame("../index.html");
        }
    });
});