sap.ui.define([
    "sap/ui/core/format/DateFormat"
], function (DateFormat) {
    "use strict";
 
	const MODELO_CLASSIFICACOES_NOME = "Classificacoes";
	const INDICE_NULO = 0;

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
			let indice = indiceClassificacao;
			if(!indiceClassificacao){
				indice = INDICE_NULO;
			}
			let classificacao = view.getModel(MODELO_CLASSIFICACOES_NOME).getData();
			return classificacao[indice].descricao;
		},

        formatarGenero(GeneroIndice, view){
			let indice = GeneroIndice;
			if(!GeneroIndice){
				indice = INDICE_NULO;
			}
			let genero = view.getModel("Generos").getData();
			return genero[indice].descricao;
		},
    }
});