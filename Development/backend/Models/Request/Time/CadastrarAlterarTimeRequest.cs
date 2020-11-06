namespace backend.Models.Request
{
    public class CadastrarAlterarTimeRequest
    {
        public int IdLogin { get; set; }
        public string NomeTime { get; set; }
        public string DescricaoTime { get; set; }
    }
}