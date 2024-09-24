sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/json/JSONModel"
], function(UIComponent) {
    "use strict";

    return UIComponent.extend("cod3rsgrowth.Component",{
        metadata : {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },
        
        init: function() {
            UIComponent.prototype.init.apply(this, arguments);
            this.getRouter().initialize();
        }
    });
});