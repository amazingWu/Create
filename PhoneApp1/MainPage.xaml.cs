using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using PhoneApp1.MyLei;
using PhoneApp1.Controls;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Threading;

using Portable.Text;
using System.Diagnostics;
using System.Threading;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Timer refreshTimer;
        private Timer loadTimer;
        private const string local_string = "http://192.168.2.19:8080/create_server/";
        private const string _refresh_share_stroy = "story/items?start=1&offset=10";

        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            init();
        }


        public void init()
        {
            getStroys("share_StroyList",local_string+"/story/items?start=1&offset=10");
        }
        //#region 页面初始化并加载网络资源
        //private void Inits()
        //{
        //    WebClient web = new WebClient();
        //    web.OpenReadAsync(new Uri("http://192.168.2.10:8080/create_server/"));
        //    web.OpenReadCompleted += new OpenReadCompletedEventHandler(WebClient_OpenReadCompleted);
        //}

        //private void WebClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        //{

        //    using (StreamReader reader = new StreamReader(e.Result))
        //    {
        //        string stroyListString = reader.ReadToEnd();
        //        MessageBox.Show(stroyListString);
               
        //        //List<Stroy> Stroys = JsonConvert.DeserializeObject<List<Stroy>>(stroyListString);
        //       // ListBox1.ItemsSource = Stroys;
        //      // CreatingStroy.ItemsSource = Stroys;
        //        //Think.ItemsSource = Stroys;
        //    }

        //}
        //#endregion


        #region 根据具体属于哪一个分类获取Stroy集合
        /// <summary>
        /// 获取网络资源
        /// 可选类别：
        /// think_StroyList（市场分析）;
        /// create_StroyList（创业故事）;
        /// share_StroyList（自由分享）
        /// </summary>
        /// <param name="what_stroy"></param>
        /// <param name="uri_string"></param>
        public void getStroys(string what_stroy,string uri_string)
        {
            switch (what_stroy)
            {
                case "share_StroyList": getShareStroyResource(uri_string); break;
                case "create_StroyList": getCreateStroyResource(uri_string); break;
                case "think_StroyList": getThinkStroyResource(uri_string); break;
                default: break;
            }
           
        }
        #endregion


        #region 获取并刷新自由分享模块的集合信息
        /// <summary>
        /// 从服务器获取shareListBoxd的集合信息
        /// </summary>
        /// <param name="uriString"></param>
        public void getShareStroyResource(string uriString)
        {
            HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uriString);
            try
            {
                stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleShareStroysResponse), stroyDetailsRequest);
            }
            catch (WebException ex)
            {
                Dispatcher.BeginInvoke(() => { MessageBox.Show("s1"+ex.Message); });
            }
        }
        private void HandleShareStroysResponse(IAsyncResult asyncResult)
        {
            try
            {
                HttpWebRequest stroysRequest = (HttpWebRequest)asyncResult.AsyncState;
                HttpWebResponse stroysResponse = (HttpWebResponse)stroysRequest.EndGetResponse(asyncResult);
                using (Stream stream=stroysResponse.GetResponseStream())
                {
                    using (StreamReader httpWebStreamReader = new StreamReader(stream))
                    {
                        string stroysResult ="";
                        stroysResult = httpWebStreamReader.ReadToEnd();
                        ObservableCollection<Stroy> newstroys = JsonConvert.DeserializeObject<ObservableCollection<Stroy>>(stroysResult);
                        Dispatcher.BeginInvoke(() => {
                            ListBox1.ItemsSource = newstroys;
                        });
                    }
                }
            }
            catch (WebException ex)
            {
                Dispatcher.BeginInvoke(() => { MessageBox.Show("s2" + ex.Status.ToString()); });
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() => { MessageBox.Show("s3" + ex.Message); });
            }
        }


        //自由分享下拉响应事件
        private void ShareRefreshRequested(object sender, EventArgs e)
        {
            if (!this.ListBox1.IsLoading)
            {
                this.ListBox1.IsRefreshing = true;
                this.refreshTimer = new Timer(
                    delegate
                    {
                        this.Dispatcher.BeginInvoke(
                            delegate
                            {
                                getShareStroyResource(local_string + _refresh_share_stroy);
                                this.ListBox1.IsRefreshing = false;
                                MessageBox.Show("刷新成功");
                            });
                    },
                    null, 3000, -1);
            }
        }

        //自由分享查看更多事件（上拉）
        private void ShareLoadRequest(object sender, EventArgs e)
        {
            if (!this.ListBox1.IsRefreshing)
            {
                this.ListBox1.IsLoading = true;
                this.loadTimer = new Timer(
                    delegate
                    {
                        this.Dispatcher.BeginInvoke(
                            delegate
                            {

                                MessageBox.Show("加载完成");
                            });
                    },
                    null, 3000, -1);
            }
        }
        #endregion






        #region 获取并刷新创业模块的集合信息
        /// <summary>
        /// 获取并刷新创业模块的集合信息
        /// </summary>
        /// <param name="uriString"></param>
        public void getCreateStroyResource(string uriString)
        {
            HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uriString);
            try
            {
                stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleCreateStroysResponse), stroyDetailsRequest);
            }
            catch (WebException ex)
            {
            }
        }
        private void HandleCreateStroysResponse(IAsyncResult asyncResult)
        {
            try
            {
                HttpWebRequest stroysRequest = (HttpWebRequest)asyncResult.AsyncState;
                HttpWebResponse stroysResponse = (HttpWebResponse)stroysRequest.EndGetResponse(asyncResult);
                using (Stream stream = stroysResponse.GetResponseStream())
                {
                    using (StreamReader httpWebStreamReader = new StreamReader(stream))
                    {
                        string stroysResult = httpWebStreamReader.ReadToEnd();
                        Dispatcher.BeginInvoke(() => { MessageBox.Show(stroysResult); });
                        ObservableCollection<Stroy> newstroys = JsonConvert.DeserializeObject<ObservableCollection<Stroy>>(stroysResult);
                        Dispatcher.BeginInvoke(() => { CreateStroy.ItemsSource = newstroys; });
                    }
                }
            }
            catch (WebException ex)
            {
                Dispatcher.BeginInvoke(() => { MessageBox.Show(ex.Status.ToString()); });
            }
            catch (Exception ex)
            {

            }
        }
        #endregion


        #region 获取并刷新市场分析模块的集合信息
        /// <summary>
        /// 获取并刷新市场分析模块的集合信息
        /// </summary>
        /// <param name="uriString"></param>
        public void getThinkStroyResource(string uriString)
        {
            HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uriString);
            try
            {
                stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleThinkStroysResponse), stroyDetailsRequest);
            }
            catch (WebException ex)
            {
            }
        }
        private void HandleThinkStroysResponse(IAsyncResult asyncResult)
        {
            try
            {
                HttpWebRequest stroysRequest = (HttpWebRequest)asyncResult.AsyncState;
                HttpWebResponse stroysResponse = (HttpWebResponse)stroysRequest.EndGetResponse(asyncResult);
                using (Stream stream = stroysResponse.GetResponseStream())
                {
                    using (StreamReader httpWebStreamReader = new StreamReader(stream))
                    {
                        string stroysResult = httpWebStreamReader.ReadToEnd();
                        Dispatcher.BeginInvoke(() => { MessageBox.Show(stroysResult); });
                        ObservableCollection<Stroy> newstroys = JsonConvert.DeserializeObject<ObservableCollection<Stroy>>(stroysResult);
                        Dispatcher.BeginInvoke(() => { ThinkStroy.ItemsSource = newstroys; });
                    }
                }
            }
            catch (WebException ex)
            {
                Dispatcher.BeginInvoke(() => { MessageBox.Show(ex.Status.ToString()); });
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //转到主页
        private void ToMyPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyPages/MyPage.xaml",UriKind.Relative));
        }
        
        
        //自由分享模块listboxSelectchanged
       private void StroySelectClick(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.mainPanel.SelectedIndex != -1)
            {
                Stroy stroy = (Stroy)ListBox1.mainPanel.SelectedItem;
                NavigationService.Navigate(new Uri("/MyPages/StroyDetailsPage.xaml?id="+stroy.ID+"&title=" + stroy.Title+"&author="+stroy.Author, UriKind.Relative));
            }
        }


        //转到发送界面
        private void ToSendPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyPages/SendMessagePage.xaml", UriKind.Relative));
        }
        //转到导航界面
        private void myoption_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyPages/DaoHangPage.xaml", UriKind.Relative));
        }
        //离开界面后listbox选择置空
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ListBox1.mainPanel.SelectedIndex = -1;
            ListBox1.mainPanel.SelectedItem = null;
            
        }




    }
}