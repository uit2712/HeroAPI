using HeroAPI.Messages;
using HeroAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroAPI.Metadata
{
    [Table(nameof(Hero))]
    public class HeroMetadata
    {
        [NotMapped]
        private string _heroName;

        [Key]
        [Display(Name = "HeroId", ResourceType = typeof(HeroMessages))]
        [Required(ErrorMessageResourceName = "HeroIdRequired", ErrorMessageResourceType = typeof(HeroMessages))]
        public int HeroId { get; set; }

        [Display(Name = "HeroName", ResourceType = typeof(HeroMessages))]
        [Required(ErrorMessageResourceName = "HeroNameRequired", ErrorMessageResourceType = typeof(HeroMessages))]
        public string HeroName { get; set; }

        public virtual ICollection<PowerDetail> PowerDetails { get; set; }
    }
}