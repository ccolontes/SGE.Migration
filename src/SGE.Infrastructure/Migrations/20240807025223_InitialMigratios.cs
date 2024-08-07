using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigratios : Migration
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
                name: "ProcedureProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureProcesses_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessProcedure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessProcedureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessProcedure", x => new { x.Id, x.ProcessId });
                    table.ForeignKey(
                        name: "FK_ProcessProcedure_Processes_ProcessId",
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
                    { new Guid("021a6d0d-2a8e-4c7f-b4bc-e0994a893ea3"), "CorreosCargaCT", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("030e02f4-6abb-49d1-9ecf-e706860ca9ed"), "TextoFirmaCertificadoEspectro", null, null, false, "Asesora del Despacho del Viceministerio de Transformación Digital encargada de las funciones del Subdirector para la Industria de Comunicaciones" },
                    { new Guid("042d604a-9acc-4eed-aee7-56a122610d88"), "EspTemp_CorreoRadicarMintic", null, null, false, "solicitudesane@g.com" },
                    { new Guid("0464f916-a5db-4f8f-a27e-e8fc0186426d"), "ExplanationAdicionarObservacion", null, null, false, "Por favor ingrese la razón por la cual realizó este cambio" },
                    { new Guid("0526278c-ea76-44cf-bb4a-140318c922b2"), "ExplanationApplicationDetailsAnexarArchivosFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("057389a0-81ff-4c52-b7b4-83ffde24340a"), "FirmaElectronicaAZTipoMime", null, null, false, "application/pdf" },
                    { new Guid("06bd583a-9b62-440c-9997-e6ee9698ef1f"), "NombreArchivoAlfaRadicarArchivo", null, null, false, "Radicación_Archivo_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("075c8bd8-42e9-4453-b12a-816be81b6d32"), "AZDigital_Resoluciones_UsuarioFirmante_Satelital", null, null, false, "nalmeyda" },
                    { new Guid("0833b4ab-1644-41c6-ad9a-f0956c355fdd"), "SystemDescription", null, null, false, "El Sistema para la Gestión del Espectro Radioeléctrico “SGE” permite a los titulares de permiso para el uso del espectro tramitar ante el Ministerio de Tecnologías de la Información y las Comunicaciones" },
                    { new Guid("08983775-ad9a-4bb6-8b77-4a128ef43640"), "PaginaMinisterio", null, null, false, "http://www.mintic.gov.co/" },
                    { new Guid("08f213a7-e825-4dfb-8302-7a0071b6ed9a"), "CorreosAlertaCesionRedes", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("0a54ff7e-5375-493c-b3f2-f655e3ce9c1f"), "EmailAnalisisAdministrativo", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("0a6b4011-6db8-4e3b-8f7e-1b30cb2b68e9"), "ExplanationApplicationInProccess", null, null, false, "Se listan las solicitudes que aún no han sido radicadas oficialmente en el sistema." },
                    { new Guid("0be3796a-6d2b-4c9c-9bd1-e6ac5751e111"), "FirmaElectronicaAZGrupo", null, null, false, "20211007-161726-6bbb98-36629518" },
                    { new Guid("0c113782-3d17-49fa-a025-ec283f46bfaf"), "CorreosSubasanacionANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("0c43c418-8cbf-4b36-ab7a-02cfb4a9693a"), "AZDigital_IdDirectorioConsultaNOPSO", null, null, false, "24828" },
                    { new Guid("0d50fd1a-c647-4a5d-aec3-642020639e66"), "EspTemp_PuntajeTramite", null, null, false, "50" },
                    { new Guid("0e535b3a-bd60-4c57-ac47-d6b29e0606d0"), "AZDigital_Resoluciones_UsuarioFirmanteDir_EspTemp", null, null, false, "nalmeyda" },
                    { new Guid("0ee0cd84-2bd6-4acb-852a-2bca331537c5"), "ApiNotificaciones_Clave", null, null, false, "6ed4a3759c2234bcc9e144151b5d44bc" },
                    { new Guid("105af734-ba2f-4686-b9be-c325b88a7fac"), "CorreosDocumentosRequeridosCoordinador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("10ae0701-7079-481c-a9f5-0a3a2521668d"), "IMT_IdAntenna", null, null, false, "27374" },
                    { new Guid("117675d4-bf57-49d6-86f9-a5a1e803c710"), "CuadroNacionalAtribucionesFrecuenciaLink", null, null, false, "http://www.mintic.gov.co/images/documentos/espectro_radioelectrico/cuadro_nacional/cuadro_nacional_atribucion_bandas_de_frecuencias_2010.pdf" },
                    { new Guid("117b14cf-705f-437d-bd01-41debf15b435"), "VersionFormatosAnexos_Satelital", null, null, false, "V1.4" },
                    { new Guid("12053820-fff8-408d-a0f1-f4061f519a77"), "CorreoDevolucionProceso", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("1299eebd-5742-4261-80fc-7ab514303155"), "EspTemp_CorreoCopiaANE-MINTIC", null, null, false, "solicitudesane@g.com" },
                    { new Guid("14fceb76-4e65-4280-a380-3f20e3a492ab"), "CorreosDesmarcacionLocalidad", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("1512caaa-8174-4151-b87e-75796e4e7677"), "CorreoEnvioRadicarSatelitalANE-Mintic", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("15631457-5e18-4b21-b05d-d3d08db5c9c3"), "ExplanationApplicationDetails", null, null, false, "Información básica de la solicitud" },
                    { new Guid("16164331-ce02-4d16-afac-e62c20979b87"), "TokenTMP_User", null, null, false, "Sistema de Gestión del Espectro" },
                    { new Guid("166e3546-6903-4b07-8dfd-873d44ee88c9"), "Subdireccion_Industria", null, null, false, "gperdomo@mintic.gov.co" },
                    { new Guid("17a7f07e-e659-4fe6-bcc7-96b4a62ea501"), "CorreosCreacionPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("17c01700-47f1-4035-8754-fda78a3fdfb1"), "EmailAne2", null, null, false, "No disponible" },
                    { new Guid("180c1396-0d99-4398-8a91-f28217aed208"), "TelefonoAne1", null, null, false, "3442299" },
                    { new Guid("18bb0547-f433-474c-8834-60ce91277dee"), "CorreoCertificadoDocumentosMerge", null, null, false, "0" },
                    { new Guid("19c3a369-2206-4092-8443-5b2eb3187435"), "CorreosSubsanacionOperadorCopiaOculta", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("1a336ce1-be54-4ee0-b9af-51213294a576"), "CorreoCertificadoDocumentosCodificacion", null, null, false, "Base64" },
                    { new Guid("1bcb7dfb-750e-4282-9a9f-65f50411133d"), "ExplanationTechnicalInformationIndex", null, null, false, "Visualización de la información técnica de la solicitud" },
                    { new Guid("1e1c8e1d-1254-428a-bf90-5ff4e7f23f5b"), "AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("20959190-b047-4450-966b-f62d027138ce"), "DiasRevisionRadicadosAlfa", null, null, false, "30" },
                    { new Guid("2199dd78-b40a-42f3-81bb-724b778c4816"), "Fecha_Subsanacion_Coordinador_Satelital_Tecnico", null, null, false, "5" },
                    { new Guid("223ec92d-7d8b-4a12-909b-6becdc917212"), "IMT_Temp_File", null, null, false, "C:\\SAGE\\CargueIMT\\IMT_Back\\tempdatafile" },
                    { new Guid("235586b4-39ac-47cd-bacd-f00206bf5fdc"), "MailSmtpPort", null, null, false, "587" },
                    { new Guid("23cfa467-3648-4576-a514-69c893e204eb"), "SubdirectorIndustria", null, null, false, "gperdomo" },
                    { new Guid("2545bbaa-3516-42c4-9e1e-f20386b2a1c8"), "IMT_RadioBusquedaMetros", null, null, false, "2600" },
                    { new Guid("25d6d8d1-5c04-4099-863d-1945bb62d672"), "CorreoCertificadoContraseña", null, null, false, "2eca78d9b47f82705c9bbc5efe71cd95" },
                    { new Guid("26088fa7-5aa2-49e9-9cfa-bb86936fa732"), "FechaInicioMantenimiento", null, null, false, "11/10/2023 20:00:00.000" },
                    { new Guid("2652bea8-84f9-448c-864d-9ffc13aa62c9"), "ApproveAdministrativeAnalisisWfTipo", null, null, false, "0" },
                    { new Guid("26d19393-800c-4f00-82e6-6646e92a47c8"), "ExplanationApplicationEdit", null, null, false, "Puede asignar un nombre personalizado a esta solicitud" },
                    { new Guid("276d957c-eec3-4e4e-a500-30e24e673486"), "CorreoCertificadoUsuario", null, null, false, "20230922-132449-805237-73089455" },
                    { new Guid("278478c9-3db3-4a36-aaf5-5275bc716108"), "CorreosMarcacionLocalidad", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("282ccac1-579b-4fbf-b5c0-3ba22e0dcce2"), "RolesPermisoRevisionOficio", null, null, false, "73,74,75,101,107" },
                    { new Guid("28a60301-2440-45d6-97da-9eb2021a7e2e"), "CorreoMinticSoporte", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("2945b911-f10a-406a-aec3-872625dc2f67"), "DocumentosSGE_URL", null, "URL de documentos del SGE", false, "https://cert-gestion-espectro.mintic.gov.co/DocSGE/DocSGE_Front" },
                    { new Guid("295a5dee-4d7d-4183-8904-7499da554396"), "Satelital_Portada_MINTIC", null, null, false, "Ministerio de Tecnologías de la Información y las Comunicaciones; solicitudessatelital@g.com" },
                    { new Guid("29b0312e-377e-4865-ba03-9bd739d1d9dd"), "ExplanationEquipmentList", null, null, false, "Para el caso de monitores de modulación y monitor de frecuencia y la línea de transmisión en las redes de radiodifusión sonora (AM" },
                    { new Guid("29cd6d2d-f07a-45cd-8ea7-87ec9fe45580"), "AZDigital_Resoluciones_ProcedeRecurso", null, null, false, "Rep10" },
                    { new Guid("2a083c90-90dc-4394-978f-fbf984857e96"), "LogonMessageAdic", null, null, false, "o envíe un correo a minticresponde@mintic.gov.co" },
                    { new Guid("2b088d42-88a4-4cf7-9413-b74a86c6407b"), "ApiNotificaciones_PlantillaEmail", null, null, false, "EmailNotificacion.html" },
                    { new Guid("2b5c9b0b-bce5-4414-9b5b-2223a70e2080"), "TextoDetalleAlfaClosing", null, null, false, "Notificación de Aprobación final de la Solicitud: {0}" },
                    { new Guid("2bf4cbb0-3ca0-4b47-b9ee-112c10e8d6e6"), "AZDigital_IdDirectorioRadicadoNOPSO", null, null, false, "6369" },
                    { new Guid("2c0e98cf-0e3a-4b0c-a228-e448354cf68c"), "ExplanationPortfolioEdit", null, null, false, "Desde este formulario es posible modificar el nombre del expediente correspondiente al expediente seleccionado" },
                    { new Guid("2c3186e3-937f-4ee7-8bea-f9a6873d350e"), "ExplanationSimulacionSpectrumE", null, null, false, "Ingrese a esta opción si desea simular algún enlace usando el Sistema de Simulación en Línea." },
                    { new Guid("2cb54c9c-9df6-4493-a6da-9e8ca72f111b"), "ExplanationApplicationInProccessFront", null, null, false, "Se listan las solicitudes que aún no han sido radicadas oficialmente en el sistema." },
                    { new Guid("2ce3217d-8064-4fc5-9c20-12b983c0512c"), "Fecha_Subsanacion_Revisor_Satelital_Tecnico", null, null, false, "10" },
                    { new Guid("2cef1604-d1a3-4e0e-8d88-dbc2ad1c105c"), "UserAlfa", null, null, false, "usersage" },
                    { new Guid("2d878c8d-2ced-4c54-8e0e-c325fb7a666d"), "EstadosExpedienteSincronizacion", null, null, false, "eAUT" },
                    { new Guid("2dc8f1bc-0340-454b-a190-336100bb389f"), "CertificacionCarteraTextoFirma", null, null, false, "Coordinadora GIT de Cartera" },
                    { new Guid("2ed341f9-2b47-4014-9ab2-2cec5a08c2aa"), "CorreoEnvioAdjuntoRadicarSatelitalANE", null, null, false, "Solicitudesdeespectro@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("2f3ba290-1ec8-44e8-bb28-abecf82b1244"), "MotivoRechazoCartera", null, null, false, "No cumplir con lo establecido en el numeral 2 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("2f4da161-f16e-4b01-b65a-46a7c560fea8"), "IMT_AZDigital_IdDirectorio", null, null, false, "132082" },
                    { new Guid("30173cf5-3c9b-4a8b-ad9f-55d74d616cdc"), "IMT_AZDigital_TramiteRegistro", null, null, false, "RPTA_N" },
                    { new Guid("31b935da-23c2-447d-af08-c3f80255e213"), "LegendSpectrumE", null, null, false, "Sistema de Simulación" },
                    { new Guid("32544071-0f8f-4225-8063-05d738c2fc0b"), "Garantia_Director", null, null, false, "Director de Industria de Comunicaciones" },
                    { new Guid("3410dad8-d0d1-46d6-9b88-cf3b03cc36f4"), "CorreoCertificadoRemitenteDireccion", null, null, false, "Casa 1" },
                    { new Guid("3513a42f-2d23-4436-ac81-d6b1899beaa3"), "EspTemp_Hojas_Archivo_Tecnico", null, null, false, "1. Admin,2. Info General,3. IMT o PMP,4. Punto a Punto,5. Control de Cambios,Menu" },
                    { new Guid("352ca806-7fc2-49cb-986c-5d9150e32698"), "AZDigital_IdDirectorioRadicadoSatelital", null, null, false, "102235" },
                    { new Guid("3571cfbb-3a6b-4d76-96ba-206e9afd161a"), "ExplanationApplicationFileUpload", null, null, false, "Aliste los siguientes documentos: Formato básico de solicitud" },
                    { new Guid("35c435ba-fbcf-4e27-9c32-a0dd522644be"), "Temp_File_Satelital_New", null, null, false, "C:\\SAGE\\Satelital\\Satelital_Back\\tempdatafile" },
                    { new Guid("3623b308-9b76-4e9d-ad01-ef4795e6625d"), "ExplanationApplicationFileList", null, null, false, "A continuación se listan los archivos adjuntos a la solicitud seleccionada." },
                    { new Guid("36333c7e-4900-4a92-a569-2065f3eacf22"), "CorreoCertificadoAplicacion", null, null, false, "TesAmerica" },
                    { new Guid("36640bb0-3e07-432e-823e-da3226768893"), "CorreoCertificadoCanalesAsunto", null, null, false, "Prueba Email Servicio Notificaciones" },
                    { new Guid("36ec2add-831a-41d0-81d3-c1116a636de2"), "Fecha_Subsanacion_Coordinador_Satelital_Administrativo", null, null, false, "1" },
                    { new Guid("373ee363-d91f-481e-a6c1-fccae8726ffe"), "AlertConfirmCreateObservation", null, null, false, "¿Está seguro que desea guardar el cambio?" },
                    { new Guid("38ed2e64-19f0-460b-94a9-e5b35f31795e"), "EspTemp_ClaseExpediente", null, null, false, "90" },
                    { new Guid("3b35781e-d0fb-4a55-8318-785d9b1e35fb"), "AlertBeforeClosingApproval", null, null, false, "Señor funcionario" },
                    { new Guid("3b966935-fb9f-4836-b1a1-76bc4aaab426"), "CorreoRadicadoANEPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("3bb7eb89-d9e6-49c8-a847-6d2474a34125"), "Resolucion", null, null, false, "485 de 2024" },
                    { new Guid("3bdf7dad-2e76-4691-a071-1cb2bd6be22e"), "EstadosExpedienteMuerto", null, null, false, "eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("3c417086-2c7f-4526-921c-403352a2b453"), "MailSmtpHost", null, null, false, "smtp.gmail.com" },
                    { new Guid("3c5e70fd-7816-45ef-81df-6d5795474353"), "NombreAne", null, null, false, "Agencia Nacional del Espectro" },
                    { new Guid("3cc05630-1886-4bb6-9328-05ebcf4a63aa"), "ApproveTechnicalAnalisisCdDestino", null, null, false, "311" },
                    { new Guid("3d0d20da-6a07-4da2-8275-cc6ae1ab93c7"), "TextoRefRadicadoAnalisisTecnico", null, null, false, "Resultado de Análisis Técnico de la Solicitud con radicado MINTIC No. {0} del {1}." },
                    { new Guid("3ead63f0-bcd9-4b05-9e62-36436cdb7c08"), "ApiNotificaciones_Usuario", null, null, false, "20231218-163125-18a4c0-17460376" },
                    { new Guid("3ef619d0-e11e-4733-ac32-b0f920ca4ad0"), "FirmaElectronicaUrl", null, null, false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("3f81192b-0293-40ad-ab5b-c5a541c81ef4"), "EspTemp_CorreoAprobacionResolucion", null, null, false, "solicitudesane@g.com,kballen@g.com,crojas@g.com,ligomez@g.com" },
                    { new Guid("403ce8d3-e03f-4320-8366-7b69f97ed8a7"), "AZDigital_Resoluciones_UsuarioFirmanteVice_EspTemp", null, null, false, "svaldes" },
                    { new Guid("40f954ff-8d14-4f9c-a3be-2be51f785012"), "ApproveAdministrativeAnalisisSerieDocumental", null, null, false, "Serie Documental" },
                    { new Guid("416c7da3-4430-47f8-8553-0d90b7f21ac2"), "AZDigital_IdDirectorioConsultaPSO", null, null, false, "24828" },
                    { new Guid("437d5f80-2010-41ee-8ddd-512ccb8e8644"), "CorreosSubsanacionOperador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("43aa253e-830d-493e-876b-a1a74ba27b1a"), "GraficaNacionalAtribucionesFrecuenciaLink", null, null, false, "http://www.mintic.gov.co/images/documentos/espectro_radioelectrico/cuadro_nacional/grafico_cuadro_nacional.pdf" },
                    { new Guid("4409eb76-bc5e-49b2-9568-3c497ec51265"), "MensajeAdvertenciaRTICDiferenciasNOPSO", null, null, false, "Señor usuario" },
                    { new Guid("4419ffbc-78e2-4323-b859-3747512cb0a3"), "EspTemp_AZDigital_TramiteRegistro", null, null, false, "rs" },
                    { new Guid("44533aa7-c9d8-4795-8b08-aa5a9ca23f7e"), "CorreoRechazoMINTIC_ANE_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("45764874-8e42-4d81-8f42-8db07de4c5f9"), "CodigoDestinoAne", null, null, false, "pru001" },
                    { new Guid("478503aa-5d10-45c2-a34c-b4b1612863f2"), "CodigoDestinoMintic", null, null, false, "pru001" },
                    { new Guid("494e811b-d4f7-4a09-beee-8f42e1d04546"), "NombreArchivoAlfaAnalisisTecnico", null, null, false, "Aprobacion_Tecnica_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("4970c67e-c3cb-46bf-97f4-bf73b16d512b"), "CorreoRechazoMintic-Mintic", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("49d9a11e-047a-49c8-a465-56509fa36244"), "TiempoTokenMatrizANE", null, null, false, "50000" },
                    { new Guid("49e129d7-6bcd-4c0f-adc0-28300e7a09d3"), "SerieDocumentalAlfa", null, null, false, "100" },
                    { new Guid("49e3d2cd-26aa-4a63-a7b7-9a0ce52b1459"), "MailSmtpPassword", null, null, false, "Tesamerica123*" },
                    { new Guid("4a08a91a-3781-46f1-acab-caa251305074"), "MailRevisorModuloResolucionesSinGarantia", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("4a5a3160-b614-4468-8e15-7d07369b68e1"), "RutaGetTokenRUES", null, null, false, "wsToken" },
                    { new Guid("4aa8d4a0-93bf-422b-990a-6c683c73075a"), "PasswordRUES", null, null, false, "k272ki8bLnLpFK7aUuUEzw==" },
                    { new Guid("4c1a1ffb-1070-411f-81ae-f7a260a1d5ae"), "TokenTMP_Email", null, null, false, "soporte.sge@mintic.gov.co" },
                    { new Guid("4d90fc56-039a-4087-b22b-93cc9aead83c"), "MainPattern", null, null, false, "[ .;,:¿?¡!(){}&%$_*+\\'''#|=º^¨~-]" },
                    { new Guid("4dfafedb-4f21-4ea8-8050-4cbbe31057c5"), "UrlImportSpectrumE", null, null, false, "http://simulacion.ane.gov.co:8088/se/portal/ane/loginproc.php?" },
                    { new Guid("4e645130-50c0-41f8-baab-506909678ef3"), "FirmaElectronicaAZUsuario", null, null, false, "20201209-092929-982602-00332255" },
                    { new Guid("4f7b3317-bd01-4ebd-b410-e84ab28c2023"), "ExplanationApplicationCreationPortfolio", null, null, false, "Debe hacer una solicitud por expediente y la documentación debe corresponder al expediente que está tramitando." },
                    { new Guid("4fd1423b-11b7-4554-8d36-9c6c261fd4a4"), "EspTemp_AZDigital_IdDirectorio", null, null, false, "6369" },
                    { new Guid("500a21fb-5b1f-4a4b-9a88-28e7c83131b5"), "MailDesarrolladorModuloResolucionesSinGarantia", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("505131c2-2fea-495b-be34-6a24c45c44bf"), "Columna_Potencia_BB", null, null, false, "R" },
                    { new Guid("5061664e-e2f0-4da8-99e2-a8383983d96f"), "IdExpedienteIMT", null, null, false, "70974" },
                    { new Guid("51715021-1406-4491-8735-34dfee01565d"), "EstadosExpedienteNoUsadosCesion", null, null, false, "eRES,eCT,eBDU,eDEP,eIN,eREG,eVEN,eTER,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("522ac20b-b053-4a59-9b7a-734d49014e48"), "ExplanationApplicationMessageListSummaryNoNotes", null, null, false, "No se encontraron anotaciones." },
                    { new Guid("52d277fb-059d-4680-8cd8-e0e1b9a042cc"), "CorreoAprobacionMINTIC-ANE_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("530a3daf-3616-4a61-b63e-ca299438234d"), "TextoDetalleAlfaRadicacion", null, null, false, "Radicación de la Solicitud: {0}" },
                    { new Guid("530d7209-a0c4-4f36-a256-fc50db081a27"), "ServicioSGE-RUESLocal", null, "Link de consumo para el servicio SGE-RUES", false, "http://192.168.0.10:8749/api/rues/consultaRUES" },
                    { new Guid("555980ff-c8f1-483e-a6d1-161e4ce935c1"), "CorreosAletaBloqueos", null, null, false, "andres.rodriguez@tesamerica.com.co,bloqueos@g.com" },
                    { new Guid("562f21b8-c2ad-4de5-bed8-20498be4d1be"), "AdvertenciaNavegador", null, null, false, "Te recomendamos usar los siguientes navegadores para que tu experiencia con el SGE sea óptima: <img style='width:16px;vertical-align:text-bottom;' src='/content/images/icons/chrome24.png' alt='Icono del navegador Google Chrome'>Google Chrome V.49 y <img style='width:16px;vertical-align:text-bottom;' src='/content/images/icons/firefox24.png' alt='Icono del navegador Mozilla'>Mozilla Firefox V.42 o versiones superiores." },
                    { new Guid("576f57c3-0b13-4a06-9572-83decf3ae1d2"), "AZDigital_Resoluciones_TipoNotificacionFisico", null, null, false, "P" },
                    { new Guid("588d5b3f-921b-4e92-8970-12bd927a6719"), "EspTemp_CorreoRechazoANE-MINTIC", null, null, false, "solicitudesane@g.com" },
                    { new Guid("5a08b3cc-2f68-4c12-b3b5-02fb11b0460e"), "EspTemp_CorreoAprobacionMINTIC-ANE", null, null, false, "Solicitudesdeespectro@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("5b233fe2-e1f0-4484-bd0b-74711dfb2ba3"), "PointToPointAndPointToMultipointExplanation", null, null, false, "Si por algún motivo" },
                    { new Guid("5bc6a2dc-2a25-4ee6-bd96-e7623abd556f"), "TechnicalInformationSummaryNetworkNumber", null, null, false, "Red número:" },
                    { new Guid("5bce34f8-c3e9-4ef9-a862-9d3c7cc973d0"), "AZDigital_SitioSatelital", null, null, false, "TL" },
                    { new Guid("5be38bc4-9acb-40fd-bc3a-20567d4b0f70"), "CorreoAprobacionMinTIC", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("5bf4b37c-907a-4509-bce7-7bf643588fc4"), "CorreoTesamerica", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("5c3edb0d-2b26-4e6f-9046-93fcfffcb5fc"), "MensajeInfoPSOP1", null, null, false, "Las solicitudes que se realizan en esta sección deben ser tramitadas bajo un Proceso de Selección Objetiva- PSO" },
                    { new Guid("5ca3a7a8-81f8-4b27-9355-530ffc101964"), "IMT_CorreoRadicarMinticyANE", null, null, false, "Solicitudesdeespectro@g.com,juan.benavides@tesamerica.com.co,dircom@g.com" },
                    { new Guid("5e9bec72-b82c-4e37-960e-a79f99cf8642"), "AZDigital_IdDirectorioRadicadoPSO", null, null, false, "6369" },
                    { new Guid("5ea0cc51-6b3c-4d9b-b4b3-2e6d726e74d7"), "EstadosRedesSolicitudCanFrecBB", null, null, false, "rAUT" },
                    { new Guid("5f1257d7-0771-4efd-99df-991c87ad90c9"), "MensajeDuranteMantenimiento", null, null, false, "El Ministerio de Tecnologías de la Información/Fondo Único de TIC informa que se encuentra realizando un mantenimiento al aplicativo desde <u>las {0} hasta las {1} Durante este mantenimiento los servicios no están disponibles.</u> Agradecemos su comprensión." },
                    { new Guid("5f4d9725-7888-421b-8478-c1b4da87fe58"), "DestinatariosBCCDesestimientoTacitoSatelital", null, null, false, "soporte.sge@tesamerica.com.co" },
                    { new Guid("5fd30cc7-d3bd-41ae-bc94-bf6b4c57af44"), "TelefonoMintic1", null, null, false, "3443460" },
                    { new Guid("5ff56876-1b61-4d40-a3ad-fb88596dc10d"), "AZDigital_Resoluciones_TipoActo", null, null, false, "R" },
                    { new Guid("603c3c6e-03fb-4f76-8704-c6e4cd25dddb"), "EspTemp_CorreoRadicarANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("613c011c-3a56-4162-9c2f-178c9519c786"), "IMT_AZDigital_Sitio", null, null, false, "TL" },
                    { new Guid("61ee4dd9-4882-4b28-b21e-99deaf489be6"), "CorreosDocumentosRequeridosCoordinadorANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("63437fce-5e8e-4b70-919c-e067606317f4"), "AlertBeforeRadicationAdicional", null, null, false, "Sr. Usuario" },
                    { new Guid("63a40e2d-067f-4916-a188-62ad54a8b5e2"), "AZDigital_Resoluciones_UsuarioFirmante_EyS", null, null, false, "svaldes" },
                    { new Guid("63e01df9-d970-44ec-a64b-d897034f990e"), "AlertBeforeDeleting", null, null, false, "Señor usuario" },
                    { new Guid("64771fb6-7241-402f-9cfd-8644355d251d"), "ExplanationApplicationClosing", null, null, false, "Las solicitudes en cierre se encuentran en proceso de generación de la resolución" },
                    { new Guid("6493d80a-f3ce-4b23-80b8-794b0f1344f4"), "EmailAnalisisTecnico", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("65715dd5-b094-46c9-a5cc-400dc545d6cd"), "RutaGetConsultaRUES", null, null, false, "wsConsultaRUES" },
                    { new Guid("659119fb-f785-4272-b4a8-d567c0410c21"), "ServicioRUES", null, "Link de consumo para el servicio RUES", false, "http://10.100.101.174/r1/CO-QA/GOB/CONFECAMARAS-0001/RUES/" },
                    { new Guid("6597dc3f-b06f-47a0-8178-dc97e392a083"), "ServicioSGE-RUES", null, "Link de consumo para el servicio SGE-RUES", false, "http://salicaria:8749/api/rues/consultaRUES" },
                    { new Guid("660360f6-33b2-432c-8fa5-99d134d6ea60"), "NombreArchivoAlfaAnalisisAdministrativo", null, null, false, "Registro_Fin_Analisis_Administrativo_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("6650765c-3fd4-41a9-acd0-264ab3749c96"), "Fecha_Subsanacion_Revisor_Satelital_Administrativo", null, null, false, "1" },
                    { new Guid("6699dc94-57d8-4db3-bea7-b88a290a1d83"), "TextoDetalleAlfaAnalisisTecnico", null, null, false, "Notificación de Aprobación de Análisis Técnico de la Solicitud: {0}" },
                    { new Guid("66b91df8-b3d8-4eea-b9c7-a0de24603363"), "CorreoCertificadoRemitenteEmail", null, null, false, "silvia.mesino@analitica.com.co" },
                    { new Guid("6889698c-bb0a-4b25-b5cc-e059ff104a0e"), "ApiNotificaciones_Action", null, null, false, "urn:/#NewOperation" },
                    { new Guid("68ade7e6-3254-4e13-880c-0bd00c1d1d1c"), "EmailCierre", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("68f35fc5-7cdb-46e3-bd4b-ebdc47c8666f"), "GrandTypeRUES", null, null, false, "password" },
                    { new Guid("69ac0be8-c2d5-4460-9f7f-bf69849892f2"), "SolFisicaDiasAdicionalFechaVenc", null, null, false, "60" },
                    { new Guid("6a78cb69-264d-4c76-a6af-dc6bf167e6bf"), "MensajeAdvertenciaRTICDiferenciasPSO", null, null, false, "Señor usuario" },
                    { new Guid("6be1b52f-8480-4b4e-b877-55dc24c0e712"), "EspTemp_Fecha_Subsanacion_Tec", null, null, false, "1" },
                    { new Guid("6c46a96f-9199-4c10-a21b-a2b0f85f86bf"), "ApproveTechnicalAnalisisWfTipo", null, null, false, "0" },
                    { new Guid("6d2a1fba-af62-4868-9c5a-4b9ca99f24f1"), "CustomerFrontLegalInfo", null, null, false, "Es interés del Ministerio de Tecnologías de la Información y las Comunicaciones (TIC) la salvaguardia de la privacidad de la información personal del usuario obtenida a través del sitio web" },
                    { new Guid("6e33e017-d01f-4296-9371-0530763df971"), "FirmaElectronicaAZRol", null, null, false, "F" },
                    { new Guid("6e604e5d-c43d-43ac-aad6-4454426257bb"), "RolesPermisoRevisionResoluciones", null, null, false, "2,3,4,5,6,7,22,57,59,60,61,62,76,77,78,79,99,100,108" },
                    { new Guid("6fa04af1-7d1c-4422-89f2-b63575d7f4ba"), "LogonMessage", null, null, false, "Escriba su usuario y contraseña de Registro TIC" },
                    { new Guid("6fa06ba0-85c9-4011-9d37-3a4fa187b558"), "MotivoRechazoRUTIC", null, null, false, "No cumplir con lo establecido en el numeral 1 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("712299cb-6765-40ad-8cdb-5bff4f8465b3"), "CorreoRechazoANE-MINTIC_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("71529fe9-618e-42ed-af71-6398422f9092"), "TextoDetalleAlfaRechazoSolicitud", null, null, false, "Notificación de Rechazo de la Solicitud: {0}" },
                    { new Guid("73d3ed9f-f6e9-484b-bcec-99e02a3796eb"), "DestinatariosDesestimientoTacitoSatelital", null, null, false, "hernan.palta@tesamerica.com.co" },
                    { new Guid("74038d86-b41f-435f-b2b5-af62f611fed4"), "NitMintic", null, null, false, "89999953-1" },
                    { new Guid("7497a5ff-55c5-417c-a9e4-09f039101df4"), "ExplanationApplicationDetailsAnexarArchivos", null, null, false, "Señor usuario" },
                    { new Guid("752ad9df-f8e7-48c3-bc09-f318afa20e96"), "TextoDetalleAlfaAnalisisAdministrativo", null, null, false, "Notificación de Aprobación de Análisis Administrativo de la Solicitud: {0}" },
                    { new Guid("756cbcb4-7ece-49d3-b1a6-56fcd04e4c1d"), "CorreoEnvioANE-MinticNOPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("757cc7c0-b8c3-41f8-b973-01f5a09a6c96"), "ApproveAdministrativeAnalisisNaturaleza", null, null, false, "770" },
                    { new Guid("757f395f-1f81-48aa-a6ba-07fb120f6c7f"), "CorreosAletaBloqueoGarantias", null, null, false, "andres.rodriguez@tesamerica.com.co,garantias@g.com" },
                    { new Guid("760c5660-0ae7-4552-9b23-879cc1ad9183"), "CorreoCertificadoDocumentosTipoMime", null, null, false, "application/pdf" },
                    { new Guid("768f1402-599a-4cad-856b-148b1f1bebdd"), "xmlnsazs", null, null, false, "http://www.analitica.com.co/AZSign/Esquemas" },
                    { new Guid("76edb7bd-62e7-4b56-8947-9f30e0d66bc4"), "EspTemp_CorreoCopiaMINTIC-ANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("79126f29-2237-4a31-b2dd-1df58a8d3194"), "http://www.mintic.gov.co/", null, null, false, "http://www.mintic.gov.co/" },
                    { new Guid("798e3822-f320-4171-8f57-0e6deed59482"), "TechnicalInformationSummaryNetworkCount", null, null, false, "Número de redes de la solicitud:" },
                    { new Guid("7ac31c99-cbb7-4e65-a5ed-ea5577d8737c"), "AutenticacionTMP", null, "https://espectro-co.ane.gov.co/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=", false, "https://espectro-co.ane.gov.co/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=" },
                    { new Guid("7bea86ad-eb37-4f93-94d2-de35ea039719"), "Temp_File_Satelital", null, null, false, "C:\\SAGE\\SGE\\tempdatafile" },
                    { new Guid("7c860e43-9a83-4c36-987a-856d09b8130a"), "UbicacionDocumentosSGE", null, null, false, "C:\\SAGE\\DocumentosSGE\\" },
                    { new Guid("7d7f786b-8b20-44e4-ac94-b3745cbe2429"), "PrivacyPolicy", null, "Ver el texto completo", false, "http://www.mintic.gov.co/index.php/privacidad-condiciones-uso" },
                    { new Guid("7e63563c-decd-4a69-9f94-9e864a7547cb"), "ResumenTecnicoTexto", null, null, false, "En virtud de la(s) solicitud(es) de [TipoTramite_NumRadicado]" },
                    { new Guid("7ec5f396-df82-4f44-83e9-adb5f03cf430"), "CorreoRemitente", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("7f09eff3-2e57-4900-a5de-c3889b3ff72a"), "ApiNotificaciones_TipoMime", null, null, false, "application/pdf" },
                    { new Guid("7f82f239-6a59-47a2-ae88-f0d11180e220"), "MensajeBloqueoRTIC", null, null, false, "Señor usuario" },
                    { new Guid("81936e9a-1c62-42c0-9909-75e2490f2e66"), "EntornoPruebas", null, null, false, "1" },
                    { new Guid("81cf1678-fa63-4baa-93bc-28d3b26b7f4e"), "AlertBeforeRadication", null, null, false, "Señor usuario: tenga en cuenta que una vez radicada la solicitud" },
                    { new Guid("820b3428-574b-4e9d-bb03-67729f465f8c"), "LogonMessageFront", null, null, false, "Señor funcionario" },
                    { new Guid("822adda4-dada-41c4-8c6d-e02378a38778"), "AZDigital_TramiteRadicadoSatelital", null, null, false, "PQRSD" },
                    { new Guid("8236e1f6-ca2b-404a-941c-fd0f64521566"), "AZDigital_Dependencia", null, null, false, "Pru" },
                    { new Guid("835aae51-56ee-464d-9656-3d89e01cfea9"), "TelefonoAne2", null, null, false, "No disponible" },
                    { new Guid("83d1d38d-8784-4b70-9408-a0b8fad7097b"), "ExplanationAdministrationGrid", null, null, false, "En esta sección podrá consultar o crear antenas y equipos y consultar reportes sobre información técnica y administrativa" },
                    { new Guid("840bf545-fc8d-4e0a-9a1a-6682bab2cdb4"), "CorreoCoordinacion_GGCCG", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("8489b11e-45c7-4347-9b97-b849b82bab04"), "TiempoAutoguardadoMilisegundos", null, null, false, "300000" },
                    { new Guid("84f64b35-54f8-4585-8264-139fa9a2d7bb"), "Temp_File_EspectroTemporal", null, null, false, "C:\\SAGE\\EspectroTemporal\\EspectroTemp_Back\\tempdatafile" },
                    { new Guid("85be221b-d50f-44dc-94b1-66451270eee6"), "FirmaElectronicaAZTipoPDF", null, null, false, "PDF" },
                    { new Guid("864f90f4-131e-4d8e-88e3-8f5b618ce946"), "CustomerFrontContactInfo", null, null, false, "Para dudas o inquietudes respecto a la funcionalidad de esta aplicación" },
                    { new Guid("86ffc2bc-b55d-40ae-bbc5-ce4dd2eff578"), "RequiredFieldImageMessage", null, null, false, "Campo requerido" },
                    { new Guid("889ac093-e7e2-4181-bb05-48b2bdc03370"), "MainPatternAddress", null, null, false, "[a-z .;,:ñ¿?¡!(){}&%$_*+\\'@''/\\\\#|=º^¨~-]" },
                    { new Guid("8954f303-8d05-4a99-99c2-78e5860bb7e1"), "ServicioAuraQuantic", null, "Link de consumo para servicio AuraQuantic", false, "https://uatbpm-integraciones.mintic.gov.co:8001/ServiciosRUTIC/api/Rutic/ConsultarDatosAdministrativos" },
                    { new Guid("89759cdf-71aa-4baa-991c-6b16ce05637c"), "BDU_Clase", null, null, false, "92" },
                    { new Guid("8a137454-e384-466f-a19e-87257a85d254"), "TextoDetalleAlfaRadicarArchivo", null, null, false, "Notificación de Radicación de Archivo  de la Solicitud: {0}" },
                    { new Guid("8a1665ae-2918-4348-8fcc-dc5bef5ca2f9"), "EmailFinalizada", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("8a302bc0-a5e4-46ea-a117-2e529437c627"), "AZDigital_Resoluciones_UsuarioFirmante", null, null, false, "nalmeyda" },
                    { new Guid("8aff8628-25c6-4150-829a-1340efecd1f3"), "FirmaElectronicaAZURL", null, "Link consumo para el servicio de firma electrónica (AZSign)", false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("8b5d2dcb-6f77-4866-a98b-758f2f46d0fb"), "LegendCantFilegApplicationDetails", null, null, false, "Información faltante para radicar la solicitud" },
                    { new Guid("8e1679dd-7a5c-4a13-8014-3ceec1f92033"), "ExplanationEquipmentCreation", null, null, false, "Formulario de creación de equipo" },
                    { new Guid("8e571069-ae98-4483-8c8f-7ddd1f0e942e"), "FaxMintic", null, null, false, "No disponible" },
                    { new Guid("8e5c8b3d-6ce2-4083-b824-19a28e421061"), "ExplanationApplicationCreation", null, null, false, "Por favor ingrese la información requerida para crear una nueva solicitud" },
                    { new Guid("8eb1017b-3492-419a-97c0-986bc33abda8"), "EspTemp_PortadaMINTIC", null, null, false, "Ministerio de Tecnologías de la Información y las Comunicaciones; solicitudesane@g.com" },
                    { new Guid("8fd664ad-763c-4c64-98ac-e5961b63d645"), "EmailAne1", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("90b67539-2a15-4001-8398-9fe297553c58"), "FaxAne", null, null, false, "2436212" },
                    { new Guid("923e09d5-a4a6-41bd-b9da-396a5c2bffd8"), "PasswordServicioAuraPortalNew", null, null, false, "1mp3rs0n4t3." },
                    { new Guid("92478b59-a2d0-4349-9dcb-2bb405faef84"), "AZDigital_DependenciaSatelital", null, null, false, "2.2.0.1" },
                    { new Guid("9337f439-5418-4bc5-84f4-a4ac1ce925f8"), "CorreoCopiaANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("93446caa-58b4-4de7-9939-d75d3f326353"), "MensajeAdvertenciaCartera", null, null, false, "Señor usuario" },
                    { new Guid("94b08a49-b9f5-4c94-8d95-bc23cc48c934"), "CorreoCertificadoURL", null, "Link consumo para el servicio de Notificaciones (IntegraTIC)", false, "https://cert-integratic.mintic.gov.co/Notificaciones/WebServices/SOAP/" },
                    { new Guid("9573f54c-809b-40f7-9f99-4248bf06fcae"), "EspTemp_AZDigital_Sitio", null, null, false, "Prue" },
                    { new Guid("958b40ad-f710-45a7-899d-95651b81ce7e"), "EspTemp_AZDigital_Dependencia", null, null, false, "Pru" },
                    { new Guid("961e130d-f15d-48d2-91ef-9a9c9fdc85ee"), "CorreosRequerimientoTotalBB", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("9815f79c-783b-41cb-a439-824765e738ae"), "ExplanationTechnicalInformationSummaryNoInfo", null, null, false, "No se ha ingresado información técnica a la solicitud." },
                    { new Guid("98864882-1f4d-4d40-8d94-9d0b0c83bc00"), "CorreoDesistimientoOperador", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("99002e12-278f-463e-b314-58c3dea3b4a9"), "WfTipoAlfa", null, null, false, "0" },
                    { new Guid("9922b325-7514-4d0c-bbe2-552e37a19ce6"), "FirmaElectronicaAZCodificacion", null, null, false, "Base64" },
                    { new Guid("9a2218b0-3efa-495b-9a20-40562d78a1a1"), "AlertBeforeRadicationError", null, null, false, "Señor operador" },
                    { new Guid("9acffc23-1020-461c-aba4-202f7b9be7d8"), "EmailMintic1", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("9b6cad03-ac49-4a7a-ae59-b49fc9ef8af6"), "xmlnsxsi", null, null, false, "http://www.w3.org/2001/XMLSchema-instance" },
                    { new Guid("9c1e8fc3-e361-4b71-8ba9-1beea34582b1"), "MailUsername", null, null, false, "Soporte Tesamerica" },
                    { new Guid("9d2061b6-7d43-4957-a268-653354b11e57"), "AutenticacionTMP_Pruebas", null, null, false, "https://pruebas.tesmonitorplanning.com/TesMonitorPlanning/TesMonitorPlanningWeb/index.html?ID=" },
                    { new Guid("9eb4a3ed-579f-4aa9-a6fd-e10a345437c5"), "MensajeAdvertenciaGarantias", null, null, false, "Señor usuario" },
                    { new Guid("9efaae82-bee9-432a-9677-69986a47d8eb"), "CorreoCertificadoCanalesMerge", null, null, false, "0" },
                    { new Guid("a011c60d-bd7e-4251-9db2-952ca827f392"), "SubdirectorPSO", null, null, false, "gperdomo" },
                    { new Guid("a09f10d0-bfbf-4463-be42-18f396b61930"), "ExplanationApplicationRedes", null, null, false, "Por favor seleccione las redes del expediente seleccionado que desea incluir en el certificado." },
                    { new Guid("a0ddf6be-2231-4403-943b-f9b2100a0d25"), "FechaFinMantenimiento", null, null, false, "11/10/2023 23:00:00.000" },
                    { new Guid("a0ee64e9-973c-4423-a749-80afef87c169"), "DireccionMintic", null, null, false, "Edificio Murillo Toro Cra. 8a entre calles 12 y 13" },
                    { new Guid("a16cb569-4510-4e34-ae5f-0de98d99e6ec"), "xsischemaLocation", null, null, false, "http://www.analitica.com.co/AZSign/Esquemas file:///F:/AZSign/Producto/AZSign/WebServices/WS-AZSign.xsd" },
                    { new Guid("a18258e3-9f86-4f67-a0cf-f52dca228111"), "FirmaElectronicaAZOrden", null, null, false, "0" },
                    { new Guid("a1c24253-2c03-4375-9dc9-5390f783145a"), "CityCodeMintic", null, null, false, "11001" },
                    { new Guid("a29c6468-51b4-4534-89c5-6760cd0ee28e"), "CorreoAprobacionANE-MINTIC_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" },
                    { new Guid("a4465825-e31a-4fbe-a35b-7b4eb1d212a5"), "Satelital_FirmaElec_Director", null, null, false, "dreinales" },
                    { new Guid("a484a525-d54a-4740-87db-8604b75d8ba0"), "MensajeCrearExpediente", null, null, false, "<div class='nombre_campo'><p style='margin:20px; text-align:justify;'>Señor usuario:</p><br/><p style='margin:20px; text-align:justify;'>El usuario acepta que a través del registro en el sitio web" },
                    { new Guid("a4b3d69b-33a4-426e-b010-40ec6e5839a3"), "EspTemp_CorreoRechazoMINTIC_ANE", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("a56bee44-0f16-449f-a40a-9f8c4b11a1d9"), "EstadosExpedienteNoUsadosFueraPSO", null, null, false, "eVEN,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("a60e54c2-f2a5-4828-b76d-6614244b296e"), "ExplanationApplicationDetailsRadicar", null, null, false, "Señor usuario" },
                    { new Guid("a6addc7a-39bf-4008-9172-97f6f5846181"), "EstadosExpedienteRadicacionParalelo", null, null, false, "eAUT,eSOL" },
                    { new Guid("a71bb091-1b39-4f04-a985-6f9f3b6112ab"), "CorreosRechazoSolicitudANE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("a77d00c8-4949-45e0-a33e-28fe814f78f9"), "TextoRefRegistroAnalisisAdministrativo", null, null, false, "Traslado para Análisis Técnico de la Solicitud con radicado No. {0} del {1}." },
                    { new Guid("a8a1205c-81b9-4a13-aed7-bd5a56fe4eb4"), "ApproveAdministrativeAnalisisCdDestino", null, null, false, "311" },
                    { new Guid("a8ba8c49-20a8-4afb-b63b-f92aa123f254"), "ExplanationApplicationCertificados", null, null, false, "Por favor seleccione el tipo de certificado" },
                    { new Guid("a8c517a4-a455-4065-baf5-09b77c2fe84a"), "AlertBeforeAdministrativeAnalisisApprobation", null, null, false, "Señor funcionario" },
                    { new Guid("a9a8d3fa-207c-4825-938b-e87197c5672a"), "MensajeBloqueoCartera", null, null, false, "Señor usuario" },
                    { new Guid("a9b0afce-09a5-4c78-b162-3532ab3a04d1"), "FirmaElectronicaAZTipoFirma", null, null, false, "E" },
                    { new Guid("a9c2f519-36c5-4a97-b02d-ded5eb6ef2ae"), "ExplanationAntennaCreation", null, null, false, "Formulario de creación de antena" },
                    { new Guid("aa41601e-41b4-4f45-a646-6cc1a8a18dee"), "RolesPermisoModuloResoluciones", null, null, false, "1,2,3,4,5,6,7,10,21,22,30,57,59,60,61,62,72,73,74,75,76,77,78,79,98,99,100,101,107,108" },
                    { new Guid("ab06db53-d71b-4ec6-a0b3-bfa8318016aa"), "HeaderRUES", null, null, false, "CO-QA/GOB/MINTIC-0012/SISCD" },
                    { new Guid("aba26369-6b84-4c8c-82bd-cbfc9926e9c6"), "CorreoDevolucionCT", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("abb70e3d-9ab0-4a31-872c-1f2702fb8ee0"), "TokenTMP_SecretKey", null, null, false, "F4209FA7-FAF6-4BF0-8A5E-783BE439DF9E" },
                    { new Guid("aef2274f-35c2-4e85-951d-ece054efe967"), "CorreoCertificadoRemitenteNombre", null, null, false, "Andres Rodriguez" },
                    { new Guid("afa63ea3-4983-4cb7-836d-4e6f42c74031"), "MetodoEnvioAlfa", null, null, false, "TL" },
                    { new Guid("b09205b1-16f3-4d1c-bf00-84646a9e1f92"), "AlertBeforeFileDeleting", null, null, false, "¿Está seguro que desea eliminar este archivo?" },
                    { new Guid("b106847d-81b0-48ee-8585-68daac3ef0df"), "MainPatternRazonSocial", null, null, false, "[^a-z]" },
                    { new Guid("b3083413-b806-467e-ae1a-2eeb98721200"), "UsernameRUES", null, null, false, "UserMinTic" },
                    { new Guid("b3b1bae7-8251-44a0-80c2-a155f47442ee"), "EspTemp_TextoReqPorAnexoTec", null, null, false, "Anexo Técnico para permisos temporales: Para agilizar la evaluación técnica de la solicitud en curso" },
                    { new Guid("b479b3a8-504e-4bbf-955b-6aa3cfd5d06a"), "WfTipoAlfaInterno", null, null, false, "1" },
                    { new Guid("b4c518e2-9faa-4551-ab37-3ba05d2658e7"), "CorreoCertificadoRemitenteCargo", null, null, false, "Representante Legal" },
                    { new Guid("b505d18b-e0d0-433f-92e9-68920dc48612"), "CorreoAprobacionResolucionRevisor5", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("b5e15743-423e-4b60-a504-34716db3fc19"), "IMT_AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("b6260d14-95bd-496e-b8c6-1ff49e8c439d"), "MensajeInfoEmergenciaSeguridad", null, null, false, "Las solicitudes que se realizan en esta sección se encuentran exceptuadas del procedimiento de selección objetiva" },
                    { new Guid("b6840488-1e15-4966-802b-e050e4aa117c"), "Clases_Expedientes_Satelital", null, null, false, "92" },
                    { new Guid("b6bd8454-1a80-49d4-aaf4-7ba0d874322c"), "ApproveTechnicalAnalisisNaturaleza", null, null, false, "770" },
                    { new Guid("b88c8977-eab5-4bd5-9e3e-23af1882b87c"), "ExplanationApplicationDetailsRadicarFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("bbe1436a-e8f7-49ac-8fe0-afbe0d39f98a"), "ApiNotificaciones_Aplicacion", null, null, false, "TesAmerica" },
                    { new Guid("be4489ba-205e-4d6d-bb29-e3c20c90bff3"), "SupportEmail_Prueba", null, "rsandoval@mintic.gov.co", false, "mailto:rsandoval@mintic.gov.co" },
                    { new Guid("bea6bacb-398a-4d90-bfad-12dc75ed1bc6"), "ExplanationAntennaList", null, null, false, "Seleccione la antena desde la lista de selección para ver los detalles. Si la antena no se encuentra puede crearla haciendo clic en el botón 'Nueva antena'" },
                    { new Guid("beab24d9-894f-4828-ae7d-72a769192a83"), "TextoNotificacionSigpol", null, null, false, "Señor usuario una de sus garantías presenta una novedad" },
                    { new Guid("c090d029-3089-4fcd-8a80-005193dff504"), "CorreoCertificadoCanalesEmailCertificado", null, null, false, "1" },
                    { new Guid("c0938d2f-85c0-4f6a-a0b2-2d9d725fdd7d"), "FirmaElectronicaAZContraseña", null, null, false, "b1a8262799b1746913b4476ab1b17238" },
                    { new Guid("c1f0cb39-ae1a-41fd-b6ca-718bffe5e808"), "CorreoCertificadoCanalesMensaje", null, null, false, "Mensaje del Email Pruebas" },
                    { new Guid("c2325235-e737-456e-9c8f-e191bc89ac16"), "NombreArchivoAlfaClosing", null, null, false, "Aprobacion_Final_Solicitud_{0}_{1:ddMMyyHHmmss}.rtf" },
                    { new Guid("c26a59dd-b8d8-428d-a6e3-b11238082d9a"), "ExplanationApplicationSolve", null, null, false, "Consulte el histórico de las solicitudes finalizadas" },
                    { new Guid("c2b6e405-f1d8-452d-b0b6-6f9cce055a72"), "ExplanationRejectApplication", null, null, false, "Por favor ingrese la información requerida para rechazar la solitud" },
                    { new Guid("c2d9793f-876f-43c7-8e61-5c29eae30b11"), "TiposResolucionRenovacionOtorga", null, null, false, "1" },
                    { new Guid("c446a74b-c804-4cbd-b7e5-130ff28c5c37"), "EstadosRedesVAC", null, null, false, "rAUT,rRES,rPRN,rPRE,rTT" },
                    { new Guid("c471f837-2a32-4321-96e4-60c9663c844e"), "Satelital_CorreoFinResolucionMINTIC", null, null, false, "ebernate@g.com,kballen@g.com,carengifo@g.com,crojas@g.com,aruiz@g.com,nmendez@g.com" },
                    { new Guid("c58c23eb-a48a-4674-908d-d5e740a7004f"), "TelefonoMintic2", null, null, false, "No disponible" },
                    { new Guid("c5ca40ae-f462-4310-9eac-f3d163c093ef"), "AZDigital_Resoluciones_Dependencia", null, null, false, "100" },
                    { new Guid("c5f96629-1901-42aa-bce7-8b1e5560daa8"), "EmailsNotificacionSubsanarDocumentos", null, null, false, "soporte.tesamerica@tesamerica.com.co" },
                    { new Guid("c64309e8-3cb3-4d03-84d9-90f74f03bec2"), "SupportEmail", null, "(soporte.sge@mintic.gov.co)", false, "mailto:soporte.sge@mintic.gov.co" },
                    { new Guid("c7c40cf3-9373-4c2e-8440-5f9b9be47ed4"), "NumeroArchivosRadicacion", null, null, false, "2" },
                    { new Guid("c907998e-f2a8-4bfd-b9d0-ca1025d2f95e"), "NombreArchivoAlfaRadicacion", null, null, false, "Radicacion_Solicitud_{0}_{1:ddMMyyHHmmss}.xml" },
                    { new Guid("c92c33cf-9977-45ae-a45d-697f6ef42736"), "IMT_AZDigital_Dependencia", null, null, false, "2.2" },
                    { new Guid("c9c70b78-c4b3-4f4f-bfb3-5609c6d69b15"), "RegistroTicUrl", null, "Registro de TIC", false, "http://www.mintic.gov.co/portal/604/w3-article-6398.html" },
                    { new Guid("c9f0485c-6f43-49bd-a876-d49f185869bf"), "ExplanationApplicationDetailsEditarInfoTecnica", null, null, false, "Señor usuario" },
                    { new Guid("cab53b36-b14f-4019-9819-0277aee92240"), "UrlLoginSpectrumE", null, null, false, "http://simulacion.ane.gov.co:8088/se/portal/ane/loginproc.php?" },
                    { new Guid("cafe6dd1-fa31-4093-b5c8-89355d7b3ce3"), "RolesPermisoVerDocumentacionSolicitudesDirectas", null, null, false, "30,76,77,78,79,57,59,98,60,61,62,99,100,72,73,74,75,101,107,108" },
                    { new Guid("cbac277f-ca1e-4128-9435-108cb0e0b092"), "EmailMintic2", null, null, false, "No disponible" },
                    { new Guid("cdf69568-315f-4c04-a67e-a06083923690"), "CorreosRechazoSolicitudMINTIC", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("ce269e58-c873-4514-bc0e-fe9546e6d489"), "CoordinadorPSO", null, null, false, "ogarzon" },
                    { new Guid("d0fd4ae1-c6a8-41ea-9372-8328f4a83d30"), "MotivoRechazoGarantias", null, null, false, "No cumplir con lo establecido en el numeral 3 del artículo 3 de la resolución 485 de 2024" },
                    { new Guid("d168f962-f4ec-4c67-a6d8-db1b071430d7"), "ExplanationFilesSummaryNoFiles", null, null, false, "No se han adjuntado archivos a la solicitud." },
                    { new Guid("d1827d20-052f-4989-b887-a99015cdba1a"), "ExcelAutoliquidador", null, null, false, "Use el botón 'Cargar formato excel' si desea liquidar múltiples redes mediante un archivo .xls previamente diligenciado. El formato puede obtenerse haciendo clic en el botón 'Plantilla formato excel'" },
                    { new Guid("d2363926-21b8-4957-a857-91a9b6490602"), "EspTemp_Fecha_Subsanacion_Admin", null, null, false, "1" },
                    { new Guid("d2ff473b-7280-4395-89aa-9a6ccaa8ac25"), "DependenciaAlfa", null, null, false, "sage001" },
                    { new Guid("d39bc0a2-f6e9-4a4a-8831-358b94b15e59"), "ApiNotificaciones_Url", null, null, false, "https://integratic.mintic.gov.co/Notificaciones/Webservices/SOAP/" },
                    { new Guid("d4917eb1-77c6-4b89-9ca3-5c3c82fcd49c"), "TermsAndConitions", null, null, false, "Términos y condiciones: como usuario de la aplicación" },
                    { new Guid("d4b91763-5a4d-4287-b73a-14c65d18b719"), "FilesNeededToRadicate", null, null, false, "los tipos de archivos obligatorios para radicar una solicitud en un proceso de selección objetiva son: Formato Básico de la Solicitud (firmado por el representante legal)" },
                    { new Guid("d4c487cb-4d64-4bd9-96f8-b4993d73d654"), "ApproveTechnicalAnalisisSerieDocumental", null, null, false, "Serie Documental" },
                    { new Guid("d5ccd5d4-b456-4b25-a112-a2a489b48ff1"), "EspTemp_PortadaANE", null, null, false, "Agencia Nacional del Espectro;Solicitudesdeespectro@g.com" },
                    { new Guid("d5d4f5f8-eb0b-4d5a-8ca2-f94762eb3e40"), "CorreosAlertaCancelaciones", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("d5db93e7-a05b-4860-afdc-8d4cebbdfd0f"), "UrlFirmaElectronica", null, "URL de consumo para el servicio de firma electrónica", false, "https://azsign.analitica.com.co/WebServices/SOAP/" },
                    { new Guid("d6011df7-859d-4573-8b18-f5aafd1e94a7"), "EstadosExpedienteRadicacionSerie", null, null, false, "eRES,eCT" },
                    { new Guid("d62ae6bf-8e9b-417d-8f8b-3a5ef935d400"), "NombreMintic", null, null, false, "Ministerio TIC" },
                    { new Guid("d665ad7a-cd42-4b9d-8ab5-41f8433cf8d6"), "CertificacionGarantiasTextoFirma", null, null, false, "Coordinador GIT de Gestión de Garantías" },
                    { new Guid("d682af83-1699-405f-81c3-d024719ec709"), "DestinatariosDesestimientoTacitoSatelitalpreliminarAne", null, null, false, "hernan.palta@tesamerica.com.co" },
                    { new Guid("d6d7bfe0-59d2-4edf-8be9-c3eb68aa75c3"), "TechnicalInformationSummaryXmlMassivelyUploaded", null, null, false, "Información cargada masivamente a partir de archivo .xml" },
                    { new Guid("d7a5afa3-221b-4920-b689-15e8b056a8b3"), "CorreoCertificadoCanalesPlantillaEmail", null, null, false, "EmailNotificacion.html" },
                    { new Guid("d7d6fc47-1550-40a6-9c6d-0b3bc2e89923"), "MensajeInfoNOPSO", null, null, false, "Las solicitudes que se realizan en esta sección corresponden a las que pueden ser tramitadas fuera de un Proceso de Selección Objetiva- PSO" },
                    { new Guid("d8224f63-3528-406f-836d-b7e34ebe82ef"), "NaturalezaAlfaSolicitud", null, null, false, "100" },
                    { new Guid("d82289a9-0773-4534-90ff-c98e224078d6"), "CorreoInformeEvaluacion", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("d859d6bb-f955-481b-9f2c-d0148024d219"), "CorreoEnvioANE-Mintic", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("d88ea36b-6ffd-4224-a44f-b77803a80b03"), "EspTemp_ExtensionArchivoPatronRadiacion", null, null, false, ".bmp,.gif,.heif,.heic,.jpg,.jpeg,.png,.psd,.svg,.tif,.tiff,.doc,.docx,.md,.odt,.pdf,.ppt,.pptx,.rtf,.txt,.xls,.xlsx,.7z,.rar,.zip" },
                    { new Guid("d9f21d94-659f-4aa6-b3c8-c0fe5adfb990"), "DireccionMensajeFormato", null, null, false, "El formato para ingresar la dirección de la estación en el anexo es: Identificación de la vía (calle" },
                    { new Guid("da382949-caf9-4776-8035-9e3384b52eb0"), "FirmaElectronicaRefWebHook", null, null, false, "AZDigital: (5)" },
                    { new Guid("db42f947-1468-41d4-b28d-92b76886a647"), "Satelital_Portada_ANE", null, null, false, "Agencia Nacional del Espectro;Solicitudesdeespectro@g.com" },
                    { new Guid("db8fc0d3-52d3-4010-af0f-354109dffdd3"), "ExplanationApplicationDetailsEditarInfoTecnicaFuncionario", null, null, false, "Señor funcionario" },
                    { new Guid("dbe89446-b76a-4229-afbf-c85cd1eaf059"), "ExplanationDuplexerCreation", null, null, false, "Formulario de creación de duplexor" },
                    { new Guid("dc047d41-0b57-4caf-96af-21a7636450c2"), "AZDigital_Sitio", null, null, false, "Prue" },
                    { new Guid("dc34a6bd-c290-49eb-b9f6-e7308503b257"), "Satelital_FirmaElec_SubDirector", null, null, false, "lpineda" },
                    { new Guid("de8b1d3f-ddf2-48ae-af12-714460759a3d"), "Cronograma", null, null, false, "2" },
                    { new Guid("dfb99c7b-fc55-42dc-b09b-d0fd5d667136"), "CustomerFrontProcessInfo", null, null, false, "El Sistema para la Gestión del Espectro Radioeléctrico “SGE”" },
                    { new Guid("e0ba0a45-fd55-4d07-a603-a7d2bce5040d"), "CausaRechazoNOSubsanar", null, null, false, "No cumplir con lo establecido en el numeral 1" },
                    { new Guid("e0fae68f-8f06-473a-8cf7-e8128c68b14d"), "FirmaElectronicaAction", null, null, false, "urn:/#NewOperation" },
                    { new Guid("e185e001-6650-41d5-a2fe-a6551be9d3bf"), "ExplanationApplicationAdministrativeAnalysis", null, null, false, "El análisis administrativo de una solicitud es el primer proceso luego de su radicación." },
                    { new Guid("e2632e92-f774-460f-a7c8-4b38e6bf2a65"), "LegendFilingApplicationDetails", null, null, false, "Radicación de la solicitud" },
                    { new Guid("e2b2b45b-e137-494f-bb5a-a6632af100dc"), "TokenTMP_Rol", null, null, false, "128" },
                    { new Guid("e2ea80fe-6007-44bb-a596-740759790b2d"), "MensajeBloqueoGarantias", null, null, false, "Señor usuario" },
                    { new Guid("e3c95193-7658-436e-90d8-bc6ace37d88d"), "MensajeAdvertenciaRTIC", null, null, false, "Señor usuario" },
                    { new Guid("e47f1ff5-d22e-4c00-b5a8-007ce483dc50"), "ExplanationApplicationDetailsArchivosSolDirectas", null, null, false, "Archivos necesarios: Cédula de ciudadanía" },
                    { new Guid("e5c70239-99f5-4f07-99b9-4a9f970ac394"), "CorreosCopiaOcultaRechazoSolicitud", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("e64b2a98-eacb-4ce7-993c-89dad0a6f471"), "FirmaElectronicaNombre", null, null, false, "Prueba Documento AZSign PHP WS" },
                    { new Guid("e67380da-1e55-43b6-9673-8d793d13811c"), "CorreosAlertaCesionExpediente", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("e6aea4d0-9674-4809-bc1a-845423f0fa58"), "CorreosAletaBloqueoRUTIC", null, null, false, "andres.rodriguez@tesamerica.com.co,rutic@g.com" },
                    { new Guid("e70ebb13-53f7-4b57-8419-c061710fdb7f"), "AlertBeforeTechnicalAnalisisApprobation", null, null, false, "Señor funcionario" },
                    { new Guid("e817933a-d1ab-43cb-a5d4-767fbd6c72e5"), "FirmaElectronicaAZEstado", null, null, false, "1-P" },
                    { new Guid("e82fdef8-0453-42c9-80a7-b27249888a63"), "EsPrueba", null, null, false, "true" },
                    { new Guid("ea93b779-caee-4a6f-bb04-8aefb63b0cd4"), "EstadosExpedienteNoUsadosPSO", null, null, false, "eCT,eRES,eVEN,eX0,eX1,eX1B,eX2B,eX3,eX4,eX4B" },
                    { new Guid("eb0fdcc8-09f6-4596-962d-09f6e2f46571"), "CityCodeAne", null, null, false, "11001" },
                    { new Guid("eba2bd33-993b-4dca-8874-8de6dbed1391"), "CorreoCopiaANE-MINTIC_Satelital", null, null, false, "Solicitudesdeespectro@g.com" },
                    { new Guid("ec551919-3780-4905-933d-c00a4f3d6bbf"), "TokenTMP_TypeIdent", null, null, false, "NIT" },
                    { new Guid("ec626cf6-8816-4075-85de-0518b98cffd2"), "FirmaElectronicaAZCuenta", null, null, false, "20201120-151412-85f600-89728214" },
                    { new Guid("ec989e36-c15e-4814-b718-a692a36d25e4"), "AdvertenciaFlash", null, null, false, "Para el correcto funcionamiento de la herramienta es necesario actualizar Flash Player" },
                    { new Guid("ecbacb06-fca4-410a-84e7-9bf230379f8b"), "AZDigital_TramiteRegistroSatelital", null, null, false, "RPTA_S" },
                    { new Guid("ecccc3ee-2bf6-4cbb-b3f5-ac8e94cf488c"), "FilesSummaryFilesCount", null, null, false, "Número de archivos adjuntos:" },
                    { new Guid("eda70921-9620-4ccb-a80b-7530ed226334"), "PasswordAlfa", null, null, false, "0qLpWZIlpg2zlKSYcj0D" },
                    { new Guid("edaf84ce-0029-430c-bfab-e91c8b78b879"), "MensajePrevioMantenimiento", null, null, false, "El Ministerio de Tecnologías de la Información/Fondo Único de TIC informa que el próximo <b>{0} hasta las {1}</b> realizara mantenimiento al aplicativo. <b>Durante este mantenimiento los servicios no estarán disponibles.</b> Agradecemos su comprensión no ingresando a la aplicación en esta franja de tiempo." },
                    { new Guid("ee5f9c04-56bb-4147-921d-5545173ec8e2"), "ExplanationApplicationTechnicalAnalysis", null, null, false, "En el análisis técnico se efectuará un estudio detallado de la información técnica registrada para cada solicitud" },
                    { new Guid("ee7c856f-bb7b-44aa-975c-b7ecb5f4aec1"), "CorreoResumenTecnico", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("ef9f62ec-6b4a-41e9-bf24-30981c71d45e"), "Clases_Expedientes_Industria", null, null, false, "97,95,20" },
                    { new Guid("f000f5ff-ff3f-4b7a-9db8-499cbf3e5a1c"), "EspTemp_AZDigital_TramiteRadicado", null, null, false, "PQRSD" },
                    { new Guid("f006e370-d426-422e-a0c9-1b0c378e4186"), "DestinatariosCCDesestimientoTacitoSatelital", null, null, false, "" },
                    { new Guid("f1f246eb-d0e7-4510-86b4-557e90bd0683"), "EstadosExpedienteDatosContacto", null, null, false, "eREG" },
                    { new Guid("f2696378-304b-4aa2-bfdc-e62b4d3d7438"), "EstadosExpedienteActivo", null, null, false, "eAUT" },
                    { new Guid("f2a73b6e-dc7c-4a56-a1e8-3406c5cab099"), "Garantia_Coordinador", null, null, false, "Coordinador del Grupo Interno de Trabajo Gestión de Garantías" },
                    { new Guid("f2e4be40-51f3-4d44-be4a-ca9159427d27"), "EspTemp_VersionFormatoAnexo", null, null, false, "1,1" },
                    { new Guid("f2fe3369-dc4a-4ec4-81f7-a11652788ce0"), "AZDigital_TramiteRegistro", null, null, false, "rs" },
                    { new Guid("f31219d6-f590-407c-83d9-f55203e04808"), "ApiNotificaciones_URIPlantilla", null, null, false, "TesAmerica.docx" },
                    { new Guid("f376f41c-4eb8-451e-b3e1-c4e32423c78b"), "CorreosRadicacionSolicitudesPSO", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("f466e5be-29d9-4a3e-85ce-1f301cd443b6"), "UsuarioServicioAuraPortalNew", null, null, false, "mintic/bpmimpersonate" },
                    { new Guid("f5affe7f-9347-40be-a773-3f2bebb34a09"), "Garantia_Subdirector", null, null, false, "Subdirector de Industria de Comunicaciones" },
                    { new Guid("f5fe911e-c811-470b-83c4-405fd1b02057"), "AZDigital_Resoluciones_TipoNotificacionCorreo", null, null, false, "CE" },
                    { new Guid("f68a0382-c2ff-4c95-93a8-1a9eb8f58219"), "ExplanationPortfolioGrid", null, null, false, "Listado de expedientes. Utilice los íconos frente a cada expediente para observar los detalles o editar. Si no encuentra el número de expediente deseado" },
                    { new Guid("f6af38ca-8294-486a-8ea3-a5517db78366"), "DireccionAne", null, null, false, "Calle 93B # 16-47" },
                    { new Guid("f7334048-94c5-49d4-9adf-9b7a4b560c52"), "NombreArchivoAlfaRechazoSolicitud", null, null, false, "Rechazo_Solicitud_{0}_{1:ddMMyyHHmmss}.pdf" },
                    { new Guid("f80f844b-b78e-429f-a763-15096d774d70"), "FlashPlayer", null, "https://get.adobe.com/es/flashplayer/", false, "https://get.adobe.com/es/flashplayer/" },
                    { new Guid("f8880208-46f0-4fbb-b415-c9205db8db8b"), "IMT_IdEquip", null, null, false, "17363" },
                    { new Guid("f8ffdf5d-b0ad-4982-ab7d-7d78c4bdccb6"), "DireccionMensajeMaximoCaracteres", null, null, false, "En el anexo solo se pueden ingresar máximo 49 caracteres en la dirección de la estación." },
                    { new Guid("f9362b3a-fad7-42fc-a6fc-7ad162d0820a"), "FirmaElectronicaAZAplicativo", null, null, false, "20201209-092929-982602-00332255" },
                    { new Guid("fb12e130-e0d2-4ae4-86d1-5f37bdd6989c"), "ExplanationTechnicalInformationEdit", null, null, false, "Información general y creación de antenas" },
                    { new Guid("fc03e011-5a2f-4823-87f5-02de13a7935f"), "NitAne", null, null, false, "9003342653" },
                    { new Guid("fc162218-da2d-436f-9dc5-b3adf01c7aba"), "Temp_File_Espectro_New", null, null, false, "C:\\SAGE\\EspectroTemporal\\EspectroTemp_Back\\tempdatafile" },
                    { new Guid("fd6d239c-729c-4832-a475-d6f0ce142327"), "ExplanationDuplexerList", null, null, false, "Seleccione el duplexor desde la lista de selección para ver los detalles. Si el duplexor no se encuentra puede crearlo haciendo clic en el botón 'Nuevo duplexor'" },
                    { new Guid("fdad100f-d956-4a6a-a542-cbab4f71e08e"), "NumeroArchivosRadicacionSolDirecta", null, null, false, "9" },
                    { new Guid("fe3d482d-bfee-40ed-959a-149647d4b9d8"), "CorreoCoordinacion_GGERE", null, null, false, "andres.rodriguez@tesamerica.com.co" },
                    { new Guid("ff52c068-059e-4492-a669-87567767f38e"), "EspTemp_CorreoAprobacionANE_MINTIC", null, null, false, "solicitudesane@g.com,ruben.zuleta@tesamerica.com.co" },
                    { new Guid("ffa58477-e636-40b4-a6c1-c2bb44e415ff"), "ClasesExpedienteRTIC", null, null, false, "96,81,83,84,86,87,88,89" },
                    { new Guid("ffffacc6-ac37-44b0-b0a3-c98cc31b2030"), "CorreoCopiaMINTIC-ANE_Satelital", null, null, false, "solicitudessatelital@g.com,Paola@g.com" }
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
                    { "01J4NC0YB39WF56DG4TRN7Y1X5", "SOLICITUD_ESTADO", null, null, false, "Estados de una solicitud", null, null },
                    { "01J4NC0YB3KKMRZXJ2THHXFYQ8", "PERSONA_CONDICION", null, null, false, "Condición de persona", null, null },
                    { "01J4NC0YB3WF7ZSF13S9Z2B611", "PERSONA_TIPO", null, null, false, "Tipo de persona", null, null },
                    { "01J4NC0YB3XCXCSN0MBPK2RRQ6", "REPRESENTANTE_TIPO", null, null, false, "Tipo de representante", null, null },
                    { "01J4NC0YB3174TYR28HD52AA30", "SOLICITUD_ESTADO_DESISTIDA_PENDIENTE", null, "La solicitud fue aprobada por la ANE y genero CT, y el operador la desiste. Pendiente devolver el CT", false, "Desistida Pendiente", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB31DKBNV2R54KP4K3D", "SOLICITUD_ESTADO_DESISTIDA_TACITAMENTE", null, "Solicitud rechazada por no realizar la subsanación en el tiempo establecido", false, "Desistida tacitamente", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB321KAF9FD4NGJMZJV", "SOLICITUD_ESTADO_SUBSANACIÓN_POR_CAMPOS", null, "El operador realiza la subsanación del requerimiento por campos del anexo técnico realizado por la ANE", false, "Subsanación por campos", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3273KDDW4DMK56Z70", "SOLICITUD_ESTADO_RESUMEN_TÉCNICO_GENERADO", null, "La ANE genera el resumen técnico", false, "Resumen Técnico Generado", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB33MY88DF1R33HVPGK", "PERSONA_TIPO_NATURAL", null, null, false, "Natural", "01J4NC0YB3WF7ZSF13S9Z2B611", null },
                    { "01J4NC0YB352G75BYBJ9E77EYG", "REPRESENTANTE_TIPO_APODERADO", null, "Aquella persona designada mediante poder general o especial, conferido por el representante legal con facultades para ello, para solicitar permisos de espectro a nombre de la empresa que representa.", false, "Apoderado", "01J4NC0YB3XCXCSN0MBPK2RRQ6", null },
                    { "01J4NC0YB36J5KS1456B31TX3M", "SOLICITUD_ESTADO_GENERANDO_OFICIO", null, "La solicitud fue rechada por alguna de las dos entidades (MinTIC-ANE) y pasa al flujo de oficio", false, "Generando Oficio", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB36S69T2VBVKNRGVHD", "SOLICITUD_ESTADO_GENERANDO_RESOLUCIÓN", null, "La solicitud fue aprobada por ambas entidades (MinTIC-ANE) y pasa al flujo de resolución", false, "Generando Resolución", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB382ZWZ1XK2TNSAEA5", "SOLICITUD_ESTADO_APROBADA", null, "Solicitud aprobada", false, "Aprobada", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3A9S7YTFJD78D1JGC", "SOLICITUD_ESTADO_RECHAZADA", null, "Solicitud rechaza", false, "Rechazada", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3BG8C601TN4C18JBK", "SOLICITUD_ESTADO_PENDIENTE_RADICACIÓN", null, "Solicitud que no ha sido radicada", false, "Pendiente Radicación", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3CKWW30655XZKD6NH", "SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO", null, "La solicitud se rechaza por cartera, garantías, RUTIC u otro motivo general", false, "Rechazo Administrativo", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3DXSGVJG914XNGWJD", "PERSONA_CONDICION_INTERNACIONAL", null, null, false, "Extranjero", "01J4NC0YB3KKMRZXJ2THHXFYQ8", null },
                    { "01J4NC0YB3E17GQF1WD597GN00", "SOLICITUD_ESTADO_RECHAZADA_PENDIENTE", null, "Solicitud aprobada por la ANE (CT generado) y rechazada por MinTIC. Pendiente de devolver el CT", false, "Rechazada Pendiente", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3EDYD2JMZWV2Z7N83", "SOLICITUD_ESTADO_EN_REVISION", null, "Solicitud radicada y en flujo de revisión", false, "En revision", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3FWS7J33G04J1SHX9", "SOLICITUD_ESTADO_DEVOLUCIÓN_REQUERIMIENTO", null, "El coordinador devuelve el requerimiento al evaluador para que vuelva a revisar", false, "Devolución requerimiento", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3FZ58BNQZEVAGGD5B", "PERSONA_TIPO_JURIDICA", null, null, false, "Juridica", "01J4NC0YB3WF7ZSF13S9Z2B611", null },
                    { "01J4NC0YB3FZC0SEJ14C9NGJ0P", "SOLICITUD_ESTADO_REQUERIDA", null, "Solicitud requerida", false, "Requerida", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3JJTTQ586869Y9WX2", "SOLICITUD_ESTADO_DESISTIDA", null, "Solicitud desistida por el operador", false, "Desistida", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3JM6ZC3PZGTRP1MAR", "REPRESENTANTE_TIPO_LEGAL_ILIMITADO_EN_SUS_FACULTADES", null, "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa.", false, "Representante legal ilimitado en sus facultades", "01J4NC0YB3XCXCSN0MBPK2RRQ6", null },
                    { "01J4NC0YB3M31JKSTR69N3ABP3", "SOLICITUD_ESTADO_REQUERIMIENTO_POR_CAMPOS", null, "La ANE realiza un requerimiento por campos del anexo técnico", false, "Requerimiento por campos", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3P5H2RMWP627Q42H3", "SOLICITUD_ESTADO_RECHAZO_ADMINISTRATIVO_EN_COORDINACIÓN", null, "El evaluador rechazo la solicitud por cartera, garantías, RUTIC u otro motivo general, y está pendiente la aprobación del rechazo por parte del coordinador", false, "Rechazo Administrativo en coordinación", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3SKCX67S30MWG3YRC", "REPRESENTANTE_TIPO_LEGAL_LIMITADO_EN_SUS_FACULTADES", null, "Aquel que de acuerdo con lo expresado en el certificado de existencia y representación legal de la empresa no posee plenas facultades para solicitar permisos de espectro a nombre de la empresa que representa, por lo cual, requiere de la presentación de un poder adicional que lo faculte para realizar solicitudes de este tipo.", false, "Representante legal limitado en sus facultades", "01J4NC0YB3XCXCSN0MBPK2RRQ6", null },
                    { "01J4NC0YB3SM2KSA7KJENHRRBT", "SOLICITUD_ESTADO_OFICIO_APROBADO", null, "El oficio finaliza el flujo, es aprobado y se envia para firma electrónica", false, "Oficio Aprobado", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3SP4QNAF2ZZX4TFNT", "SOLICITUD_ESTADO_RESOLUCIÓN_APROBADA", null, "La resolución finaliza el flujo y se envia a IntegraTIC", false, "Resolución aprobada", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3SRD71YQQSD052FCP", "SOLICITUD_ESTADO_RECHAZO_EN_COORDINACIÓN", null, "El evaluador rechazo uno o más documentos y está pendiente la aprobación del rechazo por parte del coordinador", false, "Rechazo en coordinación", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3SYSYBN5YS2EZA0A0", "SOLICITUD_ESTADO_REQUERIMIENTO_EN_COORDINACIÓN", null, "El evaluador requiere uno o más documentos y está pendiente la aprobación del requerimiento por parte del coordinador", false, "Requerimiento en coordinación", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3TW4ECBDSFT6TBH8M", "SOLICITUD_ESTADO_DESISTIDA_TÁCITAMENTE_PENDIENTE", null, "La fecha limite de subsanación se venció y la ANE puede aumentar el plazo de subsanación", false, "Desistida Tácitamente Pendiente", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3TWPV9V3XW4XVAC3R", "PERSONA_CONDICION_NACIONAL", null, null, false, "Nacional", "01J4NC0YB3KKMRZXJ2THHXFYQ8", null },
                    { "01J4NC0YB3W65XRK3GGQ5MEHVW", "SOLICITUD_ESTADO_RESOLUCIÓN_GENERADA", null, "El proyector genera la resolución", false, "Resolución Generada", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3W8K4JA3AF00FAQ27", "SOLICITUD_ESTADO_SUBSANADA", null, "El operador subsana los requerimientos", false, "Subsanada", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3WYJMRXQ9GW2VFGHF", "SOLICITUD_ESTADO_DEVOLUCIÓN_RESOLUCIÓN", null, "El proceso esta en el flujo de resolución y se devuelve a la ANE para volver a revisar", false, "Devolución Resolución", "01J4NC0YB39WF56DG4TRN7Y1X5", null },
                    { "01J4NC0YB3Y6WX2M6K6YK4V330", "SOLICITUD_ESTADO_OFICIO_GENERADO", null, "El proyector genera el oficio", false, "Oficio Generado", "01J4NC0YB39WF56DG4TRN7Y1X5", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTexts_Code",
                table: "DynamicTexts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureProcesses_ProcedureId",
                table: "ProcedureProcesses",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessProcedure_ProcessId",
                table: "ProcessProcedure",
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
                name: "ProcedureProcesses");

            migrationBuilder.DropTable(
                name: "ProcessProcedure");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Processes");
        }
    }
}
