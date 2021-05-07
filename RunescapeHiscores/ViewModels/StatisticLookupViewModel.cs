using GalaSoft.MvvmLight.Command;
using RunescapeHiscores.Models;
using RunescapeHiscores.Network;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var skills = await _HiscoreClient.LookupStats(StatisticLookupModel.Name, StatisticLookupModel.SelectedType);

            if(skills == null)
            {
                StatisticLookupModel.Levels = null;
                return;
            }
            Queue<Skill> skillQueue = new Queue<Skill>((IEnumerable<Skill>)Enum.GetValues(typeof(Skill)));
            StatisticLookupModel.Levels = skills.Select(tuple => new SkillModel(skillQueue.Dequeue(), tuple.Rank, tuple.Level, tuple.Xp)).ToList();
        }
    }



}


