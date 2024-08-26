sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
	"use strict";

	const NOME_VIEW = "app.App";

	Opa5.createPageObjects({
		onTheAppPage: {
			actions: {
				EuClicoNoBotao() {
					return this.waitFor({
						viewName: NOME_VIEW,
						actions: new Press(),
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarUmTextoDiferente : function () {
                    return this.waitFor({
                        viewName : NOME_VIEW,
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