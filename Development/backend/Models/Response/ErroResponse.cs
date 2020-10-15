namespace backend.Models.Response
{
    public class ErroResponse
    {
        public int Codigo {get; set;}
        public string Erro {get; set;}

        public ErroResponse (int Codigo, string Erro)
        {
            this.Codigo = Codigo;
            this.Erro = Erro;
        }
    }
}