sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
	"sap/ui/test/matchers/Properties"
], (Opa5, Press, EnterText, Properties) => {
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
							//debugger
							var itemSelecionado = item.mAggregations.items[7];
							item.selectText(7)
							//item.setSelectedItem(itemSelecionado);
							//item.fireChange();
						},
						success: () => Opa5.assert.ok(true, "O combo box foi selecionado com sucesso!<3"),
						errorMessage: "O combo box não foi encontrado!"
					});
                },

				aoClicarComboBox(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						controlType: "sap.m.ComboBox",
						actions: new Press(),
						success: () => Opa5.assert.ok(true, "O combo box foi selecionado com sucesso!<3"),
						errorMessage: "O combo box não foi encontrado!"
					});
                },

                aoClicarBotaoFiltro(){
                    return this.waitFor({
                        viewName: NOME_VIEW,
                        controlType: "sap.m.ToggleButton",
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botao de filtrar foi clicado com sucesso!<3"),
						errorMessage: "O botao filtrar nao foi encontrado não foi encontrado!"
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
                            return tabela[0].getModel("filme").getData().length == quantidadeDeFilmes
                        },
                        success: () => Opa5.assert.ok(true, "A quantidade esta correta!"),
                        errorMessage: "Não foi possível verificar a quantidade de filmes filtrados"
                    });
                },
			}
		}
	});
})