using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Collections.ObjectModel;
using System.Threading;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
            DemoData = new ObservableCollection<string>();
            AddString(0, 12);
            this.testListBox.ItemsSource = this.DemoData;
        }
        private Timer refreshTimer;
        private Timer loadTimer;
        private ObservableCollection<string> DemoData;
        private int index = 0;

        // 构造函数

        private void AddString(int statnum, int num)
        {
            string buf = "列表项";
            for (int i = 0; i < num; i++)
            {
                DemoData.Add(buf + ++index);
            }
        }

        private void Refresh()
        {
            DemoData.Clear();
            index = 0;
            string buf = "刷新项";
            for (int i = 1; i <= 12; i++)
            {
                DemoData.Add(buf + i);
            }
        }

        //下拉刷新响应事件
        private void testListBox_RefreshRequested(object sender, EventArgs e)
        {
            //如果底部没有在加载，则响应下拉刷新
            if (!this.testListBox.IsLoading)
            {
                this.testListBox.IsRefreshing = true;
                this.refreshTimer = new Timer(
                    delegate
                    {
                        this.Dispatcher.BeginInvoke(
                            delegate
                            {
                                Refresh();
                                this.testListBox.ItemsSource = DemoData;
                                this.testListBox.IsRefreshing = false;
                                MessageBox.Show("刷新成功");
                            });
                    },
                    null, 3000, -1);
            }
        }

        //上拉加载响应事件
        private void testListBox_LoadRequested(object sender, EventArgs e)
        {
            //如果顶部没有在刷新，则响应上拉加载
            if (!this.testListBox.IsRefreshing)
            {
                this.testListBox.IsLoading = true;
                this.loadTimer = new Timer(
                    delegate
                    {
                        this.Dispatcher.BeginInvoke(
                            delegate
                            {
                                AddString(index, 10);
                                this.testListBox.ItemsSource = DemoData;
                                this.testListBox.IsLoading = false;
                                MessageBox.Show("加载完成");
                            });
                    },
                    null, 3000, -1);
            }
        }
    }
}