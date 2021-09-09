using Cargo4You.Models.Entities;
using Cargo4You.Repositiories;
using Cargo4You.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cargo4You.Tests
{
    [TestFixture]
    public class ParcelChecksServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IParcelChecksRepository> mockParcelChecksRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockParcelChecksRepository = this.mockRepository.Create<IParcelChecksRepository>();

            mockParcelChecksRepository.Setup(s => s.Create(It.IsAny<ParcelChecks>())).Returns<ParcelChecks>(x => Task.FromResult(x));
        }

        private ParcelChecksService CreateService()
        {
            return new ParcelChecksService(this.mockParcelChecksRepository.Object);
        }

        [Test]
        public async Task CreateAsync_ShouldReturnParcelChecksDto()
        {
            // Arrange
            ParcelChecksService service = this.CreateService();

            CreateParcelChecksDto createParcelChecksDto = new CreateParcelChecksDto
            {
                Weight = 6,
                Height = 6,
                Depth = 6,
                Width = 6,
            };

            // Act
            ParcelChecksDto parcelChecksDto = await service.CreateAsync(createParcelChecksDto);

            // Assert
            //this.mockRepository.VerifyAll();

            Assert.IsNotNull(parcelChecksDto);

            Assert.AreEqual(createParcelChecksDto.Weight, parcelChecksDto.Weight);
            Assert.AreEqual(createParcelChecksDto.Height, parcelChecksDto.Height);
            Assert.AreEqual(createParcelChecksDto.Width, parcelChecksDto.Width);
            Assert.AreEqual(createParcelChecksDto.Depth, parcelChecksDto.Depth);
        }
    }
}
