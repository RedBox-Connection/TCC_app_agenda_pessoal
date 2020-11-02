using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections;
using System.Text.RegularExpressions;



namespace backend.Business
{
    public class GerenciadorEmail
    {
        public void EnviarEmail(string destinatario, DateTime expiracao, long codigo)
        {
            string htmlString = $@"<html>
                                    <header>
                                        <h1>Ola e bom dia</h1>
                                    </header>
                                    <body>
                                        <h6>Utilize esse Codigo até {expiracao} para Recuperar a sua senha: {codigo.ToString()}</h6>
                                    </body>
                                    <footer>
                                        {codigo}
                                    </footer>
                                   </html>";

            MailMessage mensagem = new MailMessage("noreply.organizer.mailsender@gmail.com", destinatario, "Codigo de Recuperação", htmlString);

            using (var smtpClient = new SmtpClient())
            {
                mensagem.IsBodyHtml = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("noreply.organizer.mailsender@gmail.com", "Redbox123");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 20_000;
                smtpClient.Send(mensagem);
            }
        }
    }
}