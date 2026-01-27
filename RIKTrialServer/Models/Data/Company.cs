namespace RIKTrialServer.Models.Data
{
    public class Company
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public string Name { get; set; } = null!;
        public string CompanyCode { get; set; } = null!;
        public int ParticipantAmount { get; set; }
        public string AdditionalInfo { get; set; } = null!;
    }
}
