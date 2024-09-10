sap.ui.define([
    "sap/ui/core/format/DateFormat",
	"cod3rsgrowth/app/controller/BaseController"
], function (DateFormat, BaseController) {
    "use strict";
 
	const MODELO_CLASSIFICACOES_NOME = "Classificacoes";
	const INDICE_NULO = 0;
	const CHAVE_I18N_DISPONIVEL = "Formatador.Disponivel";
	const CHAVE_I18N_INDISPONIVEL = "Formatador.Indisponivel";
	const MODELO_FORMATACAO_DATA = "yyyy-MM-dd";
	const MODELO_GENEROS = "Generos";

    return  {
        formatarDisponivel: function(Disponivel) {
			let valorFormatado = CHAVE_I18N_INDISPONIVEL;
			if(Disponivel){
				valorFormatado = CHAVE_I18N_DISPONIVEL;
			}
			return valorFormatado;
		},

        formatarData: function(Data) {
            let dataFormato = DateFormat.getDateInstance({pattern: MODELO_FORMATACAO_DATA});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

        formatarClassificacao: function(indiceClassificacao, view){
			let indice = indiceClassificacao;
			if(!indiceClassificacao){
				indice = INDICE_NULO;
			}
			let classificacao = view.getModel(MODELO_CLASSIFICACOES_NOME).getData();
			return classificacao[indice].descricao;
		},

        formatarGenero: function(GeneroIndice, view){
			let indice = GeneroIndice;
			if(!GeneroIndice){
				indice = INDICE_NULO;
			}
			let genero = view.getModel(MODELO_GENEROS).getData();
			return genero[indice].descricao;
		},
    }
});