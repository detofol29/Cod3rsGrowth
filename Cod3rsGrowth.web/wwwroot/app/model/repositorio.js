sap.ui.define([
    "sap/ui/model/json/JSONModel"
], function (JSONModel) {
    "use strict";
 
    const STRING_VAZIA = "";
    const URL_RETORNO_ENUNS_GENERO = "http://localhost:5152/api/Enum";
    const URL_RETORNO_ENUNS_CLASSIFICACOES = "http://localhost:5152/api/Enum/classificacao";
    const URL_RETORNO_CRIAR_FILME = "http://localhost:5152/api/Filme";
    const MODELO_GENEROS_NOME = "Generos";
    const MODELO_CLASSIFICACOES_NOME = "Classificacoes";
    const MODELO_FILTRO_NOME = "modeloFiltro";

    return {

        carregarDadosFilme: async function(filtros, view) {
            const urlComponenteApi = "/api/";
            const nomeRota = "Filme";
            const urlComponenteFiltrosOperador = "?";
            const nomeModelo = "filme";
            
            const urlPagina = window.location.origin;
            const url = urlPagina + urlComponenteApi + nomeRota;
            const urlFiltro = urlPagina + urlComponenteApi + nomeRota + urlComponenteFiltrosOperador + filtros;

            if (filtros == STRING_VAZIA) {
                await fetch(url)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), nomeModelo));
            } 
            else {
                await fetch(urlFiltro)
                    .then(requisicao => requisicao.json())
                    .then(dados => view.setModel(new JSONModel(dados), nomeModelo));
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
            const metodoDeRequisicaoPost = 'POST';

            let resposta = await fetch(URL_RETORNO_CRIAR_FILME, {
                method: metodoDeRequisicaoPost,
                headers: { 'Content-Type': 'application/json' },
                body: modeloJson
            });

            if(!resposta.ok){
                return resposta.json();
            }

            return resposta;
        },

        editar: async function(modeloJson){
            const metodoDeRequisicaoPatch = 'PATCH';

            let resposta = await fetch(URL_RETORNO_CRIAR_FILME, {
                method: metodoDeRequisicaoPatch,
                headers: { 'Content-Type': 'application/json' },
                body: modeloJson
            });

            if(!resposta.ok){
                return resposta.json();
            }
            return resposta;
        },

        obterPorId: async function(view, idFilme, nomeModelo){
            const urlConectivo = "/";
            let url = URL_RETORNO_CRIAR_FILME + urlConectivo + idFilme.toString();
            await fetch(url)
            .then(requisicao => requisicao.json())
            .then(dados => view.setModel(new JSONModel(dados), nomeModelo));
        },

        remover: async function(id){
            const urlConectivo = "/";
            const urlRequisicao = URL_RETORNO_CRIAR_FILME + urlConectivo + id;
            const metodoDeRequisicaoDelete = 'DELETE';

            let resposta = await fetch(urlRequisicao, {
                method: metodoDeRequisicaoDelete,
                headers: { 'Content-Type': 'application/json' }
            });

            if(!resposta.ok){
                return resposta.json();
            }

            return resposta;
        }
    }
});