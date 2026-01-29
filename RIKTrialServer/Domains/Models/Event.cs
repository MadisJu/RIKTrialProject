namespace RIKTrialServer.Domains.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }
        public string AdditionalInfo { get; set; } = null!;

        // -- ef navigation --

        private readonly List<EventParticipant> _participants = new();
        public IReadOnlyCollection<EventParticipant> Participants => _participants;

        // -- uncs --
        public void RegisterParticipant(Guid participantId)
        {
            _participants.Add(new EventParticipant(Id, participantId));
        }

        public void UnRegisterParticipant(Guid participantId)
        {
            EventParticipant? register = _participants.FirstOrDefault(x => x.ParticipantId == participantId);

            if (register == null) return;

            _participants.Remove(register);
        }

    }

    
}
