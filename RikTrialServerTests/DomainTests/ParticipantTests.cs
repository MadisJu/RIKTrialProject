using RIKTrialServer.Domains.Models;
using RIKTrialSharedModels.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RikTrialServerTests.DomainTests
{
    public class ParticipantTests
    {
        [Fact]
        public void PersonHasParticipantAmountOfOne()
        {
            Person p = new
            (
                Guid.NewGuid(),
                1,
                "Madingus",
                "Tambingus",
                "12345689012",
                "Is allergic to peanuts"
            );

            Assert.Equal(1, p.ParticipantCount);
        }

        [Fact]
        public void CompanyHasXParticipantAmount()
        {
            Company comp = new
            (
                Guid.NewGuid(),
                1,
                "MadislolInc OÜ",
                "1236767",
                2,
                "Coolest programming firm ever"
            );

            Assert.Equal(2, comp.ParticipantCount);
        }
    }
}
