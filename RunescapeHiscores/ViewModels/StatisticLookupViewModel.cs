using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RunescapeHiscores.Models;
using RunescapeHiscores.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RunescapeHiscores.ViewModels
{
    class StatisticLookupViewModel
    {

        private static readonly HiscoreClient _HiscoreClient = new HiscoreClient();

        public Array Types { get; set; } = Enum.GetValues(typeof(LookupType));

        public ICommand FetchStatsCommand { get; private set; }

        public StatisticLookupViewModel()
        {
            StatisticLookupModel = new StatisticLookupModel();
            FetchStatsCommand = new RelayCommand(FetchStats);
        }

        public StatisticLookupModel StatisticLookupModel { get; set; }

        private async void FetchStats()
        {
            StatisticLookupModel.Levels = await _HiscoreClient.LookupStats(StatisticLookupModel.Name, StatisticLookupModel.SelectedType);
            if (StatisticLookupModel.Levels != null)
            {
                foreach (var item in StatisticLookupModel.Levels)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }



}


