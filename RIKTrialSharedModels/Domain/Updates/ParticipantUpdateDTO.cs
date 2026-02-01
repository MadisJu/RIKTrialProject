using RIKTrialSharedModels.Domain.Types;

namespace RIKTrialSharedModels.Domain.Updates
{
    public class ParticipantUpdateDTO
    {
        public ParticipantType Type { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? AdditionalInfo { get; set; }

        // For person type participant
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdNumber { get; set; }

        // For Company type

        public string? Name { get; set; }
        public string? CompanyCode { get; set; }
        public int? ParticipantAmount { get; set; }
    }
}
