using SQLiteWpfSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQLiteWpfSample
{
    /// <summary>
    /// Interaction logic for phoneWindow2.xaml
    /// </summary>
    public partial class PhoneWindow2 : Window
    {
        public PhoneViewModel PhoneViewModel { get; set; }

        public PhoneWindow2(PhoneViewModel phoneViewModel)
        {
            InitializeComponent();
            PhoneViewModel = phoneViewModel;
            this.DataContext = PhoneViewModel;
        }

      

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
