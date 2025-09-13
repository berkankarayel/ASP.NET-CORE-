using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        // Katılımcıları geçici olarak bellekte tutacağız
        private static List<Participant> participants = new List<Participant>();

        public IActionResult Index()
        {
            var hour = DateTime.Now.Hour;
            string message = GetGreetingMessage(hour);

            ViewData["Greeting"] = message;

            // Toplantı bilgilerini controller ile dolduruyoruz.
            var meetingInfo = new MeetingInfo
            {
                Title = "Toplantı Katılım",
                Location = "İstanbul, Abc Kongre Merkezi",
                Date = new DateTime(2025, 1, 20, 20, 0, 0),
                ParticipantsCount = participants.Count(x => x.WillAttend == true) // ✅ düzeltildi
            };

            return View(meetingInfo);
        }

        private string GetGreetingMessage(int hour)
        {
            if (hour >= 6 && hour < 12)
                return "Günaydın";
            else if (hour >= 12 && hour < 18)
                return "İyi Günler";
            else if (hour >= 18 && hour < 23)
                return "İyi Akşamlar";
            else
                return "İyi Geceler";
        }

        [HttpGet]
        public IActionResult Apply() // Formu göstermek için
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                // Eğer valid değilse aynı formu hata mesajlarıyla göster
                return View(participant);
            }

            participant.Id = participants.Count + 1;
            participants.Add(participant);

            if (participant.WillAttend == true) // ✅ düzeltildi
            {
                ViewBag.Message = $"Teşekkürler, {participant.Name}. Toplantıya sizinle birlikte katılım sağlanacak.";
            }
            else
            {
                ViewBag.Message = $"Üzgünüz, {participant.Name}. Katılmayacağınızı belirttiniz.";
            }

            return View("ApplyResult");
        }

        public IActionResult Participants()
        {
            return View(participants);
        }

        public IActionResult Detail(int id)
        {
            var participant = participants.FirstOrDefault(p => p.Id == id);

            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }
    }
}
