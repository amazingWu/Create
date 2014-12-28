using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Synthesis;
using PhoneApp1.MyLei;
using System.IO;
using Newtonsoft.Json;

namespace PhoneApp1.MyPages
{
    public partial class StroyDetailsPage : PhoneApplicationPage
    {
        SpeechSynthesizer voice;
        private StroyDetails stroyDetail;//详细信息
        public StroyDetailsPage()
        {
            InitializeComponent();
            this.voice = new SpeechSynthesizer();
        }
         protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
         {
            base.OnNavigatedTo(e);//调用基类的虚方法是应该的，但不是必须的

             if (NavigationContext.QueryString.ContainsKey("id"))
            {
                 int id=int.Parse(NavigationContext.QueryString["id"]);
                 //StroyService stroy_details_service = new StroyService();
                // stroy_details_service.getStroyDetails(id);
                 //StroyDetails stroy_detail = stroy_details_service.ContentDetails;
                // content.Text = stroy_detail.Content;
                 //stroy_details_service.getStroys("share_StroyList");
                 
                 TitleTxt.Text = NavigationContext.QueryString["title"];

                 
            }
         }
         #region 从网络获取详细信息
         public void getStroyDetails(int id)
         {
             string uriString = "http://192.168.2.24:8080/create_server/detail/" + id.ToString();
             HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uriString);
             stroyDetailsRequest.Method = "GET";
             stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleStroyDetailsResponse), stroyDetailsRequest);
         }

         private void HandleStroyDetailsResponse(IAsyncResult asyncResult)
         {
             HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
             HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
             try
             {
                 using (Stream stream = response.GetResponseStream())
                 {
                     using (StreamReader httpWebStreamReader = new StreamReader(stream))
                     {

                         string stroyDetailsResult = httpWebStreamReader.ReadToEnd();

                         StroyDetails stroyDetails = JsonConvert.DeserializeObject<StroyDetails>(stroyDetailsResult);
                         stroyDetail = stroyDetails;
                     }
                 }
             }
             catch (FormatException)
             {
                 return;
             }
         }
        #endregion
         private async void ReadClick(object sender, RoutedEventArgs e)
         {
             try
             {
                 Read.IsEnabled = false;
                 await voice.SpeakTextAsync("Hellow World");
                 Read.IsEnabled = true;

             }catch(Exception ex){
                
             }
         }
    }
}