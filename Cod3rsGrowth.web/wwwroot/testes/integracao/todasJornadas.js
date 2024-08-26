sap.ui.define([
    "sap/ui/test/Opa5",
    "cod3rsgrowth/testes/integracao/arrangements/Startup",
    "cod3rsgrowth/testes/integracao/jornadaBotao"
],(Opa5,
     Startup,
      jornadaBotao) => {
    "use strict";
 
    var sViewNameSpace = "cod3rsgrowth";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: sViewNameSpace,
        autoWait: true
    });
});