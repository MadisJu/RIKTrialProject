using Moq;
using RIKTrialServer.Domains.Models;
using RIKTrialServer.Repositories.Interfaces;
using RIKTrialServer.Services.Implementations;
using RIKTrialSharedModels.Domain.Creation;

namespace RikTrialServerTests.ServiceTests
{
    public class EventServiceTests
    {
        [Fact]
        public async Task CreateEventInPastNotAllowed()
        {
            Mock<IEventRepository> mock = new();

            EventService service = new EventService(mock.Object);

            EventCreationDTO dto = new EventCreationDTO
            {
                Name = "Gaming fest 2019",
                AdditionalInfo = "Best gaming fest in estonia",
                Date = DateTime.UtcNow.AddYears(-7),
                Location = "Haapsalu"
            };

            bool result = await service.AddEvent(dto, CancellationToken.None);

            Assert.False(result);

            mock.Verify
                (
                    r => r.AddEvent(It.IsAny<Event>(), It.IsAny<CancellationToken>()),
                    Times.Never
                );
        }

        [Fact]
        public async Task CreateEventInFuture()
        {
            Mock<IEventRepository> mock = new();

            mock.Setup(r => r.AddEvent(It.IsAny<Event>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);

            EventService service = new(mock.Object);

            EventCreationDTO dto = new()
            {
                Name = "Gaming fest 2027",
                AdditionalInfo = "Best gaming fest in estonia",
                Date = DateTime.UtcNow.AddYears(1),
                Location = "Haapsalu"
            };

            bool result = await service.AddEvent(dto, CancellationToken.None);

            Assert.True(result);

            mock.Verify
                (
                    r => r.AddEvent(It.IsAny<Event>(), It.IsAny<CancellationToken>()),
                    Times.Once
                );
        }

        [Fact]
        public async Task RegisterInPastEventNotAllowed()
        {
            Mock<IEventRepository> mock = new();

            EventService service = new(mock.Object);

            Guid eventId = Guid.NewGuid();

            Event ev = new
            (
                eventId,
                "GrandFantasia gaming fest",
                "Tartu aardla 9a",
                DateTime.UtcNow.AddYears(-1),
                "Bring your own computer"
            );

            mock.Setup(r => r.GetEventByID(eventId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ev);

            bool result = await service.RegisterParticipant(eventId, Guid.NewGuid(), CancellationToken.None);

            Assert.False(result);

            mock.Verify
                (
                    r => r.AddEvent(It.IsAny<Event>(), It.IsAny<CancellationToken>()),
                    Times.Never
                );

            mock.Verify
                (
                    r => r.GetEventByID(It.IsAny<Guid>(), It.IsAny<CancellationToken>()),
                    Times.Once
                );
        }

        [Fact]
        public async Task UnRegisterInPastEventNotAllowed()
        {
            Mock<IEventRepository> mock = new();

            EventService service = new(mock.Object);

            Guid eventId = Guid.NewGuid();

            Event ev = new
            (
                eventId,
                "GrandFantasia gaming fest",
                "Tartu aardla 9a",
                DateTime.UtcNow.AddYears(-1),
                "Bring your own computer"
            );

            mock.Setup(r => r.GetEventByID(eventId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ev);

            bool result = await service.UnRegisterParticipant(eventId, Guid.NewGuid(), CancellationToken.None);

            Assert.False(result);

            mock.Verify
                (
                    r => r.AddEvent(It.IsAny<Event>(), It.IsAny<CancellationToken>()),
                    Times.Never
                );

            mock.Verify
                (
                    r => r.GetEventByID(It.IsAny<Guid>(), It.IsAny<CancellationToken>()),
                    Times.Once
                );
        }
    }
}
