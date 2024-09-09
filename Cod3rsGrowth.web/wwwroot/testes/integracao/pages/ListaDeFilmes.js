sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"
], (Opa5, Press, EnterText) => {
	"use strict";

	const NOME_VIEW = "app.view.ListaDeFilmes";
	Opa5.createPageObjects({
		naListaDeFilmes: {
			actions: {
				aoClicarGenero(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.ComboBox",
						actions: (item) => {
							var itemSelecionado = item.mAggregations.items[7];
							item.setSelectedItem(itemSelecionado);
						},
						success: () => Opa5.assert.ok(true, "O combo box foi selecionado com sucesso!"),
						errorMessage: "O combo box não foi encontrado!"
					});
                },

                aoClicarBotaoFiltro(){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.m.ToggleButton",
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botao de filtrar foi clicado com sucesso!"),
						errorMessage: "O botao filtrar não foi encontrado não foi encontrado!"
                    });
                },

				aoAdicionarTituloDoFilmeCorrespondenteNaBarraDePesquisa(titulo){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.SearchField",
						actions: new EnterText({ text: titulo}),
						success: () => Opa5.assert.ok(true, "O nome do filme foi digitado com sucesso!"),
						errorMessage: "O nome do filme não foi digitado com sucesso"
					})
				},

				aoRemoverFiltrosGenero(){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.ComboBox",
						actions: (item) => {
							item.clearSelection();
						},
						success: () => Opa5.assert.ok(true, "O combo box foi limpo!"),
						errorMessage: "O combo box não foi limpo!"
					});
				}
			},

			assertions: {
                aTelaFoiCarregadaCorretamente() {
					return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela Lista de filmes foi carregada corretamete!"),
						errorMessage: "A tela lista de filmes não foi carregada corretamente!"
					});
				},

                aTabelaDevePossuirAQuantidadeDeElementos(quantidadeDeFilmes){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.ui.table.Table",
                        check: function (tabela) {
                            return tabela[0]._iBindingLength == quantidadeDeFilmes
                        },
                        success: () => Opa5.assert.ok(true, "A quantidade está correta!"),
                        errorMessage: "Não foi possível verificar a quantidade de filmes filtrados"
                    });
                },

				oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente(chave){
					return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.Title",
						matchers: {
							i18NText: {
								propertyName: "text",
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
})