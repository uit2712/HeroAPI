using HeroAPI.Messages;
using HeroAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroAPI.Metadata
{
    [Table(nameof(Power))]
    public class PowerMetadata
    {
        [NotMapped]
        private string _powerName;
        [Key]
        [Display(Name = "PowerId", ResourceType = typeof(PowerMessages))]
        [Required(ErrorMessageResourceName = "PowerIdRequired", ErrorMessageResourceType = typeof(PowerMessages))]
        public int PowerId { get; set; }

        [Display(Name = "PowerName", ResourceType = typeof(PowerMessages))]
        [Required(ErrorMessageResourceName = "PowerNameRequired", ErrorMessageResourceType = typeof(PowerMessages))]
        public string PowerName { get; set; }

        public virtual ICollection<PowerDetail> PowerDetails { get; set; }
    }
}