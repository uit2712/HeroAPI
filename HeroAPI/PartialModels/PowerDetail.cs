using HeroAPI.Metadata;
using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    public partial class PowerDetail
    {
        public PowerDetail() { }

        public PowerDetail(int heroId, int powerId)
        {
            HeroId = heroId;
            PowerId = powerId;
        }
    }
}