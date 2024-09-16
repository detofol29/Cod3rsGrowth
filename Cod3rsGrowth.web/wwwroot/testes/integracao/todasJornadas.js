sap.ui.define([
    "sap/ui/test/Opa5",
    "cod3rsgrowth/testes/integracao/arrangements/Startup",
    "cod3rsgrowth/testes/integracao/jornadaListaDeFilmes",
    "cod3rsgrowth/testes/integracao/jornadaNotFound",
    "cod3rsgrowth/testes/integracao/jornadaCadastroDeFilmes"
],function(Opa5,
     Startup,
     JornadaListaDeFilmes,
     JornadaNotFound,
     JornadaCadastroDeFilmes
     ) {
    "use strict";
 
    const VIEW_NAMESPACE = "cod3rsgrowth";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: VIEW_NAMESPACE,
        autoWait: true
    });
});