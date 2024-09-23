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

    const INDICE_ZERO = 0;
	const NOME_VIEW = "app.view.CadastroDeFilmes";
	const BOTAO_IDENTIFICADOR = "sap.m.Button";
	const PROPRIEDADE_TEXTO = "text";
    const PROPRIEDADE_TITULO = "title";
	const INPUT_IDENTIFICADOR = "sap.m.Input";
	const PLACEHOLDER_IDENTIFICADOR = "placeholder";
    const VIEW_DETALHES = "app.view.DetalhesDeFilmes";
    const DIALOG_IDENTIFICADOR = "sap.m.Dialog";
    const FORM_IDENTIFICADOR = "sap.ui.layout.form.Form";
    const PAGINA_IDENTIFICADOR = "sap.m.Page";
    const CHAVE_I18N_INPUT_DIRETOR = "CadastroDeFilmes.InputDiretor.Texto";
    const CHAVE_I18N_INPUT_NOTA = "CadastroDeFilmes.InputNota.Texto";

	Opa5.createPageObjects({
		naTelaDeEdicao: {
			actions: {
				aoPreencherANotaComValorCorrespondente: function(nota){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: CHAVE_I18N_INPUT_NOTA
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
							key: CHAVE_I18N_INPUT_DIRETOR
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
						controlType: PAGINA_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TITULO,
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O titulo da pagina foi encontrado com sucesso!"),
						errorMessage: "O titulo da pagina nao foi encontrado!"
					});
                },

                oTextoDoFormularioDeveTerOValorDaChaveI18nCorrespondente: function(chave){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: FORM_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TITULO,
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O titulo do formulario foi encontrado com sucesso!"),
						errorMessage: "O titulo do formulario nao foi encontrado!"
					});
                },

                aCaixaDialogDeveAparecerComAMensagemDeSucesso: function(MensagemSucesso){
                    return this.waitFor({
						controlType: DIALOG_IDENTIFICADOR,
						check: function (DialogErro) {
							let result = DialogErro[INDICE_ZERO].getContent()[INDICE_ZERO].mProperties.text === MensagemSucesso
							return result;
						},
						success: () => Opa5.assert.ok(true, "A caixa de mensagem cadastro foi aberto com sucesso!"),
						errorMessage: "A caixa de mensagem cadastro nao foi aberta!"
					});
                },

                oBotaoDeveLevarParaTelaDeDetalhes: function(){
                    return this.waitFor({
						viewName: VIEW_DETALHES,
						success: () => Opa5.assert.ok(true, "A tela Cadastro de detalhes foi carregada corretamete!"),
						errorMessage: "A tela de detalhes não foi carregada corretamente!"
					});
                }
			}
		}
	});
});