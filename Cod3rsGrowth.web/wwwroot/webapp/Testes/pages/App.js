sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/press"
], (Opa5, Press) => {
    "use strict";

    var arrengements = new Opa5({
        euInicioMeuApp(){
            return this.IsStartMyAppInAFrame("../index.html");
        }
    });

    var actions = new Opa5({
        EuClicoNoBotao(){
            return this.waitFor({
                viewName : "App",
                id : "BotaoDeTeste",
                actions : new Press(),
                errorMessage: "O botão não foi encontrado!"
            });
        }
    });

    var assertions = new Opa5({
        oBotaoDeveTerOTextoAlterado(){
            return this.waitFor({
                viewName : "App",
                id: "BotaoDeTeste",
                matchers : new PropertyStrictEquals({
                    name : "text",
                    value: "O botão foi clicado"
                }),
                
                success(oButton){
                    Opa5.assert.ok(true, "O texto do botão foi alterado para: " + oButton.getText());
                },

                errorMessage: "O texto do botão não foi alterado!"
            });
        }
    });
});