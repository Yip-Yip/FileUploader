using System.Net;
using AutoMapper;
using MessageLog.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prototype.Common;
using Prototype.LogicLayer;
using Prototype.MessageObjectLibrary;
using Prototype.ModelMapper;
using Prototype.RestService;

namespace Prototype.UnitTests
{
    [TestClass]
    public class AutoMapperUnitTests
    {
        [TestMethod]
        public void AutoMapperModelMapper_Init()
        {
            var mapper = new AutoMapperModelMapper();
            Assert.IsNotNull(mapper);
        }

        [TestMethod]
        public void AutoMapRequestModels_IsValid()
        {
            Mapper.CreateMap<Request, CustomerRequest>();
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertMappedRequestModelInstance_IsValid()
        {
            const string refNum = "ABCDEFG213456";
            var domainModelRequest = new Request()
            {
                CustomerId = 123456,
                RequestId = 789456879,
                CustomerReference = refNum,
                RequestStatus = 100,
                RequestServiceType = "OrderRequest"
            };
            var dtoRequest = new CustomerRequest();

            Mapper.CreateMap<Request, CustomerRequest>();
            Mapper.Map<Request, CustomerRequest>(domainModelRequest, dtoRequest);

            Assert.IsNotNull(dtoRequest);
            Assert.AreEqual(refNum, dtoRequest.CustomerReference);

            Assert.AreEqual<string>(refNum, dtoRequest.CustomerReference, "Explicit Typing");
        }

        //[TestMethod]
        //public void MapModels_Test()
        //{
        //    IMapper mapper = new AutoMapperModelMapper();
        //    ICustomerRestService contactLL = new CustomerLL(mapper);
        //    var response = contactLL.GetCustomerRequest(234);
        //    Assert.IsInstanceOfType(response, typeof(CustomerRequest));
        //}

/*        [TestMethod]
        public void CustomerRequestControllerGet_Test()
        {
            //Arrange
            var mockModel = new CustomerRequest();
            var mockDtoResponse = new DtoResponseModel<CustomerRequest>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Model = mockModel
            };
            var mockCustomerRequestProvider = new Mock<ICustomerRequestProvider>();
            mockCustomerRequestProvider.Setup(s => s.GetRequest(It.IsAny<CustomerRequest>())).Returns(mockDtoResponse);
            var CustomerRequestController = new CustomerRequestController(mockCustomerRequestProvider.Object);

            //Act
            var resp = CustomerRequestController.Get(123);

            //Assert
            Assert.IsNotNull(resp);
            Assert.IsTrue(HttpStatusCode.OK == resp.StatusCode);
            Assert.IsInstanceOfType(resp, typeof(HttpResponseMessage));
        }

        [TestMethod]
        public void CustomerRequestProviderGet_Test()
        {
            //Arrange
            var mockModel = new CustomerRequest();
            var mockmapper = new Mock<IMapper>();
            mockmapper.Setup(s => s.Map<Request, CustomerRequest>(It.IsAny<Request>())).Returns(mockModel);
            var CustomerRequestProvider = new CustomerRequestProvider(mockmapper.Object);

            //Act
            var resp = CustomerRequestProvider.GetRequest(mockModel);

            //Assert
            Assert.IsNotNull(resp);
            Assert.IsTrue(resp.Success);
            Assert.IsTrue(resp.HttpStatusCode == HttpStatusCode.OK);
            Assert.IsInstanceOfType(resp, typeof(DtoResponseModel<CustomerRequest>));
        }
 */
    }

}
