using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TextToSpeechApp.BusinessLayer;
using TextToSpeechApp.BusinessLayer.Interface;
using TextToSpeechApp.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;



namespace TextToSpeechApp.Controllers
{
    public class HomeController : Controller
    {
        ITextToSpeech _textToSpeech;
        IConfiguration _iconfiguration;
       
        TranslateTextService obj = new TranslateTextService();
        private readonly IConfiguration configuration;
        public HomeController(ITextToSpeech textToSpeech, IConfiguration iconfiguration)
        {
            _textToSpeech = textToSpeech;
            _iconfiguration = iconfiguration;
            this.configuration = iconfiguration;

        }
        public ActionResult Index()
        {
            SpeechModel speechModel = new SpeechModel();
            return View(speechModel);
        }
        
        [HttpPost]
        public ActionResult Index(SpeechModel speechModel)
        {
            //App service application settings key name(i.e. "cognitiveservicekey1")
            var demosecret = configuration["cognitiveservicekey1"];
            var SubscriptionKey = demosecret;//"fe2c614fefb345dc89b821eed0aad444";// _iconfiguration["SubscriptionKey"];
           // ViewBag.Key = speechModel.SubscriptionKey;

            Authentication obj = new Authentication(SubscriptionKey);

            ViewBag.Content = speechModel.Content;

            ViewBag.LangCode = speechModel.LanguageCode;

            ViewBag.Token = obj.GetAccessToken();

            return View(speechModel);
        }
        [HttpPost]
        public ActionResult TestApp(SpeechModel speechModel)
        {
            ViewBag.Key = speechModel.SubscriptionKey;

            Authentication obj = new Authentication(ViewBag.Key);

            ViewBag.Content = speechModel.Content;

            ViewBag.LangCode = speechModel.LanguageCode;

            ViewBag.Token = obj.GetAccessToken();

            return View(speechModel);
        }

        /// <summary>
        /// Transalte given text to speech
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="key">Azure speech subscription key</param>
        /// <param name="content">Text content for speech</param>
        /// <param name="lang">Speech conversion language</param>
        /// <returns></returns>
        public async Task<ActionResult> Translate(string token, string key, string content,string lang)
        {

            try
            {
                if (!String.IsNullOrEmpty(content))
                {
                    var waveBytes = _textToSpeech.TranslateText(token,key,content,lang);

                    return File(await Task<string>.Run(() => waveBytes), "audio/mpeg", "voice.mp3");
                }
                return File("", "audio/mpeg");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
       
    }
}