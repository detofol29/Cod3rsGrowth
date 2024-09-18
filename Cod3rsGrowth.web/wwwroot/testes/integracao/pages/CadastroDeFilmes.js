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
	const BOTAO_IDENTIFICADOR = "sap.m.Button";
	const PROPRIEDADE_TEXTO = "text";
	const INPUT_IDENTIFICADOR = "sap.m.Input";
	const PLACEHOLDER_IDENTIFICADOR = "placeholder";
	

	Opa5.createPageObjects({
		noCadastroDeFilmes: {
			actions: {
				aoClicarNoBotaoCadastrarFilme: function(chave){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BOTAO_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TEXTO,
							key: chave
						}),
						actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botao de cadastrar foi clicado com sucesso!"),
						errorMessage: "O botao cadastrar não foi encontrado!"
					});
				},

				aoPreencherOCampoTitulo(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputTitulo.Texto"
						}),
						actions: new EnterText({ text: "FilmeTesteOpa" + new Date().getMilliseconds() }),
						success: () => Opa5.assert.ok(true, "O campo titulo foi preenchido corretamente!"),
						errorMessage: "O campo titulo nao foi preenchido corretamente!"
					});
				},

				aoSelecionarGenero(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.ComboBox",
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputGenero.Texto"
						}),
						actions: (item) => {
							var itemSelecionado = item.mAggregations.items[0];
							item.setSelectedItem(itemSelecionado);
						},
						success: () => Opa5.assert.ok(true, "O campo genero foi preenchido corretamente!"),
						errorMessage: "O campo genero nao foi preenchido corretamente!"
					});
				},

				aoSelecionarData(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.DatePicker",
						actions: new EnterText({ text: "02/09/2024" }),
						success: () => Opa5.assert.ok(true, "O campo data foi preenchido corretamente!"),
						errorMessage: "O campo data nao foi preenchido corretamente!"
					});
				},

				aoPreencherOCampoDiretor(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputDiretor.Texto"
						}),
						actions: new EnterText({ text: "Diretor Teste" }),
						success: () => Opa5.assert.ok(true, "O campo diretor foi preenchido corretamente!"),
						errorMessage: "O campo diretor nao foi preenchido corretamente!"
					});
				},

				aoPreencherOCampoClassificacao(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.ComboBox",
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputClassificacao.Texto"
						}),
						actions: (item) => {
							var itemSelecionado = item.mAggregations.items[0];
							item.setSelectedItem(itemSelecionado);
						},
						success: () => Opa5.assert.ok(true, "O campo classificacao foi preenchido corretamente!"),
						errorMessage: "O campo classificacao nao foi preenchido corretamente!"
					});
				},

				aoPreencherOCampoNota(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputNota.Texto"
						}),
						actions: new EnterText({ text: "7" }),
						success: () => Opa5.assert.ok(true, "O campo nota foi preenchido corretamente!"),
						errorMessage: "O campo nota nao foi preenchido corretamente!"
					});
				},

				aoPreencherOCampoDuracao(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: INPUT_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PLACEHOLDER_IDENTIFICADOR,
							key: "CadastroDeFilmes.InputDuracao.Texto"
						}),
						actions: new EnterText({ text: "111" }),
						success: () => Opa5.assert.ok(true, "O campo duracao foi preenchido corretamente!"),
						errorMessage: "O campo duracao nao foi preenchido corretamente!"
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
						success: () => Opa5.assert.ok(true, "A tela Cadastro de filmes foi carregada corretamete!"),
						errorMessage: "A tela Cadastro de filmes não foi carregada corretamente!"
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

				aCaixaDeMensagemDeveAparecerComOsErrosCorrespondentes: function(Erros) {
					return this.waitFor({
						controlType: "sap.m.Dialog",
						check: function (DialogErro) {
							let result = DialogErro[0].getContent()[0].mProperties.text === Erros
							DialogErro[0].close();
							return result;
						},
						success: () => Opa5.assert.ok(true, "A caixa de mensagem foi aberto com sucesso!"),
						errorMessage: "A caixa de mensagem nao foi aberta!"
					});
				},

				aCaixaDialogDeveAparecerComAMensagemDeSucesso(MensagemSucesso){
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

				oBotaoDeveLevarParaTelaDeListagem: function(){
					return this.waitFor({
						viewName: "app.view.ListaDeFilmes",
						success: () => Opa5.assert.ok(true, "A tela Cadastro de listagem foi carregada corretamete!"),
						errorMessage: "A tela de filmes não foi carregada corretamente!"
					});
				}
			}
		}
	});
});