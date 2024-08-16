namespace GameKartu.Models
{
    public class Sepatu
    {
        public JenisSepatu JenisSepatu { get; set; } 

        public Sepatu (JenisSepatu jenisSepatu)
        {
            JenisSepatu = jenisSepatu;
        }
    }
}
