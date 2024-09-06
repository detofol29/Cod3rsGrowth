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

	return BaseController.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		onInit() {
			let nomeModeloFiltro = "modeloFiltro"
			const modeloFiltro = new JSONModel({genero: "", titulo: ""});
			
			this
			.getRouter()
			.getRoute("ListaDeFilmes")
			.attachPatternMatched(async () => {
				return this.aoCoincidirRota();
			}, this);
			
			const oView = this.getView();
			oView.setModel(modeloFiltro, nomeModeloFiltro);
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

		obterGenero(GeneroIndice){
			return Formatador.formatarGenero(GeneroIndice, this.getView());
		},

		obterClassificacao(indiceClassificacao){
			return Formatador.formatarClassificacao(indiceClassificacao, this.getView());
		},

		obterIndiceGenero(Genero){
			let genero = this.getView().getModel("Generos").getData();
			for (let i = 0; i < genero.length; i++) {
				if(genero[i].descricao == Genero){
					return i;
				}
			}
		},

		aoSelecionarItem(event) {
			debugger
			let generoSelecionado = event.getParameter("newValue");
			if(generoSelecionado == ""){
				this
				.getView()
				.getModel("modeloFiltro")
				.setProperty("/genero", "");
			}else{
				let indiceGenero = this.obterIndiceGenero(generoSelecionado);
				this
					.getView()
					.getModel("modeloFiltro")
					.setProperty("/genero", indiceGenero);
			}
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

		obterData(Data) {
            return Formatador.formatarData(Data);
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
		
		obterDisponivel(Disponivel) {
			return Formatador.formatarDisponivel(Disponivel);
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