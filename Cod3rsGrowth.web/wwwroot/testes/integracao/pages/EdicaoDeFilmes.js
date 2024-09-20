sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
	"sap/ui/test/matchers/I18NText",
	"sap/ui/test/matchers/Properties",
	"sap/ui/test/matchers/PropertyStrictEquals",
	"sap/m/Text"
], function(Opa5, Press, EnterText, I18NText, Properties, PropertyStrictEquals, Text) {
	"use strict";

	const NOME_VIEW = "app.view.CadastroDeFilmes";
    const NOME_VIEW_DETALHES = "app.view.DetalhesDeFilmes";
	const BOTAO_IDENTIFICADOR = "sap.m.Button";
	const PROPRIEDADE_TEXTO = "text";
	const INPUT_IDENTIFICADOR = "sap.m.Input";
	const PLACEHOLDER_IDENTIFICADOR = "placeholder";
    const OBJECT_ATTRIBUTE_IDENTIFICADOR = "sap.m.ObjectAttribute";
	

	Opa5.createPageObjects({
		naTelaDeEdicao: {
			actions: {
				aoPreencherANotaComValorCorrespondente: function(nota){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputNota.Texto"
						}),
						actions: new EnterText({ text: nota.toString() }),
						success: () => Opa5.assert.ok(true, "O campo nota foi preenchido corretamente!"),
						errorMessage: "O campo nota nao foi preenchido corretamente!"
					});
                },

                aoPreencherDiretorComValorCorrespondente: function(diretor){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputDiretor.Texto"
						}),
						actions: new EnterText({ text: diretor }),
						success: () => Opa5.assert.ok(true, "O campo diretor foi preenchido corretamente!"),
						errorMessage: "O campo diretor nao foi preenchido corretamente!"
					});
                },

                aoClicarNoBotaoEditarFilme: function(chave){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BOTAO_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TEXTO,
							key: chave
						}),
						actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botao de editar foi clicado com sucesso!"),
						errorMessage: "O botao editar não foi encontrado!"
					});
                },

                aoClicarNoBotaoDialogDeSucesso: function(){
                    return this.waitFor({
						controlType: BOTAO_IDENTIFICADOR,
						actions: new Press(),
						success: () => Opa5.assert.ok(true, "O botao foi pressionado corretamente!"),
						errorMessage: "O botao nao foi encontrado"
					});
                }
			},

			assertions: {
                aTelaFoiCarregadaCorretamente: function(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela Edicao de filmes foi carregada corretamete!"),
						errorMessage: "A tela Edicao de filmes não foi carregada corretamente!"
					});
                },

                oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.Page",
						matchers: new I18NText({
							propertyName : "title",
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O titulo da pagina foi encontrado com sucesso!"),
						errorMessage: "O titulo da pagina nao foi encontrado!"
					});
                },

                oTextoDoFormularioDeveTerOValorDaChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.ui.layout.form.Form",
						matchers: new I18NText({
							propertyName : "title",
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O titulo do formulario foi encontrado com sucesso!"),
						errorMessage: "O titulo do formulario nao foi encontrado!"
					});
                },

                aCaixaDialogDeveAparecerComAMensagemDeSucesso: function(MensagemSucesso){
                    return this.waitFor({
						controlType: "sap.m.Dialog",
						check: function (DialogErro) {
							let result = DialogErro[0].getContent()[0].mProperties.text === MensagemSucesso
							return result;
						},
						success: () => Opa5.assert.ok(true, "A caixa de mensagem cadastro foi aberto com sucesso!"),
						errorMessage: "A caixa de mensagem cadastro nao foi aberta!"
					});
                },

                oBotaoDeveLevarParaTelaDeDetalhes: function(){
                    return this.waitFor({
						viewName: "app.view.DetalhesDeFilmes",
						success: () => Opa5.assert.ok(true, "A tela Cadastro de detalhes foi carregada corretamete!"),
						errorMessage: "A tela de detalhes não foi carregada corretamente!"
					});
                }
			}
		},

        naTelaDeDetalhes: {
            actions: {

            },

            assertions: {
                oCampoNotaDeveEstarEditadoComOValorCorrespondente: function(nota){
                    return this.waitFor({
                        viewName: NOME_VIEW_DETALHES,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : nota}),
						success: () => Opa5.assert.ok(true, "A nota do filme apresenta o valor correspondente!"),
						errorMessage: "A nota do filme não apresenta o valor correspondente!"
                    });
                },

                oCampoDiretorDeveEstarEditadoComOValorCorrespondente: function(diretor){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : diretor}),
						success: () => Opa5.assert.ok(true, "O diretor do filme apresenta o valor correspondente!"),
						errorMessage: "O diretor do filme não apresenta o valor correspondente!"
                    });
                }
            }
        }
	});
});