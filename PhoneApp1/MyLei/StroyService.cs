using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using PhoneApp1;
using System.Windows.Threading;

namespace PhoneApp1.MyLei
{
    public class StroyService
    {

        //private const string shareUriString = "http://169.254.3.165:8080/create_server/story/items?start=1&offset=10";
        private const string shareUriString = "http://www.baidu.com";
        
        //#region 获取StroyDetails
        private string contentDetails;
        public string ContentDetails
        {
            get;
            set;
        }
        /////<summary>
        /////获取StroyDetails(详细内容)类
        /////</summary>
        //public void getStroyDetails(int id)
        //{
        //    string uriString = "http://192.168.2.24:8080/create_server/detail/" + id.ToString();
        //    Uri uri = new Uri(uriString);
        //    HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uri);
        //    StroyUpdateState stroyState = new StroyUpdateState();
        //    stroyState.AsyncRequest = stroyDetailsRequest;
        //    stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleStroyDetailsResponse),stroyState);
        //}

        //private void HandleStroyDetailsResponse(IAsyncResult asyncResult)
        //{
        //    StroyUpdateState stroyState = (StroyUpdateState)asyncResult.AsyncState;
        //    HttpWebRequest stroyDetailsRequest = (HttpWebRequest)stroyState.AsyncRequest;
        //    stroyState.AsyncResponse = (HttpWebResponse)stroyDetailsRequest.EndGetResponse(asyncResult);
        //    try
        //    { 
        //        using (StreamReader httpWebStreamReader = new StreamReader(stroyState.AsyncResponse.GetResponseStream()))
        //        {
                    
        //               string stroyDetailsResult = httpWebStreamReader.ReadToEnd();
                       
        //               StroyDetails stroyDetails = JsonConvert.DeserializeObject<StroyDetails>(stroyDetailsResult);
        //               contentDetails = stroyDetails;
        //               MessageBox.Show(stroyDetails.Content);
        //        }
                
        //    }
        //    catch(FormatException)
        //    {
        //        return;
        //    }
        //}

        
        #region 获取Stroy集合
        private ObservableCollection<Stroy> share_StroyList;
        private ObservableCollection<Stroy> think_StroyList;
        private ObservableCollection<Stroy> create_StroyList;
        public ObservableCollection<Stroy> Share_StroyList
        {
            get
            {
                return share_StroyList;
            }
            set
            {
                share_StroyList = value;
            }
        }
        public ObservableCollection<Stroy> Think_StroyList
        {
            get
            {
                return think_StroyList;
            }
            set
            {
                think_StroyList = value;
            }
        }
        public ObservableCollection<Stroy> Create_StroyList
        {
            get
            {
                return create_StroyList;
            }
            set
            {
                create_StroyList = value;
            }
        }
        /// <summary>
        /// 获取资 可选类别：think_StroyList;create_StroyList;share_StroyList
        /// </summary>
        /// <param name="what_stroy"></param>
        public void getStroys(string what_stroy)
        {
            switch(what_stroy)
            {
                case "share_StroyList": getStroyResource(shareUriString); break;
                default: break;
            }
        }
        public void getStroyResource(string uriString)
        {
            HttpWebRequest stroyDetailsRequest = (HttpWebRequest)WebRequest.Create(uriString);
            stroyDetailsRequest.Method = "GET";
            stroyDetailsRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                stroyDetailsRequest.BeginGetResponse(new AsyncCallback(HandleStroysResponse), stroyDetailsRequest);
            }
            catch(WebException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void HandleStroysResponse(IAsyncResult asyncResult)
        {
            
           try
           {
               HttpWebRequest stroyDetailsRequest = (HttpWebRequest)asyncResult.AsyncState;
               HttpWebResponse stroyDetailsResponse=(HttpWebResponse)stroyDetailsRequest.EndGetResponse(asyncResult);
               using (StreamReader httpWebStreamReader = new StreamReader(stroyDetailsResponse.GetResponseStream()))
               {
                   string stroyDetailsResult = httpWebStreamReader.ReadToEnd();
                   contentDetails = stroyDetailsResult;
                   //ObservableCollection<Stroy> Stroys = JsonConvert.DeserializeObject<ObservableCollection<Stroy>>(stroyDetailsResult);
                   //share_StroyList = Stroys;
               }
               stroyDetailsResponse.Close();
            }
            catch (WebException ex)
            {
                return;
            }
           catch (Exception ex)
           {

           }
        } 
        #endregion
    }
    

    

    /// <summary>
    /// 内含httpWebRequest和httpWebResponse
    /// </summary>
    //public class StroyUpdateState
    //{
    //    public HttpWebRequest AsyncRequest { get; set; }
    //    public HttpWebResponse AsyncResponse { get; set; }
    //}
}
