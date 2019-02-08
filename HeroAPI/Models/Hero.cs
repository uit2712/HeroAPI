using HeroAPI.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    [MetadataType(typeof(HeroMetadata))]
    public partial class Hero
    {
        private string _heroName;
        public int HeroId { get; set; }
        public string HeroName
        {
            get { return _heroName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    _heroName = "Thor";
                else _heroName = value;
            }
        }
    }
}