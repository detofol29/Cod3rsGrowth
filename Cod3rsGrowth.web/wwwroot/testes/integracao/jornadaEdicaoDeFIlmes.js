sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/EdicaoDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página edicao de filmes");

    const PROJETO_NOME = "cod3rsgrowth";
    const HASH = "EdicaoDeFilmes/2087";
    const MENSAGEM_SUCESSO = "Filme editado com sucesso!";
    const CHAVE_I18N_PAGINA_TITULO = "EdicaoDeFilmes.Pagina.Titulo";
    const CHAVE_I18N_FORMULARIO_TITULO = "EdicaoDeFilmes.Formulario.Titulo";
    const CHAVE_I18N_BOTAO_CADASTRO_TEXTO = "EdicaoDeFilmes.Botao.Texto";
    const NOTA_EDITADA = 1;
    const DIRETOR_EDITADO = "Diretor Editado";

    opaQUnit("Carregar tela de edicao",(Given, When, Then) => {
      
        Given
            .iStartMyUIComponent({
                componentConfig: {
                name: PROJETO_NOME
                },
                hash: HASH
            });
        
        Then
            .naTelaDeEdicao
            .aTelaFoiCarregadaCorretamente();

        Then
            .naTelaDeEdicao
            .oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente(CHAVE_I18N_PAGINA_TITULO);

        Then
            .naTelaDeEdicao
            .oTextoDoFormularioDeveTerOValorDaChaveI18nCorrespondente(CHAVE_I18N_FORMULARIO_TITULO);
        
        When
            .naTelaDeEdicao
            .aoPreencherANotaComValorCorrespondente(NOTA_EDITADA);

        When
            .naTelaDeEdicao
            .aoPreencherDiretorComValorCorrespondente(DIRETOR_EDITADO);

        When
            .naTelaDeEdicao
            .aoClicarNoBotaoEditarFilme(CHAVE_I18N_BOTAO_CADASTRO_TEXTO);
        
        Then
            .naTelaDeEdicao
            .aCaixaDialogDeveAparecerComAMensagemDeSucesso(MENSAGEM_SUCESSO);

        When
            .naTelaDeEdicao
            .aoClicarNoBotaoDialogDeSucesso();

        Then
            .naTelaDeEdicao
            .oBotaoDeveLevarParaTelaDeDetalhes();

        Then
            .iTeardownMyApp();
    });
});