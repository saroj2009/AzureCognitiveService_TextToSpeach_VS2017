using System.Threading.Tasks;

namespace TextToSpeechApp.BusinessLayer.Interface
{
    interface ITranslateText
    {
        Task<string> Translate(string uri, string text, string key);
    }
}
