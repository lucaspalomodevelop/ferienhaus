using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

using ferienhaus.Klassen;

namespace ferienhaus
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        public static List<Estate> estates = new List<Estate>();

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //foreach (var item in estates)
            //{
            //    Data.Instance.write(item);
            //}

        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
