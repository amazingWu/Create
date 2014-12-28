using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PhoneApp1.MyLei
{
    public class User
    {
        public string Uid{get;set;}//唯一标识符(用户登录账号)
        public string Name { get; set; }

        public string MySaying { get; set; }
        public string MyLogo { get; set; }
        public ObservableCollection<long> MyCollection { set; get; }
        public ObservableCollection<long> MySender { get; set; }
        
    }
}
