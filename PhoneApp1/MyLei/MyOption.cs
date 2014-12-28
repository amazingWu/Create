using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.MyLei
{
    class MyOption
    {
        public  string OptionLogo{get;set;}
        public  string Content{get;set;}
        public string OtherLogo { get; set; }
        public MyOption(string optionlogo,string content,string otherlogo)
        {
            this.OptionLogo = optionlogo;
            this.Content = content;
            this.OtherLogo = otherlogo;
        }
        public MyOption()
            : this("","","")
        {

        }
        public override string ToString()
        {
            return Content.ToString();
        }
        
    }
}
