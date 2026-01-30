using RIKTrialSharedModels.Domain.Validation;

namespace RikTrialServerTests.DomainTests
{
    public class IdCodeValidationTests
    {
        [Fact]
        public void ValidIdCodeChecksum()
        {
            string id = "39501234214";

            bool result = IdCodeValidation.ValidEstonianId(id);

            Assert.True(result);
        }

        [Fact]
        public void InvalidIdCodeChecksum()
        {
            string id = "39501234210";

            bool result = IdCodeValidation.ValidEstonianId(id);

            Assert.False(result);
        }

        [Fact]
        public void InvalidIdCodeLength()
        {
            string id = "39501234210";

            bool result = IdCodeValidation.ValidEstonianId(id);

            Assert.False(result);
        }

    }
}
