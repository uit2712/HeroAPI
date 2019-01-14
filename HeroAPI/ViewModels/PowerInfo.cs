using HeroAPI.Models;

namespace HeroAPI.ViewModels
{
    public class PowerInfo
    {
        public PowerInfo(Power power)
        {
            if (power != null)
            {
                PowerId = power.PowerId;
                PowerName = power.PowerName;
            }
        }

        public int PowerId { get; set; }
        public string PowerName { get; set; }
    }
}