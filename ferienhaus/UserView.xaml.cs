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


          //  EstateManager.getInstance().checkAvailability();
        }
    }
}
