using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            var result = DateTime.Now.ToString("yy");
            int dateOfYear = Int16.Parse(result);

            try
            {
                Console.Write("kredi kartınızın numarasını giriniz : ");
                creditCard.CardNumber = Console.ReadLine();
                if (creditCard.CardNumber.Length != 16)
                {
                    throw new CreditCardException("kart numaranız 16 karater olmalı");
                }
                Console.Write(" Cvv numarasını giriniz : ");
                creditCard.Cvv = Convert.ToInt32(Console.ReadLine());
                if (creditCard.Cvv > 999 || creditCard.Cvv < 0)
                {
                    throw new CreditCardException("cvv numarası 3 numaradan oluşmaktadır");
                }
                Console.Write(" son kullanma tarihi (01/22) formatında olacak şekilde giriniz : ");
                creditCard.ExpireDate = Console.ReadLine();
                if (creditCard.ExpireDate.Length != 5)
                {
                    throw new CreditCardException("kullanma tarihi yalnış  girdiniz");
                }
                string[] dates = creditCard.ExpireDate.Split(new char[] { '/' });
                int[] dateIntFormat = Array.ConvertAll(dates, int.Parse);

                if ((dateIntFormat[0] <= DateTime.Now.Month && dateIntFormat[1] < dateOfYear) || dateIntFormat[1] < dateOfYear)
                {
                    throw new CreditCardException("kullanma tarihi geçmiş");
                }
                Console.WriteLine(creditCard.CreditCardInfo());
            }
            catch (Exception ex)
            {
                new CreditCardException(ex.Message);
            }
        }
    }
}
