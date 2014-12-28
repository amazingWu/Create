using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1
{
    public static class Config
    {
        /// <summary>
        /// 表示当前是否具有网路
        /// </summary>
        public static bool IsNetworkRunning
        {
            get
            {
                return PhoneApplicationService.Current.State.ContainsKey("IsNetworkRunning") ?
                    (bool)PhoneApplicationService.Current.State["IsNetworkRunning"] : false;
            }
            set { PhoneApplicationService.Current.State["IsNetworkRunning"] = value; }
        }
        /// <summary>
        /// 用户UID
        /// </summary>
        public static int UID
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("uid") ?
                (int)IsolatedStorageSettings.ApplicationSettings["uid"] : 0;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["uid"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        /// <summary>
        /// 登陆用户名
        /// </summary>
        public static string LoginName
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("LoginName") ?
                    IsolatedStorageSettings.ApplicationSettings["LoginName"] as string : null;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["LoginName"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public static string Password
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("Password") ?
                    IsolatedStorageSettings.ApplicationSettings["Password"] as string : null;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["Password"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        /// <summary>
        /// Cookie
        /// </summary>
        public static string Cookie
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("Cookie") ?
                    IsolatedStorageSettings.ApplicationSettings["Cookie"] as string : null;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["Cookie"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }



        /// <summary>
        /// 表示当前是否登陆
        /// </summary>
        public static bool IsLogin
        {
            get { return !string.IsNullOrWhiteSpace(Cookie); }
        }


        /// <summary>
        /// 存储的自我信息
        /// </summary>
        public static User UserInfo
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("UserInfo") ?
                    IsolatedStorageSettings.ApplicationSettings["UserInfo"] as User : null;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["UserInfo"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }



    }
}
