sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/CadastroDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página cadastro de filmes");

    const PROJETO_NOME = "cod3rsgrowth";
    const HASH = "CadastroDeFilmes";
    const ERROS_INICIAIS = "O campo Título não pode estar vazio!\nO Campo Gênero não pode estar vazio!\nO campo Data não pode estar vazio!\nO campo Diretor não pode estar vazio!\nO campo Classificação não pode estar vazio!\nO campo nota não pode estar vazio!\nO campo Duração não pode estar vazio!\n";
    const MENSAGEM_SUCESSO = "Filme cadastrado com sucesso!";
    opaQUnit("Carregar tela de cadastro",(Given, When, Then) => {
      
        Given
        .iStartMyUIComponent({
        componentConfig: {
            name: PROJETO_NOME
        },
        hash: HASH
        });

        Then
        .noCadastroDeFilmes
        .aTelaFoiCarregadaCorretamente();

        Then
        .noCadastroDeFilmes
        .oTextoDaPaginaDeveTerOValorDaChaveI18nCorrespondente("CadastroDeFilmes.Pagina.Titulo");

        Then
        .noCadastroDeFilmes
        .oTextoDoFormularioDeveTerOValorDaChaveI18nCorrespondente("CadastroDeFilmes.Formulario.Titulo");

        When
        .noCadastroDeFilmes
        .aoClicarNoBotaoCadastrarFilme("CadastroDeFilmes.BotaoDeCadastrar.Texto");

        Then
        .noCadastroDeFilmes
        .aCaixaDeMensagemDeveAparecerComOsErrosCorrespondentes(ERROS_INICIAIS);

        When
        .noCadastroDeFilmes
        .aoPreencherOCampoTitulo();

        When
        .noCadastroDeFilmes
        .aoSelecionarGenero();

        When
        .noCadastroDeFilmes
        .aoSelecionarData();

        When
        .noCadastroDeFilmes
        .aoPreencherOCampoDiretor();

        When
        .noCadastroDeFilmes
        .aoPreencherOCampoClassificacao();

        When
        .noCadastroDeFilmes
        .aoPreencherOCampoNota();

        When
        .noCadastroDeFilmes
        .aoPreencherOCampoDuracao();

        When
        .noCadastroDeFilmes
        .aoClicarNoBotaoCadastrarFilme("CadastroDeFilmes.BotaoDeCadastrar.Texto");

        Then
        .noCadastroDeFilmes
        .aCaixaDialogDeveAparecerComAMensagemDeSucesso(MENSAGEM_SUCESSO);

        When
        .noCadastroDeFilmes
        .aoClicarNoBotaoDialogDeSucesso();

        Then
        .noCadastroDeFilmes
        .oBotaoDeveLevarParaTelaDeListagem();

        Then.iTeardownMyApp();
    });
});