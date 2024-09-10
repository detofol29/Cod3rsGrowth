sap.ui.define([
  "sap/ui/test/opaQunit",
  "cod3rsgrowth/testes/integracao/pages/App"
],function(opaQUnit) {
  "use strict";

  QUnit.module("Página App Principal");
  const CHAVE_I18N_BOTAO_TEXTO_INICIAL = "Botao.TextoInicial";
  const CHAVE_I18N_BOTAO_TEXTO_FINAL = "Botao.TextoClicado";
  const PROJETO_NOME = "cod3rsgrowth";

  opaQUnit("Ao clicar no botão o texo deve ser alterado",(Given, When, Then) => {
        
    Given
      .iStartMyUIComponent({
        componentConfig: {
          name: PROJETO_NOME
        }
      });
    Then
      .naPaginaDoApp
      .aTelaFoiCarregadaCorretamente();
    Then
      .naPaginaDoApp
      .oBotaoDeveApresentarTextoInicialComChaveI18nCorrespondente(CHAVE_I18N_BOTAO_TEXTO_INICIAL);
    When
      .naPaginaDoApp
      .VerificarCliqueNoBotaoDeTeste();
    Then
      .naPaginaDoApp
      .oBotaoDeveApresentarTextoFinalComChaveI18nCorrespondente(CHAVE_I18N_BOTAO_TEXTO_FINAL);
    Then
      .iTeardownMyApp();
  });
});