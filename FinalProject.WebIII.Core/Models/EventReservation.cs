using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Models
{
    public class EventReservation
    {
        public long IdReservation { get; set; }
        public long IdEvent { get; set; }
        public string PersonName { get; set; }
        public long Quantity { get; set; }

    }
}
