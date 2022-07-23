using System;
using System.Globalization;

namespace HomeWork
{
    class Program
    {

        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
          var result=  DateTime.Now.ToString("yy");
        int  dateOfYear=  Int16.Parse(result);
         
            try
            {
                Console.Write("kredi kartınızın numarasını giriniz : ");
                creditCard.CardNumber = Console.ReadLine();
                Console.Write(" Cvc numarasını giriniz : ");
                creditCard.Cvc = Convert.ToInt32(Console.ReadLine());
                Console.Write(" son kullanma tarihi (01/22) formatında olacak şekilde giriniz : ");
                creditCard.ExpireDate = Console.ReadLine();

                string[] dates = creditCard.ExpireDate.Split(new char[] { '/' });
                int[] dateIntFormat = Array.ConvertAll(dates, int.Parse);

                if (creditCard.CardNumber.Length != 16)
                {
                    Console.WriteLine("kart numaranız 16 karater olmalı");
                    return;
                }
                else if (creditCard.Cvc > 999 || creditCard.Cvc < 0)
                {
                    Console.WriteLine("cvc numarası 3 numaradan oluşmaktadır");
                    return;
                }

                else if (creditCard.ExpireDate.Length != 5 && (dateIntFormat[0] <= DateTime.Now.Month && dateIntFormat[1] < dateOfYear) || dateIntFormat[1] < dateOfYear)
                {
                    Console.WriteLine("son kullanma tarihi yalnış girdiniz ");
                    return;
                }

            }
            catch (Exception)
            {
                Exception creditCardException = new Exception("Kredi bilgileri yalnış girildi");

            }

            Console.WriteLine("Kart Numaranız : " + creditCard.CardNumber);
            Console.WriteLine("Kartınızın son kullanma tarihi : " + creditCard.ExpireDate);
            Console.WriteLine("Kartınızın cvc numarası : " + creditCard.Cvc);
        }
    }
}
