sap.ui.define([
    "sap/ui/core/format/DateFormat",
	"cod3rsgrowth/app/controller/BaseController",
], function (DateFormat, BaseController) {
    "use strict";
 
	const MODELO_CLASSIFICACOES_NOME = "Classificacoes";
	const INDICE_NULO = 0;
	const CHAVE_I18N_DISPONIVEL = "Formatador.Disponivel";
	const CHAVE_I18N_INDISPONIVEL = "Formatador.Indisponivel";
	const MODELO_GENEROS = "Generos";

    return  {
        formatarDisponivel: function(Disponivel) {
			let valorFormatado = CHAVE_I18N_INDISPONIVEL;
			if(Disponivel){
				valorFormatado = CHAVE_I18N_DISPONIVEL;
			}
			return valorFormatado;
		},

        formatarData: function(Data, Formato) {
            let dataFormato = DateFormat.getDateInstance({pattern: Formato});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

        formatarClassificacao: function(indiceClassificacao){
			let indice = indiceClassificacao;
			if(!indiceClassificacao){
				indice = INDICE_NULO;
			}
			let classificacao = this.getView().getModel(MODELO_CLASSIFICACOES_NOME).getData();
			return classificacao[indice].descricao;
		},

        formatarGenero: function(indiceGenero){
			let indice = indiceGenero;
			if(!indiceGenero){
				indice = INDICE_NULO;
			}
			let genero = this.getView().getModel(MODELO_GENEROS).getData();
			return genero[indice].descricao;
		},
    }
});