using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyComTech.Models
{
    [Serializable]
    public class AppliedSkills
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int Rating { get; set; }
    }
}