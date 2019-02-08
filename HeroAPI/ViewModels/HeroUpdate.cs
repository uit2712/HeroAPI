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
                HeroName = hero.HeroName;
            }
        }

        public int HeroId { get; set; }
        public string HeroName { get; set; }
    }
}