using System.Windows;

namespace SQLiteWpfSample
{
    /// <summary>
    /// Interaction logic for PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        public Phone Phone { get; private set; }

        public PhoneWindow(Phone p)
        {
            InitializeComponent();
            Phone = p;
            this.DataContext = Phone;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
