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

using ferienhaus.Klassen;

namespace ferienhaus
{
    /// <summary>
    /// Interaktionslogik für UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {

        public string ort { get; set; }
        public int personen { get; set; }
        public int zimmeranzahl { get; set; }
        public double preismax { get; set; }
        public DateTime ankunft { get; set; }
        public DateTime abfahrt { get; set; }

        public UserView()
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
            ankunft = this.datum_ankunft.DisplayDate;
            abfahrt = this.datum_abfahrt.DisplayDate;
        }


        private void suche_Click(object sender, RoutedEventArgs e)
        {
            getDataFromFields();

            List<BookingTime> BTL = new List<BookingTime>();

            BTL.Add(new BookingTime(ankunft, abfahrt));

            Estate seachEstate = new Estate()
            {
                Bedrooms = zimmeranzahl,
                CustomerID = "",
                Persons = personen,
                Price = preismax,
                BookingTimes = BTL,

            };

            List<Estate> foundEstates = EstateManager.getInstance().checkAvailability(seachEstate);
            listFoundEstates(foundEstates);
        }

        public void listFoundEstates(List<Estate> estates)
        {
            List<EstateItem> estateListItem = new List<EstateItem>();
            foreach (Estate estate in estates)
            {
                estateListItem.Add(new EstateItem() { EstateName = estate.EstateName });
            }
            estate_liste.ItemsSource = estateListItem;
        }

        private void bookEstate(object sender, RoutedEventArgs e)
        {

            ((Button)sender).Content = "Gebucht!";
            string estateName = ((Button)sender).Tag.ToString();
            List<Estate> estates = EstateManager.getInstance().estates;

            Estate bookEstate;
               // meins auch .-.
            foreach(Estate estate in estates)
            {
                if(estate.EstateName == estateName)
                {
                    bookEstate = estate;
                    break;
                }
            }

            List<BookingTime> BTL = estate.BookingTime;
            BTL.Add(new BookingTime(ankunft, abfahrt));
        }
    }

    class EstateItem
    {
        public string EstateName { get; set; }
    }
}
