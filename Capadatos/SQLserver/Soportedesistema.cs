using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos.SQLserver
{
   public class Soportedesistema: ServerMasteremail
    {
        public Soportedesistema()
        {
            SenderMail = "samuel0221fire@gmail.com";
            Password = "bingoybugui18anos";
            Host = "smtp.gmail.com";
            Port = 587;
            Ssl = true;
            Inicializarsmtpcliente();
        }
    }
}
