sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/App"
],(opaQUnit) => {
    "use strict";

    QUnit.module("Página App Principal");
    opaQUnit("Ao clicar no botão o texo deve ser alterado",(Given, When, Then) => {
          
      Given
        .iStartMyUIComponent({
          componentConfig: {
            name: "cod3rsgrowth"
          }
        });
      Then
        .naPaginaDoApp
        .aTelaFoiCarregadaCorretamente();
      Then
        .naPaginaDoApp
        .oBotaoDeveApresentarTextoInicialComChaveI18nCorrespondente("Botao.TextoInicial");
      When
        .naPaginaDoApp
        .VerificarCliqueNoBotaoDeTeste();
      Then
        .naPaginaDoApp
        .oBotaoDeveApresentarTextoFinalComChaveI18nCorrespondente("Botao.TextoClicado");
    });
});