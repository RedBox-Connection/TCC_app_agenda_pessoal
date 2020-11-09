using System;

namespace backend.Models.Response
{
    public class CartaoTarefaResponse
    {
        public int IdCartao { get; set; }
        public string NomeCartao { get; set; }
        public DateTime DataCartao { get; set; }
        public string Hora { get; set; }
        public string StatusDia { get; set; }
        public string Status { get; set; }
        public int IdQuadro { get; set; }
        public string Cor { get; set; }
    }
}