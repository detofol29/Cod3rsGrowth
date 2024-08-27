sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/I18NText",
	"sap/ui/test/matchers/AggregationContainsPropertyEqual"
], (Opa5, Press, I18NText, AggregationContainsPropertyEqual) => {
	"use strict";

	var nomeDaView = "app.App";
	var botaoId = "botaoTeste";

	Opa5.createPageObjects({
		naPaginaDoApp: {
			actions: {
				VerificarCliqueNoBotaoDeTeste() {
					return this.waitFor({
						viewName: nomeDaView,
						controlType: "sap.m.Button",
						matchers : {
							i18NText : {
								propertyName: "text",
        						key: "Botao.TextoInicial"
							}
						},
						actions: new Press(),
						success : function () {
                            Opa5.assert.ok(true, "O botao foi clicado corretamente");
                        },
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarTextoCorrespondentePrimeiro(textoBotao) {
                    return this.waitFor({
						//id: botaoId,
						viewName : nomeDaView,
						controlType: "sap.m.Button",
						matchers : {
							i18NText : {
								propertyName: "text",
        						key: textoBotao
							}
						},
                        success : function (oButton) {
                            Opa5.assert.ok(true, "Texto do botão atual: " + oButton.getText());
                        },
                        errorMessage : "Texto do botão não encontrado!"
                    });
                },

				oBotaoDeveApresentarTextoCorrespondenteSegundo(textoBotao) {
                    return this.waitFor({
						//id: botaoId,
						viewName : nomeDaView,
						controlType: "sap.m.Button",
						// matchers : {
						// 	i18NText : {
						// 		propertyName: "text",
        				// 		key: textoBotao
						// 	}
						// },
						matchers : new AggregationContainsPropertyEqual({
							aggregationName: "text",
        					propertyName: "text",
        					propertyValue: textoBotao
						}),
                        success : function (oButton) {
                            Opa5.assert.ok(true, "Texto do botão atual: " + oButton.getText());
                        },
                        errorMessage : "Texto do botão não encontrado!"
                    });
                },

				aTelaFoiCarregadaCorretamente() {
					return this.waitFor({
						viewName: nomeDaView,
						success: () => Opa5.assert.ok(true, "A tela foi carregada corretamete"),
						errorMessage: "A tela principal nao foi carregada corretamente!"
					});
				}
			}
		}
	});
});