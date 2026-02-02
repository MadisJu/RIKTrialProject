using Moq;
using RIKTrialServer.Domains.Models;
using RIKTrialServer.Repositories.Interfaces;
using RIKTrialServer.Services.Implementations;
using RIKTrialSharedModels.Domain.Creation;
using RIKTrialSharedModels.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace RikTrialServerTests.ServiceTests
{
    public class ParticipantServiceTests
    {
        [Fact]
        public async Task CreatePersonWithCompanyData()
        {
            Mock<IParticipantRepository> mock = new();

            ParticipantService service = new ParticipantService(mock.Object);

            ParticipantCreationDTO dto = new ParticipantCreationDTO
            {
                Type = ParticipantType.PERSON,
                PaymentMethodId = 1,
                Name = "I am actually passing company data",
                ComapnyCode = "123136767",
                AdditionalInfo = "Some cool info about me",
                ParticipantAmount = 67
            };

            Guid? result = await service.CreateParticipant(dto, CancellationToken.None);

            Assert.Null(result);

            mock.Verify
                (
                    r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()),
                    Times.Never
                );
        }

        [Fact]
        public async Task CreateCompanyWithPersonData()
        {
            Mock<IParticipantRepository> mock = new();

            ParticipantService service = new ParticipantService(mock.Object);

            ParticipantCreationDTO dto = new ParticipantCreationDTO
            {
                Type = ParticipantType.COMPANY,
                PaymentMethodId = 1,
                FirstName = "IAmPerson",
                IdNumber = "123123123",
                AdditionalInfo = "I like c#",
                LastName = "CoolPerson"
            };

            Guid? result = await service.CreateParticipant(dto, CancellationToken.None);

            Assert.Null(result);

            mock.Verify
                (
                    r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()),
                    Times.Never
                );
        }

        [Fact]
        public async Task CreateParticipantPerson()
        {
            Mock<IParticipantRepository> mock = new();

            mock.Setup(r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            ParticipantService service = new ParticipantService(mock.Object);

            ParticipantCreationDTO dto = new ParticipantCreationDTO
            {
                Type = ParticipantType.PERSON,
                PaymentMethodId = 1,
                FirstName = "Madis",
                IdNumber = "50211011514",
                AdditionalInfo = "Allergic to python",
                LastName = "Tamberg"
            };

            Guid? result = await service.CreateParticipant(dto, CancellationToken.None);

            Assert.NotNull(result);

            mock.Verify
                (
                    r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()),
                    Times.AtLeastOnce
                );
        }

        [Fact]
        public async Task CreateParticipantCompany()
        {
            Mock<IParticipantRepository> mock = new();

            mock.Setup(r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            ParticipantService service = new ParticipantService(mock.Object);

            ParticipantCreationDTO dto = new ParticipantCreationDTO
            {
                Type = ParticipantType.COMPANY,
                PaymentMethodId = 1,
                Name = "Madislolinc",
                ComapnyCode = "123456782",
                AdditionalInfo = "Best coders in town, me and my split personality",
                ParticipantAmount = 2
            };

            Guid? result = await service.CreateParticipant(dto, CancellationToken.None);

            Assert.NotNull(result);

            mock.Verify
                (
                    r => r.AddParticipant(It.IsAny<Participant>(), It.IsAny<CancellationToken>()),
                    Times.AtLeastOnce
                );
        }
    }
}
