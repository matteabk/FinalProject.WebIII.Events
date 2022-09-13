using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Models
{
    public class EventReservation
    {
        public long IdReservation { get; set; }
        [Required(ErrorMessage = "Por favor, inserir um ID de evento.")]
        public long IdEvent { get; set; }
        [Required(ErrorMessage = "Por favor, inserir o nome para reserva.")]
        public string PersonName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Por favor inserir a quantidade de pessoas.")]
        public long Quantity { get; set; }

    }
}
