sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/NotFound"
], function(opaQUnit) {
    "use strict";

    QUnit.module("Página NotFound");

    const PROJETO_NOME = "cod3rsgrowth";
    const CHAVE_I18N_NOTFOUND_TITULO = "NotFound.Titulo";
    const CHAVE_I18N_NOTFOUND_TEXTO = "NotFound.Texto";
    const CHAVE_I18N_NOTFOUND_DESCRICAO = "NotFound.Descricao";
    const HASH_NOTFOUND = "/#/i";

    opaQUnit("Testes da tela de NotFound",(Given, When, Then) => {
          
      Given
        .iStartMyUIComponent({
        componentConfig: {
            name: PROJETO_NOME
        },
        hash: HASH_NOTFOUND
        });
      Then
        .naPaginaNotFound
        .aTelaFoiCarregadaCorretamente();
      Then
        .naPaginaNotFound
        .oTituloDeveSerIgualAoComChaveI18nCorrespondente(CHAVE_I18N_NOTFOUND_TITULO);
      Then
        .naPaginaNotFound
        .oTextoDeveSerIgualAoComChaveI18nCorrespondente(CHAVE_I18N_NOTFOUND_TEXTO);
      Then
        .naPaginaNotFound
        .aDescricaoDeveSerIgualAoComChaveI18nCorrespondente(CHAVE_I18N_NOTFOUND_DESCRICAO);
      Then
        .iTeardownMyApp();
    });
});