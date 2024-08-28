sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
	"use strict";

	const NOME_VIEW = "app.App";

	Opa5.createPageObjects({
		naPaginaDoApp: {
			actions: {
				VerificarCliqueNoBotaoDeTeste() {
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.Button",
						matchers : {
							i18NText : {
								propertyName: "text",
        						key: "Botao.TextoInicial"
							}
						},
						actions: new Press(),
						success : () => Opa5.assert.ok(true, "O botão foi clicado corretamente"),
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarTextoInicialComChaveI18nCorrespondente(textoBotaoInicial) {
                    return this.waitFor({
						controlType: "sap.m.Button",
						matchers : {
							i18NText : {
								propertyName: "text",
        						key: textoBotaoInicial
							}
						},
                        success : () => Opa5.assert.ok(true, "O texto do botão foi alterado com sucesso!"),
                        errorMessage : "Texto do botão não encontrado!"
                    });
                },

				oBotaoDeveApresentarTextoFinalComChaveI18nCorrespondente(textoBotaoFinal) {
                    return this.waitFor({
						controlType: "sap.m.Button",
						matchers : {
							i18NText : {
								propertyName: "text",
        						key: textoBotaoFinal
							}
						},
                        success : () => Opa5.assert.ok(true, "O texto do botão foi alterado com sucesso!"),
                        errorMessage : "Texto do botão não encontrado!"
                    });
                },

				aTelaFoiCarregadaCorretamente() {
					return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela foi carregada corretamete!"),
						errorMessage: "A tela principal não foi carregada corretamente!"
					});
				}
			}
		}
	});
})