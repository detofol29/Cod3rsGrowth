sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/App"
],(opaQUnit) => {
    "use strict";

    QUnit.module("Pagina App Principal"); ///////
    opaQUnit("Ao clicar no botão deve mudar o texto", function (Given, When, Then) {
          
      Given
        .iStartMyUIComponent({
          componentConfig: {
            name: "cod3rsgrowth"
          }
        });
      Then
        .naPaginaDoApp
        .aTelaFoiCarregadaCorretamente();
      // Then
      //   .naPaginaDoApp
      //   .oBotaoDeveApresentarTextoCorrespondentePrimeiro("Botao.TextoInicial");
      When
        .naPaginaDoApp
        .VerificarCliqueNoBotaoDeTeste();
      Then
        .naPaginaDoApp
        .oBotaoDeveApresentarTextoCorrespondenteSegundo("Botão clicado!");
    });
});