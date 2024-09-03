sap.ui.define([
	"sap/base/Log",
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/core/format/DateFormat",
	"sap/m/ToolbarSpacer",
	"sap/ui/thirdparty/jquery",
	"sap/ui/core/date/UI5Date"
], function(Log, Controller, JSONModel, Filter, FilterOperator, DateFormat, ToolbarSpacer, jQuery, UI5Date) {
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

	return Controller.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		onInit: function() {
			const oView = this.getView();

			// set explored app's demo model on this sample
			const oJSONModel = this.initSampleDataModel();
			oView.setModel(oJSONModel);

			oView.setModel(new JSONModel({
				filterValue: ""
			}), "ui");

			this._oTxtFilter = null;
			this._oFacetFilter = null;

			sap.ui.require(["sap/ui/table/sample/TableExampleUtils"], function(TableExampleUtils) {
				const oTb = oView.byId("infobar");
				oTb.addContent(new ToolbarSpacer());
				oTb.addContent(TableExampleUtils.createInfoButton("sap/ui/table/sample/Aggregations"));
			}, function(oError) { /*ignore*/ });
		},

		initSampleDataModel: function() {
			const oModel = new JSONModel();

			jQuery.ajax(sap.ui.require.toUrl("Filmes.json"), {
				dataType: "json",
				success: function(oData) {
					const aTemp1 = [];
					const aTemp2 = [];
					const aSuppliersData = [];
					const aCategoryData = [];
					for (let i = 0; i < oData.length; i++) {
						const oProduct = oData[i];
						if (oProduct.titulo && aTemp1.indexOf(oProduct.titulo) < 0) {
							aTemp1.push(oProduct.titulo);
							aSuppliersData.push({Name: oProduct.titulo});
						}
						if (oProduct.genero && aTemp2.indexOf(oProduct.genero) < 0) {
							aTemp2.push(oProduct.genero);
							aCategoryData.push({Name: oProduct.genero});
						}
					}
					oData.titulo = aSuppliersData;
					oData.genero = aCategoryData;
					oModel.setData(oData);
				},
				error: function() {
					Log.error("failed to load json");
				}
			});

			return oModel;
		},

		_filter: function() {
			let oFilter = null;

			if (this._oTxtFilter && this._oFacetFilter) {
				oFilter = new Filter([this._oTxtFilter, this._oFacetFilter], true);
			} else if (this._oTxtFilter) {
				oFilter = this._oTxtFilter;
			} else if (this._oFacetFilter) {
				oFilter = this._oFacetFilter;
			}

			this.byId("tabelaFilmes").getBinding().filter(oFilter, "cod3rsgrowth");
		},

		handleTxtFilter: function(oEvent) {
			const sQuery = oEvent ? oEvent.getParameter("query") : null;
			this._oTxtFilter = null;

			if (sQuery) {
				this._oTxtFilter = new Filter([
					new Filter("titulo", FilterOperator.Contains, sQuery)
				], false);
			}

			this.getView().getModel("ui").setProperty("/filterValue", sQuery);

			if (oEvent) {
				this._filter();
			}
		},

		clearAllFilters: function() {
			this.handleTxtFilter();
			this.handleFacetFilterReset();
			this._filter();
		},

		_getFacetFilterLists: function() {
			const oFacetFilter = this.byId("facetFilter");
			return oFacetFilter.getLists();
		},

		handleFacetFilterReset: function(oEvent) {
			const aFacetFilterLists = this._getFacetFilterLists();

			for (let i = 0; i < aFacetFilterLists.length; i++) {
				aFacetFilterLists[i].setSelectedKeys();
			}
			this._oFacetFilter = null;

			if (oEvent) {
				this._filter();
			}
		},

		handleListClose: function(oEvent) {
			const aFacetFilterLists = this._getFacetFilterLists().filter(function(oList) {
				return oList.getActive() && oList.getSelectedItems().length;
			});

			this._oFacetFilter = new Filter(aFacetFilterLists.map(function(oList) {
				return new Filter(oList.getSelectedItems().map(function(oItem) {
					return new Filter(oList.getTitle(), FilterOperator.EQ, oItem.getText());
				}), false);
			}), true);

			this._filter();
		},

		formatAvailableToObjectState: function(bAvailable) {
			return bAvailable ? "Success" : "Error";
		},


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