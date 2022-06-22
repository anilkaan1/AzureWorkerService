using AzureWorkerService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.Services
{
    public class registrationList
    {
        public List<Registration> registrations { get; set; }

    }


    public static class RegistrationJson
    {

        public static registrationList registrationsObj;

        private static registrationList gatherRegistrations()
        {

            string filename = String.Format(Environment.CurrentDirectory + "/wwwroot/Registration.json");

            using (StreamReader file = File.OpenText(filename))
            {

                using (JsonTextReader reader2 = new JsonTextReader(file))
                {

                    // 'Exception has been thrown by the target of an invocation.'

                    // reader2.ReadAsString();

                    string a = file.ReadToEnd();

                    registrationsObj = JsonConvert.DeserializeObject<registrationList>(a);

                }
            }

            return registrationsObj;

        }

        public static string registerNewUser(String UserId, String InstallationId)
        {
            gatherRegistrations();

            if (registrationsObj.registrations.Any(Reg => Reg.InstallationId == InstallationId))
            {
                return "Already Exists";
            }

            registrationsObj.registrations.Add(new Registration(UserId, InstallationId));

            string jsonOutput = Newtonsoft.Json.JsonConvert.SerializeObject(registrationsObj);

            string filename = Environment.CurrentDirectory + "/wwwroot/Registration.json";


            using (StreamWriter file = File.CreateText(filename))
            {

                using (JsonTextWriter writer = new JsonTextWriter(file))
                {

                    JObject serializedObject = JObject.Parse(jsonOutput);

                    serializedObject.WriteTo(writer);
                }
            }
            return "ok";
        }


        public static string unRegisterUser(String InstallationId)
        {
            gatherRegistrations();

            if (!(registrationsObj.registrations.Any(Reg => Reg.InstallationId == InstallationId)))
            {
                return "User Not Exists, Bugged";
            }

            registrationsObj.registrations.RemoveAll(x => x.InstallationId == InstallationId);


            string jsonOutput = Newtonsoft.Json.JsonConvert.SerializeObject(registrationsObj);

            string filename = Environment.CurrentDirectory + "/wwwroot/Registration.json";


            using (StreamWriter file = File.CreateText(filename))
            {

                using (JsonTextWriter writer = new JsonTextWriter(file))
                {

                    JObject serializedObject = JObject.Parse(jsonOutput);

                    serializedObject.WriteTo(writer);
                }
            }

            return "ok";

        }
    }
}
