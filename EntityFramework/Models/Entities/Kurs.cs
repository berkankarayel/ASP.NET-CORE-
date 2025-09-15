namespace EntityFramework.Models.Entities
{
    public class Kurs
    {
        public int KursId { get; set; }   // Primary Key
        public string Baslik { get; set; }

        // 🔹 1 Öğretmen - n Kurs ilişkisi (Her kursun tek öğretmeni olur)
        public int OgretmenId { get; set; }   
        public Ogretmen Ogretmen { get; set; }

        // 🔹 n-n ilişki (Bir kursa birçok öğrenci katılabilir)
        public ICollection<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();
    }
}
