using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace TextToSpeechApp.Models
{
    public class SpeechModel
    {
        public string Content { get; set; }

        public string SubscriptionKey { get; set; }// = "8fe93a8c99734245a2b103109ae0290f";

        [DisplayName("Language Selection :")]
        public string LanguageCode { get; set; } = "NA";

        public List<SelectListItem> LanguagePreference { get; set; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "NA", Text = "-Select-" },
        new SelectListItem { Value = "en-US", Text = "English (United States)"  },
        new SelectListItem { Value = "en-IN", Text = "English (India)"  },
        new SelectListItem { Value = "ta-IN", Text = "Tamil (India)"  },
        new SelectListItem { Value = "hi-IN", Text = "Hindi (India)"  },
        new SelectListItem { Value = "te-IN", Text = "Telugu (India)"  }
        };
    }
}
