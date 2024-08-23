sap.ui.define([
    "sap/ui/test/Opa5",
    "cod3rsgrowth/testes/integracao/arrangements/Startup",
    "cod3rsgrowth/testes/integracao/jornadaBotao"
], function (Opa5, Startup) {
    "use strict";
 
    const NAME_SPACE = "cod3rsgrowth";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: NAME_SPACE,
        autoWait: true
    });
});