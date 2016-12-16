using CommandLine;
using CommandLine.Text;

namespace StoreSubmission
{
    public class ClientConfiguration
    {

        /// <summary>
        /// Client Id of your AAD app.
        /// Example" ba3c223b-03ab-4a44-aa32-38aa10c27e32
        /// </summary>
        [Option('i', "clientId", Required = true, HelpText = "Client Id of your AAD app")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret of your AAD app
        /// </summary>
        [Option('s', "clientSecret", Required = true, HelpText = "Client secret of your AAD app")]
        public string ClientSecret { get; set; }


        private string tennantId { get; set; }

        [Option('t', "tennantId", Required = false, HelpText = "TennantId is used to create the tokenEndpoint")]
        public string TennantId
        {
            get => tennantId;
            set
            {
                tennantId = value;
                TokenEndpoint = $"https://login.microsoftonline.com/{tennantId}/oauth2/token";
            }
        }

        /// <summary>
        /// Service root endpoint.
        /// Example: https://manage.devcenter.microsoft.com
        /// </summary>
        //[Option('u', "ServiceUrl", Required = false, DefaultValue = "https://manage.devcenter.microsoft.com", HelpText = "Service root endpoint")]
        public string ServiceUrl { get; set; } = "https://manage.devcenter.microsoft.com";

        /// <summary>
        /// Token endpoint to which the request is to be made. Specific to your AAD app
        /// Example: https://login.windows.net/d454d300-128e-2d81-334a-27d9b2baf002/oauth2/token
        /// </summary>
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// Resource scope. If not provided (set to null), default one is used for the production API
        /// endpoint ("https://manage.devcenter.microsoft.com")
        /// </summary>
        //[Option('c', "Scope", Required = false, DefaultValue = "https://manage.devcenter.microsoft.com", HelpText = "Resource scope. If not provided (set to null), default one is used for the production API endpoint")]
        public string Scope { get; set; } = "https://manage.devcenter.microsoft.com";

        /// <summary>
        /// Application ID.
        /// Example: 9WZANCRD4AMD
        /// </summary>
        [Option("applicationId", Required = true, HelpText = "Application ID")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// In-app-product ID;
        /// Example: 9WZBMAAD4VVV
        /// </summary>
        //[Option("inAppProductId", Required = false, HelpText = "In-app-product ID")]
        public string InAppProductId { get; set; }

        /// <summary>
        /// AppxFile
        /// Example: mural.appxupload
        /// </summary>
        [Option("appxFile", Required = true, HelpText = "AppxFile name")]
        public string AppxFile { get; set; }

        /// <summary>
        /// ZipFile
        /// Example: mural.zip
        /// </summary>
        [Option("zipFile", Required = true, HelpText = "ZipFile to upload")]
        public string ZipFile { get; set; }

        /// <summary>
        /// Flight Id
        /// Example: 62211033-c2fa-3934-9b03-d72a6b2a171d
        /// </summary>
        [Option("flightId", Required = false, HelpText = "Flight Id")]
        public string FlightId { get; set; }

        /// <summary>
        /// IsFlight
        /// </summary>
        [Option("isFlight", Required = false, DefaultValue = false, HelpText = "Create an App submission or a Flight submission")]
        public bool IsFlight { get; set; }

        /// <summary>
        /// mandatory
        /// </summary>
        [Option("mandatory", Required = false, DefaultValue = false)]
        public bool IsMandatory { get; set; }

        /// <summary>
        /// PublishMode
        /// </summary>
        [Option("publishMode", Required = false, DefaultValue = TargetPublishMode.Manual, HelpText = "publish mode: Immediate/Manual")]
        public TargetPublishMode PublishMode { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    public enum TargetPublishMode
    {
        Immediate,
        Manual,
    }
}