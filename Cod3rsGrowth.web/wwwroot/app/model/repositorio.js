sap.ui.define([
    "sap/ui/model/json/JSONModel"
], function (JSONModel) {
    "use strict";
 
    const STRING_VAZIA = "";
    const NOME_MODELO = "filme"
    const NOME_ROTA = "Filme"
    const URL_COMPONENTE_API = "/api/";
    const URL_COMPONENTE_FILTROS_OPERADOR = "?";
    const URL_RETORNO_ENUNS_GENERO = "http://localhost:5152/api/Enum";
    const URL_RETORNO_ENUNS_CLASSIFICACOES = "http://localhost:5152/api/Enum/classificacao";
    const URL_RETORNO_CRIAR_FILME = "http://localhost:5152/api/Filme";
    const MODELO_GENEROS_NOME = "Generos";
    const MODELO_CLASSIFICACOES_NOME = "Classificacoes";
    const MODELO_FILTRO_NOME = "modeloFiltro";
    const METODO_DE_REQUISICAO_POST = 'POST';
    const NOME_MODELO_DETALHE = "filmeDetalhe";

    return {

        carregarDadosFilme: async function(filtros, view) {
            const urlPagina = window.location.origin;
            const url = urlPagina + URL_COMPONENTE_API + NOME_ROTA;
            const urlFiltro = urlPagina + URL_COMPONENTE_API + NOME_ROTA + URL_COMPONENTE_FILTROS_OPERADOR + filtros;

            if (filtros == STRING_VAZIA) {
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
 
        obterEnumGenero: async function(view){
            await fetch (URL_RETORNO_ENUNS_GENERO)
                .then((res) => res.json())
                .then(dados => view.setModel(new JSONModel(dados), MODELO_GENEROS_NOME));
        },
 
        obterEnumClassificacao: async function(view){
            await fetch (URL_RETORNO_ENUNS_CLASSIFICACOES)
                .then((res) => res.json())
                .then((res) => view.setModel(new JSONModel(res), MODELO_CLASSIFICACOES_NOME));
        },

        obterModeloFiltro: async function(view){
            let modeloFiltro = new JSONModel({genero: STRING_VAZIA, titulo: STRING_VAZIA});
            view.setModel(modeloFiltro, MODELO_FILTRO_NOME);
        },

        cadastrarFilme: async function(modeloJson){
            let resposta = await fetch(URL_RETORNO_CRIAR_FILME, {
                method: METODO_DE_REQUISICAO_POST,
                headers: { 'Content-Type': 'application/json' },
                body: modeloJson
            });
            if(!resposta.ok){
                return resposta.json();
            }
            return resposta;
        },

        obterPorId: async function(view, idFilme){
            let url = URL_RETORNO_CRIAR_FILME + "/" + idFilme.toString();
            await fetch(url)
            .then(requisicao => requisicao.json())
            .then(dados => view.setModel(new JSONModel(dados), NOME_MODELO_DETALHE));
        }
    }
});