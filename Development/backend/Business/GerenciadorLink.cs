using System;

namespace backend.Business
{
    public class GerenciadorLink
    {
        Database.TimeDatabase timeDb = new Database.TimeDatabase();

        public string GerarLink(int idTime, int idQuadroTime)
        {
            string url = "host:3000/Inicial?idTime=" + idTime + "&idQuadroTime=" + idQuadroTime + "/invitation";
            //return : "host:3000/Inicial?idTime=1&idQuadroTime=1/invitation"

            return url;
        }

        public void ValidarLink(string link)
        {
            this.ValidarHostLink(link);

            this.ValidarIdTimeLink(link);

            this.ValidarIdQuadroTimeLink(link);
        }

        private void ValidarHostLink(string link)
        {
            string host = link.Substring(0, 9);

            if(!(host.Length == 9 || host.Contains("host:3000")))
                throw new Exception("Link inválido, não possui o host.");
        }

        private void ValidarIdTimeLink(string link)
        {
            string idTime = link.Substring((link.IndexOf("idTime=") + 7), link.IndexOf('&') - (link.IndexOf("idTime=") + 7));
            int test = 0;
            if(Convert.ToInt32(idTime).GetType() != test.GetType())
                throw new Exception("Id do time inválido.");
        }

        private void ValidarIdQuadroTimeLink(string link)
        {
            string idQuadroTime = link.Substring((link.IndexOf("&idQuadroTime=") + 14), link.LastIndexOf('/') - (link.IndexOf("&idQuadroTime=") + 14));
            int test = 0;
            if(Convert.ToInt32(idQuadroTime).GetType() != test.GetType())
                throw new Exception("Id do quadro do time inválido.");
        }
    }
}