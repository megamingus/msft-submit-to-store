using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSubmission
{
    class Program
    {

        static void Main(string[] args)
        {
            var options = new ClientConfiguration();
            var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

            if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-2)))
            {
                Run(options);
            }
        }
        private static void Run(ClientConfiguration config)
        {
            if (config.IsFlight)
            {
                if (string.IsNullOrEmpty(config.FlightId))
                {
                    Console.WriteLine("A FlightId is needed");
                    Environment.Exit(-2);
                }

                new FlightSubmissionUpdate(config).RunFlightSubmissionUpdate();
            }
            else
                new AppSubmissionUpdate(config).RunAppSubmissionUpdate();

            //var tennantId = args[0];

            //var config = new ClientConfiguration()
            //{
            //    ClientId = args[1],
            //    ClientSecret = args[2],
            //    ApplicationId = args[3],
            //    FlightId = args[4],
            //    AppxFile = args[5],
            //    ZipFile = args[6],
            //    TokenEndpoint = $"https://login.microsoftonline.com/{tennantId}/oauth2/token",
            //    ServiceUrl = "https://manage.devcenter.microsoft.com",
            //    Scope = "https://manage.devcenter.microsoft.com",
            //};
            //var isFlight = false;
            //if (args.Length > 7)
            //    bool.TryParse(args[7], out isFlight);
            //if (isFlight)
            //    new FlightSubmissionUpdate(config).RunFlightSubmissionUpdate();
            //else
            //    new AppSubmissionUpdate(config).RunAppSubmissionUpdate();
        }



    }
}
