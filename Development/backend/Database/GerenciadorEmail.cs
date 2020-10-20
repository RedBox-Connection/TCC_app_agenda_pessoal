using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections;
using System.Text.RegularExpressions;



namespace backend.Database
{
    public class GerenciadorEmail
    {
        public void EnviarEmail(string destinatario, DateTime expiracao, long codigo)
        {
            MailMessage mensagem = new MailMessage("sousamellodiego04@gmail.com", destinatario, "Codigo de Recuperação", "Utilize esse Codigo até " + expiracao.ToString() + " para Recuperar a sua senha: " + codigo.ToString());

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("sousamellodiego04@gmail.com", "dsm06171825");
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