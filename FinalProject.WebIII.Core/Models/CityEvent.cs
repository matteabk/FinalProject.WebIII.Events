using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Models
{
    public class CityEvent
    {
        public long IdEvent { get; set; }
        [Required(ErrorMessage = "Por favor, inserir título para o evento.")]
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        [Required(ErrorMessage = "Por favor, inserir a data do evento.")]
        public DateTime DateHourEvent { get; set; }
        [Required(ErrorMessage = "Por favor, inserir o local do evento.")]
        public string Local { get; set; } = String.Empty;
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Por favor, informar o status do evento.")]
        public bool Status { get; set; }

    }
}
