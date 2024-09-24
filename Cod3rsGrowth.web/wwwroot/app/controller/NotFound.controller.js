sap.ui.define([
    "cod3rsgrowth/app/controller/BaseController"
], function(BaseController) {
    "use strict";

    const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.NotFound";
    const ROTA_PRINCIPAL = "ListaDeFilmes";
    
    return BaseController.extend(ROTA_CONTROLLER, {
        onInit: function(){
        },

        aoClicarNavButton: function() {
            return this.irParaRotaCorrespondente(ROTA_PRINCIPAL);
        }
	});
});