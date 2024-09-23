sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador"
], function(BaseController, JSONModel, Repositorio, Formatador) {
	"use strict";

	const STRING_VAZIA = "";
	const MODELO_FILTRO_NOME = "modeloFiltro";
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
		
		formatador: Formatador,

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

		_obterIndiceGenero: function(Genero){
			const modeloGenerosNome = "Generos";

			let generos = this.getView().getModel(modeloGenerosNome).getData();
			for (let i = INDICE_ZERO; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

		aoSelecionarItem: function(event) {
			const modeloFiltroGenero = "/genero";
			const eventoPropriedadeNewValue = "newValue";

			let generoSelecionado = event.getParameter(eventoPropriedadeNewValue);
			if(generoSelecionado == STRING_VAZIA){
				this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty(modeloFiltroGenero, STRING_VAZIA);
			} else{
				let indiceGenero = this._obterIndiceGenero(generoSelecionado);
				this
					.getView()
					.getModel(MODELO_FILTRO_NOME)
					.setProperty(modeloFiltroGenero, indiceGenero);
			}
		},

		obterData: function(Data) {
			const modeloFormatacaoData = "yyyy-MM-dd";
            return Formatador.formatarData(Data, modeloFormatacaoData);
		},
		
		obterDisponivel: function(Disponivel) {
			let chaveI18n = Formatador.formatarDisponivel(Disponivel);
			return this.retornarTextoI18nCorrespondente(chaveI18n);
		},

		aoPerderFocoBarraDePesquisa: function(event){
			const modeloFiltroTitulo = "/titulo";
			const eventoPropriedadeValue = "value";

			let query = event.getParameter(eventoPropriedadeValue);
			this
				.getView()
				.getModel(MODELO_FILTRO_NOME)
				.setProperty(modeloFiltroTitulo, query);
		},

		aoClicarEmFiltrar: async function() {
			const comboBoxFiltroGeneroId = "filtroGenero";
			const urlComponenteGeneroAcrescido = "&FiltroGenero=";
			const urlComponenteGenero = "FiltroGenero=";
			const urlComponenteTitulo = "FiltroTitulo=";

            this.processarAcao(() => {
                let view = this.getView();
				let modeloFiltro = view.getModel(MODELO_FILTRO_NOME).getData();
				let titulo = modeloFiltro.titulo;

				let generoNome = this.byId(comboBoxFiltroGeneroId).mProperties.value;
				let generoIndice = this._obterIndiceGenero(generoNome);

                let filtros = STRING_VAZIA;

                filtros = titulo.length == INDICE_ZERO
					? filtros + STRING_VAZIA
					: urlComponenteTitulo + titulo;

                filtros = generoIndice == undefined
					? filtros + STRING_VAZIA
					: (filtros.length == INDICE_ZERO ? filtros + urlComponenteGenero + generoIndice: filtros + urlComponenteGeneroAcrescido + generoIndice);

                Repositorio.carregarDadosFilme(filtros, view);
            });
        },
	
		aoClicarEmCadastrar: function(){
			const rotaCadastro = "CadastroDeFilmes"
            return this.irParaRotaCorrespondente(rotaCadastro);
		},

		aoSelecionarLinha: function(event){
			const rotaDetalhes = "DetalhesDeFilmes"
			let idFilme = event.getParameters().rowBindingContext.getObject().id;
			return this.irParaRotaCorrespondente(rotaDetalhes, idFilme);
		}
	});
});