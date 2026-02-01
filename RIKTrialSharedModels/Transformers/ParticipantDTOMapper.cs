using RIKTrialSharedModels.Domain.Returns;
using RIKTrialSharedModels.Domain.Updates;

namespace RIKTrialSharedModels.Transformers
{
    public static class ParticipantDTOMapper
    {
        public static ParticipantUpdateDTO MapParticipantDataToCreationDTO(ParticipantReturnDTO data)
        {
            return new ParticipantUpdateDTO
            {
                Type = data.Type,
                PaymentMethodId = data.PaymentMethod.Id,
                AdditionalInfo = data.AdditionalInfo,

                FirstName = data.FirstName,
                LastName = data.LastName,
                IdNumber = data.IdNumber,

                Name = data.Name,
                CompanyCode = data.CompanyCode,
                ParticipantAmount = data.ParticipantAmount
            };
        }
    }
}
