namespace backend.Models.Response
{
    public class TimeIntegranteResponse
    {
        public int IdIntegrante { get; set; }
        public string Permissao { get; set; }
        public string NomeUsuario { get; set; }
        public string FotoPerfil { get; set; }
        public int IdLogin { get; set; }
    }
}