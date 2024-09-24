sap.ui.define([
    "sap/ui/test/Opa5"
], function(Opa5) {
    "use strict";
    
    const ROTA_CONTROLLER = "cod3rsgrowth.testes.integracao.arrangements.Startup";
    const ROTA_INDEX = "../index.html";
    
    return Opa5.extend(ROTA_CONTROLLER, {
        iStartMyApp: function() {
            return this.iStartMyAppInAFrame(ROTA_INDEX);
        }
    });
});