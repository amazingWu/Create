﻿#pragma checksum "G:\PhoneApp1\PhoneApp1\MyPages\SendMessagePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7B2B8B873A9F44A07729B7014609C530"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34011
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp1.MyPages {
    
    
    public partial class SendMessagePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image logo;
        
        internal System.Windows.Controls.Grid myNewStroyGrid;
        
        internal System.Windows.Controls.TextBox myNewStroy;
        
        internal System.Windows.Controls.Grid other_Options;
        
        internal System.Windows.Controls.Button option1;
        
        internal System.Windows.Controls.Button option2;
        
        internal Microsoft.Phone.Shell.ApplicationBar appbar;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton myPage;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton sender;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/MyPages/SendMessagePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.logo = ((System.Windows.Controls.Image)(this.FindName("logo")));
            this.myNewStroyGrid = ((System.Windows.Controls.Grid)(this.FindName("myNewStroyGrid")));
            this.myNewStroy = ((System.Windows.Controls.TextBox)(this.FindName("myNewStroy")));
            this.other_Options = ((System.Windows.Controls.Grid)(this.FindName("other_Options")));
            this.option1 = ((System.Windows.Controls.Button)(this.FindName("option1")));
            this.option2 = ((System.Windows.Controls.Button)(this.FindName("option2")));
            this.appbar = ((Microsoft.Phone.Shell.ApplicationBar)(this.FindName("appbar")));
            this.myPage = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("myPage")));
            this.sender = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("sender")));
        }
    }
}

