sap.ui.define([
	"cod3rsgrowth/app/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"cod3rsgrowth/app/model/repositorio",
	"cod3rsgrowth/app/model/formatador",
    "sap/m/MessageBox"
], function(BaseController, JSONModel, Repositorio, Formatador, MessageBox) {
	"use strict";

	const STRING_VAZIA = "";
	const ROTA_CONTROLLER = "cod3rsgrowth.app.controller.CadastroDeFilmes";
    const ROTA_CADASTRO = "CadastroDeFilmes";
    const MODELO_FORMATACAO_DATA = "yyyy-MM-dd";
    const MODELO_GENEROS_NOME = "Generos";
	const MODELO_CLASSIFICACAO_NOME = "Classificacoes";
    const INDICE_ZERO = 0;
    const SALTO_DE_LINHA = "\n";


	return BaseController.extend(ROTA_CONTROLLER, {

		onInit: function() {			
            this
			.getRouter()
			.getRoute(ROTA_CADASTRO)
			.attachPatternMatched(async () => {
				return this._aoCoincidirRota();
			}, this);
		},

        _aoCoincidirRota: function() {
            let view = this.getView();
            this.processarAcao(async () => {
                await Promise.all([
                    Repositorio.carregarDadosFilme(STRING_VAZIA, view),
                    Repositorio.obterEnumGenero(view),
                    Repositorio.obterEnumClassificacao(view),
					Repositorio.obterModeloFiltro(view)
                ]);
            });
        },

        _obterIndiceGenero: function(Genero){
			let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
			for (let i = INDICE_ZERO; i < generos.length; i++) {
				if(generos[i].descricao == Genero){
					return i;
				}
			}
		},

        _obterIndiceClassificacao: function(Classificacao){
			let classificacoes = this.getView().getModel(MODELO_CLASSIFICACAO_NOME).getData();
			for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
				if(classificacoes[i].descricao == Classificacao){
					return i;
				}
			}
		},
        //VALIDADORES

        _validarGenero: function() {
            //debugger
            let view = this.getView();
            let inputGenero = view.byId("generoFilmeInput");
            if(inputGenero._lastValue.length == INDICE_ZERO){
                //inputGenero.mProperties.valueState = "Error";
                return "O campo genero nao pode estar vazio!"
            }

            let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
            for (let i = INDICE_ZERO; i < generos.length; i++) {
                if(generos[i].descricao == inputGenero._lastValue){
                    //inputGenero.mProperties.valueState = "None"
                    return true
                }
            }
            inputGenero.mProperties.valueState = "None"
            return "Selecione um genero valido";
        },

        _validarClassificacao: function(){
            let view = this.getView();
            let inputClassificacao = view.byId("classificacaoFilmeInput");
            if(inputClassificacao._lastValue.length == INDICE_ZERO){
                //inputClassificacao.mProperties.valueState = "Error";
                return "O campo Classificacao nao pode estar vazio!"
            }

            let classificacoes = this.getView().getModel(MODELO_CLASSIFICACAO_NOME).getData();
            for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
                if(classificacoes[i].descricao == inputClassificacao._lastValue){
                    //inputClassificacao.mProperties.valueState = "None"
                    return true
                }
            }
            inputClassificacao.mProperties.valueState = "None"
            return "Selecione uma classificacao valida!";
        },

        _validarTitulo: function(){
            let view = this.getView();
            let inputTitulo = view.byId("tituloFilmeInput");
            if(inputTitulo._lastValue.length == INDICE_ZERO){
                //inputTitulo.mProperties.valueState = "Error";
                return "O campo Titulo nao pode estar vazio!";
            }
            return true;
        },

        _validarDiretor: function(){
            let view = this.getView();
            let inputDiretor = view.byId("diretorFilmeInput");
            if(inputDiretor._lastValue.length == INDICE_ZERO){

                return "O campo Diretor nao pode estar vazio!";
            }
            for (let i = 0; i < 9; i++) {
                if(inputDiretor._lastValue.includes(i.toString())){
                    return "O campo Diretor nao pode conter numeros";
                }
            }
            return true;
        },

        _validarNota: function(){
            let view = this.getView();
            let inputNota = view.byId("notaFilmeInput");
            let notaConvertida = inputNota._lastValue;
            if(inputNota._lastValue.length == INDICE_ZERO){
                return "O campo nota nao pode estar vazio!"
            }
            if(notaConvertida > 10 || notaConvertida < 0){
                return "Nota invalida";
            }
            return true;
        },

        _validarDuracao: function(){
            let view = this.getView();
            let inputDuracao = view.byId("duracaoFilmeInput");
            let duracao = inputDuracao._lastValue;
            if(inputDuracao._lastValue.length == INDICE_ZERO){
                return "O campo Duracao nao pode estar vazio!"
            }

            if(duracao < 1 || duracao > 1000){
                return "A duracao deve estar no intervalo entre 1 e 1000 minutos!";
            }

            return true;
        },

        _validarTodos: function(){

            let generoValidado = this._validarGenero();
            let tituloValidado = this. _validarTitulo();
            let diretorValidado = this._validarDiretor();
            let notaValidada = this._validarNota();
            let duracaoValidada = this._validarDuracao();
            let classificacaoValidada = this._validarClassificacao();
            let dataValidada = this._validarData();

            let ErrosDeValidacao = tituloValidado == true 
            ? STRING_VAZIA 
            : tituloValidado + SALTO_DE_LINHA;

            ErrosDeValidacao += generoValidado == true 
            ? STRING_VAZIA 
            : generoValidado + SALTO_DE_LINHA;

            ErrosDeValidacao += dataValidada == true 
            ? STRING_VAZIA 
            : dataValidada + SALTO_DE_LINHA;

            ErrosDeValidacao += diretorValidado == true 
            ? STRING_VAZIA 
            : diretorValidado + SALTO_DE_LINHA;

            ErrosDeValidacao += classificacaoValidada == true 
            ? STRING_VAZIA 
            : classificacaoValidada + SALTO_DE_LINHA;

            ErrosDeValidacao += notaValidada == true 
            ? STRING_VAZIA 
            : notaValidada + SALTO_DE_LINHA;

            ErrosDeValidacao += duracaoValidada == true 
            ? STRING_VAZIA 
            : duracaoValidada + SALTO_DE_LINHA;
            
            if(ErrosDeValidacao.length == INDICE_ZERO){
                return true;
            }
            return ErrosDeValidacao;
        },

        _validarData: function(){
            let view = this.getView();
            let inputData = view.byId("dataDeLancamentoInput");
            let data = inputData.getDateValue();
            if(inputData.getValue().length == INDICE_ZERO){
                return "O campo Data nao pode estar vazio!"
            }
            let dataAtual = new Date();
            let dataFilme = new Date(data);
            let dataLimite = new Date('12 28 1895');
            //debugger
            if(dataFilme.getTime() > dataAtual.getTime()){
                return "A data de lancamento nao pode ser superior a data atual!";
            }

            if(dataFilme.getTime() < dataLimite.getTime()){
                return "A data de lancamento nao pode ser inferior a data do primeiro filme!";
            }

            return true;
        },

        //FIM VALIDADORES

        aoClicarEmCadastrar: async function(event){
            let view = this.getView();
            let validacaoDeEntradas = this._validarTodos();
            if(validacaoDeEntradas != true){
                return MessageBox.alert(validacaoDeEntradas);
            }

            let titulo = view.byId("tituloFilmeInput")._lastValue;
            let diretor = view.byId("diretorFilmeInput")._lastValue;
            let genero = view.byId("generoFilmeInput")._lastValue;
            let data = view.byId("dataDeLancamentoInput").getDateValue();
            let classificacao = view.byId("classificacaoFilmeInput")._lastValue;
            let nota = view.byId("notaFilmeInput")._lastValue;
            let duracao = view.byId("duracaoFilmeInput")._lastValue;

            //Formatacoes
            let dataFormatada = data;
            let generoFormatado = this._obterIndiceGenero(genero);
            let classificacaoFormatada = this._obterIndiceClassificacao(classificacao);
            let notaFormatada = parseFloat(nota);
            let duracaoFormatada = parseInt(duracao);

            let ModeloFilme = new JSONModel({
                titulo: titulo,
                dataDeLancamento: dataFormatada,
                genero: generoFormatado,
                emCartaz: false,
                nota: notaFormatada,
                duracao: duracaoFormatada,
                disponivelNoPlano: false,
                diretor: diretor,
                classificacao: classificacaoFormatada,
                atores: null
            });
            view.setModel(ModeloFilme, "FilmeCadastrado");
            let dadosFilme = ModeloFilme.getJSON();
            let resultado = await Repositorio.cadastrarFilme(dadosFilme);
            if(!resultado.ok){
                return MessageBox.alert(resultado.Title);
            }

            return MessageBox.success("O filme foi cadastrado com sucesso!");
        },

        aoClicarEmVoltar: function(){
            return this.irParaRotaCorrespondente("ListaDeFilmes");
        }

	});
});