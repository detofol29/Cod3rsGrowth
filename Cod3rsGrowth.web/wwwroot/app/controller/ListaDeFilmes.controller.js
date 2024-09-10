sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador"
], function(BaseController, JSONModel, Repositorio, Formatador) {
	"use strict";

	const STRING_VAZIA = "";
	const COMBOBOX_FILTRO_GENERO_ID = "filtroGenero";
	const MODELO_GENEROS_NOME = "Generos";
	const MODELO_FILTRO_NOME = "modeloFiltro";
	const MODELO_FILTRO_TITULO = "/titulo";
	const MODELO_FILTRO_GENERO = "/genero";
	const EVENTO_PROPRIEDADE_VALUE = "value";
	const EVENTO_PROPRIEDADE_NEWVALUE = "newValue";
	const URL_COMPONENTE_TITULO = "FiltroTitulo=";
	const URL_COMPONENTE_GENERO = "FiltroGenero=";
	const URL_COMPONENTE_GENERO_ACRESCIDO = "&FiltroGenero=";
	const ROTA_LISTA_DE_FILMES = "ListaDeFilmes";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.ListaDeFilmes";
	const INDICE_ZERO = 0;

	return BaseController.extend(ROTA_CONTROLLER, {

		onInit: function() {			
			this
			.getRouter()
			.getRoute(ROTA_LISTA_DE_FILMES)
			.attachPatternMatched(async () => {
				return this._aoCoincidirRota();
			}, this);			
		},

		_aoCoincidirRota: function() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.carregarDadosFilme(STRING_VAZIA, view),
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
					Repositorio.obterModeloFiltro(view)
                ]);
            });
        },

		obterGenero: function(GeneroIndice){
			return Formatador.formatarGenero(GeneroIndice, this.getView());
		},

		obterClassificacao: function(indiceClassificacao){
			return Formatador.formatarClassificacao(indiceClassificacao, this.getView());
		},

		_obterIndiceGenero: function(Genero){
			let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
			for (let i = INDICE_ZERO; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

		aoSelecionarItem: function(event) {
			let generoSelecionado = event.getParameter(EVENTO_PROPRIEDADE_NEWVALUE);
			if(generoSelecionado == STRING_VAZIA){
				this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty(MODELO_FILTRO_GENERO, STRING_VAZIA);
			}else{
				let indiceGenero = this._obterIndiceGenero(generoSelecionado);
				this
					.getView()
					.getModel(MODELO_FILTRO_NOME)
					.setProperty(MODELO_FILTRO_GENERO, indiceGenero);
			}
		},

		obterData: function(Data) {
            return Formatador.formatarData(Data);
		},
		
		obterDisponivel: function(Disponivel) {
			let chaveI18n = Formatador.formatarDisponivel(Disponivel);
			return this.retornarTextoI18nCorrespondente(chaveI18n);
		},

		aoPerderFocoBarraDePesquisa: function(event){
			let query = event.getParameter(EVENTO_PROPRIEDADE_VALUE);
			this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty(MODELO_FILTRO_TITULO, query);
		},

		aoClicarEmFiltrar: async function() {
            this.processarAcao(() => {
                let view = this.getView();
				let modeloFiltro = view.getModel(MODELO_FILTRO_NOME).getData();
				let titulo = modeloFiltro.titulo;

				let generoNome = view.byId(COMBOBOX_FILTRO_GENERO_ID).mProperties.value;
				let generoIndice = this._obterIndiceGenero(generoNome);

                let filtros = STRING_VAZIA;

                filtros = titulo.length == INDICE_ZERO
					? filtros + STRING_VAZIA
					: URL_COMPONENTE_TITULO + titulo;

                filtros = generoIndice == undefined
					? filtros + STRING_VAZIA
					: (filtros.length == INDICE_ZERO ? filtros + URL_COMPONENTE_GENERO + generoIndice: filtros + URL_COMPONENTE_GENERO_ACRESCIDO + generoIndice);

                Repositorio.carregarDadosFilme(filtros, view);
            });
        }
	});
});