using HeroAPI.Enums;
using HeroAPI.ViewModels;

namespace HeroAPI.Models
{
    public partial class Power
    {
        public Power() { }
        
        public Power(string powerName)
        {
            PowerName = powerName;
        }

        public Power(PowerCreate power)
        {
            if (power != null)
                PowerName = power.PowerName;
        }
    }
}