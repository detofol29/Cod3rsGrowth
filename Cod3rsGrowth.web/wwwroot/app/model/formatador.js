sap.ui.define([
    "sap/ui/core/format/DateFormat",
	"cod3rsgrowth/app/controller/BaseController",
], function (DateFormat, BaseController) {
    "use strict";
 
	const INDICE_NULO = 0;

    return  {
        formatarDisponivel: function(Disponivel) {
			const chaveI18nDisponivel = "Formatador.Disponivel";
			const chaveI18nIndisponivel = "Formatador.Indisponivel";

			let valorFormatado = chaveI18nIndisponivel;
			if(Disponivel){
				valorFormatado = chaveI18nDisponivel;
			}
			return valorFormatado;
		},

        formatarData: function(Data) {
			const modeloFormatacaoData = "dd/MM/yyyy";

            let dataFormato = DateFormat.getDateInstance({pattern: modeloFormatacaoData});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

        formatarClassificacao: function(indiceClassificacao){
			const modeloClassificacoesNome = "Classificacoes";

			let indice = indiceClassificacao;
			if(!indiceClassificacao){
				indice = INDICE_NULO;
			}
			let classificacao = this.getView().getModel(modeloClassificacoesNome).getData();
			return classificacao[indice].descricao;
		},

        formatarGenero: function(indiceGenero){
			const modeloGeneros = "Generos";

			let indice = indiceGenero;
			if(!indiceGenero){
				indice = INDICE_NULO;
			}
			let genero = this.getView().getModel(modeloGeneros).getData();
			return genero[indice].descricao;
		},
    }
});