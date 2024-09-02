sap.ui.define([
	"sap/base/Log",
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/ui/core/format/DateFormat",
	"sap/ui/thirdparty/jquery",
	"sap/ui/core/date/UI5Date"
], function(Log, Controller, JSONModel, MessageToast, DateFormat, jQuery, UI5Date) {
	"use strict";

	var oGeneroMap = {
		0: "Ficção Científica",
		1: "Ação",
		2: "Terror",
		3: "Romance",
		4: "Drama",
		5: "Aventura",
		6: "Comédia",
		7: "Fantasia"
	};
	
	var oClassificacaoMap = {
		0: "Livre",
		1: "10 anos",
		2: "12 anos",
		3: "14 anos",
		4: "16 anos",
		5: "18 anos"
	};

	return Controller.extend("cod3rsgrowth.app.controller.ListaDeFilmes", {

		ajustarData(data){
			// const oDateFormat = DateFormat.getDateInstance({source: {pattern: "timestamp"}, pattern: "dd/MM/yyyy"});
			// const oProduct = data.ProductCollection[i];

			//--> Implementar um metodo para formatar os dados Json <--
		},

		obterGenero(Genero) {
			return oGeneroMap[Genero];
		},
		
		obterClassificacao(Classificacao) {
			return oClassificacaoMap[Classificacao];
		},

		formatarData(Data) {
            if (!Data) {
                return null;
            }

            var dataFormato = DateFormat.getDateInstance({pattern: "yyyy-MM-dd"});
            var oData = new Date(Data); // Converte string para objeto Date

            return dataFormato.format(oData); // Formata a data para o formato "yyyy-MM-dd"
		}	
	});
});