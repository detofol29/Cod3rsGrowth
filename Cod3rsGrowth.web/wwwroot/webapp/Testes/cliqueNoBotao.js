sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/opaQUnit",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "./pages/App"
], (opaQUnit) => {
    "use strict";

    opaQUnit("Ao pressionar o botão", (Given, When, Then) => {

        Given.euInicioMeuApp();
        When.EuClicoNoBotao();
        Then.oBotaoDeveTerOTextoAlterado();
    });
});