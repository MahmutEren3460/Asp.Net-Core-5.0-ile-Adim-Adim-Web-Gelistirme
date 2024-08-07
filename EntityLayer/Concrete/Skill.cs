using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
  public  class Skill
    {
#pragma warning disable CS8618
		[Key]
        public int SkillID { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
