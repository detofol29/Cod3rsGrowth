sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/NotFound"
],(opaQUnit) => {
    "use strict";

    QUnit.module("Página NotFound");
    opaQUnit("Testes da tela de NotFound",(Given, When, Then) => {
          
      Given
        .iStartMyUIComponent({
        componentConfig: {
            name: "cod3rsgrowth"
        },
        hash: "/#/i"
        });
      Then
        .naPaginaNotFound
        .aTelaFoiCarregadaCorretamente();
      Then
        .naPaginaNotFound
        .oTituloDeveSerIgualAoComChaveI18nCorrespondente("NotFound.Titulo");
      Then
        .naPaginaNotFound
        .oTextoDeveSerIgualAoComChaveI18nCorrespondente("NotFound.Texto");
      Then
        .naPaginaNotFound
        .aDescricaoDeveSerIgualAoComChaveI18nCorrespondente("NotFound.Descricao");
      Then
        .iTeardownMyApp();
    });
});