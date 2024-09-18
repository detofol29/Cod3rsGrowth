sap.ui.define([
    "sap/ui/test/opaQunit",
    "cod3rsgrowth/testes/integracao/pages/DetalhesDeFilmes"
  ], function(opaQUnit) {
    "use strict";
  
    QUnit.module("Página Detalhes de filmes");

    const PROJETO_NOME = "cod3rsgrowth";
    const HASH = "DetalhesDeFilmes/15";
    const CHAVE_I18N_TITULO_DA_PAGINA = "DetalhesDoFilme.Titulo";
    const CHAVE_I18N_TEXTO_DA_PAGINA = "DetalhesDoFilme.Texto";
    const CHAVE_I18N_BOTAO_EDITAR = "DetalhesDoFilme.BotaoEditar.Texto";
    const TITULO_FILME_ESPERADO = "Batman: O Cavaleiro das Trevas";
    const GENERO_FILME_ESPERADO = "Fantasia";
    const DATA_FILME_ESPERADO = "18/07/2008";
    const NOTA_FILME_ESPERADO = "8";
    const CLASSIFICACAO_FILME_ESPERADO = "12+";
    const DURACAO_FILME_ESPERADO = "152";
    const DIRETOR_FILME_ESPERADO = "Christopher Nolan";
    const DISPONIVEL_FILME_ESPERADO = "Não";

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
            .aoClicarEmEditar(CHAVE_I18N_BOTAO_EDITAR);

        Then
            .naTelaDeDetalhes
            .aTelaDeEdicaoDeveSerAberta();

        Then
            .iTeardownMyApp();
    });
});