using System;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        
        public string Local { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEvento { get; set; }
        [Required]
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string Imagem { get; set; }
    }
}