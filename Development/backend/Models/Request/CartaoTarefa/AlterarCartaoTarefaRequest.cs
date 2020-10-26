using System;

namespace backend.Models.Request
{
    public class AlterarCartaoTarefaRequest
    {
        public int IdCartao { get; set; }
        public string NomeCartao { get; set; }
        public string Hora { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public int IdQuadro { get; set; }
        public string Status { get; set; }
    }
}