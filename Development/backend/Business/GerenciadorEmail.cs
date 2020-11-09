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
                                                    width: 100vw;
                                                    height: 100vh;
                                                    display: flex;
                                                    flex-direction: column;
                                                    align-items: center;
                                                    justify-content: space-evenly;
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
                                                            width: 17%;'>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;'>Red<span style='color: black; font-weight: bolder;'>Box</span>
                                                    </span>
                                                    <span style='color: white;
                                                                font-weight: bolder;'>
                                                                Connection
                                                    </span>

                                                    <img src='https://raw.githubusercontent.com/RedBox-Connection/TCC_app_agenda_pessoal/master/Development/backend/Storage/Images/redBoxLogo.png' alt='redBoxLogo'
                                                        style='height: 50px;
                                                                width: 50px;
                                                                border-radius: 100%;'/>
                                                </div>
                                                <!-- Motivo -->
                                                <div>
                                                    <p style='font-weight: bolder;'>
                                                        Código para Recuperação de Senha
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
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: space-between;
                                                            color: white;
                                                            font-weight: bolder;
                                                            height: 70vh;
                                                            width: 80%;
                                                            background-color: rgb(0, 0, 0, 0.2);
                                                            border-radius: 5px;
                                                            margin: 0.2%;'>
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
                                                            width: 22%;'>
                                                    <div style='font-weight: bolder;
                                                                color: black;
                                                                display: flex;
                                                                align-items: center;
                                                                '>
                                                        Copyrigth &copy; by
                                                    </div>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;'
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
                                                            width: 15%;
                                                            font-weight: bolder;'>
                                                    <span>&#x2691;</span>
                                                    <span>São Paulo, Brasil.</span>
                                                </div>
                                            </div>
                                        </body>
                                    </html>";

            MailMessage mensagem = new MailMessage("noreply.organizer.mailsender@gmail.com", destinatario, "", htmlString);

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
                                                    width: 50vw;
                                                    height: 100vh;
                                                    display: flex;
                                                    flex-direction: column;
                                                    align-items: center;
                                                    justify-content: space-evenly;
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
                                                            width: 35%;'>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;'>Red<span style='color: black; font-weight: bolder;'>Box</span>
                                                    </span>
                                                    <span style='color: white;
                                                                font-weight: bolder;'>
                                                                Connection
                                                    </span>

                                                    <img src='https://raw.githubusercontent.com/RedBox-Connection/TCC_app_agenda_pessoal/master/Development/backend/Storage/Images/redBoxLogo.png' alt='redBoxLogo'
                                                        style='height: 50px;
                                                                width: 50px;
                                                                border-radius: 100%;'/>
                                                </div>
                                                <!-- Motivo -->
                                                <div>
                                                    <p style='font-weight: bolder;'>
                                                        Código para Recuperação de Senha
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
                                                <div style='display: flex;
                                                            align-items: center;
                                                            justify-content: center;
                                                            color: white;
                                                            font-weight: bolder;
                                                            height: 70vh;
                                                            width: 80%;
                                                            background-color: rgb(0, 0, 0, 0.2);
                                                            border-radius: 5px;
                                                            margin: 0.2%;'>
                                                    <p>
                                                        <!-- text here -->
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
                                                            width: 50%;'>
                                                    <div style='font-weight: bolder;
                                                                color: black;
                                                                display: flex;
                                                                align-items: center;
                                                                '>
                                                        Copyrigth &copy; by
                                                    </div>
                                                    <span style='color: darkred;
                                                                font-weight: bolder;'
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
                                                            font-weight: bolder;'>
                                                    <span>&#x2691;</span>
                                                    <span>São Paulo, Brasil.</span>
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