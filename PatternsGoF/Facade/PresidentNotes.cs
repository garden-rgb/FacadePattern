using System;

namespace PatternsGoF.Facade
{
    public class PresidentNotes
    {
        public int Id { get; set; }
        public string DailyAgenda { get; set; }
        public DateTime PostedAt { get; set; }

        public PresidentNotes MakeAnAnnouncment(string text)
        {
            return new PresidentNotes { DailyAgenda = $"{text}", PostedAt = DateTime.Now };
        }
    }
}
