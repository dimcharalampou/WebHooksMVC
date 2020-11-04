using Newtonsoft.Json;
using Pass_Data_Between_Views_MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using ModelsClass;
using ModelsNew;
using System.Text;
using System.Net;

namespace Pass_Data_Between_Views_MVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        private async Task<string> PostRequest(string x)
        {
            var proxy = new WebProxy
            {
                Address = new Uri("http://10.72.180.27:8080"),
                BypassProxyOnLocal = true,
                UseDefaultCredentials = true
            };

            var httpClientHandler = new System.Net.Http.HttpClientHandler
            {
                Proxy = proxy
            };

            httpClientHandler.PreAuthenticate = true;
            httpClientHandler.UseDefaultCredentials = false;
            var content = new StringContent(x, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://bol.mondial-assistance.gr/viberapi/api/clients/PostMessage");

            HttpClient Http = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            var response = Http.PostAsync(RequestUri, content).Result;
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }
    

        [HttpPost]
        public async Task<ActionResult> Viber(Sender sender, Message message, string _event, long timestamp, long message_token)
        {
            if (sender.id != null)
            {
                //UserMessage UsrMsg = new UserMessage();
                //UsrMsg.sender = sender;
                //UsrMsg.message = message;
                //UsrMsg.timestamp = timestamp;
                //UsrMsg.message_token = message_token;
                //UsrMsg._event = _event;
                //TextMessage Msg = new TextMessage();
                //Msg.Text = UsrMsg.message.text;
                //Msg.Receiver = UsrMsg.sender.id;
                //User usr = new User();
                //usr.Name = "Me New";
                //usr.ApiVersion = 1;
                //Msg.Sender = usr;
                Messager mssg = new Messager();
                mssg.Text = message.text;
                mssg.Receiver = sender.id;
                Senderr sndf = new Senderr();
                sndf.Name = "Me New";
                mssg.Senderr = sndf;
                var x = JsonConvert.SerializeObject(mssg);
                x = x.Replace("Senderr", "Sender").Replace("Messager", "Message");
                var res = await PostRequest(x);
            }
            return View();
        }
    }
}