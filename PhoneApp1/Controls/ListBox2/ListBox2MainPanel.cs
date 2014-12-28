using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhoneApp1.Controls.ListBox2
{
    [TemplatePart(Name = ListBox2MainPanel.ScrollViewerPart, Type = typeof(ScrollViewer))]

    public class ListBox2MainPanel:ListBox
    {
        public const string ScrollViewerPart = "ScrollViewer";

        public ListBox2MainPanel()
        {
            this.DefaultStyleKey = typeof(ListBox2MainPanel);
        }

        #region AutoScrollMargin DependencyProperty

        public static readonly DependencyProperty AutoScrollMarginProperty = DependencyProperty.Register(
            "AutoScrollMargin", typeof(int), typeof(ListBox2MainPanel), new PropertyMetadata(32));

        public double AutoScrollMargin
        {
            get
            {
                return (int)this.GetValue(ListBox2MainPanel.AutoScrollMarginProperty);
            }
            set
            {
                this.SetValue(ListBox2MainPanel.AutoScrollMarginProperty, value);
            }
        }

        #endregion
    }
}
