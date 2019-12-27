using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsBot.Models
{
   public class AdaptiveCardModel
    {
        public string AdaptiveCardName { get; set; }
        public string RichTextBlock { get; set; }
        public string RichTextBoxTextValue { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public string TextBox { get; set; }
        public string ButtonName { get; set; }
        public string ButtonTypeValue { get; set; }
    }
}
