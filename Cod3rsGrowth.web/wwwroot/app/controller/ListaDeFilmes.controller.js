sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador"
], function(BaseController, JSONModel, Repositorio, Formatador) {
	"use strict";

	const STRING_VAZIA = "";
	const MODELO_GENEROS_NOME = "Generos";
	const MODELO_FILTRO_NOME = "modeloFiltro";
	const COMBOBOX_FILTRO_GENERO_ID = "filtroGenero";

	return BaseController.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		onInit() {
			let modeloFiltro = new JSONModel({genero: STRING_VAZIA, titulo: STRING_VAZIA});
			
			this
			.getRouter()
			.getRoute("ListaDeFilmes")
			.attachPatternMatched(async () => {
				return this.aoCoincidirRota();
			}, this);
			
			const oView = this.getView();
			oView.setModel(modeloFiltro, MODELO_FILTRO_NOME);
		},

		aoCoincidirRota() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.carregarDadosFilme(STRING_VAZIA, view),
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view)
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
			let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
			for (let i = 0; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

		aoSelecionarItem(event) {
			let generoSelecionado = event.getParameter("newValue");
			if(generoSelecionado == STRING_VAZIA){
				this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty("/genero", STRING_VAZIA);
			}else{
				let indiceGenero = this.obterIndiceGenero(generoSelecionado);
				this
					.getView()
					.getModel(MODELO_FILTRO_NOME)
					.setProperty("/genero", indiceGenero);
			}
		},

		obterData(Data) {
            return Formatador.formatarData(Data);
		},
		
		obterDisponivel(Disponivel) {
			return Formatador.formatarDisponivel(Disponivel);
		},

		aoPerderFocoBarraDePesquisa(event){
			const sQuery = event.getParameter("value");
			this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty("/titulo", sQuery);
		},

		async aoClicarEmFiltrar() {
            this.processarAcao(() => {
                let view = this.getView();
				let modeloFiltro = view.getModel(MODELO_FILTRO_NOME).getData();
				let titulo = modeloFiltro.titulo;

				let generoNome = view.byId(COMBOBOX_FILTRO_GENERO_ID).mProperties.value;
				let generoIndice = this.obterIndiceGenero(generoNome);

                let filtros = STRING_VAZIA;

                filtros = titulo.length == 0
					? filtros + ""
					: "FiltroTitulo=" + titulo;

                filtros = generoIndice == undefined
					? filtros + ""
					: (filtros.length == 0 ? filtros + "FiltroGenero=" + generoIndice: filtros + "&FiltroGenero=" + generoIndice);

                Repositorio.carregarDadosFilme(filtros, view);
            });
        }
	});
});