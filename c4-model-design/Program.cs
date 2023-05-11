using Structurizr;
using Structurizr.Api;

namespace c4_model_design
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderModels();
        }

        static void RenderModels()
        {
            const long workspaceId = 82355;
            const string apiKey = "5f6d3fa3-a4bd-4fd7-9178-321c967494cb";
            const string apiSecret = "e23968ba-4ff0-4e51-9ac7-ea663d374916";

            StructurizrClient structurizrClient = new StructurizrClient(apiKey, apiSecret);

            Workspace workspace = new Workspace("Gym", "Partial arch");

            ViewSet viewSet = workspace.Views;

            Model model = workspace.Model;

            // 1. Diagrama de Contexto
          SoftwareSystem technogymEcosystem = model.AddSoftwareSystem("Technogym Unified Ecosystem", "Una plataforma digital abierta para personalizar experiencias de entrenamiento y potenciar el negocio de los clubes.");
 SoftwareSystem stripe = model.AddSoftwareSystem("Stripe", "Una plataforma de pagos online que permite procesar tarjetas de crédito y débito.");
 SoftwareSystem googleCloud = model.AddSoftwareSystem("Google Cloud", "Una plataforma de servicios en la nube que ofrece soluciones de computación, almacenamiento, bases de datos, inteligencia artificial y más.");

 Person endUser = model.AddPerson("End user", "Una persona que usa los equipos y servicios de Technogym para mejorar su bienestar.");
 Person businessCustomer = model.AddPerson("Business customer", "Una organización o centro deportivo que ofrece equipos y servicios de Technogym a sus miembros o clientes.");
 Person fitnessClub = model.AddPerson("Fitness club", "Un club o gimnasio que ofrece equipos y servicios de Technogym a sus miembros o clientes.");
 Person supplier = model.AddPerson("Supplier", "Una empresa que suministra productos o servicios a Technogym.");
 Person maintenanceTechnician = model.AddPerson("Maintenance technician", "Una persona que se encarga de reparar y mantener los equipos de Technogym.");

 endUser.Uses(technogymEcosystem, "Accede a programas y contenidos personalizados de entrenamiento desde cualquier lugar y en cualquier momento.");
 businessCustomer.Uses(technogymEcosystem, "Se conecta con sus clientes usando sistemas web o móviles, dentro o fuera del club.");
 fitnessClub.Uses(technogymEcosystem, "Se conecta con sus miembros usando sistemas web o móviles, dentro o fuera del club.");
 supplier.Uses(technogymEcosystem, "Suministra productos o servicios a Technogym.");
 maintenanceTechnician.Uses(technogymEcosystem, "Repara y mantiene los equipos de Technogym.");

 technogymEcosystem.Uses(stripe, "Usa la plataforma de pagos para procesar las transacciones online.");
 technogymEcosystem.Uses(googleCloud, "Usa la plataforma de servicios en la nube para alojar y ejecutar sus soluciones.");
 
 // Tags
 endUser.AddTags("EndUser");
 businessCustomer.AddTags("BusinessCustomer");
 fitnessClub.AddTags("FitnessClub");
 supplier.AddTags("Supplier");
 maintenanceTechnician.AddTags("MaintenanceTechnician");
 technogymEcosystem.AddTags("TechnogymEcosystem");
 stripe.AddTags("Stripe");
 googleCloud.AddTags("GoogleCloud");

 Styles styles = viewSet.Configuration.Styles;
 styles.Add(new ElementStyle("EndUser") { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Person });
 styles.Add(new ElementStyle("BusinessCustomer") { Background = "#aa60af", Color = "#ffffff", Shape = Shape.Person });
 styles.Add(new ElementStyle("FitnessClub") { Background = "#0aaf60", Color = "#ffffff", Shape = Shape.Person });
 styles.Add(new ElementStyle("Supplier") { Background = "#af600a", Color = "#ffffff", Shape = Shape.Person });
 styles.Add(new ElementStyle("MaintenanceTechnician") { Background = "#af0a60", Color = "#ffffff", Shape = Shape.Person });
 styles.Add(new ElementStyle("TechnogymEcosystem") { Background = "#008f39", Color = "#ffffff", Shape = Shape.RoundedBox });
 styles.Add(new ElementStyle("Stripe") { Background = "#90714c", Color = "#ffffff", Shape = Shape.RoundedBox });
 styles.Add(new ElementStyle("GoogleCloud") { Background = "#2f95c7", Color = "#ffffff", Shape = Shape.RoundedBox });
 SystemContextView contextView = viewSet.CreateSystemContextView(technogymEcosystem, "Contexto", "Diagrama de contexto");
 contextView.PaperSize = PaperSize.A4_Landscape;
 contextView.AddAllSoftwareSystems();
 contextView.AddAllPeople();
 
 // 2. Diagrama de Contenedor
Container webApp = technogymEcosystem.AddContainer("Web Application", "Permite a los usuarios acceder a los servicios y productos de Technogym.", "Angular");
 Container mobileApp = technogymEcosystem.AddContainer("Mobile Application", "Permite a los usuarios acceder a los servicios y productos de Technogym desde sus dispositivos móviles.", "Android/iOS");
 Container apiGateway = technogymEcosystem.AddContainer("API Gateway", "Proporciona un punto de entrada único para todas las peticiones .", "Google Cloud Run");
 Container sharedContext = technogymEcosystem.AddContainer("Shared Context", "Bounded Context del  Compartido que proporciona funcionalidades comunes.", "Google Cloud Run");
 Container identityContext = technogymEcosystem.AddContainer("Identity Context", "Bounded Context del  de Identidad que gestiona el registro, la autenticación y la autorización de los usuarios.", "Google Cloud Run");
 Container ecommerceContext = technogymEcosystem.AddContainer("Ecommerce Context", "Bounded Context del  de Comercio Electrónico que gestiona la venta online de productos y suscripciones.", "Google Cloud Run");
 Container inventoryContext = technogymEcosystem.AddContainer("Inventory Context", "Bounded Context del  de Inventario que gestiona el catálogo, el inventario y las adquisiciones de productos y servicios.", "Google Cloud Run");
 Container accountsContext = technogymEcosystem.AddContainer("Accounts Context", "Bounded Context del  de Cuentas que gestiona la información de cuentas, perfiles y preferencias de los usuarios.", "Google Cloud Run");
 Container trainingContext = technogymEcosystem.AddContainer("Training Context", "Bounded Context del  de Entrenamiento que gestiona el diseño, la ejecución y el seguimiento de planes de entrenamiento.", "Google Cloud Run");
 Container businessContext = technogymEcosystem.AddContainer("Business Context", "Bounded Context del  de Negocio que gestiona los servicios premium para smart facilities.", "Google Cloud Run");
 Container contentContext = technogymEcosystem.AddContainer("Content Context", "Bounded Context del  de Contenido que gestiona el contenido multimedia de entrenamiento y capacitación.", "Google Cloud Run");
 Container aiCoachContext = technogymEcosystem.AddContainer("AI Coach Context", "Bounded Context del  de Entrenador Inteligente que proporciona asistencia inteligente en las sesiones de entrenamiento.", "Google Cloud Run");
 Container analyticsContext = technogymEcosystem.AddContainer("Analytics Context", "Bounded Context del  de Análisis que gestiona el registro y análisis de datos de actividades en la plataforma.", "Google Cloud Run");
 Container database = technogymEcosystem.AddContainer("Database", "Almacena información persistente sobre usuarios, productos, servicios, etc.", "Google Cloud SQL");
 Container messageBus = technogymEcosystem.AddContainer("Message Bus", "Facilita la comunicación asíncrona  mediante eventos.", "Google Pub/Sub");
 Container fileStorage = technogymEcosystem.AddContainer("File Storage", "Almacena archivos multimedia como imágenes, videos, etc.", "Google Cloud Storage");
 Container videoStreaming = technogymEcosystem.AddContainer("Video Streaming", "Permite transmitir videos en vivo o bajo demanda a los usuarios.", "Google Cloud CDN");
 
 webApp.Uses(apiGateway, "Llama a");
 mobileApp.Uses(apiGateway, "Llama a");
apiGateway.Uses(sharedContext, "Llama a");
apiGateway.Uses(identityContext, "Llama a");
apiGateway.Uses(ecommerceContext, "Llama a");
apiGateway.Uses(inventoryContext, "Llama a");
apiGateway.Uses(accountsContext, "Llama a");
apiGateway.Uses(trainingContext, "Llama a");
apiGateway.Uses(businessContext, "Llama a");
apiGateway.Uses(contentContext, "Llama a");
apiGateway.Uses(aiCoachContext, "Llama a");
apiGateway.Uses(analyticsContext, "Llama a");

sharedContext.Uses(database, "Consulta", "JDBC");
identityContext.Uses(database, "Consulta", "JDBC");
ecommerceContext.Uses(database, "Consulta", "JDBC");
inventoryContext.Uses(database, "Consulta", "JDBC");
accountsContext.Uses(database, "Consulta", "JDBC");
trainingContext.Uses(database, "Consulta", "JDBC");
businessContext.Uses(database, "Consulta", "JDBC");
contentContext.Uses(database, "Consulta", "JDBC");
aiCoachContext.Uses(database, "Consulta", "JDBC");
analyticsContext.Uses(database, "Consulta", "JDBC");

sharedContext.Uses(messageBus, "Publica eventos");
identityContext.Uses(messageBus, "Publica eventos");
ecommerceContext.Uses(messageBus, "Publica eventos");
inventoryContext.Uses(messageBus, "Publica eventos");
accountsContext.Uses(messageBus, "Publica eventos");
trainingContext.Uses(messageBus, "Publica eventos");
businessContext.Uses(messageBus, "Publica eventos");
contentContext.Uses(messageBus, "Publica eventos");
aiCoachContext.Uses(messageBus, "Publica eventos");
analyticsContext.Uses(messageBus, "Publica eventos");

sharedContext.Uses(messageBus, "Se suscribe a eventos");
identityContext.Uses(messageBus, "Se suscribe a eventos");
ecommerceContext.Uses(messageBus, "Se suscribe a eventos");
inventoryContext.Uses(messageBus, "Se suscribe a eventos");
accountsContext.Uses(messageBus, "Se suscribe a eventos");
trainingContext.Uses(messageBus, "Se suscribe a eventos");
businessContext.Uses(messageBus, "Se suscribe a eventos");
contentContext.Uses(messageBus, "Se suscribe a eventos");
aiCoachContext.Uses(messageBus, "Se suscribe a eventos");
analyticsContext.Uses(messageBus, "Se suscribe a eventos");

contentContext.Uses(fileStorage, "Almacena y recupera archivos multimedia", "");
contentContext.Uses(videoStreaming, "", "");
ecommerceContext.Uses(stripe,"Usa la plataforma de pagos para procesar las transacciones online.", "");

 
 ContainerView containerView = viewSet.CreateContainerView(technogymEcosystem, "Contenedor", "Diagrama de contenedores");
 contextView.PaperSize = PaperSize.A4_Landscape;
 containerView.AddAllElements();
 
 // Tags
webApp.AddTags("WebApp"); 
mobileApp.AddTags("MobileApp"); 
apiGateway.AddTags("ApiGateway"); 
sharedContext.AddTags("SharedContext"); 
identityContext.AddTags("IdentityContext"); 
ecommerceContext.AddTags("EcommerceContext"); 
inventoryContext.AddTags("InventoryContext"); 
accountsContext.AddTags("AccountsContext"); 
trainingContext.AddTags("TrainingContext"); 
businessContext.AddTags("BusinessContext"); 
contentContext.AddTags("ContentContext"); 
aiCoachContext.AddTags("AiCoachContext"); 
analyticsContext.AddTags("AnalyticsContext"); 
database.AddTags("Database"); 
messageBus.AddTags("MessageBus"); 
fileStorage.AddTags("FileStorage"); 
videoStreaming.AddTags("VideoStreaming");

styles.Add(new ElementStyle("WebApp") { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Box });
styles.Add(new ElementStyle("MobileApp") { Background = "#aa60af", Color = "#ffffff", Shape = Shape.Box });
styles.Add(new ElementStyle("ApiGateway") { Background = "#0aaf60", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("SharedContext") { Background = "#af600a", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("IdentityContext") { Background = "#af0a60", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("EcommerceContext") { Background = "#008f39", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("InventoryContext") { Background = "#90714c", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("AccountsContext") { Background = "#2f95c7", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("TrainingContext") { Background = "#95c72f", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("BusinessContext") { Background = "#c7952f", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("ContentContext") { Background = "#c72f95", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("AiCoachContext") { Background = "#2fc795", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("AnalyticsContext") { Background = "#2f2fc7", Color = "#ffffff", Shape = Shape.Hexagon });
styles.Add(new ElementStyle("Database") { Background = "#c7c72f", Color = "#ffffff", Shape = Shape.Cylinder });
styles.Add(new ElementStyle("MessageBus") { Background = "#c7c7c7", Color = "#000000", Shape = Shape.Pipe });
styles.Add(new ElementStyle("FileStorage") { Background = "#000000", Color = "#ffffff", Shape = Shape.Folder });
            
         
            
            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);
        }
    }
}