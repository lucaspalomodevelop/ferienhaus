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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ferienhaus.Klassen;

namespace ferienhaus
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        //    object mydata =  Data.read();


        }

        private void Button_Click_User(object sender, RoutedEventArgs e)
        {
            
            UserView userView = new UserView();
            userView.Show();
            this.Close();
        }

 

        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.Show();
            this.Close();
        }
    }
}
