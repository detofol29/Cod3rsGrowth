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

	const NOME_VIEW = "app.view.DetalhesDeFilmes";
	const BOTAO_TOGGLE_IDENTIFICADOR = "sap.m.ToggleButton";
    const DIALOG_IDENTIFICADOR = "sap.m.Dialog";
	const PROPRIEDADE_TEXTO = "text";
    const PROPRIEDADE_TITULO = "title";
    const PAGINA_IDENTIFICADOR = "sap.m.Page";
    const OBJECT_HEADER_IDENTIFICADOR = "sap.m.ObjectHeader";
    const OBJECT_ATTRIBUTE_IDENTIFICADOR = "sap.m.ObjectAttribute";
	const BOTAO_IDENTIFICADOR = "sap.m.Button";

	Opa5.createPageObjects({
		naTelaDeDetalhes: {
			actions: {
                aoClicarEmEditar: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
						controlType: BOTAO_TOGGLE_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TEXTO,
							key: chave
						}),
						actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de editar foi clicado com sucesso!"),
						errorMessage: "O botão editar não foi encontrado!"
                    });
                },

                aoClicarEmRemover: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
						controlType: BOTAO_TOGGLE_IDENTIFICADOR,
						matchers: new I18NText({
							propertyName : PROPRIEDADE_TEXTO,
							key: chave
						}),
						actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de remover foi clicado com sucesso!"),
						errorMessage: "O botão de remover não foi encontrado!"
                    });
                },

                aoClicarNoBotaoDialogComOTextoCorrespondente: function(textoBotao){
                    return this.waitFor({
						controlType: BOTAO_IDENTIFICADOR,
						matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : textoBotao}),
						actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão do dialog foi clicado com sucesso!"),
						errorMessage: "O botão do dialog não foi encontrado!"
                    });
                }
            },

			assertions: {
                aTelaFoiCarregadaCorretamente: function(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela de detalhes foi carregada corretamete!"),
						errorMessage: "A tela de detalhes não foi carregada corretamente!"
					});
                },

                oTextoDaPaginaApresentaOValorCorrespondente: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: PAGINA_IDENTIFICADOR,
                        matchers: new I18NText({
							propertyName : PROPRIEDADE_TITULO,
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O texto da página apresenta o valor correspondente!"),
						errorMessage: "O texto da página não apresenta o valor correspondente!"
                    });
                },

                oTituloDaPaginaApresentaOValorCorrespondente: function(chave){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_HEADER_IDENTIFICADOR,
                        matchers: new I18NText({
							propertyName : PROPRIEDADE_TITULO,
							key: chave
						}),
						success: () => Opa5.assert.ok(true, "O título da página apresenta o valor correspondente!"),
						errorMessage: "O título da página não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeTituloDeveApresentarOValorCorrespondente: function(titulo){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : titulo}),
						success: () => Opa5.assert.ok(true, "O título do filme apresenta o valor correspondente!"),
						errorMessage: "O título do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeGeneroDeveApresentarOValorCorrespondente: function(genero){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : genero}),
						success: () => Opa5.assert.ok(true, "O gênero do filme apresenta o valor correspondente!"),
						errorMessage: "O gênero do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDataDeveApresentarOValorCorrespondente: function(data){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : data}),
						success: () => Opa5.assert.ok(true, "A data do filme apresenta o valor correspondente!"),
						errorMessage: "A data do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeNotaDeveApresentarOValorCorrespondente: function(nota){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : nota}),
						success: () => Opa5.assert.ok(true, "A nota do filme apresenta o valor correspondente!"),
						errorMessage: "A nota do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeClassificacaoDeveApresentarOValorCorrespondente: function(classificacao){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : classificacao}),
						success: () => Opa5.assert.ok(true, "A classificação do filme apresenta o valor correspondente!"),
						errorMessage: "A classificação do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDuracaoDeveApresentarOValorCorrespondente: function(duracao){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : duracao}),
						success: () => Opa5.assert.ok(true, "A duração do filme apresenta o valor correspondente!"),
						errorMessage: "A duração do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDiretorDeveApresentarOValorCorrespondente: function(diretor){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : diretor}),
						success: () => Opa5.assert.ok(true, "O diretor do filme apresenta o valor correspondente!"),
						errorMessage: "O diretor do filme não apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDisponivelDeveApresentarOValorCorrespondente: function(disponivel){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : disponivel}),
						success: () => Opa5.assert.ok(true, "O disponivel do filme apresenta o valor correspondente!"),
						errorMessage: "O disponivel do filme não apresenta o valor correspondente!"
                    });
                },

                aTelaDeEdicaoDeveSerAberta: function(){
                    const viewDaTelaEditar = "app.view.CadastroDeFilmes"
                    return this.waitFor({
                        viewName: viewDaTelaEditar,
						success: () => Opa5.assert.ok(true, "A tela de editar foi carregada corretamente!"),
						errorMessage: "A tela de editar não foi carregada corretamente!"
                    });
                },

                aCaixaDialogDeveAparecerComAMensagemDeConfirmacao(MensagemdDeConfirmacao){
					return this.waitFor({
						controlType: DIALOG_IDENTIFICADOR,
						check: function (Dialog) {
							let result = Dialog[0].getContent()[0].mProperties.text === MensagemdDeConfirmacao
							return result;
						},
						success: () => Opa5.assert.ok(true, "A caixa de confirmacao foi aberta com sucesso!"),
						errorMessage: "A caixa de confirmacao nao foi aberta!"
					});
				},

                aCaixaDialogDeveAparecerComAMensagemDeSucesso(MensagemdDeConfirmacao){
					return this.waitFor({
						controlType: DIALOG_IDENTIFICADOR,
						check: function (Dialog) {
							let result = Dialog[0].getContent()[0].mProperties.text === MensagemdDeConfirmacao
							return result;
						},
						success: () => Opa5.assert.ok(true, "A caixa de sucesso foi aberta com sucesso!"),
						errorMessage: "A caixa de sucesso nao foi aberta!"
					});
				},

                aTelaDeListagemDeveSerAberta: function(){
                    const viewDaTelaLista = "app.view.ListaDeFilmes"
                    return this.waitFor({
                        viewName: viewDaTelaLista,
						success: () => Opa5.assert.ok(true, "A tela de Listagem foi carregada corretamente!"),
						errorMessage: "A tela de Listagem não foi carregada corretamente!"
                    });
                }
			}
		}
	});
});