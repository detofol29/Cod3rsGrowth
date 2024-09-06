sap.ui.define([
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/format/DateFormat",
], function (JSONModel, DateFormat) {
    "use strict";
 
    return {
        formatarDisponivel(Disponivel) {
			let valorFormatado = "Não";
			if(Disponivel){
				valorFormatado = "Sim";
			}
			return valorFormatado;
		},

        formatarData(Data) {
            let dataFormato = DateFormat.getDateInstance({pattern: "yyyy-MM-dd"});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

        formatarClassificacao(indiceClassificacao, view){
			let indiceNulo = 0;
			let indice = indiceClassificacao;
			if(!indiceClassificacao){
				indice = indiceNulo;
			}
			let classificacao = view.getModel("Classificacoes").getData();
			return classificacao[indice].descricao;
		},

        formatarGenero(GeneroIndice, view){
			let indiceNulo = 0;
			let indice = GeneroIndice;
			if(!GeneroIndice){
				indice = indiceNulo;
			}
			let genero = view.getModel("Generos").getData();
			return genero[indice].descricao;
		},
    }
});