sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"
], function(Opa5, Press, EnterText) {
	"use strict";

	const NOME_VIEW = "app.view.ListaDeFilmes";
	const INDICE_INICIAL = 0;
	const INDICE_GENERO_FANTASIA = 7;
	const COMBOBOX_IDENTIFICADOR = "sap.m.ComboBox";
	const BOTAO_FILTRAR_IDENTIFICADOR = "sap.m.ToggleButton";
	const BARRA_DE_PESQUISA_IDENTIFICADOR = "sap.m.SearchField";
	const TABELA_IDENTIFICADOR = "sap.ui.table.Table";
	const TITULO_IDENTIFICADOR = "sap.m.Title";
	const PROPRIEDADE_TEXTO = "text";
	

	Opa5.createPageObjects({
		naListaDeFilmes: {
			actions: {
				aoClicarGenero: function(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: COMBOBOX_IDENTIFICADOR,
						actions: (item) => {
							var itemSelecionado = item.mAggregations.items[INDICE_GENERO_FANTASIA];
							item.setSelectedItem(itemSelecionado);
						},
						success: () => Opa5.assert.ok(true, "O combo box foi selecionado com sucesso!"),
						errorMessage: "O combo box não foi encontrado!"
					});
                },

                aoClicarBotaoFiltro: function(){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: BOTAO_FILTRAR_IDENTIFICADOR,
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botao de filtrar foi clicado com sucesso!"),
						errorMessage: "O botao filtrar não foi encontrado não foi encontrado!"
                    });
                },

				aoAdicionarTituloDoFilmeCorrespondenteNaBarraDePesquisa: function(titulo){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: BARRA_DE_PESQUISA_IDENTIFICADOR,
						actions: new EnterText({ text: titulo}),
						success: () => Opa5.assert.ok(true, "O nome do filme foi digitado com sucesso!"),
						errorMessage: "O nome do filme não foi digitado com sucesso"
					})
				},

				aoRemoverFiltrosGenero: function(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: COMBOBOX_IDENTIFICADOR,
						actions: (item) => {
							item.clearSelection();
						},
						success: () => Opa5.assert.ok(true, "O combo box foi limpo!"),
						errorMessage: "O combo box não foi limpo!"
					});
				}
			},

			assertions: {
                aTelaFoiCarregadaCorretamente: function() {
					return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela Lista de filmes foi carregada corretamete!"),
						errorMessage: "A tela lista de filmes não foi carregada corretamente!"
					});
				},

                aTabelaDevePossuirAQuantidadeDeElementos: function(quantidadeDeFilmes){
					let numero = null;
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: TABELA_IDENTIFICADOR,
                        check: function (tabela) {
							this.numero = tabela[INDICE_INICIAL]._iBindingLength;
                            return tabela[INDICE_INICIAL]._iBindingLength == quantidadeDeFilmes
                        },
                        success: () => Opa5.assert.ok(true, "A quantidade está correta!"),
                        errorMessage: "Não foi possível verificar a quantidade de filmes filtrados" + numero.toString()
                    });
                },

				oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente: function(chave){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: TITULO_IDENTIFICADOR,
						matchers: {
							i18NText: {
								propertyName: PROPRIEDADE_TEXTO,
        						key: chave
							}
						},
						success: () => Opa5.assert.ok(true, "O título apresenta o valor correspondente!"),
						errorMessage: "O título não possui o valor correspondente!"
					});
				}
			}
		}
	});
});