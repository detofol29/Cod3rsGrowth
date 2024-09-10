sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador"
], function(BaseController, JSONModel, Repositorio, Formatador) {
	"use strict";

	const STRING_VAZIA = "";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.CadastroDeFilmes";
    const ROTA_CADASTRO = "CadastroDeFilmes";

	return BaseController.extend(ROTA_CONTROLLER, {

		onInit: function() {			
            this
			.getRouter()
			.getRoute(ROTA_CADASTRO)
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

        aoClicarEmCadastrar: function(event){
            //debugger
            let view = this.getView();
            let titulo = view.byId("tituloFilmeInput")._lastValue;
            let genero = view.byId("generoFilmeInput")._lastValue;
            let data = view.byId("dataDeLancamentoInput")._lastValue;
            let diretor = view.byId("diretorFilmeInput")._lastValue;
            let classificacao = view.byId("classificacaoFilmeInput")._lastValue;
            let nota = view.byId("notaFilmeInput")._lastValue;
            let duracao = view.byId("duracaoFilmeInput")._lastValue;

            let ModeloFilme = new JSONModel({titulo: titulo, dataDeLancamento: data, genero: genero, emCartaz: false, nota: nota, duracao: duracao, disponivelNoPlano: false, diretor: diretor, classificacao: classificacao, atores: null});
            view.setModel(ModeloFilme, "FilmeCadastrado");

            window.alert(ModeloFilme.getJSON());
        }

	});
});