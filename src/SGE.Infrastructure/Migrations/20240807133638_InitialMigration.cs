using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDismissed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Terms_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Terms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subscription_SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DismissedReminderIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalendarDictionary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessProcedures", x => new { x.Id, x.ProcessId });
                    table.ForeignKey(
                        name: "FK_ProcessProcedures_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DynamicTexts",
                columns: new[] { "Id", "Code", "DeletedOnUtc", "Description", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { new Guid("0016678f-3309-473a-bad5-5d08b1ac50f4"), "UsuarioServicioAuraPortalNew", null, null, false, "mintic/bpmimpersonate" },
                    { new Guid("0035a65e-31f2-414a-a468-a376e8dd01e3"), "CorreoCertificadoAplicacion", null, null, false, "TesAmerica" },
                    { new Guid("005cf096-cb7a-433c-9e73-bba8712a9c5f"), "Clases_Expedientes_Satelital", null, null, false, "92" },
                    { new Guid("00c15dcd-7324-4831-abd0-c2b7221104b6"), "CorreoCertificadoRemitenteDireccion", null, null, false, "Casa 1" },
                    { new Guid("01e94e6a-0679-4eb2-8f0e-afbfcb5cdc3c"), "CorreoCertificadoUsuario", null, null, false, "20230922-132449-805237-73089455" },
                    { new Guid("0212c6bd-4452-4863-bc8d-4f041596e5e2"), "Temp_File_Satelital_New", null, null, false, "C:\\SAGE\\Satelital\\Satelital_Back\\tempdatafile" },
                    { new Guid("026c8fb5-c2ef-4fdf-b6ee-d93adebe2922"), "Columna_Potencia_BB", null, null, false, "R" },
                    { new Guid("02d7d8ce-c261-4972-9b0e-2590e63f9e98"), "GraficaNacionalAtribucionesFrecuenciaLink", null, null, false, "http://www.mintic.gov.co/images/documentos/espectro_radioelectrico/cuadro_nacional/grafico_cuadro_nacional.pdf" },
                    { new Guid("04942bf6-d863-4e0f-809b-cc493ebae560"), "NombreMintic", null, null, false, "Ministerio TIC" },
                    { new Guid("0556e433-2364-4e98-951b-f9c3bc7bce67"), "CorreoCoordinacion_GGERE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("0581b663-d164-4121-b758-93a1863377a2"), "CorreosRequerimientoTotalBB", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("0592ca79-b45d-4782-8a69-c7d9ccb3f36c"), "EspTemp_ClaseExpediente", null, null, false, "90" },
                    { new Guid("063a01bf-c5a5-481f-9827-0beb59556eb8"), "ResumenTecnicoTexto", null, null, false, "En virtud de la(s) solicitud(es) de [TipoTramite_NumRadicado]" },
                    { new Guid("069fac62-d0a4-48d3-ac18-d87b98a09a11"), "FirmaElectronicaAZAplicativo", null, null, false, "20201209-092929-982602-00332255" },
                    { new Guid("0716f902-4cc3-468e-a903-80cf847e81bc"), "CorreoCertificadoCanalesAsunto", null, null, false, "Prueba Email Servicio Notificaciones" },
                    { new Guid("0778247c-02f1-43b2-a837-86d854d94d24"), "ExplanationDuplexerCreation", null, null, false, "Formulario de creación de duplexor" },
                    { new Guid("07c5d343-7ccf-4d46-b827-3581e467f27c"), "EspTemp_PuntajeTramite", null, null, false, "50" },
                    { new Guid("07cc40b2-ca1c-4b44-84a3-47a5777955e6"), "UrlImportSpectrumE", null, null, false, "http://simulacion.ane.gov.co:8088/se/portal/ane/loginproc.php?" },
                    { new Guid("0810c3d1-d10e-45de-bb5d-610ffb53fbc2"), "SystemDescription", null, null, false, "El Sistema para la Gestión del Espectro Radioeléctrico “SGE” permite a los titulares de permiso para el uso del espectro tramitar ante el Ministerio de Tecnologías de la Información y las Comunicaciones" },
                    { new Guid("0838eca9-bd9c-46a0-96c0-a5308b9e7347"), "FirmaElectronicaAZContraseña", null, null, false, "b1a8262799b1746913b4476ab1b17238" },
                    { new Guid("08c81848-daa2-452b-a530-73e957d1f4fe"), "RolesPermisoRevisionResoluciones", null, null, false, "2,3,4,5,6,7,22,57,59,60,61,62,76,77,78,79,99,100,108" },
                    { new Guid("09649a7c-753c-4300-9f67-55f4746654bb"), "CorreoCertificadoDocumentosTipoMime", null, null, false, "application/pdf" },
                    { new Guid("09dd56c0-ec07-403f-8831-2d5b27967935"), "FirmaElectronicaUrl", null, null, false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("09fdd00c-8561-429b-b9af-6ba6df8f0f6c"), "ExplanationApplicationFileUpload", null, null, false, "Aliste los siguientes documentos: Formato básico de solicitud" },
                    { new Guid("0a576d77-e937-43ac-85ba-b04896b932db"), "CorreoCopiaANE-MINTIC_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("0a988fc5-9879-4ce5-8478-8730b68062f5"), "ClasesExpedienteRTIC", null, null, false, "96,81,83,84,86,87,88,89" },
                    { new Guid("0b43287a-976d-4177-8dab-a6c6264db85a"), "GrandTypeRUES", null, null, false, "password" },
                    { new Guid("0c53041c-29c0-4740-9dda-2577408d617d"), "IMT_RadioBusquedaMetros", null, null, false, "2600" },
                    { new Guid("0c576827-651f-4466-ae0d-9fdf51baa77b"), "MainPatternAddress", null, null, false, "[a-z .;,:ñ¿?¡!(){}&%$_*+\\'@''/\\\\#|=º^¨~-]" },
                    { new Guid("0dca3501-a5fe-4a58-88be-00410e603a58"), "ApproveTechnicalAnalisisNaturaleza", null, null, false, "770" },
                    { new Guid("0f625984-2d1e-4791-b807-8eb687263ca1"), "ExplanationApplicationAdministrativeAnalysis", null, null, false, "El análisis administrativo de una solicitud es el primer proceso luego de su radicación." },
                    { new Guid("0f63069a-ac07-4b00-aa34-e8fc627151dc"), "ApiNotificaciones_PlantillaEmail", null, null, false, "EmailNotificacion.html" },
                    { new Guid("0fbc8367-413a-40ec-b0f8-58e598b0d583"), "EmailAnalisisTecnico", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("11063ea4-8f5f-49dd-9f5c-000c2efe9364"), "ExplanationApplicationInProccessFront", null, null, false, "Se listan las solicitudes que aún no han sido radicadas oficialmente en el sistema." },
                    { new Guid("117fc08b-ef0a-464c-82f6-761467419860"), "AZDigital_SitioSatelital", null, null, false, "TL" },
                    { new Guid("120580ca-4146-4155-b41f-939ca829199d"), "NombreAne", null, null, false, "Agencia Nacional del Espectro" },
                    { new Guid("138fef92-7463-49a1-bd5a-82044b38b694"), "FirmaElectronicaAZRol", null, null, false, "F" },
                    { new Guid("13da8cff-baa9-48c1-bbe0-aaa2b430cb6e"), "TiempoTokenMatrizANE", null, null, false, "50000" },
                    { new Guid("142c037a-135e-4e7e-89be-6d36bb42ec35"), "ServicioRUES", null, "Link de consumo para el servicio RUES", false, "http://10.100.101.174/r1/CO-QA/GOB/CONFECAMARAS-0001/RUES/" },
                    { new Guid("1693469b-b2e9-40da-a371-f0fd83632e6f"), "CorreoRechazoANE-MINTIC_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("170dab1e-3cd0-4b9d-b37a-f91ab05ecbe6"), "TechnicalInformationSummaryNetworkCount", null, null, false, "Número de redes de la solicitud:" },
                    { new Guid("1781adf3-5c95-4204-861a-efa9f1db72cc"), "xmlnsxsi", null, null, false, "http://www.w3.org/2001/XMLSchema-instance" },
                    { new Guid("179c504c-489b-4713-bb5d-aa0ed73685d0"), "FaxAne", null, null, false, "2436212" },
                    { new Guid("186276db-20c9-4252-93a3-fc8c1d2721ab"), "CorreoResumenTecnico", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("19ecde13-c303-4101-8fcc-5ae793b6f982"), "CuadroNacionalAtribucionesFrecuenciaLink", null, null, false, "http://www.mintic.gov.co/images/documentos/espectro_radioelectrico/cuadro_nacional/cuadro_nacional_atribucion_bandas_de_frecuencias_2010.pdf" },
                    { new Guid("1a98c50e-3930-4d7f-81b5-3f78a4d3559d"), "CorreoCoordinacion_GGCCG", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("1ab81415-2272-43c9-b105-57d91f289404"), "TextoRefRadicadoAnalisisTecnico", null, null, false, "Resultado de Análisis Técnico de la Solicitud con radicado MINTIC No. {0} del {1}." },
                    { new Guid("1b5b5e6f-d5c0-44e8-911b-3de11908012d"), "AZDigital_TramiteRegistroSatelital", null, null, false, "RPTA_S" },
                    { new Guid("1b9a8015-2205-4cb9-9afe-8c4b7b78d44b"), "CorreosSubsanacionOperador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("1cafb609-6d98-4453-bc2b-bed1f8085049"), "NitAne", null, null, false, "9003342653" },
                    { new Guid("1cba6312-6c30-4598-8792-b374954b049e"), "EstadosRedesVAC", null, null, false, "rAUT,rRES,rPRN,rPRE,rTT" },
                    { new Guid("1e2df1b8-f3ab-4be6-8537-9588647b1096"), "AZDigital_Resoluciones_TipoNotificacionFisico", null, null, false, "P" },
                    { new Guid("207ac85d-920f-4f48-a065-314baba12900"), "ExplanationApplicationDetailsArchivosSolDirectas", null, null, false, "Archivos necesarios: Cédula de ciudadanía" },
                    { new Guid("20b53539-954c-4b3d-908e-3ae49663e006"), "CorreoCertificadoRemitenteNombre", null, null, false, "Andres Rodriguez" },
                    { new Guid("20c222cb-65a4-463d-8dec-c511fbeb49d2"), "CorreoCertificadoRemitenteEmail", null, null, false, "silvia.mesino@analitica.com.co" },
                    { new Guid("22490912-5963-47c2-a5d3-7b06872787f9"), "EspTemp_CorreoRechazoANE-MINTIC", null, null, false, "solicitudesane@g.com" },
                    { new Guid("22e11f65-857c-4283-bd7c-7f0062e5b77b"), "CorreoRechazoMINTIC_ANE_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("2347af32-9920-47e8-9715-f9feb67d2257"), "AZDigital_IdDirectorioConsultaNOPSO", null, null, false, "24828" },
                    { new Guid("23b09fce-fcb8-4b7f-aa32-7ef556ffec7e"), "FirmaElectronicaAZEstado", null, null, false, "1-P" },
                    { new Guid("2574a3d0-afc3-4693-b0d2-f2633d941b36"), "FirmaElectronicaAZURL", null, "Link consumo para el servicio de firma electrónica (AZSign)", false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("25b434c5-0982-4d4d-9c57-b303c70dddc7"), "TiposResolucionRenovacionOtorga", null, null, false, "1" },
                    { new Guid("26eb8f73-9f3b-4b44-af58-aca77076e436"), "AZDigital_Dependencia", null, null, false, "Pru" },
                    { new Guid("270d4791-c8b6-4ed3-8c21-7cf24b25e93a"), "ExplanationApplicationClosing", null, null, false, "Las solicitudes en cierre se encuentran en proceso de generación de la resolución" },
                    { new Guid("29b2049a-b072-4067-bb69-c35ecedc0a0a"), "CorreoCertificadoCanalesEmailCertificado", null, null, false, "1" },
                    { new Guid("29e9a402-b423-4bf1-b0cd-83d9dece3247"), "FlashPlayer", null, "https://get.adobe.com/es/flashplayer/", false, "https://get.adobe.com/es/flashplayer/" },
                    { new Guid("2aec36b1-088e-48aa-a4ce-d0b3cacfae7d"), "FirmaElectronicaRefWebHook", null, null, false, "AZDigital: (5)" },
                    { new Guid("2b3c7ff9-a926-468c-b601-99eb1cac16ae"), "EspTemp_Hojas_Archivo_Tecnico", null, null, false, "1. Admin,2. Info General,3. IMT o PMP,4. Punto a Punto,5. Control de Cambios,Menu" },
                    { new Guid("2b7c865b-7985-4b2b-bd79-6abedef72105"), "CustomerFrontLegalInfo", null, null, false, "Es interés del Ministerio de Tecnologías de la Información y las Comunicaciones (TIC) la salvaguardia de la privacidad de la información personal del usuario obtenida a través del sitio web" },
                    { new Guid("2c3c4370-aff8-4ba6-ba81-23d3ba1a0427"), "CorreosAlertaCancelaciones", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("2ca958fd-0540-4a8b-b677-df908bfd8399"), "ExplanationPortfolioEdit", null, null, false, "Desde este formulario es posible modificar el nombre del expediente correspondiente al expediente seleccionado" },
                    { new Guid("2d1b9e70-7f09-4904-afb2-852b9ce53fd5"), "IMT_AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("2d4d9ca8-77f4-4114-94ce-6d0db93d81a4"), "Temp_File_Satelital", null, null, false, "C:\\SAGE\\SGE\\tempdatafile" },
                    { new Guid("2e015a7e-4521-4641-9b55-d7cbf6d1309c"), "Fecha_Subsanacion_Revisor_Satelital_Administrativo", null, null, false, "1" },
                    { new Guid("2e149328-5611-492a-97ae-11ba858e6a65"), "CorreosRadicacionSolicitudesPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("2e30dffe-4996-4704-b57c-61aab6008dc2"), "EspTemp_VersionFormatoAnexo", null, null, false, "1,1" },
                    { new Guid("2ea855cb-1b0d-4e15-b58a-0ab33ada2cbf"), "SerieDocumentalAlfa", null, null, false, "100" },
                    { new Guid("2ec7e9ba-aaed-4d05-be5b-818d4fd06fc8"), "Satelital_FirmaElec_Director", null, null, false, "dreinales" },
                    { new Guid("2f47a8da-1898-435a-8916-0fb0a98ec551"), "EmailAne2", null, null, false, "No disponible" },
                    { new Guid("317e0372-6f78-4011-99ba-0d2b0cb24697"), "Satelital_FirmaElec_SubDirector", null, null, false, "lpineda" },
                    { new Guid("3350a764-e8fa-429e-a73a-a155788e8f5f"), "ExplanationTechnicalInformationIndex", null, null, false, "Visualización de la información técnica de la solicitud" },
                    { new Guid("3440d178-e184-4d76-8266-bf0c306216cb"), "LogonMessageFront", null, null, false, "Señor funcionario" },
                    { new Guid("353671e9-6403-4cab-ac4a-41b062160243"), "EstadosExpedienteMuerto", null, null, false, "eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("3558ab9d-7c00-4c22-839f-0f0be6f39879"), "EmailAnalisisAdministrativo", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("359864e4-fbdf-4ca3-81b7-2e706cb4ef34"), "ApproveTechnicalAnalisisSerieDocumental", null, null, false, "Serie Documental" },
                    { new Guid("35ca78cf-44ee-4f75-b89a-0b6100724a51"), "ExplanationApplicationCreation", null, null, false, "Por favor ingrese la información requerida para crear una nueva solicitud" },
                    { new Guid("369280d6-03b5-4177-85f0-d5d16de0e801"), "AZDigital_IdDirectorioRadicadoSatelital", null, null, false, "102235" },
                    { new Guid("37e2445c-b828-409d-baca-b68049d268da"), "SolFisicaDiasAdicionalFechaVenc", null, null, false, "60" },
                    { new Guid("384e98f7-9616-4079-bdf8-fcd31bf0658e"), "CorreoInformeEvaluacion", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("39576863-118e-444d-ab25-f1f0edf19b11"), "TokenTMP_SecretKey", null, null, false, "F4209FA7-FAF6-4BF0-8A5E-783BE439DF9E" },
                    { new Guid("39607d60-9828-49c1-ac4e-69bce06d9908"), "CorreosDocumentosRequeridosCoordinadorANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("39c60e2a-e96f-47cb-94b4-343607be7411"), "ApproveAdministrativeAnalisisWfTipo", null, null, false, "0" },
                    { new Guid("3a8974d8-89a8-4996-a80f-f86a65594bda"), "RutaGetConsultaRUES", null, null, false, "wsConsultaRUES" },
                    { new Guid("3bb443a2-a8ee-40fc-94d0-5c1d8a2b45ca"), "EspTemp_CorreoRechazoMINTIC_ANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("3bc19dbb-a859-4b62-b87e-6963cdf4c759"), "UrlLoginSpectrumE", null, null, false, "http://simulacion.ane.gov.co:8088/se/portal/ane/loginproc.php?" },
                    { new Guid("3cc45ec3-4540-4d93-bdff-228af4be9df2"), "TextoRefRegistroAnalisisAdministrativo", null, null, false, "Traslado para Análisis Técnico de la Solicitud con radicado No. {0} del {1}." },
                    { new Guid("3d01e3f6-9bd5-49f0-afa6-ba2cf9131b12"), "AlertBeforeAdministrativeAnalisisApprobation", null, null, false, "Señor funcionario" },
                    { new Guid("3d88b581-04cd-475b-b135-80a54b96e938"), "WfTipoAlfa", null, null, false, "0" },
                    { new Guid("3e0f30c6-8872-426f-85b9-34aa327e29d3"), "EmailMintic2", null, null, false, "No disponible" },
                    { new Guid("3e5d77fd-31d0-4459-bc2c-bdb9cb19e252"), "EmailMintic1", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("3e5f4f2d-7fbc-44d4-afd4-a88781dfd6b4"), "Cronograma", null, null, false, "2" },
                    { new Guid("3e929bbe-ed65-4d84-839c-8936e4bf722d"), "DestinatariosDesestimientoTacitoSatelitalpreliminarAne", null, null, false, "hernan.palta@tesamerica.com.co" },
                    { new Guid("4078ffa0-ad54-40d7-b49f-a0a5ca1a3c92"), "EmailAne1", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("416745e4-307e-48b1-a6d7-f7db94fb8bfa"), "UserAlfa", null, null, false, "usersage" },
                    { new Guid("42bdfda8-58f7-4765-84e7-bc3960e2989d"), "FirmaElectronicaAZCodificacion", null, null, false, "Base64" },
                    { new Guid("443c6ce6-4dd2-42eb-aef7-6e993e613ff3"), "RegistroTicUrl", null, "Registro de TIC", false, "http://www.mintic.gov.co/portal/604/w3-article-6398.html" },
                    { new Guid("4534e679-dfc8-4b64-a674-b69f67ec12d1"), "AlertBeforeFileDeleting", null, null, false, "¿Está seguro que desea eliminar este archivo?" },
                    { new Guid("4640bcea-d9d6-4f24-b580-99ab9795a92b"), "ServicioAuraQuantic", null, "Link de consumo para servicio AuraQuantic", false, "https://uatbpm-integraciones.mintic.gov.co:8001/ServiciosRUTIC/api/Rutic/ConsultarDatosAdministrativos" },
                    { new Guid("4790afb0-81b0-468a-99c4-e97b8ab3985c"), "FechaFinMantenimiento", null, null, false, "11/10/2023 23:00:00.000" },
                    { new Guid("4829ed49-14be-4c5e-bca2-9492e92b479b"), "TelefonoMintic2", null, null, false, "No disponible" },
                    { new Guid("486a1f90-fb8e-4caa-b00e-2c351997e8c9"), "CorreoAprobacionMINTIC-ANE_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("48fec384-6f81-45dd-98bd-971b82175196"), "ApproveAdministrativeAnalisisCdDestino", null, null, false, "311" },
                    { new Guid("49dca48b-1c89-4435-acea-7d9c00e96a31"), "ExplanationFilesSummaryNoFiles", null, null, false, "No se han adjuntado archivos a la solicitud." },
                    { new Guid("4a1df364-88c4-4444-8650-92baebbd4b00"), "TextoNotificacionSigpol", null, null, false, "Señor usuario una de sus garantías presenta una novedad" },
                    { new Guid("4a21d9f9-8d3a-4649-90f0-8dcdae6c9fbc"), "DireccionAne", null, null, false, "Calle 93B # 16-47" },
                    { new Guid("4a3516b7-5322-4c30-8002-321230168f9e"), "FirmaElectronicaAZTipoPDF", null, null, false, "PDF" },
                    { new Guid("4a86e6cc-1e9e-4643-b752-036662e938cf"), "EspTemp_CorreoAprobacionMINTIC-ANE", null, null, false, "Solicitudesdeespectro@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("4c31ec91-4f9d-4ba5-9e31-ddacf30b0fab"), "Resolucion", null, null, false, "485 de 2024" },
                    { new Guid("4da93616-3b57-4e80-91c9-a64d7ddbd852"), "FirmaElectronicaAZTipoFirma", null, null, false, "E" },
                    { new Guid("4dc169a8-35ab-43ee-a625-c2a8608f65f8"), "ApiNotificaciones_TipoMime", null, null, false, "application/pdf" },
                    { new Guid("5057e9c1-07d8-48d2-914f-0cf819ece4e6"), "DireccionMensajeMaximoCaracteres", null, null, false, "En el anexo solo se pueden ingresar máximo 49 caracteres en la dirección de la estación." },
                    { new Guid("50eb14c8-0b3c-412f-bb8c-c2d75f010ab4"), "NumeroArchivosRadicacionSolDirecta", null, null, false, "9" },
                    { new Guid("5191a74c-e278-4edc-85ca-21a922ebbe0c"), "ExplanationApplicationRedes", null, null, false, "Por favor seleccione las redes del expediente seleccionado que desea incluir en el certificado." },
                    { new Guid("519c0073-e93f-47f4-8508-ad44913126d6"), "DocumentosSGE_URL", null, "URL de documentos del SGE", false, "https://cert-gestion-espectro.mintic.gov.co/DocSGE/DocSGE_Front" },
                    { new Guid("5263813d-079e-49f3-bf22-083b090e1594"), "NombreArchivoAlfaRadicarArchivo", null, null, false, "Radicación_Archivo_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("528c838e-2772-4235-ad83-4b6cb1f9a976"), "Satelital_CorreoFinResolucionMINTIC", null, null, false, "ebernate@g.com,kballen@g.com,carengifo@g.com,crojas@g.com,aruiz@g.com,nmendez@g.com" },
                    { new Guid("535c2ea9-62fd-40fa-8e40-c258772e0ef3"), "WfTipoAlfaInterno", null, null, false, "1" },
                    { new Guid("54884fc3-6dba-43fd-ba8f-d4c74413e4e6"), "CorreosRechazoSolicitudMINTIC", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("570040fa-1f4c-4daf-a2a2-4405ace1c7fe"), "MensajeBloqueoCartera", null, null, false, "Señor usuario" },
                    { new Guid("5737dabd-51d3-46da-8bc0-4d5ca1145888"), "ExplanationApplicationCreationPortfolio", null, null, false, "Debe hacer una solicitud por expediente y la documentación debe corresponder al expediente que está tramitando." },
                    { new Guid("589d0dbd-ed94-4dfe-9aea-fc003f3592ee"), "CorreosDesmarcacionLocalidad", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("58e5697b-273a-49d1-89ac-5e5ff1195e0b"), "AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("5960b033-8fae-4a32-b087-5ff2ddfe7d21"), "DependenciaAlfa", null, null, false, "sage001" },
                    { new Guid("596ef3fc-2718-471a-9ee5-28e1507bd583"), "TermsAndConitions", null, null, false, "Términos y condiciones: como usuario de la aplicación" },
                    { new Guid("5a008a47-0a7f-47fb-9685-3fc9d2450811"), "FilesSummaryFilesCount", null, null, false, "Número de archivos adjuntos:" },
                    { new Guid("5a08ed52-8187-437e-822c-33c2db9e3732"), "ExplanationEquipmentCreation", null, null, false, "Formulario de creación de equipo" },
                    { new Guid("5af67271-d998-484e-b3cd-0ac4aa447641"), "DiasRevisionRadicadosAlfa", null, null, false, "30" },
                    { new Guid("5b54a19a-ac71-4bcf-8df1-6a7ebd34bccf"), "IMT_CorreoRadicarMinticyANE", null, null, false, "Solicitudesdeespectro@g.com,juan.benavides@tesamerica.com.co,dircom@g.com" },
                    { new Guid("5bba3ff2-8214-4b15-992e-a03282346309"), "CorreoCertificadoCanalesMerge", null, null, false, "0" },
                    { new Guid("5bccb689-0900-48fe-aa39-03c1fa3a0c0d"), "http://www.mintic.gov.co/", null, null, false, "http://www.mintic.gov.co/" },
                    { new Guid("5cb374fa-facf-4436-aa99-a2fc4daa79cf"), "MensajePrevioMantenimiento", null, null, false, "El Ministerio de Tecnologías de la Información/Fondo Único de TIC informa que el próximo <b>{0} hasta las {1}</b> realizara mantenimiento al aplicativo. <b>Durante este mantenimiento los servicios no estarán disponibles.</b> Agradecemos su comprensión no ingresando a la aplicación en esta franja de tiempo." },
                    { new Guid("5d8a6cef-461c-4192-bc1b-010b6e4a5190"), "CorreoAprobacionMinTIC", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("5d959f8e-129a-4413-91db-8bb26fa07e5a"), "CorreoCertificadoCanalesMensaje", null, null, false, "Mensaje del Email Pruebas" },
                    { new Guid("601cd206-63a8-4781-81c6-1d7eaf2af17f"), "SubdirectorIndustria", null, null, false, "gperdomo" },
                    { new Guid("60e9c8ae-628c-4eb2-90a3-a802669f3dc2"), "NombreArchivoAlfaAnalisisTecnico", null, null, false, "Aprobacion_Tecnica_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("61af8a29-37da-4c5d-a58c-e0597e48a653"), "TokenTMP_TypeIdent", null, null, false, "NIT" },
                    { new Guid("6237d22b-25c9-4dd1-898d-44c81975bfa0"), "MailRevisorModuloResolucionesSinGarantia", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("6575d17c-a096-4438-9d66-1f786f7d21f8"), "TelefonoAne1", null, null, false, "3442299" },
                    { new Guid("65eb1fb9-8e3b-4721-8bca-52bba78b344e"), "NumeroArchivosRadicacion", null, null, false, "2" },
                    { new Guid("65f34f5a-0aa4-412f-a0f6-af62f6e54db9"), "EmailsNotificacionSubsanarDocumentos", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("66059265-b4cb-4e9b-a549-2607d557705a"), "IMT_IdEquip", null, null, false, "17363" },
                    { new Guid("669a2dc7-cfc1-48ba-ac2f-24a9f0fbdd96"), "MensajeCrearExpediente", null, null, false, "<div class='nombre_campo'><p style='margin:20px; text-align:justify;'>Señor usuario:</p><br/><p style='margin:20px; text-align:justify;'>El usuario acepta que a través del registro en el sitio web" },
                    { new Guid("66da2c81-7cb2-4694-ad4b-ea7ca021aa44"), "ApiNotificaciones_Action", null, null, false, "urn:/#NewOperation" },
                    { new Guid("6829b53d-fe66-495f-bf20-c5c908bf087f"), "PrivacyPolicy", null, "Ver el texto completo", false, "http://www.mintic.gov.co/index.php/privacidad-condiciones-uso" },
                    { new Guid("6833a455-fc33-4969-9556-3656fd9ffe4e"), "MensajeBloqueoGarantias", null, null, false, "Señor usuario" },
                    { new Guid("69675143-95d5-4fd2-9884-72c159e39810"), "CorreoDevolucionCT", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("69a0e83d-4edb-42fe-a5e7-64c906e7ad33"), "CausaRechazoNOSubsanar", null, null, false, "No cumplir con lo establecido en el numeral 1" },
                    { new Guid("6a71ea56-eab8-4e71-85fb-c6d1a094990e"), "DestinatariosDesestimientoTacitoSatelital", null, null, false, "hernan.palta@tesamerica.com.co" },
                    { new Guid("6aac5471-1c1b-407a-a3ee-1b643117913b"), "RequiredFieldImageMessage", null, null, false, "Campo requerido" },
                    { new Guid("6af5520b-787b-4464-8382-b9f12ec499ad"), "CorreoEnvioAdjuntoRadicarSatelitalANE", null, null, false, "Solicitudesdeespectro@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("6b9af352-c234-4797-a4fc-72157de3c5de"), "AZDigital_Resoluciones_UsuarioFirmanteVice_EspTemp", null, null, false, "svaldes" },
                    { new Guid("6bb63b55-f1b9-4dc5-be5e-da8c72d655d4"), "AlertBeforeDeleting", null, null, false, "Señor usuario" },
                    { new Guid("6c122575-b30c-4928-bc3c-cd16986dee9d"), "EspTemp_AZDigital_Dependencia", null, null, false, "Pru" },
                    { new Guid("6c67e627-4ea6-4f50-951e-59798b1d54c7"), "Satelital_Portada_MINTIC", null, null, false, "Ministerio de Tecnologías de la Información y las Comunicaciones; solicitudessatelital@g.com" },
                    { new Guid("6c831058-b78a-4d08-b9ca-f231ee0c78a1"), "CorreosAlertaCesionRedes", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("6c85f1b6-aa9c-4c77-a845-adccb07dd102"), "CorreoMinticSoporte", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("6cb374b4-2c5b-48f0-bfbd-5adb77a0774d"), "Subdireccion_Industria", null, null, false, "gperdomo@mintic.gov.co" },
                    { new Guid("6d364e78-8275-45bf-826c-4c0c1897ee46"), "RolesPermisoVerDocumentacionSolicitudesDirectas", null, null, false, "30,76,77,78,79,57,59,98,60,61,62,99,100,72,73,74,75,101,107,108" },
                    { new Guid("6de379ff-1b2e-45cb-a9ea-23ab2ff24609"), "CorreosCopiaOcultaRechazoSolicitud", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("6ee34894-d458-4682-9bed-dfa5309001c7"), "MensajeBloqueoRTIC", null, null, false, "Señor usuario" },
                    { new Guid("6ff3e6bd-8939-49b5-8abd-bec0ae5a3846"), "EspTemp_CorreoRadicarANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("70810161-e9f6-4ce6-b3f8-9c2d0ecdf6fe"), "EstadosExpedienteDatosContacto", null, null, false, "eREG" },
                    { new Guid("70bba558-96fa-44b4-b1d7-5bb8a871ab86"), "PasswordAlfa", null, null, false, "0qLpWZIlpg2zlKSYcj0D" },
                    { new Guid("71c1e55f-4458-4e65-b2c8-a6056857446c"), "AlertBeforeClosingApproval", null, null, false, "Señor funcionario" },
                    { new Guid("7237d74b-27a3-4879-85a8-2880331ff093"), "EspTemp_AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("72435b41-2bc9-45e0-95f9-086886fa9aca"), "CorreoEnvioANE-MinticNOPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("72709919-3e19-44f8-bbcd-0860225f72a4"), "LegendCantFilegApplicationDetails", null, null, false, "Información faltante para radicar la solicitud" },
                    { new Guid("73d5bf51-c9e8-45b5-b996-c1e23b62c18d"), "AZDigital_TramiteRadicadoSatelital", null, null, false, "PQRSD" },
                    { new Guid("75813358-d327-46f0-9e5a-4fad4e79d161"), "ApproveAdministrativeAnalisisSerieDocumental", null, null, false, "Serie Documental" },
                    { new Guid("75cf8851-3f25-424d-97e5-2769146e4af5"), "PaginaMinisterio", null, null, false, "http://www.mintic.gov.co/" },
                    { new Guid("76244e4b-238d-4f22-bc00-06bfa5ab37c2"), "AZDigital_TramiteRegistro", null, null, false, "rs" },
                    { new Guid("765d2a57-7792-4c26-9683-2c06e5bac94f"), "LegendFilingApplicationDetails", null, null, false, "Radicación de la solicitud" },
                    { new Guid("776baf69-d1a2-40ff-b508-f7ec1e95778d"), "TextoDetalleAlfaRechazoSolicitud", null, null, false, "Notificación de Rechazo de la Solicitud: {0}" },
                    { new Guid("7857e8fb-2c19-47d2-bde3-c67199f7acbf"), "xmlnsazs", null, null, false, "http://www.analitica.com.co/AZSign/Esquemas" },
                    { new Guid("78ecf4b5-f3a8-476f-8e0c-8231aee0c970"), "CorreosSubasanacionANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("79b7eaea-65e1-4b71-b98d-02f2cf10d17f"), "MailSmtpHost", null, null, false, "smtp.gmail.com" },
                    { new Guid("79ce8765-8d74-4c43-87ea-95f9c624c29c"), "IMT_Temp_File", null, null, false, "C:\\SAGE\\CargueIMT\\IMT_Back\\tempdatafile" },
                    { new Guid("79eb6207-b467-4052-9596-3ab5b43cf96e"), "TechnicalInformationSummaryNetworkNumber", null, null, false, "Red número:" },
                    { new Guid("79edbd2c-61ba-4023-bc73-c9283c26af7e"), "CorreoRemitente", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("7b6a5203-6940-4347-b9b7-65827fbe8ca9"), "TelefonoMintic1", null, null, false, "3443460" },
                    { new Guid("7bb8c609-011e-4155-a6a2-2d0edc658392"), "AZDigital_Resoluciones_TipoActo", null, null, false, "R" },
                    { new Guid("7bd5b24e-80e7-4ae1-be01-96a338b5659b"), "Clases_Expedientes_Industria", null, null, false, "97,95,20" },
                    { new Guid("7bdc7ca7-083c-420b-b277-fb9b54f02157"), "ExplanationEquipmentList", null, null, false, "Para el caso de monitores de modulación y monitor de frecuencia y la línea de transmisión en las redes de radiodifusión sonora (AM" },
                    { new Guid("7c0d2eb6-8bd2-4ae8-9d0b-8b886eec868e"), "MensajeAdvertenciaRTICDiferenciasPSO", null, null, false, "Señor usuario" },
                    { new Guid("7c190396-2db3-4d0c-980d-b3b42840b54c"), "MotivoRechazoGarantias", null, null, false, "No cumplir con lo establecido en el numeral 3 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("7c481de0-40bd-45c3-8293-c893420ed47c"), "AZDigital_Resoluciones_UsuarioFirmanteDir_EspTemp", null, null, false, "nalmeyda" },
                    { new Guid("7cc10f5c-217c-4829-9c9d-4c84da9bea9a"), "EspTemp_AZDigital_TramiteRegistro", null, null, false, "rs" },
                    { new Guid("7d1ed80e-5de3-4e01-bae6-516f8b560ea3"), "CorreoCertificadoContraseña", null, null, false, "2eca78d9b47f82705c9bbc5efe71cd95" },
                    { new Guid("7d332df8-0269-40f7-8bb1-398b2ed751d4"), "AZDigital_Sitio", null, null, false, "Prue" },
                    { new Guid("7da247ae-f45f-4ce5-b81b-c7212a2166ad"), "Garantia_Director", null, null, false, "Director de Industria de Comunicaciones" },
                    { new Guid("7dd90ed9-4e74-48ac-9643-af2522c1d6ff"), "ExplanationApplicationEdit", null, null, false, "Puede asignar un nombre personalizado a esta solicitud" },
                    { new Guid("7e5735ad-ec1a-4a4f-8992-5c5f121ec673"), "NombreArchivoAlfaClosing", null, null, false, "Aprobacion_Final_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("7f03e5d9-285c-4c5f-bcdd-52db9f8669f9"), "CoordinadorPSO", null, null, false, "ogarzon" },
                    { new Guid("7f82c4b4-4504-40c8-9341-ee6286dd7a89"), "TelefonoAne2", null, null, false, "No disponible" },
                    { new Guid("7f9412d2-7dd8-41c9-a3df-db0515b1ca56"), "AZDigital_DependenciaSatelital", null, null, false, "2.2.0.1" },
                    { new Guid("7fa3c41e-dca5-4119-ac8e-7f35bfb1ab4a"), "AZDigital_Resoluciones_ProcedeRecurso", null, null, false, "Rep10" },
                    { new Guid("7fb068df-8ea2-4911-b8a4-27308616020a"), "MensajeAdvertenciaRTIC", null, null, false, "Señor usuario" },
                    { new Guid("7fb6bad3-f8b7-4dc7-b666-c90fa96dae6c"), "CodigoDestinoMintic", null, null, false, "pru001" },
                    { new Guid("802cdb00-efa6-4a0c-a531-11917f777adf"), "CorreoEnvioRadicarSatelitalANE-Mintic", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("802e3f49-9984-4102-aa5e-0e96d6d14cd7"), "UrlFirmaElectronica", null, "URL de consumo para el servicio de firma electrónica", false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("81c6aed1-6472-4903-95f1-a5c6813f8dbc"), "TextoDetalleAlfaRadicacion", null, null, false, "Radicación de la Solicitud: {0}" },
                    { new Guid("828d27ef-7aa0-4752-ac56-419a12e41bdb"), "DireccionMintic", null, null, false, "Edificio Murillo Toro Cra. 8a entre calles 12 y 13" },
                    { new Guid("82f073eb-cd30-4247-abef-244df5be3210"), "TextoDetalleAlfaRadicarArchivo", null, null, false, "Notificación de Radicación de Archivo  de la Solicitud: {0}" },
                    { new Guid("8322d348-b538-4083-aac6-5eb7fdfefab0"), "CityCodeAne", null, null, false, "11001" },
                    { new Guid("83396024-806c-4c8f-8f6a-1d8e9a114079"), "CorreosMarcacionLocalidad", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("83f24809-335b-497c-9860-7453a9aab463"), "ExplanationAntennaCreation", null, null, false, "Formulario de creación de antena" },
                    { new Guid("84f08673-fb43-456c-9c58-8c8e9a95ab26"), "ExplanationApplicationFileList", null, null, false, "A continuación se listan los archivos adjuntos a la solicitud seleccionada." },
                    { new Guid("860d7010-e128-4679-acae-2c734609fc99"), "ExplanationRejectApplication", null, null, false, "Por favor ingrese la información requerida para rechazar la solitud" },
                    { new Guid("863acef6-da69-49a0-8621-e6ec0f4283f0"), "MailUsername", null, null, false, "Soporte Tesamerica" },
                    { new Guid("864e3730-3b17-4a88-82a4-4c7d1b1c8982"), "CorreoDesistimientoOperador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("865f55e6-4ee2-456f-bee8-e3bffbfacf53"), "Fecha_Subsanacion_Revisor_Satelital_Tecnico", null, null, false, "10" },
                    { new Guid("86f000cc-aa5c-4578-b3ae-73cbf6a0df72"), "CorreoAprobacionANE-MINTIC_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("875ee931-f420-4707-9a26-6fbde62bd285"), "ExplanationPortfolioGrid", null, null, false, "Listado de expedientes. Utilice los íconos frente a cada expediente para observar los detalles o editar. Si no encuentra el número de expediente deseado" },
                    { new Guid("88167de4-1212-4865-bc6f-2d1d24860133"), "CorreosAletaBloqueos", null, null, false, "andres.rodriguez@tesamerica.com.co,bloqueos@g.com" },
                    { new Guid("88c13635-3312-43e9-8fd8-afd510c2c27c"), "EspTemp_CorreoAprobacionANE_MINTIC", null, null, false, "solicitudesane@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("88ee5bb1-fe92-4f05-bd0a-084514beb9ff"), "ExplanationApplicationInProccess", null, null, false, "Se listan las solicitudes que aún no han sido radicadas oficialmente en el sistema." },
                    { new Guid("89153050-9fb6-4422-b10b-1284853a0b54"), "CorreoCertificadoRemitenteCargo", null, null, false, "Representante Legal" },
                    { new Guid("8a4f1870-66a0-445d-a2b3-f4d2e81fe1f0"), "AdvertenciaFlash", null, null, false, "Para el correcto funcionamiento de la herramienta es necesario actualizar Flash Player" },
                    { new Guid("8d3f8c13-a9f5-4f0f-8afc-e48e8e7d6269"), "ExplanationTechnicalInformationSummaryNoInfo", null, null, false, "No se ha ingresado información técnica a la solicitud." },
                    { new Guid("8e7623f9-7792-4879-babe-ebf0976ed665"), "Fecha_Subsanacion_Coordinador_Satelital_Tecnico", null, null, false, "5" },
                    { new Guid("8e82f186-f26e-46be-b539-5fa440786ac9"), "TiempoAutoguardadoMilisegundos", null, null, false, "300000" },
                    { new Guid("8e8adb86-eb35-4cf1-9d0e-f61ee5388df7"), "NitMintic", null, null, false, "89999953-1" },
                    { new Guid("8ecbf928-01ae-495a-ad23-e39b08b471a1"), "TextoDetalleAlfaClosing", null, null, false, "Notificación de Aprobación final de la Solicitud: {0}" },
                    { new Guid("8fce5aab-804b-4888-84b8-ac85b2366ffa"), "MailSmtpPassword", null, null, false, "Tesamerica123*" },
                    { new Guid("8fe2407a-5ff4-42a0-a536-8837dceb9b9d"), "FirmaElectronicaAZTipoMime", null, null, false, "application/pdf" },
                    { new Guid("90014ed7-34e1-45da-a558-f7de05b877da"), "CorreoCertificadoCanalesPlantillaEmail", null, null, false, "EmailNotificacion.html" },
                    { new Guid("906332fb-b7a7-49b6-b89f-751544ae11b3"), "CorreosAlertaCesionExpediente", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("910b729a-db6e-48be-a45b-ef37eb4d9c52"), "CertificacionCarteraTextoFirma", null, null, false, "Coordinadora GIT de Cartera" },
                    { new Guid("91e066bc-0022-4988-9f23-3a7409e2facd"), "ExplanationDuplexerList", null, null, false, "Seleccione el duplexor desde la lista de selección para ver los detalles. Si el duplexor no se encuentra puede crearlo haciendo clic en el botón 'Nuevo duplexor'" },
                    { new Guid("9248f6a9-2220-494f-a83d-787455c4c8d7"), "EsPrueba", null, null, false, "true" },
                    { new Guid("92623f3d-9cab-4b31-a796-69b92c7afed0"), "CorreosCreacionPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("92efdd16-59e4-43e2-aed9-530034f48898"), "AlertBeforeRadicationAdicional", null, null, false, "Sr. Usuario" },
                    { new Guid("95ffeec3-0b0d-475f-b90e-f9360aee2ea6"), "EspTemp_AZDigital_Sitio", null, null, false, "Prue" },
                    { new Guid("96072f5e-bce9-4ccc-b0ab-49050f7ee4bd"), "EstadosExpedienteNoUsadosFueraPSO", null, null, false, "eVEN,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("96a45ec4-acc1-4031-a338-a44e259387ed"), "CorreosRechazoSolicitudANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("9714d8e9-00b0-424c-a9bf-f475fa838df1"), "PasswordRUES", null, null, false, "k272ki8bLnLpFK7aUuUEzw==" },
                    { new Guid("972c310f-39d6-4b68-8443-c72a3376bf73"), "AZDigital_Resoluciones_UsuarioFirmante", null, null, false, "nalmeyda" },
                    { new Guid("97ef0cdf-5685-4ecc-9f44-6934311925ea"), "MotivoRechazoCartera", null, null, false, "No cumplir con lo establecido en el numeral 2 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("98677421-f096-4502-ae80-daeb550a1fcc"), "Temp_File_EspectroTemporal", null, null, false, "C:\\SAGE\\EspectroTemporal\\EspectroTemp_Back\\tempdatafile" },
                    { new Guid("986bb4d8-3818-4d87-ba44-bcead835e3de"), "BDU_Clase", null, null, false, "92" },
                    { new Guid("998625e3-0044-4cda-a093-cbca7f8b28be"), "SubdirectorPSO", null, null, false, "gperdomo" },
                    { new Guid("9a752c61-fe38-41bb-a607-b46e91e8bd66"), "VersionFormatosAnexos_Satelital", null, null, false, "V1.4" },
                    { new Guid("9a982c71-4094-421d-a94f-36ee7a331829"), "EmailFinalizada", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("9bcc44f9-48e0-4adc-9ce9-e3835afdb401"), "LogonMessageAdic", null, null, false, "o envíe un correo a minticresponde@mintic.gov.co" },
                    { new Guid("9caa5335-3d28-4b60-85b5-23c2dc87cea6"), "RolesPermisoRevisionOficio", null, null, false, "73,74,75,101,107" },
                    { new Guid("9cb2669b-d918-4487-b982-63295a579fca"), "UbicacionDocumentosSGE", null, null, false, "C:\\SAGE\\DocumentosSGE\\" },
                    { new Guid("9f81aa07-4f29-46aa-b5f8-b28b0fd2173c"), "CorreosAletaBloqueoRUTIC", null, null, false, "andres.rodriguez@tesamerica.com.co,rutic@g.com" },
                    { new Guid("9f99fdf8-f275-49fe-9bed-09b6d8fc1ff3"), "FirmaElectronicaAZUsuario", null, null, false, "20201209-092929-982602-00332255" },
                    { new Guid("9fb54989-cd9b-466f-b510-5a52b0ee801d"), "MensajeAdvertenciaRTICDiferenciasNOPSO", null, null, false, "Señor usuario" },
                    { new Guid("a010a04e-37d1-488f-9a3d-49439db3b730"), "ExplanationApplicationDetailsEditarInfoTecnica", null, null, false, "Señor usuario" },
                    { new Guid("a04ff1f5-be86-4027-a6d3-74e0dbea6b92"), "AlertBeforeRadication", null, null, false, "Señor usuario: tenga en cuenta que una vez radicada la solicitud" },
                    { new Guid("a0c662b4-a88b-4dde-81e0-3d60a36d014b"), "ExplanationApplicationDetailsRadicar", null, null, false, "Señor usuario" },
                    { new Guid("a221eb83-89a0-4de7-90ad-fc0ef227ba6c"), "Temp_File_Espectro_New", null, null, false, "C:\\SAGE\\EspectroTemporal\\EspectroTemp_Back\\tempdatafile" },
                    { new Guid("a381e166-e265-46e6-a813-e11dd82f4418"), "FirmaElectronicaAZCuenta", null, null, false, "20201120-151412-85f600-89728214" },
                    { new Guid("a3b6ef1d-28ee-4a6b-875b-d707b511e732"), "EspTemp_TextoReqPorAnexoTec", null, null, false, "Anexo Técnico para permisos temporales: Para agilizar la evaluación técnica de la solicitud en curso" },
                    { new Guid("a6ac8e7a-7cf4-4cb0-8a14-61967ef831df"), "EstadosExpedienteRadicacionSerie", null, null, false, "eRES,eCT" },
                    { new Guid("a6c06d6e-6cb9-410a-a924-c2ff583ae028"), "MensajeInfoNOPSO", null, null, false, "Las solicitudes que se realizan en esta sección corresponden a las que pueden ser tramitadas fuera de un Proceso de Selección Objetiva- PSO" },
                    { new Guid("a713604d-5748-43aa-920b-6d80eca1d19d"), "CorreoCertificadoDocumentosCodificacion", null, null, false, "Base64" },
                    { new Guid("a7551bb0-70ff-456d-9a81-7f22e9275eba"), "IMT_AZDigital_Sitio", null, null, false, "TL" },
                    { new Guid("a7fd17cb-4ded-4f72-9df7-f15188494e81"), "CorreosDocumentosRequeridosCoordinador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("a8107b24-c6da-49e2-9d21-dda423647f1c"), "CorreoEnvioANE-Mintic", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("a99c47e7-9cce-46fa-9de9-5ed5921e26d6"), "CorreoRadicadoANEPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("aba3239a-b9a9-4b71-bc7b-fc38d08a2219"), "ApproveAdministrativeAnalisisNaturaleza", null, null, false, "770" },
                    { new Guid("abceca27-f5fb-48a7-b6b8-77c7e0b1f182"), "FechaInicioMantenimiento", null, null, false, "11/10/2023 20:00:00.000" },
                    { new Guid("acbe939d-0227-461a-b849-08e5a72fc781"), "MotivoRechazoRUTIC", null, null, false, "No cumplir con lo establecido en el numeral 1 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("ad1ab065-bb4a-45b8-ae87-02510963ae0a"), "EspTemp_PortadaANE", null, null, false, "Agencia Nacional del Espectro;Solicitudesdeespectro@g.com" },
                    { new Guid("ad5f9d03-a1f9-4936-9d63-64eaeed7fff9"), "NombreArchivoAlfaRadicacion", null, null, false, "Radicacion_Solicitud_{0}_{1:ddMMyyHHmmss}.xml" },
                    { new Guid("ad690c18-a3e2-4c2e-8acf-bb436d377941"), "ExplanationApplicationSolve", null, null, false, "Consulte el histórico de las solicitudes finalizadas" },
                    { new Guid("aedb9685-c318-4bcf-812b-d19890247b0e"), "PointToPointAndPointToMultipointExplanation", null, null, false, "Si por algún motivo" },
                    { new Guid("af013cfc-6997-4473-ae62-97eba2f6b487"), "AlertBeforeRadicationError", null, null, false, "Señor operador" },
                    { new Guid("aff20858-bf5b-44f9-9020-006e5b82db41"), "ExplanationApplicationDetailsAnexarArchivosFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("b076140b-279a-4ad9-9ebf-23c9f187ac2c"), "IMT_AZDigital_Dependencia", null, null, false, "2.2" },
                    { new Guid("b2aa776c-6bbe-4f4a-85cb-7730d2d55e0a"), "EspTemp_CorreoRadicarMintic", null, null, false, "solicitudesane@g.com" },
                    { new Guid("b2be487d-6824-4d48-8df5-aa1733cf3116"), "TextoFirmaCertificadoEspectro", null, null, false, "Asesora del Despacho del Viceministerio de Transformación Digital encargada de las funciones del Subdirector para la Industria de Comunicaciones" },
                    { new Guid("b2d96c72-6d48-4b78-8807-70a0cd2ca854"), "DireccionMensajeFormato", null, null, false, "El formato para ingresar la dirección de la estación en el anexo es: Identificación de la vía (calle" },
                    { new Guid("b2e7ed78-a0c2-44f3-b6af-bd6e2829e110"), "MensajeInfoEmergenciaSeguridad", null, null, false, "Las solicitudes que se realizan en esta sección se encuentran exceptuadas del procedimiento de selección objetiva" },
                    { new Guid("b331b022-21e9-41bd-beaa-f2420fc2e015"), "CertificacionGarantiasTextoFirma", null, null, false, "Coordinador GIT de Gestión de Garantías" },
                    { new Guid("b520c9cf-2231-40f4-8166-2f45188dcf9b"), "TokenTMP_User", null, null, false, "Sistema de Gestión del Espectro" },
                    { new Guid("b58c7d1d-b939-459c-8f9b-29c8fc504d2d"), "MailDesarrolladorModuloResolucionesSinGarantia", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("b58ec8de-b27b-4877-b145-29ca0397d30c"), "CustomerFrontContactInfo", null, null, false, "Para dudas o inquietudes respecto a la funcionalidad de esta aplicación" },
                    { new Guid("b6a4a00e-293e-4a1c-87c0-6ac93464f25e"), "PasswordServicioAuraPortalNew", null, null, false, "1mp3rs0n4t3." },
                    { new Guid("b6ca427b-b72b-427c-a398-06dbfbe81ce1"), "AZDigital_IdDirectorioRadicadoNOPSO", null, null, false, "6369" },
                    { new Guid("b70120c3-f2e4-4238-a240-c6de477b4b81"), "LogonMessage", null, null, false, "Escriba su usuario y contraseña de Registro TIC" },
                    { new Guid("b7bc4d49-e472-451d-bc2c-f0533e0dff31"), "AZDigital_IdDirectorioRadicadoPSO", null, null, false, "6369" },
                    { new Guid("b7d4bb5c-1256-40b6-8e01-2ec7bb888b31"), "CorreoTesamerica", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("b8b062da-b956-4b57-a140-fbccef6fc95c"), "AZDigital_Resoluciones_UsuarioFirmante_EyS", null, null, false, "svaldes" },
                    { new Guid("bb2ac050-4778-4a7b-b799-538c9cc5b856"), "AutenticacionTMP_Pruebas", null, null, false, "https://pruebas.tesmonitorplanning.com/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=" },
                    { new Guid("bfd73b65-0655-45e4-90a4-d5e568993a11"), "CorreoRechazoMintic-Mintic", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("bfd96605-d094-46d0-8fd4-9afeeb5fe632"), "AdvertenciaNavegador", null, null, false, "Te recomendamos usar los siguientes navegadores para que tu experiencia con el SGE sea óptima: <img style='width:16px;vertical-align:text-bottom;' src='/content/images/icons/chrome24.png' alt='Icono del navegador Google Chrome'>Google Chrome V.49 y <img style='width:16px;vertical-align:text-bottom;' src='/content/images/icons/firefox24.png' alt='Icono del navegador Mozilla'>Mozilla Firefox V.42 o versiones superiores." },
                    { new Guid("bfeb9750-e294-4dba-9abd-f378890aa801"), "Fecha_Subsanacion_Coordinador_Satelital_Administrativo", null, null, false, "1" },
                    { new Guid("c164f8cf-f456-4102-9583-fbafe3462529"), "RolesPermisoModuloResoluciones", null, null, false, "1,2,3,4,5,6,7,10,21,22,30,57,59,60,61,62,72,73,74,75,76,77,78,79,98,99,100,101,107,108" },
                    { new Guid("c1fae8fa-6c47-4e12-bcbf-7a7b89238e23"), "xsischemaLocation", null, null, false, "http://www.analitica.com.co/AZSign/Esquemas file:///F:/AZSign/Producto/AZSign/WebServices/WS-AZSign.xsd" },
                    { new Guid("c2ff5fd8-6c80-48ee-a803-b094364fb63b"), "ExplanationApplicationDetailsAnexarArchivos", null, null, false, "Señor usuario" },
                    { new Guid("c315a102-7f55-401f-ad15-be796413079d"), "EstadosRedesSolicitudCanFrecBB", null, null, false, "rAUT" },
                    { new Guid("c32233ec-59c9-47e0-83b8-0f8e6cbf13b0"), "CorreoCertificadoDocumentosMerge", null, null, false, "0" },
                    { new Guid("c3becca1-f8b2-4907-86d6-b2b620c7baf1"), "ApiNotificaciones_Aplicacion", null, null, false, "TesAmerica" },
                    { new Guid("c3e8d1b5-2ec7-4e86-9783-d394efa884c1"), "CorreosCargaCT", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("c41586a3-212f-4e83-ac42-e5e9a2e45d8a"), "MetodoEnvioAlfa", null, null, false, "TL" },
                    { new Guid("c689c23c-48f9-4a82-9e5f-61c253a6ff5c"), "AZDigital_Resoluciones_Dependencia", null, null, false, "100" },
                    { new Guid("c6c56707-feea-4678-92d9-923cba441bf5"), "ExplanationApplicationCertificados", null, null, false, "Por favor seleccione el tipo de certificado" },
                    { new Guid("c713dc54-0e12-4d53-a251-29640218fe4e"), "ExplanationApplicationDetailsRadicarFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("c735d196-d31a-4560-a44d-6ea94d686b3e"), "ExplanationTechnicalInformationEdit", null, null, false, "Información general y creación de antenas" },
                    { new Guid("c743682c-843b-4873-b066-7e52b49fdd7f"), "MensajeAdvertenciaGarantias", null, null, false, "Señor usuario" },
                    { new Guid("c7f6b172-c2dc-4b61-afd7-9e443760539a"), "ApiNotificaciones_Url", null, null, false, "https://integratic.mintic.gov.co/Notificaciones/Webservices/SOAP/" },
                    { new Guid("c8c1db01-8d25-4e00-abfa-d0f3e7e7b8b6"), "CorreoCopiaANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("ca1ab4e5-4bb7-4f4f-a480-810a278bf0e0"), "LegendSpectrumE", null, null, false, "Sistema de Simulación" },
                    { new Guid("cb12fd45-eb54-4bdd-8236-ffc7a3448af0"), "FirmaElectronicaNombre", null, null, false, "Prueba Documento AZSign PHP WS" },
                    { new Guid("cbc7834c-6947-4170-b8cf-2dfdb01235e2"), "CorreoCopiaMINTIC-ANE_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("ccf3ce2b-25d0-4367-a0de-38a999b36f0f"), "HeaderRUES", null, null, false, "CO-QA/GOB/MINTIC-0012/SISCD" },
                    { new Guid("cd76a9bd-80cd-4628-8f24-fa7edda86a10"), "EstadosExpedienteActivo", null, null, false, "eAUT" },
                    { new Guid("cd8f6fcf-ad43-4c74-b5b3-8d9762a2b592"), "EspTemp_CorreoCopiaMINTIC-ANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("cdba9a7a-9089-4e12-a055-f4e6b7546ffa"), "ApiNotificaciones_URIPlantilla", null, null, false, "TesAmerica.docx" },
                    { new Guid("cdf9df69-8e8d-41fe-9273-109fc368ba79"), "EstadosExpedienteSincronizacion", null, null, false, "eAUT" },
                    { new Guid("cf0709cd-ceea-473c-8d9a-14b72a02a748"), "ExcelAutoliquidador", null, null, false, "Use el botón 'Cargar formato excel' si desea liquidar múltiples redes mediante un archivo .xls previamente diligenciado. El formato puede obtenerse haciendo clic en el botón 'Plantilla formato excel'" },
                    { new Guid("cf81c923-6474-4ba8-a54f-ac86ca12ea5b"), "ExplanationAntennaList", null, null, false, "Seleccione la antena desde la lista de selección para ver los detalles. Si la antena no se encuentra puede crearla haciendo clic en el botón 'Nueva antena'" },
                    { new Guid("cf972bf9-6514-4090-97cf-0260ccd21d71"), "NombreArchivoAlfaRechazoSolicitud", null, null, false, "Rechazo_Solicitud_{0}_{1:ddMMyyHHmmss}.pdf" },
                    { new Guid("d014ef3a-665a-4eca-80ea-47977587ffdb"), "CorreoCertificadoURL", null, "Link consumo para el servicio de Notificaciones (IntegraTIC)", false, "https://cert-integratic.mintic.gov.co/Notificaciones/WebServices/SOAP/" },
                    { new Guid("d04319bf-05ef-421f-a066-9980c33936d8"), "MensajeAdvertenciaCartera", null, null, false, "Señor usuario" },
                    { new Guid("d0530c94-64a8-45f7-8ac7-e674db57a0ad"), "NombreArchivoAlfaAnalisisAdministrativo", null, null, false, "Registro_Fin_Analisis_Administrativo_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("d094b6ba-b334-4fc1-9479-03dd370e43b5"), "EspTemp_PortadaMINTIC", null, null, false, "Ministerio de Tecnologías de la Información y las Comunicaciones; solicitudesane@g.com" },
                    { new Guid("d0aac1ce-71f5-4083-af2e-95c4014734a0"), "CorreoAprobacionResolucionRevisor5", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("d289a4cb-d85f-4e1a-981c-0c3312e3c46b"), "FaxMintic", null, null, false, "No disponible" },
                    { new Guid("d2d5c45e-fc6e-4236-8995-0d0431b2b531"), "UsernameRUES", null, null, false, "UserMinTic" },
                    { new Guid("d3ca2233-e630-4ee3-9e67-8073dff1d8b2"), "TokenTMP_Email", null, null, false, "soporte.sge@mintic.gov.co" },
                    { new Guid("d3ea5a42-ff92-414c-ba31-f1f0e9cbcf70"), "CorreosSubsanacionOperadorCopiaOculta", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("d422fb92-3d4a-4d8e-b985-5cfd224f02c7"), "NaturalezaAlfaSolicitud", null, null, false, "100" },
                    { new Guid("d42e70db-89e0-4d3d-9953-569af2b695e2"), "ApproveTechnicalAnalisisWfTipo", null, null, false, "0" },
                    { new Guid("d43f199a-ef4a-45b1-b377-55a93a5ecfc4"), "MainPattern", null, null, false, "[ .;,:¿?¡!(){}&%$_*+\\'''#|=º^¨~-]" },
                    { new Guid("d4f9243b-5f9f-4c90-81f2-2b5880ac75c3"), "TokenTMP_Rol", null, null, false, "128" },
                    { new Guid("d5552320-810c-4a23-8139-231047c1311e"), "EspTemp_CorreoAprobacionResolucion", null, null, false, "solicitudesane@g.com,kballen@g.com,crojas@g.com,ligomez@g.com" },
                    { new Guid("d55ae10f-fc08-4bef-94b8-6454476d53ac"), "AZDigital_Resoluciones_TipoNotificacionCorreo", null, null, false, "CE" },
                    { new Guid("d74babd1-4431-4614-8f9e-24b913182752"), "AlertConfirmCreateObservation", null, null, false, "¿Está seguro que desea guardar el cambio?" },
                    { new Guid("d7c1fa1a-b0da-4b77-b696-861656909183"), "Satelital_Portada_ANE", null, null, false, "Agencia Nacional del Espectro;Solicitudesdeespectro@g.com" },
                    { new Guid("d8042a54-f702-45ea-aaea-717e1561f7d3"), "CityCodeMintic", null, null, false, "11001" },
                    { new Guid("d8333f6e-2e38-4a82-94a5-8d57c8ce47ed"), "FirmaElectronicaAZOrden", null, null, false, "0" },
                    { new Guid("da878e7e-97a3-497c-97c4-6c0ac0368e28"), "IMT_IdAntenna", null, null, false, "27374" },
                    { new Guid("dab02f8e-4b08-4d23-bdbc-c567777d6e20"), "EspTemp_Fecha_Subsanacion_Admin", null, null, false, "1" },
                    { new Guid("daff0b99-dc19-48fe-996c-eb4686714515"), "AutenticacionTMP", null, "https://espectro-co.ane.gov.co/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=", false, "https://espectro-co.ane.gov.co/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=" },
                    { new Guid("db06acc8-50f0-4111-a91f-0ed42bc81474"), "CustomerFrontProcessInfo", null, null, false, "El Sistema para la Gestión del Espectro Radioeléctrico “SGE”" },
                    { new Guid("db5e76d2-708a-48f6-ab14-b4ce700d6813"), "IMT_AZDigital_TramiteRegistro", null, null, false, "RPTA_N" },
                    { new Guid("dbf32b0a-028f-49f1-891d-f455273e6c2b"), "TextoDetalleAlfaAnalisisTecnico", null, null, false, "Notificación de Aprobación de Análisis Técnico de la Solicitud: {0}" },
                    { new Guid("dd4908a5-08e4-479c-ab6e-44251339505e"), "EspTemp_ExtensionArchivoPatronRadiacion", null, null, false, ".bmp,.gif,.heif,.heic,.jpg,.jpeg,.png,.psd,.svg,.tif,.tiff,.doc,.docx,.md,.odt,.pdf,.ppt,.pptx,.rtf,.txt,.xls,.xlsx,.7z,.rar,.zip" },
                    { new Guid("de561d31-a198-46ad-bf0c-fb5bdea89867"), "ServicioSGE-RUESLocal", null, "Link de consumo para el servicio SGE-RUES", false, "http://192.168.0.10:8749/api/rues/consultaRUES" },
                    { new Guid("df33afe0-2caa-4619-a6cd-0ffbb93eb531"), "ExplanationApplicationTechnicalAnalysis", null, null, false, "En el análisis técnico se efectuará un estudio detallado de la información técnica registrada para cada solicitud" },
                    { new Guid("df8ca8eb-3949-4708-a6a7-b0b9d7f02ba5"), "CorreoDevolucionProceso", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("e0c5fef9-2cf7-4277-a03e-6d521201863e"), "Garantia_Coordinador", null, null, false, "Coordinador del Grupo Interno de Trabajo Gestión de Garantías" },
                    { new Guid("e141510f-558a-4df0-9eef-ee14d9330e27"), "AZDigital_Resoluciones_UsuarioFirmante_Satelital", null, null, false, "nalmeyda" },
                    { new Guid("e1d5e3d2-00a6-49b7-9131-f82241d81d50"), "AlertBeforeTechnicalAnalisisApprobation", null, null, false, "Señor funcionario" },
                    { new Guid("e23be3a1-0815-4cbe-acd2-a5785b947459"), "ExplanationAdministrationGrid", null, null, false, "En esta sección podrá consultar o crear antenas y equipos y consultar reportes sobre información técnica y administrativa" },
                    { new Guid("e3631e64-65da-4dc9-8266-2326bb90bd46"), "ExplanationApplicationMessageListSummaryNoNotes", null, null, false, "No se encontraron anotaciones." },
                    { new Guid("e38f864b-6c7e-40dd-8e6a-198814c247ec"), "EstadosExpedienteNoUsadosCesion", null, null, false, "eRES,eCT,eBDU,eDEP,eIN,eREG,eVEN,eTER,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("e4bdc1cf-660d-40da-966c-1860926e6ece"), "MainPatternRazonSocial", null, null, false, "[^a-z]" },
                    { new Guid("e538f6f7-32c2-4179-9b67-132a4d1986bc"), "IMT_AZDigital_IdDirectorio", null, null, false, "132082" },
                    { new Guid("e559e442-fa6a-4b38-83dd-af4cd9b5208b"), "CorreosAletaBloqueoGarantias", null, null, false, "andres.rodriguez@tesamerica.com.co,garantias@g.com" },
                    { new Guid("e7a87cd5-93c1-4521-9758-756ecaa0a5c2"), "AZDigital_IdDirectorioConsultaPSO", null, null, false, "24828" },
                    { new Guid("e7b1c7d6-41a1-4c69-a86f-54ea09a029ae"), "RutaGetTokenRUES", null, null, false, "wsToken" },
                    { new Guid("e8092074-483d-44ba-adcb-5b6edf97b833"), "ApproveTechnicalAnalisisCdDestino", null, null, false, "311" },
                    { new Guid("e83e34d8-7c40-4114-a414-de109cc3abda"), "ExplanationApplicationDetailsEditarInfoTecnicaFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("ebdbe338-578e-4c0f-82f5-84fa8c44ea54"), "DestinatariosCCDesestimientoTacitoSatelital", null, null, false, "" },
                    { new Guid("ec292a28-6b3d-48d9-88e1-c4739accb1aa"), "TextoDetalleAlfaAnalisisAdministrativo", null, null, false, "Notificación de Aprobación de Análisis Administrativo de la Solicitud: {0}" },
                    { new Guid("ecb0da71-1162-4df8-9fba-1fbe110688cc"), "Garantia_Subdirector", null, null, false, "Subdirector de Industria de Comunicaciones" },
                    { new Guid("ee72243b-5c85-4695-983d-932ec5c134bf"), "EspTemp_CorreoCopiaANE-MINTIC", null, null, false, "solicitudesane@g.com" },
                    { new Guid("f01f4666-9346-48b9-ab42-b81fb75eb26e"), "EspTemp_Fecha_Subsanacion_Tec", null, null, false, "1" },
                    { new Guid("f0abbaa2-dd5c-4bbe-a9d3-5d377fc4861a"), "CodigoDestinoAne", null, null, false, "pru001" },
                    { new Guid("f1b60b76-d097-4f9a-99f6-987034917f28"), "MailSmtpPort", null, null, false, "587" },
                    { new Guid("f1e86c8c-61cd-4984-800a-3ec1c8f39da4"), "TechnicalInformationSummaryXmlMassivelyUploaded", null, null, false, "Información cargada masivamente a partir de archivo .xml" },
                    { new Guid("f3ed7aef-f58c-4a25-8bf8-6d333863b47b"), "EspTemp_AZDigital_IdDirectorio", null, null, false, "6369" },
                    { new Guid("f467195f-18f3-4a91-8fe5-39a73f22aa3e"), "FirmaElectronicaAZGrupo", null, null, false, "20211007-161726-6bbb98-36629518" },
                    { new Guid("f4984145-783e-45c0-8912-9396bd1f1ffa"), "MensajeDuranteMantenimiento", null, null, false, "El Ministerio de Tecnologías de la Información/Fondo Único de TIC informa que se encuentra realizando un mantenimiento al aplicativo desde <u>las {0} hasta las {1} Durante este mantenimiento los servicios no están disponibles.</u> Agradecemos su comprensión." },
                    { new Guid("f67dc068-e6df-43b9-8df0-93c5da9fdc7d"), "FirmaElectronicaAction", null, null, false, "urn:/#NewOperation" },
                    { new Guid("f6f5adc7-109a-41d2-8d12-f6da52172541"), "EntornoPruebas", null, null, false, "1" },
                    { new Guid("f77e11c1-92b8-4bcb-89c9-9c2b42e3a5a6"), "FilesNeededToRadicate", null, null, false, "los tipos de archivos obligatorios para radicar una solicitud en un proceso de selección objetiva son: Formato Básico de la Solicitud (firmado por el representante legal)" },
                    { new Guid("f7d007a0-d8f3-4b6d-b9f1-5a6dc6d81664"), "DestinatariosBCCDesestimientoTacitoSatelital", null, null, false, "soporte.sge@tesamerica.com.co" },
                    { new Guid("f8a9e315-b89b-4a5e-88d8-da10c6db7036"), "ExplanationApplicationDetails", null, null, false, "Información básica de la solicitud" },
                    { new Guid("f91bdcd9-73af-4cd6-82a9-66928ad114c5"), "ExplanationSimulacionSpectrumE", null, null, false, "Ingrese a esta opción si desea simular algún enlace usando el Sistema de Simulación en Línea." },
                    { new Guid("f92cf490-5450-4453-8953-e4b51211935b"), "ServicioSGE-RUES", null, "Link de consumo para el servicio SGE-RUES", false, "http://salicaria:8749/api/rues/consultaRUES" },
                    { new Guid("f94f9e87-fb8e-4dca-beba-134dbfc4866d"), "ApiNotificaciones_Clave", null, null, false, "6ed4a3759c2234bcc9e144151b5d44bc" },
                    { new Guid("fa0675dd-fa0d-4981-b957-ab65b63186d4"), "MensajeInfoPSOP1", null, null, false, "Las solicitudes que se realizan en esta sección deben ser tramitadas bajo un Proceso de Selección Objetiva- PSO" },
                    { new Guid("fa25c072-5e02-47ce-8270-014bddadb796"), "SupportEmail", null, "(soporte.sge@mintic.gov.co)", false, "mailto:soporte.sge@mintic.gov.co" },
                    { new Guid("fad18dd2-4983-453f-993c-dbbbe6a31183"), "EstadosExpedienteRadicacionParalelo", null, null, false, "eAUT,eSOL" },
                    { new Guid("fb656dc3-b04b-4252-bf47-09a1ecde7a41"), "ExplanationAdicionarObservacion", null, null, false, "Por favor ingrese la razón por la cual realizó este cambio" },
                    { new Guid("fc1e00c1-0322-44ba-a077-63e74e9cf835"), "EstadosExpedienteNoUsadosPSO", null, null, false, "eCT,eRES,eVEN,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("fddae410-7947-4715-afca-23c42f658c0c"), "EmailCierre", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("fdfd5ec9-ea86-4c77-aa16-374b6981e609"), "SupportEmail_Prueba", null, "rsandoval@mintic.gov.co", false, "mailto:rsandoval@mintic.gov.co" },
                    { new Guid("fe75a0bb-1d6e-4b7b-ba62-97584100dc2d"), "IdExpedienteIMT", null, null, false, "70974" },
                    { new Guid("ff0db452-f121-4428-9067-ccb3ee793c3b"), "ApiNotificaciones_Usuario", null, null, false, "20231218-163125-18a4c0-17460376" }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("118e29e1-2a44-45b8-90f5-6c05bde4a203"), "Modificaciones de parametros técnicos" },
                    { new Guid("7094ed31-49d9-4aed-8faa-d456d33d370f"), "Modificaciones de parametros técnicos" }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "Name" },
                values: new object[] { new Guid("8f335e81-a531-4276-9ec9-e31497b437e7"), null, false, "Televisión" });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "Code", "DeletedOnUtc", "Description", "IsDeleted", "Name", "ParentId", "Slug" },
                values: new object[,]
                {
                    { "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", "SOLICITUD_ESTADO", null, null, false, "Estados de una solicitud", null, null },
                    { "01J4PGWKHQCW5KP4DGNHRWP28D", "PERSONA_TIPO", null, null, false, "Tipo de persona", null, null },
                    { "01J4PGWKHQK521VFNVTR6X697P", "PERSONA_CONDICION", null, null, false, "Condición de persona", null, null },
                    { "01J4PGWKHQYE80EGQM8P25K3AM", "REPRESENTANTE_TIPO", null, null, false, "Tipo de representante", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProcessProcedures",
                columns: new[] { "Id", "ProcessId", "ProcedureId" },
                values: new object[,]
                {
                    { 1, new Guid("8f335e81-a531-4276-9ec9-e31497b437e7"), new Guid("7094ed31-49d9-4aed-8faa-d456d33d370f") },
                    { 2, new Guid("8f335e81-a531-4276-9ec9-e31497b437e7"), new Guid("118e29e1-2a44-45b8-90f5-6c05bde4a203") }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "Code", "DeletedOnUtc", "Description", "IsDeleted", "Name", "ParentId", "Slug" },
                values: new object[,]
                {
                    { "01J4PGWKHQ0D7A86X1VXBDBWPP", "SOLICITUD_ESTADO_DEVOLUCIÓN_REQUERIMIENTO", null, "El coordinador devuelve el requerimiento al evaluador para que vuelva a revisar", false, "Devolución requerimiento", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQ2B3KAPRVE4S24WEA", "SOLICITUD_ESTADO_PENDIENTE_RADICACIÓN", null, "Solicitud que no ha sido radicada", false, "Pendiente Radicación", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQ36HCX5APXGWEW6CE", "SOLICITUD_ESTADO_DESISTIDA_TÁCITAMENTE_PENDIENTE", null, "La fecha limite de subsanación se venció y la ANE puede aumentar el plazo de subsanación", false, "Desistida Tácitamente Pendiente", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQ3Y6SWCYP9YPZWG3A", "SOLICITUD_ESTADO_APROBADA", null, "Solicitud aprobada", false, "Aprobada", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQ4YNKQNTB8X10GVG6", "REPRESENTANTE_TIPO_LEGAL_ILIMITADO_EN_SUS_FACULTADES", null, "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa.", false, "Representante legal ilimitado en sus facultades", "01J4PGWKHQYE80EGQM8P25K3AM", null },
                    { "01J4PGWKHQ6C5ZN3HWEX1Z2EJV", "SOLICITUD_ESTADO_GENERANDO_RESOLUCIÓN", null, "La solicitud fue aprobada por ambas entidades (MinTIC-ANE) y pasa al flujo de resolución", false, "Generando Resolución", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQ7MTAH4671MCN7EAX", "PERSONA_TIPO_JURIDICA", null, null, false, "Juridica", "01J4PGWKHQCW5KP4DGNHRWP28D", null },
                    { "01J4PGWKHQBMX5FDH4M8B2EP4F", "SOLICITUD_ESTADO_RECHAZADA_PENDIENTE", null, "Solicitud aprobada por la ANE (CT generado) y rechazada por MinTIC. Pendiente de devolver el CT", false, "Rechazada Pendiente", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQC2DQB0V750HFGRJ7", "SOLICITUD_ESTADO_REQUERIDA", null, "Solicitud requerida", false, "Requerida", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQEYT319S6DTBJ0YY8", "SOLICITUD_ESTADO_DESISTIDA", null, "Solicitud desistida por el operador", false, "Desistida", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQF8XVK32Q9JB4H7SA", "SOLICITUD_ESTADO_GENERANDO_OFICIO", null, "La solicitud fue rechada por alguna de las dos entidades (MinTIC-ANE) y pasa al flujo de oficio", false, "Generando Oficio", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQGXM15CP4CF559KBN", "SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO", null, "La solicitud se rechaza por cartera, garantías, RUTIC u otro motivo general", false, "Rechazo Administrativo", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQJYYTS87A5S6F5TK9", "SOLICITUD_ESTADO_RECHAZO_EN_COORDINACIÓN", null, "El evaluador rechazo uno o más documentos y está pendiente la aprobación del rechazo por parte del coordinador", false, "Rechazo en coordinación", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQK833YVM55ACG3BQZ", "SOLICITUD_ESTADO_DEVOLUCIÓN_RESOLUCIÓN", null, "El proceso esta en el flujo de resolución y se devuelve a la ANE para volver a revisar", false, "Devolución Resolución", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQKRDB8EZ12J7VGY48", "REPRESENTANTE_TIPO_LEGAL_LIMITADO_EN_SUS_FACULTADES", null, "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa no posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa, por lo cual, requiere de la presentación de un poder adicional que lo faculte para realizar solicitudes de este tipo.", false, "Representante legal limitado en sus facultades", "01J4PGWKHQYE80EGQM8P25K3AM", null },
                    { "01J4PGWKHQM0B07CXH33Y7TPKP", "SOLICITUD_ESTADO_OFICIO_APROBADO", null, "El oficio finaliza el flujo, es aprobado y se envia para firma electrónica", false, "Oficio Aprobado", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQMSQ3HNGBEJ3N7BFJ", "SOLICITUD_ESTADO_RESOLUCIÓN_APROBADA", null, "La resolución finaliza el flujo y se envia a IntegraTIC", false, "Resolución aprobada", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQNJ3C86EWPPHAV484", "SOLICITUD_ESTADO_SUBSANADA", null, "El operador subsana los requerimientos", false, "Subsanada", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQNY2RC5HDF44QPG1X", "SOLICITUD_ESTADO_DESISTIDA_TACITAMENTE", null, "Solicitud rechazada por no realizar la subsanación en el tiempo establecido", false, "Desistida tacitamente", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQQ49NWXCRYCNSQW3W", "SOLICITUD_ESTADO_REQUERIMIENTO_EN_COORDINACIÓN", null, "El evaluador requiere uno o más documentos y está pendiente la aprobación del requerimiento por parte del coordinador", false, "Requerimiento en coordinación", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQR1FSZFF785BVMCJ8", "SOLICITUD_ESTADO_RESOLUCIÓN_GENERADA", null, "El proyector genera la resolución", false, "Resolución Generada", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQRKFNNVB1GMGX8KCB", "REPRESENTANTE_TIPO_APODERADO", null, "Aquella persona designada mediante poder general o especial, conferido por el representante legal con facultades para ello, para solicitar permisos de espectro a nombre de la empresa que representa.", false, "Apoderado", "01J4PGWKHQYE80EGQM8P25K3AM", null },
                    { "01J4PGWKHQRM17AC4MT0D1DYZV", "PERSONA_CONDICION_NACIONAL", null, null, false, "Nacional", "01J4PGWKHQK521VFNVTR6X697P", null },
                    { "01J4PGWKHQSXTRDRAEQG288V84", "SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO_EN_COORDINACIÓN", null, "El evaluador rechazo la solicitud por cartera, garantías, RUTIC u otro motivo general, y está pendiente la aprobación del rechazo por parte del coordinador", false, "Rechazo Administrativo en coordinación", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQT4C6J9WS36PPBDQ1", "SOLICITUD_ESTADO_OFICIO_GENERADO", null, "El proyector genera el oficio", false, "Oficio Generado", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQTPDATCJBS35XWRXY", "SOLICITUD_ESTADO_EN_REVISION", null, "Solicitud radicada y en flujo de revisión", false, "En revision", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQTWNKE0DWZ2M4RTQJ", "SOLICITUD_ESTADO_RESUMEN_TÉCNICO_GENERADO", null, "La ANE genera el resumen técnico", false, "Resumen Técnico Generado", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQX7N2CC9MAHGRSX64", "SOLICITUD_ESTADO_RECHAZADA", null, "Solicitud rechaza", false, "Rechazada", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQY166N1R6PJG6VZ9Z", "PERSONA_CONDICION_INTERNACIONAL", null, null, false, "Extranjero", "01J4PGWKHQK521VFNVTR6X697P", null },
                    { "01J4PGWKHQY25WJHB9QXCCTTKN", "SOLICITUD_ESTADO_SUBSANACIÓN_POR_CAMPOS", null, "El operador realiza la subsanación del requerimiento por campos del anexo técnico realizado por la ANE", false, "Subsanación por campos", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQYZYB8HVEQH4AG1YN", "SOLICITUD_ESTADO_DESISTIDA_PENDIENTE", null, "La solicitud fue aprobada por la ANE y genero CT, y el operador la desiste. Pendiente devolver el CT", false, "Desistida Pendiente", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQZB22CFTGWKBTNP2G", "SOLICITUD_ESTADO_REQUERIMIENTO_POR_CAMPOS", null, "La ANE realiza un requerimiento por campos del anexo técnico", false, "Requerimiento por campos", "01J4PGWKHQ9B1ZKAQQ5MVH4VS9", null },
                    { "01J4PGWKHQZQ82NEZ9R2MBZH2X", "PERSONA_TIPO_NATURAL", null, null, false, "Natural", "01J4PGWKHQCW5KP4DGNHRWP28D", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTexts_Code",
                table: "DynamicTexts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessProcedures_ProcessId",
                table: "ProcessProcedures",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_Code",
                table: "Terms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terms_ParentId",
                table: "Terms",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicTexts");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "ProcessProcedures");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Processes");
        }
    }
}
