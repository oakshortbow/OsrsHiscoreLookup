using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunescapeHiscores.Models
{
    class SkillModel
    {
        public Skill Skill { get; set; }
        public int Rank { get; set; }
        public short Level { get; set; }
        public int Xp { get; set; }

        public SkillModel(Skill _skill, int _rank, short _level, int _xp)
        {
           Skill = _skill;
           Rank = _rank;
           Level = _level;
           Xp = _xp;
        }

    }
}
