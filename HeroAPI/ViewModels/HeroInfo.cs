using HeroAPI.Models;
using System.Collections.Generic;

namespace HeroAPI.ViewModels
{
    public class HeroInfo
    {
        public HeroInfo(Hero hero)
        {
            HeroPower = new List<string>();
            if (hero != null)
            {
                HeroName = hero.HeroName;
                if (hero.PowerDetails != null)
                {
                    foreach(PowerDetail powerDetail in hero.PowerDetails)
                    {
                        if (powerDetail.Power != null)
                            HeroPower.Add(powerDetail.Power.PowerName);
                    }
                }
            }
        }

        public string HeroName { get; set; }
        public List<string> HeroPower { get; set; }
    }
}