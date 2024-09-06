sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/AggregationLengthEquals",
],
    function (Opa5, I18NText, EnterText, Press, AggregationLengthEquals) {
 
        "use strict";
 
        const LISTAGEM_JOGADOR_VIEW_NAME = "app.jogador.ListagemJogador";
        const NOME_PROPRIEDADE_PLACEHOLDER = "placeholder";
        const NOME_PROPRIEDADE_TEXT = "text";
 
        const TIPO_CAMPO_DE_BUSCA = "sap.m.SearchField";
        const CHAVE_I18N_CAMPO_DE_BUSCA = "ListagemJogador.Placeholder.CampoDeBusca.Username";
        const NOME_DE_USUARIO = "marcos";
 
        const TIPO_COMBO_BOX = "sap.m.ComboBox";
        const CHAVE_I18N_COMBO_BOX = "ListagemJogador.Placeholder.ComboBox.CampoInicial";
        const CONTA_ATIVA = "Conta ativa";
        const CONTA_INATIVA = "Conta inativa";
 
        const TIPO_DATEPICKER = "sap.m.DatePicker";
        const CHAVE_I18N_DATEPICKER = "ListagemJogador.Placeholder.DatePicker.DataDeCadastro";
        const DATA = "3 de set. de 2024";
 
        const TIPO_BOTAO = "sap.m.Button";
        const CHAVE_I18N_BOTAO_APLICAR_FILTROS = "ListagemJogador.Placeholder.ToggleButtom.AplicarFiltros";
 
        Opa5.createPageObjects({
 
            naPaginaDeListagemJogador: {
 
                actions: {
                    escreveNoCampoDeBuscaPorUsuario: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_CAMPO_DE_BUSCA,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_CAMPO_DE_BUSCA
                                }
                            },
                            actions: new EnterText({ text: NOME_DE_USUARIO }),
                            success: () => Opa5.assert.ok(true, "O campo de busca foi preenchido com o nome de usuário "),
                            errorMessage: "O campo de busca não foi preenchido com o nome de usuário "
                        });
                    },
 
                    selecionoNaComboboxDeStatusDaContaContaAtiva: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_COMBO_BOX,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_COMBO_BOX
                                }
                            },
                            actions: new EnterText({ text: CONTA_ATIVA }),
                            success: () => Opa5.assert.ok(true, "A opção Conta ativa foi selecionada na Combobox"),
                            errorMessage: "A opção Conta ativa não foi selecionada na Combobox"
 
                        });
                    },
 
                    selecionoNaComboboxDeStatusDaContaInativa: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_COMBO_BOX,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_COMBO_BOX
                                }
                            },
                            actions: new EnterText({ text: CONTA_INATIVA }),
                            success: () => Opa5.assert.ok(true, "A opção Conta inativa foi selecionada na Combobox"),
                            errorMessage: "A opção Conta inativa não foi selecionada na Combobox"
                        });
                    },
 
                    selecionoDatePickerEAdicionoAData: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_DATEPICKER,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_DATEPICKER
                                }
                            },
                            actions: new EnterText({ text: DATA }),
                            success: () => Opa5.assert.ok(true, "A data foi adicionada no Datepicker"),
                            errorMessage: "A data não foi adicionada no Datepicker"
                        });
                    },
 
                    selecionoBotaoDeAplicarFiltros: function () {
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_BOTAO,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_TEXT,
                                    key: CHAVE_I18N_BOTAO_APLICAR_FILTROS
                                }
                            },
                            actions: new Press(),
                            success: () => Opa5.assert.ok(true, "O botão de filtrar foi clicado"),
                            errorMessage: "O botão de filtrar não foi clicado"
                        });
                    }
 
                },
 
                assertions: {
                    aTabelaDeveConterAQuantidadeEsperada: function (quantidadeDeJogadores) {
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: "sap.ui.table.Table",
                            check: function (tabela) {
                               
                                return tabela[0].getModel("Jogador").getData().length == quantidadeDeJogadores
                            },
                            success: () => Opa5.assert.ok(true, "deu certo porra"),
                            errorMessage: "Não foi possível verificar a quantidade de jogadores filtrados no modelo JSON"
                        });
                    }
                }
            }
        });
    }
);sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/AggregationLengthEquals",
],
    function (Opa5, I18NText, EnterText, Press, AggregationLengthEquals) {
 
        "use strict";
 
        const LISTAGEM_JOGADOR_VIEW_NAME = "app.jogador.ListagemJogador";
        const NOME_PROPRIEDADE_PLACEHOLDER = "placeholder";
        const NOME_PROPRIEDADE_TEXT = "text";
 
        const TIPO_CAMPO_DE_BUSCA = "sap.m.SearchField";
        const CHAVE_I18N_CAMPO_DE_BUSCA = "ListagemJogador.Placeholder.CampoDeBusca.Username";
        const NOME_DE_USUARIO = "marcos";
 
        const TIPO_COMBO_BOX = "sap.m.ComboBox";
        const CHAVE_I18N_COMBO_BOX = "ListagemJogador.Placeholder.ComboBox.CampoInicial";
        const CONTA_ATIVA = "Conta ativa";
        const CONTA_INATIVA = "Conta inativa";
 
        const TIPO_DATEPICKER = "sap.m.DatePicker";
        const CHAVE_I18N_DATEPICKER = "ListagemJogador.Placeholder.DatePicker.DataDeCadastro";
        const DATA = "3 de set. de 2024";
 
        const TIPO_BOTAO = "sap.m.Button";
        const CHAVE_I18N_BOTAO_APLICAR_FILTROS = "ListagemJogador.Placeholder.ToggleButtom.AplicarFiltros";
 
        Opa5.createPageObjects({
 
            naPaginaDeListagemJogador: {
 
                actions: {
                    escreveNoCampoDeBuscaPorUsuario: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_CAMPO_DE_BUSCA,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_CAMPO_DE_BUSCA
                                }
                            },
                            actions: new EnterText({ text: NOME_DE_USUARIO }),
                            success: () => Opa5.assert.ok(true, "O campo de busca foi preenchido com o nome de usuário "),
                            errorMessage: "O campo de busca não foi preenchido com o nome de usuário "
                        });
                    },
 
                    selecionoNaComboboxDeStatusDaContaContaAtiva: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_COMBO_BOX,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_COMBO_BOX
                                }
                            },
                            actions: new EnterText({ text: CONTA_ATIVA }),
                            success: () => Opa5.assert.ok(true, "A opção Conta ativa foi selecionada na Combobox"),
                            errorMessage: "A opção Conta ativa não foi selecionada na Combobox"
 
                        });
                    },
 
                    selecionoNaComboboxDeStatusDaContaInativa: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_COMBO_BOX,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_COMBO_BOX
                                }
                            },
                            actions: new EnterText({ text: CONTA_INATIVA }),
                            success: () => Opa5.assert.ok(true, "A opção Conta inativa foi selecionada na Combobox"),
                            errorMessage: "A opção Conta inativa não foi selecionada na Combobox"
                        });
                    },
 
                    selecionoDatePickerEAdicionoAData: function () {
 
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_DATEPICKER,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_PLACEHOLDER,
                                    key: CHAVE_I18N_DATEPICKER
                                }
                            },
                            actions: new EnterText({ text: DATA }),
                            success: () => Opa5.assert.ok(true, "A data foi adicionada no Datepicker"),
                            errorMessage: "A data não foi adicionada no Datepicker"
                        });
                    },
 
                    selecionoBotaoDeAplicarFiltros: function () {
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: TIPO_BOTAO,
                            matchers: {
                                i18NText: {
                                    propertyName: NOME_PROPRIEDADE_TEXT,
                                    key: CHAVE_I18N_BOTAO_APLICAR_FILTROS
                                }
                            },
                            actions: new Press(),
                            success: () => Opa5.assert.ok(true, "O botão de filtrar foi clicado"),
                            errorMessage: "O botão de filtrar não foi clicado"
                        });
                    }
 
                },
 
                assertions: {
                    aTabelaDeveConterAQuantidadeEsperada: function (quantidadeDeJogadores) {
                        return this.waitFor({
                            viewName: LISTAGEM_JOGADOR_VIEW_NAME,
                            controlType: "sap.ui.table.Table",
                            check: function (tabela) {
                               
                                return tabela[0].getModel("Jogador").getData().length == quantidadeDeJogadores
                            },
                            success: () => Opa5.assert.ok(true, "deu certo porra"),
                            errorMessage: "Não foi possível verificar a quantidade de jogadores filtrados no modelo JSON"
                        });
                    }
                }
            }
        });
    }
);