using HeroAPI.Models;
using System.Collections.Generic;

namespace HeroAPI.ViewModels
{
    public class HeroUpdate
    {
        public HeroUpdate(Hero hero)
        {
            if (hero != null)
            {
                HeroId = hero.HeroId;
                HeroPowers = new List<int>();
                if (hero != null)
                {
                    HeroName = hero.HeroName;
                    if (hero.PowerDetails != null)
                    {
                        foreach (PowerDetail powerDetail in hero.PowerDetails)
                        {
                            if (powerDetail.Power != null)
                                HeroPowers.Add(powerDetail.Power.PowerId);
                        }
                    }
                }
            }
        }

        public int HeroId { get; set; }
        public string HeroName { get; set; }
        public List<int> HeroPowers { get; set; }
    }
}