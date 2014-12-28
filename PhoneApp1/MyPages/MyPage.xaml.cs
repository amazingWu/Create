using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.MyLei;
using System.Windows.Data;

namespace PhoneApp1
{
    public partial class MyPage : PhoneApplicationPage
    {
        public MyPage()
        {
            InitializeComponent();
            init();
        }
        public void  init()
        {
           MyOption op1 = new MyOption("/photos/mytalking.png", "我的聊天", "/photos/zhankai.png");
            MyOption op2 = new MyOption("/photos/myfriends.png", "我的好友", "/photos/zhankai.png");
            MyOption op3 = new MyOption("/photos/myshoucang.png", "我的收藏", "/photos/zhankai.png");
            MyOption op4 = new MyOption("/photos/mytiezi.png", "我的帖子", "/photos/zhankai.png");
            MyOption op5 = new MyOption("/photos/stroypage.png", "活动中心", "/photos/zhankai.png");
            MyOptions.Items.Add(op1);
            MyOptions.Items.Add(op2);
            MyOptions.Items.Add(op3);
            MyOptions.Items.Add(op4);
            MyOptions.Items.Add(op5);
        }

        private void SelectClick(object sender, SelectionChangedEventArgs e)
        {
            if (MyOptions.SelectedValue != null)
            {
                switch (MyOptions.SelectedValue.ToString())
                {
                    case "活动中心":
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                        break;
                    case "我的聊天": break;
                    case "我的好友": break;
                    case "我的收藏": break;
                    case "我的帖子": break;
                }
            }
        }

    }
}