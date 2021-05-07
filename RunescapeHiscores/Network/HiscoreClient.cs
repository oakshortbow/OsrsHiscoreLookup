using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RunescapeHiscores.Network
{
    class HiscoreClient: HttpClient
    {
        private readonly string BASE_URL = "https://secure.runescape.com/";
        private readonly string PLAYER_NORMAL_LOOKUP = "m=hiscore_oldschool/index_lite.ws?player=";
        private readonly string PLAYER_IRONMAN_LOOKUP = "m=hiscore_oldschool_ironman/index_lite.ws?player=";
        private readonly string PLAYER_ULT_IRONMAN_LOOKUP = "m=hiscore_oldschool_ultimate/index_lite.ws?player=";
        private readonly string PLAYER_HC_IRONMAN_LOOKUP = "m=hiscore_oldschool_hardcore_ironman/index_lite.ws?player=";
        private readonly string PLAYER_DMM_LOOKUP = "m=hiscore_oldschool_deadman/index_lite.ws?player=";
        private readonly string PLAYER_SDMM_LOOKUP = "m=hiscore_oldschool_deadman/index_lite.ws?player=";

        public async Task<List<(int Rank, short Level, int Xp)>> LookupStats(string name, LookupType type)
        {
            if (name == null)
            {
                return null;
            }
            string uri = BASE_URL;
            switch(type)
            {
                case LookupType.Normal:
                    uri += PLAYER_NORMAL_LOOKUP;
                    break;
                case LookupType.Ironman:
                    uri += PLAYER_IRONMAN_LOOKUP;
                    break;
                case LookupType.UltimateIronman:
                    uri += PLAYER_ULT_IRONMAN_LOOKUP;
                    break;
                case LookupType.HardcoreIronman:
                    uri += PLAYER_HC_IRONMAN_LOOKUP;
                    break;
                case LookupType.DeadmanMode:
                    uri += PLAYER_DMM_LOOKUP;
                    break;
                case LookupType.SeasonalDeadmanMode:
                    uri += PLAYER_SDMM_LOOKUP;
                    break;
            }
            uri += name.Replace(" ", "_");
            try
            {
                var response = await this.GetStringAsync(uri);
                List<(int Rank, short Level, int Xp)> list = new List<(int rank, short level, int xp)>();
                string[] skills = response.Split('\n');
                for (int i = 0; i < 24; i++)
                {
                    string[] skillValues = skills[i].Split(',');
                    list.Add((int.Parse(skillValues[0]), short.Parse(skillValues[1]), int.Parse(skillValues[2])));
                }
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }

    enum LookupType
    {
        Normal,
        Ironman,
        UltimateIronman,
        HardcoreIronman,
        DeadmanMode,
        SeasonalDeadmanMode
    }

}
