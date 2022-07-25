
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public int Cvv { get; set; }
        public string CreditCardInfo()
        {
            return "kart bilgileriniz : Kart numaranız :" + CardNumber + " , cvv numaranız : " + Cvv + " , son kullanma tarihi : " + ExpireDate;
        }
    }
}
