namespace EntityFramework.Models.Entities
{
    public class Ogrenci
    {
       public int OgrenciId { get; set; }   // Primary Key
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }


        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();  // Many-to-Many ilişki
   
   
    
   
   
    }
}