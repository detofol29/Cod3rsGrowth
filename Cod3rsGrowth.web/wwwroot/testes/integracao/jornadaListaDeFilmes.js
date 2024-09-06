sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/ListaDeFilmes"
  ],(opaQUnit) => {
    "use strict";
  
    QUnit.module("Pagina lista de filmes");
    opaQUnit("Carregar tela de lista",(Given, When, Then) => {
          
      Given
        .iStartMyUIComponent({
          componentConfig: {
            name: "cod3rsgrowth"
          }
        });
      Then
        .naListaDeFilmes
        .aTelaFoiCarregadaCorretamente();
        
      When
          .naListaDeFilmes
          .aoClicarComboBox();
      When
        .naListaDeFilmes
        .aoClicarGenero();


      When 
        .naListaDeFilmes
        .aoClicarBotaoFiltro();

      Then
        .naListaDeFilmes
        .aTabelaDevePossuirAQuantidadeDeElementos(6);
    });

    opaQUnit("Filtrar por genero",(Given, When, Then) => {
          
        Given
          .iStartMyUIComponent({
            componentConfig: {
              name: "cod3rsgrowth"
            }
          });

        When
          .naListaDeFilmes
          .aoSelecionarGenero();

        When 
          .naListaDeFilmes
          .aoClicarBotaoFiltro();
        Then
          .naListaDeFilmes
          .aTabelaDevePossuirAQuantidadeDeElementos(6);
      });
  });