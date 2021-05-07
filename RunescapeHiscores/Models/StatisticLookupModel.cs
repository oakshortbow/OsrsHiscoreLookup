using RunescapeHiscores.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RunescapeHiscores.Models
{
    class StatisticLookupModel : INotifyPropertyChanged
    {

        public string _name;
        private List<SkillModel> _levels;
        private LookupType _lookupType = LookupType.Normal;

        public List<SkillModel> Levels
        {
            get
            {
                return _levels;
            }

            set
            {
                _levels = value;
                NotifyPropertyChanged(nameof(Levels));
            }

        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }


        public LookupType SelectedType
        {
            get
            {
                return _lookupType;
            }

            set
            {
                _lookupType = value;
                NotifyPropertyChanged(nameof(SelectedType));
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SkillModel GetSkill(Skill skill)
        {
            return Levels[(int)skill];
        }
    }
    enum Skill
    {
        Overall,
        Attack,
        Defence,
        Strength,
        Hitpoints,
        Ranged,
        Prayer,
        Magic,
        Cooking,
        Woodcutting,
        Fletching,
        Fishing,
        Firemaking,
        Crafting,
        Smithing,
        Mining,
        Herblore,
        Agility,
        Thieving,
        Slayer,
        Farming,
        Runecraft,
        Hunter,
        Construction
    }
}
