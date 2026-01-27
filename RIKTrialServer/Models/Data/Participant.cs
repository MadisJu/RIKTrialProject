namespace RIKTrialServer.Models.Data
{
    public class Participant
    {
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public int EventId { get; set; }
        public ParticipantType ParticipantType { get; set; }

        // -- ef navigation --
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public List<EventParticipant> Events { get; set; } = null!;
        public Person? Person { get; set; }
        public Company? Company { get; set; }
    }

    public enum ParticipantType
    {
        Person = 0,
        Company = 1
    }
}
