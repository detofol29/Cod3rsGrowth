sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/DetalhesDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página Detalhes de filmes");

    const PROJETO_NOME = "cod3rsgrowth";
    const HASH = "DetalhesDeFilmes/2092";
    const CHAVE_I18N_TITULO_DA_PAGINA = "DetalhesDoFilme.Titulo";
    const CHAVE_I18N_TEXTO_DA_PAGINA = "DetalhesDoFilme.Texto";
    const CHAVE_I18N_BOTAO_EDITAR = "DetalhesDoFilme.BotaoEditar.Texto";
    const CHAVE_I18N_BOTAO_REMOVER = "DetalhesDoFilme.BotaoRemover.Texto";
    const TITULO_FILME_ESPERADO = "FilmeTesteOpa8";
    const GENERO_FILME_ESPERADO = "Ficção";
    const DATA_FILME_ESPERADO = "02/09/2024";
    const NOTA_FILME_ESPERADO = "7";
    const CLASSIFICACAO_FILME_ESPERADO = "Livre";
    const DURACAO_FILME_ESPERADO = "111";
    const DIRETOR_FILME_ESPERADO = "Diretor Teste";
    const DISPONIVEL_FILME_ESPERADO = "Não";
    const MENSAGEM_DE_CONFIRMACAO = "Deseja realmente excluir o filme " + TITULO_FILME_ESPERADO +"?";
    const TEXTO_BOTAO_DIALOG_CONFIRMACAO_NAO = "Não";
    const TEXTO_BOTAO_DIALOG_CONFIRMACAO_SIM = "Sim";
    const MENSAGEM_SUCESSO_REMOCAO = "O filme foi removido com sucesso!";
    const TEXTO_BOTAO_DIALOG_SUCESSO = "Ok";

    opaQUnit("Carregar tela de detalhes",(Given, When, Then) => {
      
        Given
            .iStartMyUIComponent({
                componentConfig: {
                name: PROJETO_NOME
                },
                hash: HASH
            });
        
        Then
            .naTelaDeDetalhes
            .aTelaFoiCarregadaCorretamente();

        Then
            .naTelaDeDetalhes
            .oTextoDaPaginaApresentaOValorCorrespondente(CHAVE_I18N_TITULO_DA_PAGINA);

        Then
            .naTelaDeDetalhes
            .oTituloDaPaginaApresentaOValorCorrespondente(CHAVE_I18N_TEXTO_DA_PAGINA);

        Then
            .naTelaDeDetalhes
            .aProprioedadeTituloDeveApresentarOValorCorrespondente(TITULO_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeGeneroDeveApresentarOValorCorrespondente(GENERO_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeDataDeveApresentarOValorCorrespondente(DATA_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeNotaDeveApresentarOValorCorrespondente(NOTA_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeClassificacaoDeveApresentarOValorCorrespondente(CLASSIFICACAO_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeDuracaoDeveApresentarOValorCorrespondente(DURACAO_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeDiretorDeveApresentarOValorCorrespondente(DIRETOR_FILME_ESPERADO);

        Then
            .naTelaDeDetalhes
            .aProprioedadeDisponivelDeveApresentarOValorCorrespondente(DISPONIVEL_FILME_ESPERADO);
        
        When
            .naTelaDeDetalhes
            .aoClicarEmRemover(CHAVE_I18N_BOTAO_REMOVER);

        Then
            .naTelaDeDetalhes
            .aCaixaDialogDeveAparecerComAMensagemDeConfirmacao(MENSAGEM_DE_CONFIRMACAO);

        When 
            .naTelaDeDetalhes
            .aoClicarNoBotaoDialogComOTextoCorrespondente(TEXTO_BOTAO_DIALOG_CONFIRMACAO_NAO);

        When
            .naTelaDeDetalhes
            .aoClicarEmRemover(CHAVE_I18N_BOTAO_REMOVER);

        When 
            .naTelaDeDetalhes
            .aoClicarNoBotaoDialogComOTextoCorrespondente(TEXTO_BOTAO_DIALOG_CONFIRMACAO_SIM);
        
        Then
            .naTelaDeDetalhes
            .aCaixaDialogDeveAparecerComAMensagemDeSucesso(MENSAGEM_SUCESSO_REMOCAO);

        When 
            .naTelaDeDetalhes
            .aoClicarNoBotaoDialogComOTextoCorrespondente(TEXTO_BOTAO_DIALOG_SUCESSO);

        Then
            .naTelaDeDetalhes
            .aTelaDeListagemDeveSerAberta();

        Then
            .iTeardownMyApp();
    });

    opaQUnit("Testar Botao Editar",(Given, When, Then) => {
        Given
            .iStartMyUIComponent({
                componentConfig: {
                name: PROJETO_NOME
                },
                hash: HASH
            });
        
        When
            .naTelaDeDetalhes
            .aoClicarEmEditar(CHAVE_I18N_BOTAO_EDITAR);

        Then
            .naTelaDeDetalhes
            .aTelaDeEdicaoDeveSerAberta();

        Then
            .iTeardownMyApp();
    });
});