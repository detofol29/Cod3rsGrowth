sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/core/format/DateFormat",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/base/Log",
	"sap/ui/model/json/JSONModel",
	"sap/m/ToolbarSpacer",
	"sap/ui/thirdparty/jquery",
	"sap/ui/core/date/UI5Date"
], (BaseController,DateFormat, Filter, FilterOperator, Log, JSONModel, ToolbarSpacer, jQuery, UI5Date) => {
	"use strict";

	const GENEROS = {
		0: "Genero.Ficcao",
		1: "Genero.Acao",
		2: "Genero.Terror",
		3: "Genero.Romance",
		4: "Genero.Drama",
		5: "Genero.Aventura",
		6: "Genero.Comedia",
		7: "Genero.Fantasia"
	};
	
	const CLASSIFICACAO_INDICATIVA = {
		0: "Classificacao.Livre",
		1: "Classificacao.10",
		2: "Classificacao.12",
		3: "Classificacao.14",
		4: "Classificacao.16",
		5: "Classificacao.18"
	};

	return BaseController.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		obterGenero(GeneroIndice) {
			return this.retornarTextoI18nCorrespondente(GENEROS[GeneroIndice]); 
		},
		
		obterClassificacao(ClassificacaoIndice) {
			return this.retornarTextoI18nCorrespondente(CLASSIFICACAO_INDICATIVA[ClassificacaoIndice]);
		},

		formatarData(Data) {
            var dataFormato = DateFormat.getDateInstance({pattern: "yyyy-MM-dd"});
            var oData = new Date(Data);
            return dataFormato.format(oData);
		},

		aoFiltrarFilmes(oEvent){
			const aFilter = [];
			const sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilter.push(new Filter("titulo", FilterOperator.Contains, sQuery));
			}

			// filter binding
			const oList = this.byId("tabelaFilmes");
			const oBinding = oList.getBinding("rows");
			oBinding.filter(aFilter);
		},
	});
});