sap.ui.define([
	"../localService/mockserver"
], (mockserver) => {
	"use strict";

	mockserver.init();

	sap.ui.require(["sap/ui/core/ComponentSupport"]);
});