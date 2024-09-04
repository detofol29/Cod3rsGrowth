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
], function(Log, BaseController, JSONModel, Filter, FilterOperator, DateFormat, ToolbarSpacer, jQuery, UI5Date) {
	"use strict";

	// const GENEROS = {
	// 	0: "Genero.Ficcao",
	// 	1: "Genero.Acao",
	// 	2: "Genero.Terror",
	// 	3: "Genero.Romance",
	// 	4: "Genero.Drama",
	// 	5: "Genero.Aventura",
	// 	6: "Genero.Comedia",
	// 	7: "Genero.Fantasia"
	// };
	
	// const CLASSIFICACAO_INDICATIVA = {
	// 	0: "Classificacao.Livre",
	// 	1: "Classificacao.10",
	// 	2: "Classificacao.12",
	// 	3: "Classificacao.14",
	// 	4: "Classificacao.16",
	// 	5: "Classificacao.18"
	// };

	return BaseController.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		onInit: function() {
			const oView = this.getView();
			const oJSONModel = this.initSampleDataModel();

			const modeloFiltroB = new JSONModel();

			

			fetch('http://localhost:5152/api/Filme')
			.then(resposta => resposta.json())
			.then(dadosBanco => oView.setModel(new JSONModel(dadosBanco), "filme"));

			fetch('http://localhost:5152/api/Enum')
				.then(resposta => resposta.json())
				.then(dadosBanco => oView.setModel(new JSONModel(dadosBanco), "Generos"));
			
			// fetch('http://localhost:5152/api/Enum')
			// 	.then(resposta => resposta.json())
			// 	.then(dadosBanco => oView.setModel(new JSONModel({ "Generos": dadosBanco })));

			let nomeModelo = "filtro"
			const oModel = new JSONModel({nome: "Samuel", enum: "0"});
			oView.setModel(oModel, nomeModelo);

			let nomeModelofiltro = "modeloFiltro"
			const modeloFiltro = new JSONModel();

			let modeloFiltroee = oView.getModel("filtro");
			console.log(modeloFiltro.getData())

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

		obterEnumBaseDeDados(){
			// fetch('http://localhost:5152/api/Enum')
			// 	.then(resposta => resposta.json())
			// 	.then(dadosBanco => oView.setModel(new JSONModel({ "Generos": dadosBanco })));

			
		},

		filtrarGenerosB(event){
			//debugger
			let aFilter;
			const comboBox = this.byId("comboBoxFiltroGenero")
			var indiceGeneroSelecionado = comboBox._lastValue

			const sQuery = indiceGeneroSelecionado;
			
            // const sQuery = oEvent.getParameter("query") 
            //     || oEvent.getParameter("newValue");
                
            if(sQuery) {
                aFilter = new Filter("genero", FilterOperator.Contains, sQuery);
            }

            // const oList = this.byId("tabelaFilmes");
            // const oBinding = oList.getBinding();
            // oBinding.filter(aFilter);

			this.byId("tabelaFilmes").getBinding().filter(aFilter, "cod3rsgrowth");

			// const sQuery = 1;
			// this._oFacetFilter = null;

			// if (sQuery) {
			// 	this._oFacetFilter = new Filter([
			// 		new Filter("genero", FilterOperator.Contains, sQuery)
			// 	], false);
			// }

			// this.getView().getModel("ui").setProperty("/filterValue", sQuery);

			// if (event) {
			// 	this._filter();
			// }
		},

		obterFilmesFiltrados(IndiceGenero){


			fetch('http://localhost:5152/api/Filme/filtros/' + IndiceGenero)
				.then(resposta => resposta.json())
				.then(dadosBanco => oView.setModel(dadosBanco, "filme"));

			const oList = this.byId("tabelaFilmes");
			const oBinding = oList.getBinding("items");
			oList.rows = "list"
		},

		initSampleDataModel: function() {
			const oModel = new JSONModel();

			jQuery.ajax(sap.ui.require.toUrl("{/filme}"), {
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
			debugger
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

		// obterClassificacao(ClassificacaoIndice) {
		// 	return this.retornarTextoI18nCorrespondente(CLASSIFICACAO_INDICATIVA[ClassificacaoIndice]);
		// },

		obterGenero(GeneroIndice){
			var genero = this.getView().getModel("Generos");
			return genero[GeneroIndice].descricao;
			// return this.retornarTextoI18nCorrespondente(GENEROS[GeneroIndice]);
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

			const oList = this.byId("tabelaFilmes");
			const oBinding = oList.getBinding("rows");
			oBinding.filter(aFilter);
		},

		formatarDisponivel(Disponivel) {
			if(Disponivel){
				return "Sim"
			}
			return "Não"
		},

		clearAllFilters: function() {
			this.handleTxtFilter();
			this.handleFacetFilterReset();
			this._filter();
		},

		aoClicarBotaoFiltros(event){
			//pegar o valor do modelo filtro

			//Pegar o indice da comboBox

			let valorDigitadoGenero = event.getParameter('newValue');
			this.obterFilmesFiltrados(valorDigitadoGenero);



			//mandar esses valores pra api como query
			//obter esses dados considerando os filtros

			// var sSelectedGenero = this.byId("comboBoxFiltroGenero").getParameter("selectedItem").getKey();

            // // Obtém a referência da tabela
            // var oTable = this.byId("tabelaFilmes");

            // // Define o filtro
            // var aFilters = [];
            // if (sSelectedGenero !== "todos") {
            //     aFilters.push(new Filter("genero", FilterOperator.EQ, sSelectedGenero));
            // }

            // // Aplica o filtro à binding da tabela
            // var oBinding = oTable.getBinding("rows");
            // oBinding.filter(aFilters);
		},

		//Obter os dois valores selecionados Barra e combobox
		//criar json model
		//setModel

		metodoQuePreenche(event){
			let valorDigitadoCampoNome = event.getParameter('newValue');
			let nomeModelo = "filtro"
			const oModel = new JSONModel({genero: valorDigitadoCampoNome, id: "0"});
			oView.setModel(oModel, nomeModelo);
		},

		metodoQuePreencheGenero(event){
			let valorEscolhido = event.getParameter('newValue');

			let nomeModelo = "filtro"
			const oModel = new JSONModel({generoNome: valorDigitadoCampoNome, GeneroId: "0"});
			oView.setModel(oModel, nomeModelo);
		}
	});
});