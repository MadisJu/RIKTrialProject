namespace RIKTrialServer.Models.Data
{
    public class Person
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdNumber { get; set; } = null!;
        public string AdditionalInfo { get; set; } = null!;

        // -- ef navigation --

        public Participant Participant { get; set; } = null!;
    }
}
