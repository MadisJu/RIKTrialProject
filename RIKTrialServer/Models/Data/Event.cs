namespace RIKTrialServer.Models.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }
        public string AdditionalInfo { get; set; } = null!;

        // -- ef navigation --

        public List<EventParticipant> Participants { get; set; } = new();
    }

    public class EventParticipant
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }

        // -- ef navigation --

        public Event Event { get; set; } = null!;
        public Participant Participant { get; set; } = null!;
    }
}
