namespace EasyComTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DevSkill
    {
        public int Id { get; set; }

        public int? DevId { get; set; }

        public int SkillId { get; set; }

        public int? Rating { get; set; }

        public virtual DevDetail DevDetail { get; set; }

        public virtual SkillsSetup SkillsSetup { get; set; }
    }
}
