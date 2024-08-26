sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/App"
  ],(opaQUnit) => {
    "use strict";

    QUnit.module("Botao");
    opaQUnit("Ao clicar no botão deve mudar o texto", function (Given, When, Then) {
          
          Given.iStartMyUIComponent({
            componentConfig: {
                name: "cod3rsgrowth"
            }
        });
        When.onTheAppPage.EuClicoNoBotao();

        Then.onTheAppPage.oBotaoDeveApresentarUmTextoDiferente();
    });
});