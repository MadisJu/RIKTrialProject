using RIKTrialServer.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RikTrialServerTests.DomainTests
{
    public class EventTests
    {
        [Fact]
        public void EventRegistrationWorks()
        {
            Event ev = new Event
            (
                Guid.NewGuid(),
                "GrandFantasia gaming fest",
                "Tartu aardla 9a",
                DateTime.UtcNow,
                "Bring your own computer"
            );

            ev.RegisterParticipant(Guid.NewGuid());

            Assert.Single(ev.Participants);
        }

        [Fact]
        public void EventUnRegistrationWorks()
        {
            Event ev = new Event
            (
                Guid.NewGuid(),
                "GrandFantasia gaming fest",
                "Tartu aardla 9a",
                DateTime.UtcNow,
                "Bring your own computer"
            );

            Guid participantId = Guid.NewGuid();

            ev.RegisterParticipant(participantId);

            ev.UnRegisterParticipant(participantId);

            Assert.Empty(ev.Participants);
        }
    }
}
