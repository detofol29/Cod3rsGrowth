QUnit.config.autostart = false;

sap.ui.require(["sap/ui/core/Core"], async function(Core) {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"cod3rsgrowth/testes/integracao/todasJornadas"
	], function() {
		QUnit.start();
	});
});