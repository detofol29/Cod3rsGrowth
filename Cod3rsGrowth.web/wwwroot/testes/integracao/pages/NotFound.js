sap.ui.define([
    "sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], function(Opa5, Press) {
    "use strict";

    const NOME_VIEW = "app.view.NotFound";
    const MENSAGEM_PAGINA_IDENTIFICADOR = "sap.m.MessagePage";
    const PROPRIEDADE_TITULO = "title";
    const PROPRIEDADE_TEXTO = "text";
    const PROPRIEDADE_DESCRICAO = "description";

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
            },
            
            assertions: {
                aTelaFoiCarregadaCorretamente: function(){
                    return this.waitFor({
                        viewName : NOME_VIEW,
                        success : () => Opa5.assert.ok(true, "A tela de NotFound foi carregada corretamente!"),
                        errorMessage : "A tela de NotFound não foi carregada corretamente!"
                    });
                },

                oTituloDeveSerIgualAoComChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: MENSAGEM_PAGINA_IDENTIFICADOR,
                        matchers: {
                            i18NText : {
								propertyName: PROPRIEDADE_TITULO,
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto do título está sendo apresentado corretamente!"),
                        errorMessage: "O texto do título não foi encontrado!"
                    });
                },

                oTextoDeveSerIgualAoComChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: MENSAGEM_PAGINA_IDENTIFICADOR,
                        matchers: {
                            i18NText : {
								propertyName: PROPRIEDADE_TEXTO,
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto está sendo apresentado corretamente!"),
                        errorMessage: "O texto não foi encontrado!"
                    })
                },

                aDescricaoDeveSerIgualAoComChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: MENSAGEM_PAGINA_IDENTIFICADOR,
                        matchers: {
                            i18NText : {
								propertyName: PROPRIEDADE_DESCRICAO,
        						key: chave
							}
                        },
                        success: () => Opa5.assert.ok(true, "O texto da descrição está sendo apresentado corretamente!"),
                        errorMessage: "O texto da descrição não foi encontrado!"
                    });
                }
            }
        }
    });
});