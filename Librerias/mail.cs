using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Librerias
{
    public class mail
    {
        private MailMessage message;
        private SmtpClient clienteSmtp;
        private string user;
        private string password;

        public void ConfigurarMail(string from, string usuario, string contraseña, int puerto_salida, string smtp)
        {
            this.message = new MailMessage
            {
                From = new MailAddress(from),
            };
            this.clienteSmtp = new SmtpClient(smtp);
            this.user = usuario;
            this.password = contraseña;
            this.clienteSmtp.Port = puerto_salida;
        }

        public bool EnviarMail(string to, string cc, string asunto, string mensaje)
        {
            try
            {
                this.message.To.Add(to);
                this.message.CC.Add(cc);
                this.message.Subject = asunto;
                this.message.IsBodyHtml = true; // el texto del mensaje lo pueden poner en HTML y darle formato
                this.message.Body = mensaje;
                this.clienteSmtp.EnableSsl = true;
                this.clienteSmtp.UseDefaultCredentials = false;
                this.clienteSmtp.Credentials = new NetworkCredential(this.user, this.password);
                this.clienteSmtp.Send(this.message);

                return true;
            }
            catch
            {
                try
                {
                    // Establesco que no usare seguridad ssl (por si no pudo enviarlo con ssl habilitado)
                    this.clienteSmtp.EnableSsl = false;
                    this.clienteSmtp.Send(this.message);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
