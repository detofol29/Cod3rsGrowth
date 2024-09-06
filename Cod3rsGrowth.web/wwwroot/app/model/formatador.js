sap.ui.define([
    "sap/ui/model/json/JSONModel"
], function (JSONModel) {
    "use strict";
 
    return {
        formatarData(Data) {
            let dataFormato = DateFormat.getDateInstance({pattern: "yyyy-MM-dd"});
            let oData = new Date(Data);
            return dataFormato.format(oData);
		},

        formatarDisponivel(Disponivel) {
			let valorFormatado = "Não";
			if(Disponivel){
				valorFormatado = "Sim";
			}
			return valorFormatado;
		},

        formatarClassificacao(indiceClassificacao, view){
			let classificacao = view.getModel("Classificacoes").getData();
			return classificacao[indiceClassificacao].descricao;
		},
    }
});