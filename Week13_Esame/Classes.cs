namespace MyClasses
{
    public class Contribuente
    {
        // FIELDS
        private string _nome;
        private string _cognome;
        private string _dataNascita;
        private string _codiceFiscale;
        private string _sesso;
        private string _comuneResidenza;
        private double _redditoAnnuale;

        // PROPERTIES
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length > 0)
                {
                    _nome = value;
                }
                else
                {
                    throw new Exception("Il nome deve essere di almeno un carattere");
                }
            }
        }
        public string Cognome
        {
            get
            {
                return _cognome;
            }
            set
            {
                if (value.Length > 0)
                {
                    _cognome = value;
                }
                else
                {
                    throw new Exception("Il cognome deve essere di almeno un carattere");
                }
            }
        }
        public string DataNascita
        {
            get
            {
                return _dataNascita;
            }
            set
            {
                _dataNascita = value;
            }
        }
        public string CodiceFiscale
        {
            get
            {
                return _codiceFiscale;
            }
            set
            {
                if (value.Length != 16)
                {
                    throw new Exception("Il codice fiscale deve essere di 16 caratteri");
                }
                _codiceFiscale = value.ToUpper();
            }
        }
        public string Sesso
        {
            get
            {
                return _sesso;
            }
            set
            {
                if (value.ToLower() != "m" && value.ToLower() != "f")
                {
                    throw new Exception("Il valore per il sesso deve corrispondere a 'm' o 'f'");
                }
                _sesso = value;
            }
        }
        public string ComuneResidenza
        {
            get
            {
                return _comuneResidenza;
            }
            set
            {
                _comuneResidenza = value;
            }
        }
        public double RedditoAnnuale
        {
            get
            {
                return _redditoAnnuale;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Il reddito deve essere un valore positivo");
                }
                _redditoAnnuale = value;
            }
        }

        // PROCEDURES
        public void SetFields()
        {
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            Console.Write("Cognome: ");
            Cognome = Console.ReadLine();

            Console.Write("Data di nascita. gg/mm/yyyy: ");
            DataNascita = Console.ReadLine();

            Console.Write("Codice Fiscale: ");
            CodiceFiscale = Console.ReadLine();

            Console.Write("Sesso. M o F: ");
            Sesso = Console.ReadLine();

            Console.Write("Comune di residenza: ");
            ComuneResidenza = Console.ReadLine();

            Console.Write("Reddito annuale: ");
            RedditoAnnuale = double.Parse(Console.ReadLine());
        }
        public void PrintDataSummary()
        {
            Console.Clear();
            Console.WriteLine("Grazie per esserti registrato. Ecco qui un riepilogo dei tuoi dati.\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cognome: {Cognome}");
            Console.WriteLine($"Data di nascita: {DataNascita}");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Comune di residenza: {ComuneResidenza}");
            Console.WriteLine($"Reddito annuale: {RedditoAnnuale} €");
        }
        public void PrintTaxesToPay()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Calcolo dell'imposta da versare");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"nato il {DataNascita} ({Sesso.ToUpper()}),");
            Console.WriteLine($"residente in {ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale} €");
            Console.WriteLine($"IMPOSTA DA VERSARE: {CalculateTaxes()} €");
        }

        // FUNCTIONS
        public double CalculateTaxes()
        {
            double exceedAmount = 0;
            double taxesToPay = 0; ;
            if (RedditoAnnuale > FasceReddito.Fascia5)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia5) * Aliquota.Fascia5;
                taxesToPay = ImpostaBase.Fascia5 + exceedAmount;
            }
            else if (RedditoAnnuale > FasceReddito.Fascia4)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia4) * Aliquota.Fascia4;
                taxesToPay = ImpostaBase.Fascia4 + exceedAmount;

            }
            else if (RedditoAnnuale > FasceReddito.Fascia3)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia3) * Aliquota.Fascia3;
                taxesToPay = ImpostaBase.Fascia3 + exceedAmount;

            }
            else if (RedditoAnnuale > FasceReddito.Fascia2)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia2) * Aliquota.Fascia2;
                taxesToPay = ImpostaBase.Fascia2 + exceedAmount;

            }
            else
            {
                exceedAmount = RedditoAnnuale * Aliquota.Fascia1;
                taxesToPay = exceedAmount;

            }
            return taxesToPay;

        }

        // CONSTRUCTORS
        public Contribuente()
        {
            SetFields();
        }
    }
    public class FasceReddito
    {
        public static double Fascia2
        {
            get
            {
                return 15000;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 28000;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 55000;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 75000;
            }
        }
    }
    public class Aliquota
    {
        public static double Fascia1
        {
            get
            {
                return 0.23;
            }
        }
        public static double Fascia2
        {
            get
            {
                return 0.27;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 0.38;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 0.41;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 0.43;
            }
        }
    }
    public class ImpostaBase
    {
        public static double Fascia2
        {
            get
            {
                return 3450;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 6960;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 17220;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 25420;
            }
        }

    }
}