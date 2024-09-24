sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
	"use strict";

	const NOME_VIEW = "app.view.App";
	const BOTAO_IDENTIFICADOR = "sap.m.Button";
	const BOTAO_PROPRIEDADE_TEXTO = "text";
	const BOTAO_TEXTO_INICIAL = "Botao.TextoInicial";

	Opa5.createPageObjects({
		naPaginaDoApp: {
			actions: {
				VerificarCliqueNoBotaoDeTeste() {
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BOTAO_IDENTIFICADOR,
						matchers: {
							i18NText: {
								propertyName: BOTAO_PROPRIEDADE_TEXTO,
        						key: BOTAO_TEXTO_INICIAL
							}
						},
						actions: new Press(),
						success: () => Opa5.assert.ok(true, "O botão foi clicado corretamente"),
						errorMessage: "O botão não foi encontrado!"
					});
				}
			},

			assertions: {
				oBotaoDeveApresentarTextoInicialComChaveI18nCorrespondente(chave) {
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BOTAO_IDENTIFICADOR,
						matchers: {
							i18NText: {
								propertyName: BOTAO_PROPRIEDADE_TEXTO,
        						key: chave
							}
						},
                        success: () => Opa5.assert.ok(true, "O texto do botão inicial está correto!"),
                        errorMessage : "Texto do botão não encontrado!"
                    });
                },

				oBotaoDeveApresentarTextoFinalComChaveI18nCorrespondente(chave) {
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BOTAO_IDENTIFICADOR,
						matchers : {
							i18NText : {
								propertyName: BOTAO_PROPRIEDADE_TEXTO,
        						key: chave
							}
						},
                        success: () => Opa5.assert.ok(true, "O texto do botão foi alterado com sucesso!"),
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
});