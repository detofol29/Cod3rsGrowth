sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/ListaDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página lista de filmes");

    const QUANTIDADE_DE_FILMES_ESPERADA_NA_PESQUISA_POR_GENERO = 8;
    const QUANTIDADE_DE_FILMES_TOTAL_ESPERADA = 37;
    const QUANTIDADE_DE_FILMES_ESPERADA_NA_PESQUISA_POR_NOME = 3;
    const CHAVE_I18N_ESPERADA = "ListaDeFilmes.Titulo";
    const TITULO_FILME = "Carros";
    const PROJETO_NOME = "cod3rsgrowth";
    const HASH_LISTA = "ListaDeFilmes"

    opaQUnit("Carregar tela de lista",(Given, When, Then) => {
      
      Given
        .iStartMyUIComponent({
          componentConfig: {
            name: PROJETO_NOME
          },
        });
      Then
        .naListaDeFilmes
        .aTelaFoiCarregadaCorretamente();
        
      Then
        .naListaDeFilmes
        .oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente(CHAVE_I18N_ESPERADA);

      When
        .naListaDeFilmes
        .aoClicarGenero();

      When 
        .naListaDeFilmes
        .aoClicarBotaoFiltro();

      Then
        .naListaDeFilmes
        .aTabelaDevePossuirAQuantidadeDeElementos(QUANTIDADE_DE_FILMES_ESPERADA_NA_PESQUISA_POR_GENERO);

      When
        .naListaDeFilmes
        .aoRemoverFiltrosGenero();
      
      When 
        .naListaDeFilmes
        .aoClicarBotaoFiltro();

      Then
        .naListaDeFilmes
        .aTabelaDevePossuirAQuantidadeDeElementos(QUANTIDADE_DE_FILMES_TOTAL_ESPERADA);

      When
        .naListaDeFilmes
        .aoAdicionarTituloDoFilmeCorrespondenteNaBarraDePesquisa(TITULO_FILME);
      
      When 
        .naListaDeFilmes
        .aoClicarBotaoFiltro();
      
      Then
        .naListaDeFilmes
        .aTabelaDevePossuirAQuantidadeDeElementos(QUANTIDADE_DE_FILMES_ESPERADA_NA_PESQUISA_POR_NOME);
    });
});