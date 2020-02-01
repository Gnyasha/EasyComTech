namespace EasyComTech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DevHour
    {
        public int Id { get; set; }

        public int? DevId { get; set; }

        public int? HourId { get; set; }

        public virtual DevDetail DevDetail { get; set; }

        public virtual HoursSetup HoursSetup { get; set; }
    }
}
