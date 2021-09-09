using Cargo4You.Models.Entities;
using Cargo4You.Repositiories;
using Cargo4You.Services;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Cargo4You.Tests
{
    [TestFixture]
    public class CouriersServiceTests
    {
        public const string Data = "[{'Id':1,'Name':'Cargo4You','Validations':[{'Id':1,'ValidationValue':20,'MeasureUnit':1,'Operator':'<=','CourierId':1},{'Id':2,'ValidationValue':2000,'MeasureUnit':0,'Operator':'<=','CourierId':1}],'Calculations':[{'Id':1,'Operator':'<=','CourierId':1,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':10,'IncrementalCost':null},{'Id':2,'Operator':'>','CourierId':1,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':20,'IncrementalCost':null},{'Id':3,'Operator':'<=','CourierId':1,'ValueLimit':2000,'MeasureUnit':0,'PredefinedCost':20,'IncrementalCost':null},{'Id':4,'Operator':'<=','CourierId':1,'ValueLimit':2,'MeasureUnit':1,'PredefinedCost':15,'IncrementalCost':null},{'Id':5,'Operator':'>','CourierId':1,'ValueLimit':2,'MeasureUnit':1,'PredefinedCost':18,'IncrementalCost':null},{'Id':6,'Operator':'<=','CourierId':1,'ValueLimit':15,'MeasureUnit':1,'PredefinedCost':18,'IncrementalCost':null},{'Id':7,'Operator':'>','CourierId':1,'ValueLimit':15,'MeasureUnit':1,'PredefinedCost':35,'IncrementalCost':null},{'Id':8,'Operator':'<=','CourierId':1,'ValueLimit':20,'MeasureUnit':1,'PredefinedCost':35,'IncrementalCost':null}]},{'Id':2,'Name':'ShipFaster','Validations':[{'Id':3,'ValidationValue':10,'MeasureUnit':1,'Operator':'>','CourierId':2},{'Id':4,'ValidationValue':30,'MeasureUnit':1,'Operator':'<=','CourierId':2},{'Id':5,'ValidationValue':1700,'MeasureUnit':0,'Operator':'<=','CourierId':2}],'Calculations':[{'Id':9,'Operator':'<=','CourierId':2,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':11.99,'IncrementalCost':null},{'Id':10,'Operator':'>','CourierId':2,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':21.99,'IncrementalCost':null},{'Id':11,'Operator':'<=','CourierId':2,'ValueLimit':1700,'MeasureUnit':0,'PredefinedCost':21.99,'IncrementalCost':null},{'Id':12,'Operator':'>','CourierId':2,'ValueLimit':10,'MeasureUnit':1,'PredefinedCost':16.5,'IncrementalCost':null},{'Id':13,'Operator':'<=','CourierId':2,'ValueLimit':15,'MeasureUnit':1,'PredefinedCost':16.5,'IncrementalCost':null},{'Id':14,'Operator':'>','CourierId':2,'ValueLimit':15,'MeasureUnit':1,'PredefinedCost':36.5,'IncrementalCost':null},{'Id':15,'Operator':'<=','CourierId':2,'ValueLimit':25,'MeasureUnit':1,'PredefinedCost':36.5,'IncrementalCost':null},{'Id':16,'Operator':'>','CourierId':2,'ValueLimit':25,'MeasureUnit':1,'PredefinedCost':40,'IncrementalCost':0.417}]},{'Id':3,'Name':'MaltaShip','Validations':[{'Id':6,'ValidationValue':10,'MeasureUnit':1,'Operator':'>=','CourierId':3},{'Id':7,'ValidationValue':500,'MeasureUnit':0,'Operator':'>=','CourierId':3}],'Calculations':[{'Id':17,'Operator':'<=','CourierId':3,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':9.5,'IncrementalCost':null},{'Id':18,'Operator':'>','CourierId':3,'ValueLimit':1000,'MeasureUnit':0,'PredefinedCost':19.5,'IncrementalCost':null},{'Id':19,'Operator':'<=','CourierId':3,'ValueLimit':2000,'MeasureUnit':0,'PredefinedCost':19.5,'IncrementalCost':null},{'Id':20,'Operator':'>','CourierId':3,'ValueLimit':2000,'MeasureUnit':0,'PredefinedCost':48.5,'IncrementalCost':null},{'Id':21,'Operator':'<=','CourierId':3,'ValueLimit':5000,'MeasureUnit':0,'PredefinedCost':48.5,'IncrementalCost':null},{'Id':22,'Operator':'>','CourierId':3,'ValueLimit':5000,'MeasureUnit':0,'PredefinedCost':147.5,'IncrementalCost':null},{'Id':23,'Operator':'>','CourierId':3,'ValueLimit':10,'MeasureUnit':1,'PredefinedCost':16.99,'IncrementalCost':null},{'Id':24,'Operator':'<=','CourierId':3,'ValueLimit':20,'MeasureUnit':1,'PredefinedCost':16.99,'IncrementalCost':null},{'Id':25,'Operator':'>','CourierId':3,'ValueLimit':20,'MeasureUnit':1,'PredefinedCost':33.99,'IncrementalCost':null},{'Id':26,'Operator':'<=','CourierId':3,'ValueLimit':30,'MeasureUnit':1,'PredefinedCost':33.99,'IncrementalCost':null},{'Id':27,'Operator':'>','CourierId':3,'ValueLimit':30,'MeasureUnit':1,'PredefinedCost':43.99,'IncrementalCost':0.41}]}]";

        private MockRepository mockRepository;

        private Mock<ICouriersRepository> mockCouriersRepository;

        [SetUp]
        public void SetUp()
        {

            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockCouriersRepository = this.mockRepository.Create<ICouriersRepository>();

            this.mockCouriersRepository.Setup(x => x.GetAll()).Returns(JsonConvert.DeserializeObject<List<Couriers>>(Data).AsQueryable());
        }

        private CouriersService CreateService()
        {
            return new CouriersService(this.mockCouriersRepository.Object);
        }

        [Test]
        public void Search_ShouldReturnCouriersCalculations()
        {
            // Arrange
            CouriersService service = this.CreateService();

            CreateParcelChecksDto createParcelChecksDto = new CreateParcelChecksDto
            {
                Weight = 5,
                Height = 5,
                Depth = 5,
                Width = 5,
            };

            // Act
            List<CouriersDto> result = service.Search(createParcelChecksDto);

            // Assert
            Assert.IsNotNull(result);

     
            Assert.AreEqual(result.FirstOrDefault().Price, 18);
         

            this.mockRepository.VerifyAll();
        }
    }
}
