namespace EasyComTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DevDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DevDetail()
        {
            DevDayTimes = new HashSet<DevDayTime>();
            DevHours = new HashSet<DevHour>();
            DevSkills = new HashSet<DevSkill>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Skype { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public string LinkedIn { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Portfolio { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DevDayTime> DevDayTimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DevHour> DevHours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DevSkill> DevSkills { get; set; }
    }
}
