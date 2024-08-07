using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
   public class SocialMedia
    {
#pragma warning disable CS8618
		[Key]
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
    }
}
