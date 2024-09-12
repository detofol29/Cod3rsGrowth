sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"
], function(Opa5, Press, EnterText) {
	"use strict";

	const NOME_VIEW = "app.view.CadastroDeFilmes";
	const INDICE_INICIAL = 0;
	const INDICE_GENERO_FANTASIA = 7;
	const COMBOBOX_IDENTIFICADOR = "sap.m.ComboBox";
	const BOTAO_FILTRAR_IDENTIFICADOR = "sap.m.ToggleButton";
	const BARRA_DE_PESQUISA_IDENTIFICADOR = "sap.m.SearchField";
	const TABELA_IDENTIFICADOR = "sap.ui.table.Table";
	const TITULO_IDENTIFICADOR = "sap.m.Title";
	const PROPRIEDADE_TEXTO = "text";
	

	Opa5.createPageObjects({
		noCadastroDeFilmes: {
			actions: {
				
			},

			assertions: {
                aTelaFoiCarregadaCorretamente: function(){
                    return this.waitFor({
						viewName: NOME_VIEW,
						success: () => Opa5.assert.ok(true, "A tela Cadastro de filmes foi carregada corretamete!"),
						errorMessage: "A tela Cadastro de filmes não foi carregada corretamente!"
					});
                }
			}
		}
	});
});