sap.ui.define([
    "sap/ui/core/format/DateFormat",
	"cod3rsgrowth/app/controller/BaseController"
], function (DateFormat, BaseController) {
    "use strict";
 
    const INDICE_ZERO = 0;
    const ESTADO_ENTRADA_INVALIDA = "Error";
    const ESTADO_ENTRADA_VALIDA = "None";

    return  {

        _validarGenero: function(viewController) {
            const mensagemGeneroVazio = "O Campo Gênero não pode estar vazio!";
            const mensagemGeneroInvalido = "Selecione um Gênero válido!";
            const inputGeneroId = "generoFilmeInput";
            const modeloGenerosNome = "Generos";

            let view = viewController;
            let inputGenero = view.byId(inputGeneroId);

            if(inputGenero.getValue().length == INDICE_ZERO){
                inputGenero.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemGeneroVazio
            }

            let generos = view.getModel(modeloGenerosNome).getData();
            
            for (let i = INDICE_ZERO; i < generos.length; i++) {
                if(generos[i].descricao == inputGenero.getValue()){
                    inputGenero.setValueState(ESTADO_ENTRADA_VALIDA);
                    return true
                }
            }
            inputGenero.setValueState(ESTADO_ENTRADA_INVALIDA);
            return mensagemGeneroInvalido;
        },

        _validarClassificacao: function(viewController){
            const mensagemClassificacaoVazio = "O campo Classificação não pode estar vazio!";
            const mensagemClassificacaoInvalida = "Selecione uma classificação válida!";
            const inputClassificacaoId = "classificacaoFilmeInput";
            const modeloClassificacaoNome = "Classificacoes";

            let view = viewController;
            let inputClassificacao = view.byId(inputClassificacaoId);

            if(inputClassificacao.getValue().length == INDICE_ZERO){
                inputClassificacao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemClassificacaoVazio
            }

            let classificacoes = view.getModel(modeloClassificacaoNome).getData();

            for (let i = INDICE_ZERO; i < classificacoes.length; i++) {
                if(classificacoes[i].descricao == inputClassificacao.getValue()){
                    inputClassificacao.setValueState(ESTADO_ENTRADA_VALIDA);
                    return true
                }
            }

            inputClassificacao.setValueState(ESTADO_ENTRADA_INVALIDA);
            return mensagemClassificacaoInvalida;
        },

        _validarTitulo: function(viewController){
            const mensagemTituloVazio = "O campo Título não pode estar vazio!";
            const inputTituloId = "tituloFilmeInput";

            let view = viewController;
            let inputTitulo = view.byId(inputTituloId);

            if(inputTitulo.getValue().length == INDICE_ZERO){
                inputTitulo.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemTituloVazio;
            }

            inputTitulo.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarDiretor: function(viewController){
            const mensagemDiretorVazio = "O campo Diretor não pode estar vazio!";
            const mensagemDiretorComNumeros = "O campo Diretor não pode conter números!";
            const inputDiretorId = "diretorFilmeInput";
            const maiorIndiceNumerico = 9;

            let view = viewController;
            let inputDiretor = view.byId(inputDiretorId);

            if(inputDiretor.getValue().length == INDICE_ZERO){
                inputDiretor.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDiretorVazio;
            }

            for (let i = INDICE_ZERO; i < maiorIndiceNumerico; i++) {
                if(inputDiretor.getValue().includes(i.toString())){
                    inputDiretor.setValueState(ESTADO_ENTRADA_INVALIDA);
                    return mensagemDiretorComNumeros;
                }
            }
            inputDiretor.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarNota: function(viewController){
            const mensagemNotaVazio = "O campo nota não pode estar vazio!";
            const mensagemNotaInvalida = "A nota deve estar no intervalo [0-10]!";
            const notaMaximaPermitida = 10;
            const inputNotaId = "notaFilmeInput";

            let view = viewController;
            let inputNota = view.byId(inputNotaId);
            let notaConvertida = inputNota.getValue();

            if(inputNota.getValue().length == INDICE_ZERO){
                inputNota.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemNotaVazio
            }

            if(notaConvertida > notaMaximaPermitida || notaConvertida < INDICE_ZERO){
                inputNota.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemNotaInvalida;
            }
            inputNota.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarDuracao: function(viewController){
            const mensagemDuracaoVazio = "O campo Duração não pode estar vazio!";
            const mensagemDuracaoInvalida = "A duração deve estar no intervalo entre 1 e 1000 minutos!";
            const duracaoMinimaPermitida = 1;
            const duracaoMaximaPermitida = 1000;
            const inputDuracaoId = "duracaoFilmeInput";

            let view = viewController;
            let inputDuracao = view.byId(inputDuracaoId);
            let duracao = inputDuracao.getValue();

            if(inputDuracao.getValue().length == INDICE_ZERO){
                inputDuracao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDuracaoVazio
            }

            if(duracao < duracaoMinimaPermitida || duracao > duracaoMaximaPermitida){
                inputDuracao.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDuracaoInvalida;
            }
            
            inputDuracao.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        _validarData: function(viewController){
            const dataLimite = '12 28 1895';
            const mensagemDataVazia = "O campo Data não pode estar vazio!";
            const mensagemDataSuperior = "A data de lançamento não pode ser superior a data atual!";
            const mensagemDataInferior = "A data de lançamento não pode ser inferior a data do primeiro filme!";
            const inputDataId = "dataDeLancamentoInput";

            let view = viewController;
            let inputData = view.byId(inputDataId);
            let data = inputData.getDateValue();

            if(inputData.getValue().length == INDICE_ZERO){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDataVazia
            }

            let dataAtual = new Date();
            let dataFilme = new Date(data);
            let objetoDataLimite = new Date(dataLimite);

            if(dataFilme.getTime() > dataAtual.getTime()){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDataSuperior;
            }

            if(dataFilme.getTime() < objetoDataLimite.getTime()){
                inputData.setValueState(ESTADO_ENTRADA_INVALIDA);
                return mensagemDataInferior;
            }

            inputData.setValueState(ESTADO_ENTRADA_VALIDA);
            return true;
        },

        validarTodos: function(viewController){
            const saltoDeLinha = "\n";
            const stringVazia = "";

            let generoValidado = this._validarGenero(viewController);
            let tituloValidado = this._validarTitulo(viewController);
            let diretorValidado = this._validarDiretor(viewController);
            let notaValidada = this._validarNota(viewController);
            let duracaoValidada = this._validarDuracao(viewController);
            let classificacaoValidada = this._validarClassificacao(viewController);
            let dataValidada = this._validarData(viewController);

            let ErrosDeValidacao = tituloValidado == true 
            ? stringVazia 
            : tituloValidado + saltoDeLinha;

            ErrosDeValidacao += generoValidado == true 
            ? stringVazia 
            : generoValidado + saltoDeLinha;

            ErrosDeValidacao += dataValidada == true 
            ? stringVazia 
            : dataValidada + saltoDeLinha;

            ErrosDeValidacao += diretorValidado == true 
            ? stringVazia 
            : diretorValidado + saltoDeLinha;

            ErrosDeValidacao += classificacaoValidada == true 
            ? stringVazia 
            : classificacaoValidada + saltoDeLinha;

            ErrosDeValidacao += notaValidada == true 
            ? stringVazia 
            : notaValidada + saltoDeLinha;

            ErrosDeValidacao += duracaoValidada == true 
            ? stringVazia 
            : duracaoValidada + saltoDeLinha;
            
            if(ErrosDeValidacao.length == INDICE_ZERO){
                return true;
            }
            
            return ErrosDeValidacao;
        },
    }
});