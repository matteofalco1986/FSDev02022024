using MyClasses;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("\nBenvenuto nel calcolatore di tasse. Usa questo strumento per calcolare le imposte dovute al tuo beneamato fisco. Premi un tasto qualsiasi per continuare");
            Console.ReadKey();
            // Create taxpayer
            while (true)
                try
                {
                    Contribuente taxPayer = new Contribuente();
                    //taxPayer.PrintDataSummary();
                    taxPayer.PrintTaxesToPay();

                    bool isAnswerCorrect = false;
                    while (!isAnswerCorrect)
                    {
                        Console.Write("\nVuoi calcolare le tue tasse in base ad un altro reddito? Y o N: ");
                        string userAnswer = Console.ReadLine().ToLower();
                        switch (userAnswer)
                        {
                            case "n":
                                // Termina programma
                                Console.Clear();
                                Console.WriteLine("\nGrazie per aver usato il nostro calcolatore di tasse");
                                isAnswerCorrect = true;
                                return;
                            case "y":
                                // Input di reddito alternativo e ricalcolo
                                Console.Clear();
                                Console.Write("\nInserisci il tuo reddito annuo: ");
                                taxPayer.RedditoAnnuale = double.Parse(Console.ReadLine());
                                taxPayer.PrintTaxesToPay();
                                break;
                            default:
                                Console.WriteLine("La risposta non è corretta. Rispondi y o n");
                                break;
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }


        }
    }
}