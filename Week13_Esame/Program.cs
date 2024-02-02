using MyClasses;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FasceReddito.Min1);
            Console.WriteLine(FasceReddito.Max1);
            Console.WriteLine(FasceReddito.Min2);
            Console.WriteLine(FasceReddito.Max2);
            Console.WriteLine(FasceReddito.Min3);
            Console.WriteLine(FasceReddito.Max3);
            Console.WriteLine(FasceReddito.Min4);
            Console.WriteLine(FasceReddito.Max4);
            Console.WriteLine(FasceReddito.Min5);
            // Create taxpayer
            bool isTaxPayerCreated = false;
            while (!isTaxPayerCreated)
                try
                {
                    Contribuente taxPayer = new Contribuente();
                    taxPayer.PrintSummary();
                    isTaxPayerCreated = true;

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }


        }
    }
}