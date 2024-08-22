sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/App"
  ], function (opaQUnit) {
    "use strict";

    opaQUnit("Ao clicar no botão deve mudar o texto", function (Given, When, Then) {
          // Arrangements
          Given.iStartMyUIComponent({
            componentConfig: {
                name: "ui5.walkthrough"
            }
        });
          //Actions
        When.onTheAppPage.EuClicoNoBotao();
          // Assertions
        Then.onTheAppPage.oBotaoDeveApresentarUmTextoDiferente();
    });
});