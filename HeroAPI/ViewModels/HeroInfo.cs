using HeroAPI.Models;
using System.Collections.Generic;

namespace HeroAPI.ViewModels
{
    public class HeroInfo
    {
        public HeroInfo(Hero hero)
        {
            if (hero != null)
            {
                HeroId = hero.HeroId;
                HeroPower = new List<PowerInfo>();
                if (hero != null)
                {
                    HeroName = hero.HeroName;
                    if (hero.PowerDetails != null)
                    {
                        foreach (PowerDetail powerDetail in hero.PowerDetails)
                        {
                            if (powerDetail.Power != null)
                                HeroPower.Add(new PowerInfo(powerDetail.Power));
                        }
                    }
                }
            }
        }

        public int HeroId { get; set; }
        public string HeroName { get; set; }
        public List<PowerInfo> HeroPower { get; set; }
    }
}