sap.ui.define([
    "cod3rsgrowth/app/controller/BaseController"
], (BaseController) => {
    "use strict";

    return BaseController.extend("cod3rsgrowth.app.controller.NotFound", {
        onInit(){
        },

        aoClicarNavButton() {
            return this.irParaRotaPrincipal();
        }
	});
});