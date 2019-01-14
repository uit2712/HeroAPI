using HeroAPI.ViewModels;

namespace HeroAPI.Models
{
    public partial class Hero
    {
        public Hero() { }

        public Hero(string heroName)
        {
            HeroName = heroName;
        }

        public Hero(HeroCreate hero)
        {
            if (hero != null)
                HeroName = hero.HeroName;
        }
    }
}