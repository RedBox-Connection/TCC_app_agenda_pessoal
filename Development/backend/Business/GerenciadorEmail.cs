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
        Business.GerenciadorDataExpiracao gerenciadorData = new GerenciadorDataExpiracao();

        public void EnviarEmailCodigo(string destinatario, DateTime expiracao, long codigo)
        {
            string dateExp = gerenciadorData.FormatarDataExpiracao(expiracao);

            string htmlString = $@"<!DOCTYPE html>
                                    <html lang='pt-br'>
                                        <head>
                                            <meta charset='UTF-8'>
                                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                            <title>Envio de Email</title>
                                        </head>
                                        <body style='box-sizing: border-box;
                                                    margin: 0%;
                                                    padding: 1%;
                                                    background-color: #489FB5;'>
                                            <!-- Header -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: space-evenly;
                                                        color: black;
                                                        height: 10vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Nome | Logo -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;'>

                                                    <img src='https://raw.githubusercontent.com/RedBox-Connection/TCC_app_agenda_pessoal/master/Development/backend/Storage/Images/redBoxLogo.png' alt='redBoxLogo'
                                                    style='height: 50px;
                                                        width: 50px;
                                                        border-radius: 100%;
                                                        margin-top: 6%;
                                                        margin-left: 2%;
                                                        margin-right: 1%;'/>
                                                    <span style='margin-top: 12%'>
                                                        <span style='color: darkred;
                                                                    font-weight: bolder;'>Red<span style='color: black; font-weight: bolder;'>Box</span>
                                                        </span>
                                                        <span style='color: white;
                                                                    font-weight: bolder;'>
                                                                    Connection
                                                        </span>
                                                    </span>
                                                    
                                                </div>
                                                <!-- Motivo -->
                                                <div style='width: 50%;'>
                                                    <p style='font-weight: bolder; margin-top: 12%; text-align: end; margin-right: 2%'>
                                                        Código de Recuperação de Senha
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- Body -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: center;
                                                        color: black;
                                                        height: 80vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Mensagem -->
                                                <div style='color: white;
                                                            font-weight: bolder;
                                                            text-align: center;
                                                            height: calc(100% - 100px);
                                                            width: calc(100% - 100px);
                                                            background-color: rgb(0, 0, 0, 0.2);
                                                            border-radius: 5px;
                                                            margin: 50px'>
                                                    <p>
                                                        O código à seguir ficará disponível até: {dateExp}. Então, fique atento ao prazo limite.
                                                        Código: <strong>{codigo.ToString()}</strong>
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- Footer -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: space-evenly;
                                                        color: black;
                                                        height: 10vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Copyright -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;
                                                            margin-top: 6%;
                                                            margin-left: 1%'>
                                                    <div style='font-weight: bolder;
                                                                color: black;
                                                                display: flex;
                                                                align-items: center;
                                                                margin-right: 1%;'>
                                                        Copyrigth &copy; by
                                                    </div>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;
                                                                margin-right: 1%;'
                                                        >Red<span style='color: black;
                                                                        font-weight: bolder;'
                                                                >Box
                                                            </span>
                                                    </span>
                                                    <span style='color: white;
                                                                font-weight: bolder;'>
                                                                Connection
                                                    </span>
                                                </div>
                                                <!-- Localização -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;
                                                            font-weight: bolder;
                                                            margin-top: 6%;
                                                            margin-right: 1%;'>
                                                    <p style='text-align: end; margin: 0%;
                                                            width: 100%;'>&#x2691; São Paulo, Brasil.</p>
                                                </div>
                                            </div>
                                        </body>
                                    </html>";

            MailMessage mensagem = new MailMessage("noreply.organizer.mailsender@gmail.com", destinatario, "Código de Recuperação de Senha", htmlString);

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

        public void EnviarEmailCadastroDeUsuario(string destinatario)
        {
            string htmlString = $@"<!DOCTYPE html>
                                    <html lang='pt-br'>
                                        <head>
                                            <meta charset='UTF-8'>
                                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                            <title>Envio de Email</title>
                                        </head>
                                        <body style='box-sizing: border-box;
                                                    margin: 0%;
                                                    padding: 1%;
                                                    background-color: #489FB5;'>
                                            <!-- Header -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: space-evenly;
                                                        color: black;
                                                        height: 10vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Nome | Logo -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;'>

                                                    <img src='https://raw.githubusercontent.com/RedBox-Connection/TCC_app_agenda_pessoal/master/Development/backend/Storage/Images/redBoxLogo.png' alt='redBoxLogo'
                                                    style='height: 50px;
                                                        width: 50px;
                                                        border-radius: 100%;
                                                        margin-top: 6%;
                                                        margin-left: 2%;
                                                        margin-right: 1%;'/>
                                                    <span style='margin-top: 12%'>
                                                        <span style='color: darkred;
                                                                    font-weight: bolder;'>Red<span style='color: black; font-weight: bolder;'>Box</span>
                                                        </span>
                                                        <span style='color: white;
                                                                    font-weight: bolder;'>
                                                                    Connection
                                                        </span>
                                                    </span>
                                                    
                                                </div>
                                                <!-- Motivo -->
                                                <div style='width: 50%;'>
                                                    <p style='font-weight: bolder; margin-top: 12%; text-align: end; margin-right: 2%'>
                                                        Bem vindo(a) ao nosso Organizer!
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- Body -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: center;
                                                        color: black;
                                                        height: 80vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Mensagem -->
                                                <div style='color: white;
                                                            font-weight: bolder;
                                                            text-align: center;
                                                            height: calc(100% - 100px);
                                                            width: calc(100% - 100px);
                                                            background-color: rgb(0, 0, 0, 0.2);
                                                            border-radius: 5px;
                                                            margin: 50px;'>
                                                    <p>
                                                        Nossa equipe agradece a preferência e a opção pelo RedBox Organizer.
                                                        Desfrute de um organizador completo compartilhável à você e seus colegas de time!
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- Footer -->
                                            <div style='display: flex;
                                                        align-items: center;
                                                        justify-content: space-evenly;
                                                        color: black;
                                                        height: 10vh;
                                                        width: 100%;
                                                        background-color: rgb(0, 0, 0, 0.2);
                                                        border-radius: 5px;
                                                        margin: 0.2%;'>
                                                <!-- Copyright -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;
                                                            margin-top: 6%;
                                                            margin-left: 1%'>
                                                    <div style='font-weight: bolder;
                                                                color: black;
                                                                display: flex;
                                                                align-items: center;
                                                                margin-right: 1%;'>
                                                        Copyrigth &copy; by
                                                    </div>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;
                                                                margin-right: 1%;'
                                                        >Red<span style='color: black;
                                                                        font-weight: bolder;'
                                                                >Box
                                                            </span>
                                                    </span>
                                                    <span style='color: white;
                                                                font-weight: bolder;'>
                                                                Connection
                                                    </span>
                                                </div>
                                                <!-- Localização -->
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-evenly;
                                                            width: 50%;
                                                            font-weight: bolder;
                                                            margin-top: 6%;
                                                            margin-right: 1%;'>
                                                    <p style='text-align: end; margin: 0%;
                                                            width: 100%;'>&#x2691; São Paulo, Brasil.</p>
                                                </div>
                                            </div>
                                        </body>
                                    </html>";

            MailMessage mensagem = new MailMessage("noreply.organizer.mailsender@gmail.com", destinatario, "Confirmação de Cadastro", htmlString);

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