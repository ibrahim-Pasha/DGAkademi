using System;
using System.Text.RegularExpressions;

namespace HomeWork
{
    class Program
    {
        const int MaxTryCount = 3;

        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            try
            {
                int tryCount = 0;
                while (tryCount < MaxTryCount)
                {
                    if (tryCount == 0)
                    {
                        Console.Write("kredi kartınızın numarasını giriniz : ");
                    }
                    else
                    {
                        Console.Write("kart numaranızı doğru giriniz kalan dnem hakkınız ({0}) : ", MaxTryCount - tryCount);
                    }
                    creditCard.CardNumber = Console.ReadLine();
                    bool isCardNumberContainsString = CheckIfInputContainsString(creditCard.CardNumber);
                    bool isCardNumberValid = CheckCardNumberValiditiy(creditCard.CardNumber);
                    if (isCardNumberValid && !isCardNumberContainsString)
                    {
                        tryCount = MaxTryCount + 1;
                        continue;
                    }
                    tryCount++;
                    if (tryCount == MaxTryCount)
                    {
                        throw new CreditCardException("Kart numaranız 16 rakamdan olmalı");
                    }
                }
                //CVV **************************************************************************************

                Console.Write(" Cvv numarasını giriniz : ");

                creditCard.Cvv = Console.ReadLine();
                bool isCvvInputContainsString = CheckIfInputContainsString(creditCard.Cvv);
                if (isCvvInputContainsString)
                {
                    throw new CreditCardException("cvv numarası sadece rakam olabilir");
                }

                bool isCvvValidity = CheckIfCvvValidity(creditCard.Cvv);
                if (!isCvvValidity)
                {
                    throw new CreditCardException("cvv 3 karakter olmalı");
                }

                //ExpireDate **************************************************************************

                Console.Write(" son kullanma tarihi (01/22) formatında olacak şekilde giriniz : ");
                creditCard.ExpireDate = Console.ReadLine();
                bool isExpireDateValidity = CheckIfExpireDateValidity(creditCard.ExpireDate);
                if (!isExpireDateValidity)
                {
                    throw new CreditCardException("son kullanma tarihi yalnış girdiniz");
                }


                Console.WriteLine(CreditCardInfo(creditCard));
            }
            catch (CreditCardException ex)
            {
                Console.WriteLine("Hata oluştu : " + ex.Message);
            }

        }
        //**************************************************************************
        private static bool CheckCardNumberValiditiy(string CardNumber)
        {
            if (CardNumber is null)
            {
                return false;
            }
            if (CardNumber.Length != 16)
            {
                return false;
            }
            return true;
        }
        private static bool CheckIfCvvValidity(string cvv)
        {
            if (Int32.Parse(cvv) > 999 || Int32.Parse(cvv) < 0 || cvv.Length != 3)
            {
                return false;
            }
            return true;
        }
        private static bool CheckIfInputContainsString(string input)
        {

            bool result = Regex.IsMatch(input, @"^[a-zA-Z]+$");
            if (result)
            {
                return true;
            }
            return false;
        }
        private static bool CheckIfExpireDateValidity(string ExpireDate)
        {
            string result = DateTime.Now.ToString("yy");
            int dateOfYear = Int16.Parse(result);
            string[] dates = ExpireDate.Split(new char[] { '/' });
            int[] dateIntFormat = Array.ConvertAll(dates, int.Parse);

            if ((dateIntFormat[0] <= DateTime.Now.Month
                && dateIntFormat[1] < dateOfYear) || (dateIntFormat[1] < dateOfYear)
                || (ExpireDate.Length != 5 || dateIntFormat[0] > 12 || dateIntFormat[0] < 1))
            {
                return false;
            }
            return true;
        }
        private static string CreditCardInfo(CreditCard creditCard)
        {
            return "kart bilgileriniz : Kart numaranız :" + creditCard.CardNumber +
                " , cvv numaranız : " + creditCard.Cvv +
                " , son kullanma tarihi : " + creditCard.ExpireDate;
        }

    }
}
