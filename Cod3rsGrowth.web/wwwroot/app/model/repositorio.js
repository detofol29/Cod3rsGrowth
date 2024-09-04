sap.ui.define([
    "sap/ui/model/json/JSONModel",
], (JSONModel)  => {
    "use stricts";

    return {

        obterFilmes(){
            fetch('http://localhost:5152/api/Filme')
			    .then(resposta => resposta.json())
			    .then(dadosBanco => this.getview().setModel(new JSONModel({ "filme": dadosBanco })));
        },

        obterGeneros(){
            fetch('http://localhost:5152/api/Enum')
                .then(resposta => resposta.json())
                .then(dadosBanco => oView.setModel(new JSONModel({ "Generos": dadosBanco })));
        }
    }
});