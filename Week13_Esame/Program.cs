using System.Globalization;
using MyClasses;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Welcome message
            Generic.WelcomeUser();


            // Create taxpayer
            while (true)
                try
                {
                    // Crea nuovo contribuente
                    Contribuente taxPayer = new Contribuente();

                    // Stampa il risultato delle tasse da pagare
                    taxPayer.PrintTaxesToPay();

                    // Chiede all'utente di eseguire un ulteriore calcolo
                    taxPayer.CalculateMore();

                    // Termina il programma
                    return;
                    
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }


        }
    }
}