using System.IO;
using Newtonsoft.Json.Linq;

namespace AetherX {
    public class Config {

        private string token;


        public Config(string tokenPath) {
            token = GetToken(tokenPath);
        }

        /// <summary>
        /// Retrieves the Bot Token so we can initialize the Bot.
        /// </summary>
        /// <param name="path">The path to your configuration File</param>
        /// <returns>Bot Token</returns>
        private static string GetToken(string path) {
            JObject jObject = JObject.Parse(File.ReadAllText(path));

            return jObject.GetValue("token").ToString();
        }

        public string GetToken() {
            return token;
        }
        
    }
}