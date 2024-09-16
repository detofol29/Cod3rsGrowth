sap.ui.define([
    "sap/ui/core/format/DateFormat",
	"cod3rsgrowth/app/controller/BaseController"
], function (DateFormat, BaseController) {
    "use strict";
 
    const INDICE_ZERO = 0;
    const MAIOR_INDICE_NUMERICO = 9;
    const NOTA_MAXIMA_PERMITIDA = 10;
    const DURACAO_MINIMA_PERMITIDA = 1;
    const DURACAO_MAXIMA_PERMITIDA = 1000;
	const STRING_VAZIA = "";
    const SALTO_DE_LINHA = "\n";
    const MODELO_GENEROS_NOME = "Generos";
	const MODELO_CLASSIFICACAO_NOME = "Classificacoes";
    const MODELO_FILME_CADASTRADO = "FilmeCadastrado";
    const INPUT_GENERO_ID = "generoFilmeInput";
    const INPUT_CLASSIFICACAO_ID = "classificacaoFilmeInput";
    const INPUT_TITULO_ID = "tituloFilmeInput";
    const INPUT_DIRETOR_ID = "diretorFilmeInput";
    const INPUT_NOTA_ID = "notaFilmeInput";
    const INPUT_DURACAO_ID = "duracaoFilmeInput";
    const INPUT_DATA_ID = "dataDeLancamentoInput";
    const MENSAGEM_GENERO_VAZIO = "O Campo Gênero não pode estar vazio!";
    const MENSAGEM_GENERO_INVALIDO = "Selecione um Gênero válido!";
    const MENSAGEM_CLASSIFICACAO_VAZIO = "O campo Classificação não pode estar vazio!";
    const MENSAGEM_CLASSIFICACAO_INVALIDA = "Selecione uma classificação válida!";
    const MENSAGEM_TITULO_VAZIO = "O campo Título não pode estar vazio!";
    const MENSAGEM_DIRETOR_VAZIO = "O campo Diretor não pode estar vazio!";
    const MENSAGEM_DIRETOR_COM_NUMEROS = "O campo Diretor não pode conter números!";
    const MENSAGEM_NOTA_VAZIO = "O campo nota não pode estar vazio!";
    const MENSAGEM_NOTA_INVALIDA = "A nota deve estar no intervalo [0-10]!";
    const MENSAGEM_DURACAO_VAZIO = "O campo Duração não pode estar vazio!";
    const MENSAGEM_DURACAO_INVALIDA = "A duração deve estar no intervalo entre 1 e 1000 minutos!";
    const MENSAGEM_DATA_VAZIA = "O campo Data não pode estar vazio!";
    const MENSAGEM_DATA_SUPERIOR = "A data de lançamento não pode ser superior a data atual!";
    const MENSAGEM_DATA_INFERIOR = "A data de lançamento não pode ser inferior a data do primeiro filme!";
    const DATA_LIMITE = '12 28 1895';

    return  {

        validarGenero: function(viewController) {
            let view = viewController.getView();
            let inputGenero = view.byId(INPUT_GENERO_ID);

            if(inputGenero._lastValue.length == INDICE_ZERO){
                return MENSAGEM_GENERO_VAZIO
            }

            let generos = this.getView().getModel(MODELO_GENEROS_NOME).getData();
            
            for (let i = INDICE_ZERO; i < generos.length; i++) {
                if(generos[i].descricao == inputGenero._lastValue){
                    return true
                }
            }

            return MENSAGEM_GENERO_INVALIDO;
        },

        validarClassificacao: function(viewController){
            let view = viewController.getView();
            let inputClassificacao = view.byId(INPUT_CLASSIFICACAO_ID);

            if(inputClassificacao._lastValue.length == INDICE_ZERO){
                return MENSAGEM_CLASSIFICACAO_VAZIO
            }

            let classificacoes = this.getView().getModel(MODELO_CLASSIFICACAO_NOME).getData();

            for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
                if(classificacoes[i].descricao == inputClassificacao._lastValue){
                    return true
                }
            }

            return MENSAGEM_CLASSIFICACAO_INVALIDA;
        },

        validarTitulo: function(viewController){
            let view = viewController.getView();
            let inputTitulo = view.byId(INPUT_TITULO_ID);

            if(inputTitulo._lastValue.length == INDICE_ZERO){
                return MENSAGEM_TITULO_VAZIO;
            }

            return true;
        },

        validarDiretor: function(viewController){
            let view = viewController.getView();
            let inputDiretor = view.byId(INPUT_DIRETOR_ID);

            if(inputDiretor._lastValue.length == INDICE_ZERO){
                return MENSAGEM_DIRETOR_VAZIO;
            }

            for (let i = INDICE_ZERO; i < MAIOR_INDICE_NUMERICO; i++) {
                if(inputDiretor._lastValue.includes(i.toString())){
                    return MENSAGEM_DIRETOR_COM_NUMEROS;
                }
            }

            return true;
        },

        validarNota: function(viewController){
            let view = viewController.getView();
            let inputNota = view.byId(INPUT_NOTA_ID);
            let notaConvertida = inputNota._lastValue;

            if(inputNota._lastValue.length == INDICE_ZERO){
                return MENSAGEM_NOTA_VAZIO
            }

            if(notaConvertida > NOTA_MAXIMA_PERMITIDA || notaConvertida < INDICE_ZERO){
                return MENSAGEM_NOTA_INVALIDA;
            }

            return true;
        },

        validarDuracao: function(viewController){
            let view = viewController.getView();
            let inputDuracao = view.byId(INPUT_DURACAO_ID);
            let duracao = inputDuracao._lastValue;

            if(inputDuracao._lastValue.length == INDICE_ZERO){
                return MENSAGEM_DURACAO_VAZIO
            }

            if(duracao < DURACAO_MINIMA_PERMITIDA || duracao > DURACAO_MAXIMA_PERMITIDA){
                return MENSAGEM_DURACAO_INVALIDA;
            }

            return true;
        },

        validarTodos: function(viewController){

            let generoValidado = this._validarGenero(viewController);
            let tituloValidado = this._validarTitulo(viewController);
            let diretorValidado = this._validarDiretor(viewController);
            let notaValidada = this._validarNota(viewController);
            let duracaoValidada = this._validarDuracao(viewController);
            let classificacaoValidada = this._validarClassificacao(viewController);
            let dataValidada = this._validarData(viewController);

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

        validarData: function(viewController){
            let view = viewController.getView();
            let inputData = view.byId(INPUT_DATA_ID);
            let data = inputData.getDateValue();

            if(inputData.getValue().length == INDICE_ZERO){
                return MENSAGEM_DATA_VAZIA
            }

            let dataAtual = new Date();
            let dataFilme = new Date(data);
            let dataLimite = new Date(DATA_LIMITE);

            if(dataFilme.getTime() > dataAtual.getTime()){
                return MENSAGEM_DATA_SUPERIOR;
            }

            if(dataFilme.getTime() < dataLimite.getTime()){
                return MENSAGEM_DATA_INFERIOR;
            }

            return true;
        },
    }
});