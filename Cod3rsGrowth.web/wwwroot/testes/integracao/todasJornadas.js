sap.ui.define([
    "sap/ui/test/Opa5",
    "cod3rsgrowth/testes/integracao/arrangements/Startup",
    "cod3rsgrowth/testes/integracao/jornadaBotao"
],(Opa5, Startup) => {
    "use strict";
 
    const VIEW_NAMESPACE = "cod3rsgrowth";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: VIEW_NAMESPACE,
        autoWait: true
    });
});