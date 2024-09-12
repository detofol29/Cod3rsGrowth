sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/CadastroDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página cadastro de filmes");

    const PROJETO_NOME = "cod3rsgrowth";
    const HASH = "CadastroDeFilmes";

    opaQUnit("Carregar tela de cadastro",(Given, When, Then) => {
      
        Given
        .iStartMyUIComponent({
        componentConfig: {
            name: PROJETO_NOME
        },
        hash: HASH
        });

        Then
        .noCadastroDeFilmes
        .aTelaFoiCarregadaCorretamente();
    });
});