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
	const PROPRIEDADE_TEXTO = "text";
    const PROPRIEDADE_TITULO = "title";
    const PAGINA_IDENTIFICADOR = "sap.m.Page";
    const OBJECT_HEADER_IDENTIFICADOR = "sap.m.ObjectHeader";
    const OBJECT_ATTRIBUTE_IDENTIFICADOR = "sap.m.ObjectAttribute";
	

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
                        success: () => Opa5.assert.ok(true, "O botao de editar foi clicado com sucesso!"),
						errorMessage: "O botao editar não foi encontrado!"
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
						success: () => Opa5.assert.ok(true, "O texto da pagina apresenta o valor correspondente!"),
						errorMessage: "O texto da pagina nao apresenta o valor correspondente!"
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
						success: () => Opa5.assert.ok(true, "O titulo da pagina apresenta o valor correspondente!"),
						errorMessage: "O titulo da pagina nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeTituloDeveApresentarOValorCorrespondente: function(titulo){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : titulo}),
						success: () => Opa5.assert.ok(true, "O titulo do filme apresenta o valor correspondente!"),
						errorMessage: "O titulo do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeGeneroDeveApresentarOValorCorrespondente: function(genero){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : genero}),
						success: () => Opa5.assert.ok(true, "O genero do filme apresenta o valor correspondente!"),
						errorMessage: "O genero do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDataDeveApresentarOValorCorrespondente: function(data){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : data}),
						success: () => Opa5.assert.ok(true, "A data do filme apresenta o valor correspondente!"),
						errorMessage: "A data do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeNotaDeveApresentarOValorCorrespondente: function(nota){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : nota}),
						success: () => Opa5.assert.ok(true, "A nota do filme apresenta o valor correspondente!"),
						errorMessage: "A nota do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeClassificacaoDeveApresentarOValorCorrespondente: function(classificacao){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : classificacao}),
						success: () => Opa5.assert.ok(true, "A classificacao do filme apresenta o valor correspondente!"),
						errorMessage: "A classificacao do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDuracaoDeveApresentarOValorCorrespondente: function(duracao){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : duracao}),
						success: () => Opa5.assert.ok(true, "A duracao do filme apresenta o valor correspondente!"),
						errorMessage: "A duracao do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDiretorDeveApresentarOValorCorrespondente: function(diretor){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : diretor}),
						success: () => Opa5.assert.ok(true, "O diretor do filme apresenta o valor correspondente!"),
						errorMessage: "O diretor do filme nao apresenta o valor correspondente!"
                    });
                },

                aProprioedadeDisponivelDeveApresentarOValorCorrespondente: function(disponivel){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: OBJECT_ATTRIBUTE_IDENTIFICADOR,
                        matchers : new PropertyStrictEquals({name : PROPRIEDADE_TEXTO, value : disponivel}),
						success: () => Opa5.assert.ok(true, "O disponivel do filme apresenta o valor correspondente!"),
						errorMessage: "O disponivel do filme nao apresenta o valor correspondente!"
                    });
                },

                aTelaDeEdicaoDeveSerAberta: function(){
                    const viewDaTelaEditar = "app.view.EdicaoDeFilmes"
                    return this.waitFor({
                        viewName: viewDaTelaEditar,
						success: () => Opa5.assert.ok(true, "A tela de editar foi carregada corretamente!"),
						errorMessage: "A tela de editar nao foi carregada corretamente!"
                    });
                }
			}
		}
	});
});