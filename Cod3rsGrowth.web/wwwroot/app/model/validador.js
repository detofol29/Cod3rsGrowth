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
    const ESTADO_ENTRADA_INVALIDA = "Error";
    const ESTADO_ENTRADA_VALIDA = "None";


    return  {

        _validarGenero: function(viewController) {
            let view = viewController;
            let inputGenero = view.byId(INPUT_GENERO_ID);

            if(inputGenero.getValue().length == INDICE_ZERO){
                inputGenero.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_GENERO_VAZIO
            }

            let generos = view.getModel(MODELO_GENEROS_NOME).getData();
            
            for (let i = INDICE_ZERO; i < generos.length; i++) {
                if(generos[i].descricao == inputGenero.getValue()){
                    inputGenero.setValueState(ESTADO_ENTRADA_VALIDA);
                    return true
                }
            }
            inputGenero.setValueState(ESTADO_ENTRADA_INVALIDA);
            return MENSAGEM_GENERO_INVALIDO;
        },

        _validarClassificacao: function(viewController){
            let view = viewController;
            let inputClassificacao = view.byId(INPUT_CLASSIFICACAO_ID);

            if(inputClassificacao.getValue().length == INDICE_ZERO){
                inputClassificacao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_CLASSIFICACAO_VAZIO
            }

            let classificacoes = view.getModel(MODELO_CLASSIFICACAO_NOME).getData();

            for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
                if(classificacoes[i].descricao == inputClassificacao.getValue()){
                    inputClassificacao.setValueState(ESTADO_ENTRADA_VALIDA);
                    return true
                }
            }

            inputClassificacao.setValueState(ESTADO_ENTRADA_INVALIDA);
            return MENSAGEM_CLASSIFICACAO_INVALIDA;
        },

        _validarTitulo: function(viewController){
            let view = viewController;
            let inputTitulo = view.byId(INPUT_TITULO_ID);

            if(inputTitulo.getValue().length == INDICE_ZERO){
                inputTitulo.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_TITULO_VAZIO;
            }

            inputTitulo.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarDiretor: function(viewController){
            let view = viewController;
            let inputDiretor = view.byId(INPUT_DIRETOR_ID);

            if(inputDiretor.getValue().length == INDICE_ZERO){
                inputDiretor.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DIRETOR_VAZIO;
            }

            for (let i = INDICE_ZERO; i < MAIOR_INDICE_NUMERICO; i++) {
                if(inputDiretor.getValue().includes(i.toString())){
                    inputDiretor.setValueState(ESTADO_ENTRADA_INVALIDA);
                    return MENSAGEM_DIRETOR_COM_NUMEROS;
                }
            }
            inputDiretor.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarNota: function(viewController){
            let view = viewController;
            let inputNota = view.byId(INPUT_NOTA_ID);
            let notaConvertida = inputNota.getValue();

            if(inputNota.getValue().length == INDICE_ZERO){
                inputNota.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_NOTA_VAZIO
            }

            if(notaConvertida > NOTA_MAXIMA_PERMITIDA || notaConvertida < INDICE_ZERO){
                inputNota.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_NOTA_INVALIDA;
            }
            inputNota.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarDuracao: function(viewController){
            let view = viewController;
            let inputDuracao = view.byId(INPUT_DURACAO_ID);
            let duracao = inputDuracao.getValue();

            if(inputDuracao.getValue().length == INDICE_ZERO){
                inputDuracao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DURACAO_VAZIO
            }

            if(duracao < DURACAO_MINIMA_PERMITIDA || duracao > DURACAO_MAXIMA_PERMITIDA){
                inputDuracao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DURACAO_INVALIDA;
            }
            inputDuracao.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarData: function(viewController){
            let view = viewController;
            let inputData = view.byId(INPUT_DATA_ID);
            let data = inputData.getDateValue();

            if(inputData.getValue().length == INDICE_ZERO){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DATA_VAZIA
            }

            let dataAtual = new Date();
            let dataFilme = new Date(data);
            let dataLimite = new Date(DATA_LIMITE);

            if(dataFilme.getTime() > dataAtual.getTime()){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DATA_SUPERIOR;
            }

            if(dataFilme.getTime() < dataLimite.getTime()){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return MENSAGEM_DATA_INFERIOR;
            }

            inputData.setValueState(ESTADO_ENTRADA_VALIDA);
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
    }
});