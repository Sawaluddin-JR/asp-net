namespace GameKartu.Models
{
    public class KartuRemi
    {
        //public string Kembang { get; set; }
        public KembangRemi Kembang { get; set; }
        //public string Angka { get; set; }
        public AngkaRemi Angka { get; set; }

        //public KartuRemi(string kembang,string angka) {
        //Kembang = kembang;
        //Angka = angka;
        //}
        public KartuRemi(KembangRemi kembang, AngkaRemi angka)
        {
            Kembang = kembang;
            Angka = angka;
        }
        public string KartuName { 
            get {
                string angka = "";
                switch (Angka)
                {
                    case AngkaRemi.As:
                        angka = "A";
                        break;
                    case AngkaRemi.Jek:
                        angka = "J";
                        break;
                    case AngkaRemi.Kwin:
                        angka = "Q";
                        break;
                    case AngkaRemi.King:
                        angka = "K";
                        break;
                    default:
                        angka = ((int)Angka).ToString();
                        break;
                }
                //return "";
                string kembang = "";
                switch (Kembang)
                {
                    case KembangRemi.Tempe:
                        kembang = " ♦️";
                        break;
                    case KembangRemi.Keriting:
                        kembang = " ♣️";
                        break;
                    case KembangRemi.Sekop:
                        kembang = " ♠️";
                        break;
                    case KembangRemi.Lope:
                        kembang = " ♥️";
                        break;
                }
                return $"{angka}{kembang}";
            }
        }
    }
}
