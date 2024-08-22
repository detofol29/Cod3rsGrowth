sap.ui.define([
    "sap/ui/core/UIComponent", //fornece a base para a criação de componentes
    "sap/ui/model/json/JSONModel",// tilizada para trabalhar com dados JSON em um modelo
    // "sap/ui/model/resource/ResourceModel" //gerenciar e carregar recursos de internacionalização, como arquivos de propriedades
    "sap/ui/Device"
], (UIComponent, JSONModel, Device) => {
    "use strict";

    return UIComponent.extend("ui5.walkthrough.Component",{

        metadata : {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },
        
        // Este método é chamado quando o componente é inicializado
        init() {
            UIComponent.prototype.init.apply(this,arguments);

            //Define um objeto de dados inicial com uma estrutura básica
            const oData = {
                recipient : {
                    name: "Gabriel"
                }
            };

            //cria um novo modelo JSON usando os dados definidos anteriormente
            const oModel = new JSONModel(oData);

            //Define o modelo JSON criado como o modelo padrão do componente
            //todas as visualizações e controladores dentro deste componente podem acessar esses dados
            this.setModel(oModel);

            const oDeviceModel = new JSONModel(Device);
            oDeviceModel.setDefaultBindingMode("OneWay");
            this.setModel(oDeviceModel, "device");
            
            //cria as views baseado na url
            //this.getRouter().initialize();

            //cria um modelo de recursos para a internacionalização
            // const i18nModel = new ResourceModel({
            //     bundleName : "ui5.walkthrough.i18n.i18n"
            // });

            //Define o modelo de internacionalização com o nome "i18n"
            //Esse modelo pode ser acessado nas visualizações e controladores usando esse nome
            //this.setModel(i18nModel, "i18n");
            
        },

        getContentDensityClass() {
            return Device.support.touch ? "sapUiSizeCozy" : "sapUiSizeCompact";
        }
    });
});

//Essa classe é essencial para configurar a estrutura e o comportamento do aplicativo SAPUI5, inicializando modelos de dados, configurando a visualização raiz e garantindo que o aplicativo tenha acesso a dados e recursos necessários.