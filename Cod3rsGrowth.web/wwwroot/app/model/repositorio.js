sap.ui.define([
    "sap/ui/model/json/JSONModel"
], function (JSONModel) {
    "use strict";
 
    const nomeDoModelo = "filme"
    const nomeRota = "Filme"
    //titulo=Carros
    return {
        carregarDadosFilme: async function (filtros, view) {
            const urlPagina = window.location.origin;
            const url = urlPagina + "/api/" + nomeRota;
            const urlFiltro = urlPagina + "/api/" + nomeRota + "?" + filtros;
            if (filtros == "") {
                await fetch(url)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), nomeDoModelo))
            } else {
                await fetch(urlFiltro)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), nomeDoModelo))
            }
        },
 
        obterEnumGenero: async function(view){
            await fetch ("http://localhost:5152/api/Enum")
                .then((res) => res.json())
                .then(dados => view.setModel(new JSONModel(dados), "Generos"))
        },
 
        obterEnumClassificacao: async function(view){
            await fetch ("http://localhost:5152/api/Enum/classificacao")
                .then((res) => res.json())
                .then((res) => view.setModel(new JSONModel(res), "Classificacoes"))
        }
    }});