using HeroAPI.Metadata;
using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    [MetadataType(typeof(PowerDetailMetadata))]
    public partial class PowerDetail
    {
        public int HeroId { get; set; }
        public virtual Hero Hero { get; set; }
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }
    }
}