namespace EasyComTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillsSetup")]
    public partial class SkillsSetup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillsSetup()
        {
            DevSkills = new HashSet<DevSkill>();
        }

        public int Id { get; set; }

        [Required]
        public string Details { get; set; }

        public string OtherDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DevSkill> DevSkills { get; set; }
    }
}
