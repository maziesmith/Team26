using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using UpgradeYourself.Windows.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UpgradeYourself.Windows.Views
{
    public sealed partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.RenderHeaderDependingOnUser();
        }

        public string PageTitleText
        {
            get
            {
                return (string)GetValue(PageTitleTextProperty);
            }

            set
            {
                SetValue(PageTitleTextProperty, value);

            }
        }

        public static readonly DependencyProperty PageTitleTextProperty =
            DependencyProperty.Register("PageTitleText", typeof(string), typeof(PageHeader),
            new PropertyMetadata(null));

        private void RenderHeaderDependingOnUser()
        {
            if (ParseUser.CurrentUser == null)
            {
                this.navBar.Visibility = Visibility.Collapsed;
                this.pageTitle.Visibility = Visibility.Visible;
                this.pageSubTitle.Visibility = Visibility.Visible;
            }
            else
            {
                this.navBar.Visibility = Visibility.Visible;
                this.pageTitle.Visibility = Visibility.Collapsed;
                this.pageSubTitle.Visibility = Visibility.Collapsed;
            }
        }
    }
}
