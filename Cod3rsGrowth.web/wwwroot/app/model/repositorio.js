sap.ui.define([
    "sap/ui/model/json/JSONModel"
], function (JSONModel) {
    "use strict";
 
    const NOME_MODELO = "filme"
    const NOME_ROTA = "Filme"
    return {

        async carregarDadosFilme(filtros, view) {
            const urlPagina = window.location.origin;
            const url = urlPagina + "/api/" + NOME_ROTA;
            const urlFiltro = urlPagina + "/api/" + NOME_ROTA + "?" + filtros;

            if (filtros == "") {
                await fetch(url)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), NOME_MODELO));
            } 
            else {
                await fetch(urlFiltro)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), NOME_MODELO));
            }
        },
 
        async obterEnumGenero(view){
            await fetch ("http://localhost:5152/api/Enum")
                .then((res) => res.json())
                .then(dados => view.setModel(new JSONModel(dados), "Generos"))
        },
 
        async obterEnumClassificacao(view){
            await fetch ("http://localhost:5152/api/Enum/classificacao")
                .then((res) => res.json())
                .then((res) => view.setModel(new JSONModel(res), "Classificacoes"))
        }
    }
});