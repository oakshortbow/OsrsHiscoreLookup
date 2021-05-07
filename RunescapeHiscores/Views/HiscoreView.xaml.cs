using RunescapeHiscores.Network;
using RunescapeHiscores.ViewModels;
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

namespace RunescapeHiscores.Views
{
    /// <summary>
    /// Interaction logic for HiscoreView.xaml
    /// </summary>
    public partial class HiscoreView : Window
    {
        public HiscoreView()
        {
            InitializeComponent();
            this.DataContext = new StatisticLookupViewModel();
        }


        [STAThread]
        static void Main(string[] args)
        {
            var application = new System.Windows.Application();
            application.Run(new HiscoreView());
        }

    }
}
