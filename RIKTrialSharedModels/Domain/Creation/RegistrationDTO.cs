using System;
using System.Collections.Generic;
using System.Text;

namespace RIKTrialSharedModels.Domain.Creation
{
    public class RegistrationDTO
    {
        public Guid ParticipantId { get; set; }
        public Guid EventId {  get; set; }
    }
}
