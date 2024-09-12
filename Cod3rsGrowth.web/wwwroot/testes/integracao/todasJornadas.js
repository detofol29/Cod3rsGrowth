sap.ui.define([
    "sap/ui/test/Opa5",
    "cod3rsgrowth/testes/integracao/arrangements/Startup",
    "cod3rsgrowth/testes/integracao/jornadaNotFound",
    "cod3rsgrowth/testes/integracao/jornadaCadastroDeFilmes",
    "cod3rsgrowth/testes/integracao/jornadaListaDeFilmes"
],function(Opa5,
     Startup,
     JornadaNotFound,
     JornadaCadastroDeFilmes,
     JornadaListaDeFilmes
     ) {
    "use strict";
 
    const VIEW_NAMESPACE = "cod3rsgrowth";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: VIEW_NAMESPACE,
        autoWait: true
    });
});