sap.ui.define([
	"sap/base/Log",
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/core/format/DateFormat",
	"sap/ui/thirdparty/jquery",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador"
], function(Log, BaseController, JSONModel, Filter, FilterOperator, DateFormat, jQuery, repositorio, Formatador) {
	"use strict";

	const modeloGenero = "Generos";
	const modeloClassificacao = "Classificacoes"
	const FILTRO_TITULO = "filtroTitulo";
    const FILTRO_GENERO = "filtroGenero"

	return BaseController.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		onInit() {
			const oView = this.getView();
			const oJSONModel = this.initSampleDataModel();
			this
				.getRouter()
				.getRoute("ListaDeFilmes")
				.attachPatternMatched(async () => {
                	return this.aoCoincidirRota();
            	}, this);

			let nomeModeloFiltro = "modeloFiltro"
			const modeloFiltro = new JSONModel({genero: "", titulo: ""});
			oView.setModel(modeloFiltro, nomeModeloFiltro);

			oView.setModel(oJSONModel);

			oView.setModel(new JSONModel({
				filterValue: ""
			}), "ui");

			this._oTxtFilter = null;
			this._oFacetFilter = null;
		},

		aoCoincidirRota() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    repositorio.carregarDadosFilme("", view),
                    repositorio.obterEnumGenero(view),
                    repositorio.obterEnumClassificacao(view)
                ]);
            });
        },

		initSampleDataModel() {
			const oModel = new JSONModel();

			jQuery.ajax(sap.ui.require.toUrl("{/filme}"), {
				dataType: "json",
				success(oData) {
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

				error() {
					Log.error("Falha ao abrir Json");
				}
			});

			return oModel;
		},

		_filter() {
			let oFilter = null;

			if (this._oTxtFilter && this._oFacetFilter) {
				oFilter = new Filter([this._oTxtFilter, this._oFacetFilter], true);
			} else if (this._oTxtFilter) {
				oFilter = this._oTxtFilter;
			} else if (this._oFacetFilter) {
				oFilter = this._oFacetFilter;
			}

			this
				.byId("tabelaFilmes")
				.getBinding()
				.filter(oFilter, "cod3rsgrowth");
		},

		// handleTxtFilter(oEvent) {
		// 	const sQuery = oEvent ? oEvent.getParameter("query") : null;
		// 	this._oTxtFilter = null;
		// 	this.getView().getModel("modeloFiltro").setProperty("/titulo", sQuery);

		// 	if (sQuery) {
		// 		this._oTxtFilter = new Filter([
		// 			new Filter("titulo", FilterOperator.Contains, sQuery)
		// 		], false);
		// 	}

		// 	this.getView().getModel("ui").setProperty("/filterValue", sQuery);

		// 	if (oEvent) {
		// 		this._filter();
		// 	}
		// },

		obterGenero(GeneroIndice){
			let genero = this.getView().getModel("Generos").getData();
			return genero[GeneroIndice].descricao;
		},
		//formatador
		formatarClassificacao(indiceClassificacao){
			let classificacao = this.getView().getModel("Classificacoes").getData();
			return classificacao[indiceClassificacao].descricao;
		},

		obterIndiceGenero(Genero){
			let genero = this.getView().getModel("Generos").getData();
			for (let i = 0; i < genero.length; i++) {
				if(genero[i].descricao == Genero){
					return i;
				}
			}
		},

		aoSelecionarItem(event){
			let generoSelecionado = event.getParameter("newValue");
			let indiceGenero = this.obterIndiceGenero(generoSelecionado);
			this
				.getView()
				.getModel("modeloFiltro")
				.setProperty("/genero", indiceGenero);
			window
				.alert("Selecionou o item: " + generoSelecionado);
		},

		aoSairDaBarraPesquisa(event){
			let textoDigitado = event.getParameter("value");
			this
				.getView()
				.getModel("modeloFiltro")
				.setProperty("/titulo", textoDigitado);
		},

		aoClicarBotaoFiltrar(event){
			let modeloFiltro = this.getView().getModel("modeloFiltro").getData();
			let titulo = modeloFiltro.titulo;
			let generoIndice = modeloFiltro.genero;
			window.alert("O titulo selecionada para filtro eh: " + titulo + " e o indice do genero eh: " + generoIndice.toString());
			// Codigo a ser construído
		},
		//formatador
		formatarData(Data) {
            let dataFormato = DateFormat.getDateInstance({pattern: "yyyy-MM-dd"});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

		aoFiltrarFilmes(event){
			const aFilter = [];
			const sQuery = event.getParameter("query");
			this
				.getView()
				.getModel("modeloFiltro")
				.setProperty("/titulo", sQuery);

			if (sQuery) {
				aFilter
					.push(
						new Filter("titulo", FilterOperator.Contains, sQuery)
					);
			}

			const oList = this.byId("tabelaFilmes");
			const oBinding = oList.getBinding("rows");
			oBinding.filter(aFilter);
		},
		//formatador
		formatarDisponivel(Disponivel) {
			let valorFormatado = "Não";
			if(Disponivel){
				valorFormatado = "Sim";
			}
			return valorFormatado;
		},

		aoPerderFocoBarraDePesquisa(event){
			const sQuery = event.getParameter("value");
			this
				.getView()
				.getModel("modeloFiltro")
				.setProperty("/titulo", sQuery);
		},

		async aoClicarEmFiltrar() {
            this.processarAcao(() => {
				let modeloFiltro = this.getView().getModel("modeloFiltro").getData();
				let titulo = modeloFiltro.titulo;
				let generoIndice = modeloFiltro.genero;
                let view = this.getView();
                let filtros = "";

                filtros = titulo.length == 0
					? filtros + ""
					: "FiltroTitulo=" + titulo;

                filtros = generoIndice.length == 0
					? filtros + ""
					: (filtros.length == 0 ? filtros + "FiltroGenero=" + generoIndice: filtros + "&FiltroGenero=" + generoIndice);

                repositorio.carregarDadosFilme(filtros, view);
            });
        }
	});
});