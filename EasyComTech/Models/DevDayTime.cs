namespace EasyComTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DevDayTime
    {
        public int Id { get; set; }

        public int? DevId { get; set; }

        public int? DayTimeId { get; set; }

        public virtual DayTimeSetup DayTimeSetup { get; set; }

        public virtual DevDetail DevDetail { get; set; }
    }
}
