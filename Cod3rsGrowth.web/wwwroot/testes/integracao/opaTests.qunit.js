QUnit.config.autostart = false;

sap.ui.require(["sap/ui/core/Core"], async(Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"cod3rsgrowth/testes/integracao/todasJornadas"
	], () => {
		QUnit.start();
	});
});