sap.ui.define([
    "sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
    "use strict";

    const NOME_VIEW = "app.view.NotFound";

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
            },
            
            assertions: {
                aTelaFoiCarregadaCorretamente(){
                    return this.waitFor({
                        viewName : NOME_VIEW,
                        success : () => Opa5.assert.ok(true, "A tela de NotFound foi carregada corretamente!"),
                        errorMessage : "A tela de NotFound não foi carregada corretamente!"
                    });
                },

                oTituloDeveSerIgualAoComChaveI18nCorrespondente(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.m.MessagePage",
                        matchers: {
                            i18NText : {
								propertyName: "title",
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto do título está sendo apresentado corretamente!"),
                        errorMessage: "O texto do título não foi encontrado!"
                    });
                },

                oTextoDeveSerIgualAoComChaveI18nCorrespondente(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.m.MessagePage",
                        matchers: {
                            i18NText : {
								propertyName: "text",
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto está sendo apresentado corretamente!"),
                        errorMessage: "O texto não foi encontrado!"
                    })
                },

                aDescricaoDeveSerIgualAoComChaveI18nCorrespondente(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.m.MessagePage",
                        matchers: {
                            i18NText : {
								propertyName: "description",
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto da descrição está sendo apresentado corretamente!"),
                        errorMessage: "O texto da descrição não foi encontrado!"
                    })
                }
            }
        }
    });
});