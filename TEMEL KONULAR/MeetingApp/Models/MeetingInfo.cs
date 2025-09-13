namespace MeetingApp.Models
{
   public class MeetingInfo
    {
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantsCount { get; set; }
    }
}