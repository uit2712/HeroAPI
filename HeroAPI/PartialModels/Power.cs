using HeroAPI.Enums;

namespace HeroAPI.Models
{
    public partial class Power
    {
        public Power() { }
        
        public Power(string powerName)
        {
            PowerName = powerName;
        }
    }
}