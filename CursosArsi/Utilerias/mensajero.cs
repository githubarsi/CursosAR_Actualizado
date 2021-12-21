using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursosArsi.Utilerias
{
    public class mensajero
    {
        public void EnviaMensaje()
        {
            const string accountSid = "ACebdf6a7e9f9f7ec639b08932d0fb1cef";
            const string authToken = "735cadc437772d953a0a085e7878a4da";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //body: "Probando, Probando!!!",
            //from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            //to: new Twilio.Types.PhoneNumber("whatsapp:+15104221084"));
        }
    }
}