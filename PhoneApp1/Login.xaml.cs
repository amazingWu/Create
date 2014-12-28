using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class Login : PhoneApplicationPage
    {

        #region 页面加载
        public Login()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.Txt_Name.Focus();
            };
        }
         /// <summary>
        /// 页面初始化
        /// </summary>
        protected override void OnNavigatedTo(System. Windows. Navigation. NavigationEventArgs e)
        {
            this.Txt_Name. Text = Config. LoginName;
            this.Txt_PassWord. Password = Config. Password;
        }
        #endregion



        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            string name =Txt_Name.Text.Trim();
            string password = Txt_PassWord.Password.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("登陆密码不能为空");
                return;
            }

            //开始登陆
            this.Load_text.Text = "登陆中..";
            this.IsEnabled = true;
            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"username", name},
                {"pwd", password},
                {"keep_login", "1"},
            };


        }



    }
}