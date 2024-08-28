sap.ui.define([
    "sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
    "use strict";

    const NOME_VIEW = "app.view.NotFound";

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
                VerifiacarCliqueNoBotaoNavBar(){
                    return this.waitFor({
                        viewName : NOME_VIEW,
                        controlType : "sap.m.ButtonType",
                        matchers : {
                            
                        }, 
                        actions : new Press(),
                        sucess : () => Opa5.assert.ok(true, "O botao foi clicado com sucesso!"),
                        errorMessage : "O botao nao foi encontrado!"
                    });
                }
            },

            assertions: {
                aTelaFoiCarregadaCorretamente(){
                    return this.waitFor({
                        viewName : NOME_VIEW,
                        success : () => Opa5.assert.ok(true, "A tela de NotFound foi carregada corretamente!"),
                        errorMessage : "A tela de NotFound nao foi carregada corretamente!"
                    });
                }
            }
        }
    })
})