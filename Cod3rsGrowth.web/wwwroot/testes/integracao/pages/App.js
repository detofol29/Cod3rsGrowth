sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
	"use strict";

	const VIEW_NAME = "webapp.App";

	Opa5.createPageObjects({
		onTheAppPage: {
			actions: {
				EuClicoNoBotao() {
					return this.waitFor({
						id: "botaoTeste",
						viewName: VIEW_NAME,
						actions: new Press(),
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarUmTextoDiferente : function () {
                    return this.waitFor({
                        viewName : VIEW_NAME,
                        id : "botaoTeste",
                        matchers : new PropertyStrictEquals({
                            name : "text",
                            value : "Botão clicado!"
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