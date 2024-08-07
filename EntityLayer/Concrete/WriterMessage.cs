using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class WriterMessage
	{
        public int WriterMessageID { get; set; }
        public string? Sender { get; set; }
        public string? Recevier { get; set; }
		public string? SenderName { get; set; }
		public string? RecevierName { get; set; }
		public string? Subject { get; set; }
        public string? MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
