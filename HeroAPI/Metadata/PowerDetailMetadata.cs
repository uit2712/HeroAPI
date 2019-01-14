using HeroAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroAPI.Metadata
{
    public class PowerDetailMetadata
    {
        [Key, Column(Order = 0)]
        public int HeroId { get; set; }
        [ForeignKey("HeroId")]
        public virtual Hero Hero { get; set; }

        [Key, Column(Order = 1)]
        public int PowerId { get; set; }
        [ForeignKey("PowerId")]
        public virtual Power Power { get; set; }
    }
}