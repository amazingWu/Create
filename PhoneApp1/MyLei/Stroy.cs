using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Net;
using System.IO;
using PhoneApp1.MyLei;
using Newtonsoft.Json;
using System.Windows;

namespace PhoneApp1
{

    public class Stroy : INotifyPropertyChanged
    {
        /* public Stroy(long id, string title, string image, string author, int replayCount, int pv, long postTime)
         {
             this.id = id;
             this.title = title;
             this.firstImage = image;
             this.author = author;
             this.replyCount = 0;
             this.pv = 0;
             this.postTime = postTime;

         }*/
        public event PropertyChangedEventHandler PropertyChanged;

        private string author;//来源
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Author"));
                }
            }
        }

        private long id;//标识符
        public long ID
        {
            set
            {
                this.id = value;
            }
            get
            {
                return id;
            }
        }

        private string firstImage;//图片
        public string FirstImage
        {
            get
            {
                return firstImage;
            }
            set
            {
                firstImage = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstImage"));
                }
            }
        }

        private string title;//标题
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }

        private long postTime;//发表时间

        public long PostTime
        {
            get
            {
                return postTime;
            }
            set
            {
                postTime = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PostTime"));
                }
            }
        }

        private int pv;//转发数量
        public int Pv
        {
            get
            {
                return pv;
            }
            set
            {
                pv = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pv"));
                }
            }
        }


        private int replyCount;//回复数量
        public int ReplyCount
        {
            get
            {
                return replyCount;
            }
            set
            {
                replyCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ReplyCount"));
                }
            }
        }

    }
}
