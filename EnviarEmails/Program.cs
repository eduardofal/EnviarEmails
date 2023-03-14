using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;

namespace EnviarEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---DESTINATÁRIOS----
            string emails = "EMAIL_DO(S)_DESTINATÁRIO(S)"; // ---OBSERVAÇÃO: SEPARAR EMAILS COM ','---

            string[] email = emails.Split(',');

            // ---TITULO E MENSAGEM DO EMAIL ---
            Console.Write("Título do email: ");
            string titulo = Console.ReadLine();

            Console.Write("Mensagem do email: ");
            string mensagem = Console.ReadLine();

            // ---INFORMAÇÕES DO REMETENTE---
            string senha = "SENHA_APP_EMAIL";
            string emailRemetente = "EMAIL_DO_REMETENTE";

            // ---ENVIO DE EMAILS---
            for (int i = 0; i < email.Length; i++)
            {
                try
                {
                    // ---REMETENTE E DESTINATÁRIOS---
                    MailMessage mailMessage = new MailMessage(emailRemetente, email[i]);

                    // ---CONFIGURAÇÕES DO EMAIL---
                    mailMessage.Subject = $"{titulo}";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = $"<p> {mensagem} </p>";
                    mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                    mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                    // ---CONFIGURAÇÕES SMTP---
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(emailRemetente, senha);
                    smtpClient.EnableSsl = true;

                    // ---FINALIZAÇÃO E ENVIO---
                    smtpClient.Send(mailMessage);

                    Console.WriteLine($"O email para o destinatário '{email[i]}' foi enviado com sucesso!");

                }
                catch (Exception e)
                {
                    // ---EM CASO DE FALHA DO ENVIO---
                    Console.WriteLine($"Erro ao enviar o email para o destinátario '{email[i]}'!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
