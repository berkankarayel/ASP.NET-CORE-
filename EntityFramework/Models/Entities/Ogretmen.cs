namespace EntityFramework.Models.Entities
{
    public class Ogretmen
    {
        public int OgretmenId { get; set; }   // Primary Key
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public DateOnly BaslamaTarihi { get; set; }

        // Navigation Property: 1 öğretmenin birden fazla kursu olabilir
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}
