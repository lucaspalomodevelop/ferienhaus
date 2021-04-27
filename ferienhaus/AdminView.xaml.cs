using ferienhaus.Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ferienhaus
{
    /// <summary>
    /// Interaktionslogik für AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public string ort { get; set; }
        public int personen { get; set; }
        public int zimmeranzahl { get; set; }
        public double preismax { get; set; }
        public DateTime ankunft { get; set; }
        public DateTime abfahrt { get; set; }

        public AdminView()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(MainWindow_Closing);
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow MW = new MainWindow();

            MW.Show();
        }

        public void getDataFromFields()
        {
            ort = this.ortschaft.Text;
            personen = Convert.ToInt32(this.personen_maximum.Value);
            zimmeranzahl = Convert.ToInt32(this.zimmer.Value);
            try
            {
                preismax = Convert.ToDouble(this.preis_maximum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Preis ist ungültig!", "Fehler");
            }
        }

        private void addEstateButton(object sender, RoutedEventArgs e)
        {
            getDataFromFields();

            List<BookingTime> BTL = new List<BookingTime>();

            Estate estate = new Estate()
            {
                EstateName = this.name.Text,
                Bedrooms = zimmeranzahl,
                Region = ort,
                Persons = personen,
                BookingTimes = BTL,
                Price = preismax
            };

            EstateManager.getInstance().addEstate(estate);
        }
    }
}
