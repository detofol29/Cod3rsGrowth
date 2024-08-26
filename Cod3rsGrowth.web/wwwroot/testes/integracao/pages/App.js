sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/I18NText"
], (Opa5, Press, I18NText) => {
	"use strict";

	var sNomeDaView = "app.App";
	var sBotaoId = "botaoTeste";

	Opa5.createPageObjects({
		onTheAppPage: {
			actions: {
				EuClicoNoBotao() {
					return this.waitFor({
						viewName: sNomeDaView,
						actions: new Press(),
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarUmTextoDiferente : function () {
                    return this.waitFor({
						id :sBotaoId,
						viewName : sNomeDaView,
						matchers : new I18NText({
							propertyName: "text",
        					key: "textoBotaoClicado"
						}),
                        success : function (oButton) {
                            Opa5.assert.ok(true, "O texto do botão foi alterado para: " + oButton.getText());
                        },
                        errorMessage : "Texto do botão não encontrado!"
                    });
                }
			}
		}
	});
});