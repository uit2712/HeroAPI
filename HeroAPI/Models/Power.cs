using HeroAPI.Enums;
using HeroAPI.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    [MetadataType(typeof(PowerMetadata))]
    public partial class Power
    {
        private string _powerName;
        public int PowerId { get; set; }
        public string PowerName
        {
            get
            {
                return _powerName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    _powerName = EPower.Strength.ToString();
                else _powerName = value;
            }
        }

        public virtual ICollection<PowerDetail> PowerDetails { get; set; }
    }
}