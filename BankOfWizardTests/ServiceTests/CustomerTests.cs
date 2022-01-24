using AutoMapper;
using BankOfWizard.App.CustomerServices;
using BankOfWizard.App.CustomerServices.Dto;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Customers;
using BankOfWizard.Domain.BusinessRulesMesages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankOfWizard.Tests.ServiceTests
{
    public class CustomerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CustomerService _customerService;
        public CustomerTests()
        {

            var customerMockRepo = new Mock<ICustomerRepository>();
            var AccountMockRepo = new Mock<IAccountRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _mockUnitOfWork.Setup(x => x.AccountRepository).Returns(AccountMockRepo.Object);
            _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(customerMockRepo.Object);

            var mockAutoMapper = new Mock<IMapper>();

            _customerService = new CustomerService(_mockUnitOfWork.Object, mockAutoMapper.Object);
        }

        [Fact]
        public async void CreateNewCustomer_WithValidParameters_ReturnCorrectDomain()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByCustomerNumber(It.IsAny<string>())).Returns(false);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.CreateNewCustomer(It.IsAny<Customer>())).Returns(Task.FromResult(Guid.NewGuid()));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var actualCustomerId = await _customerService.CreateNewCustomer(new CreateCustomerDto
            {
                Name = "testName",
                Surname = "testSurname",
                PhoneNumber = "515123",
                County = "test",
                City = "testCity",
                CustomerNumber = "4444"
            });

            //Assert
            Assert.NotEqual(Guid.Empty, actualCustomerId);

        }

        [Fact]
        public async void CreateNewCustomer_WithFailCreated_ReturnsException()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByCustomerNumber(It.IsAny<string>())).Returns(false);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(default));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.CreateNewCustomer(new CreateCustomerDto
            {
                Name = "testName",
                Surname = "testSurname",
                PhoneNumber = "4124",
                County = "Adapazarı",
                City = "Sakarya",
                CustomerNumber = "5454"
            }));

            //Assert
            Assert.NotEqual(exception.Message, ErrorMessages.CustomerAlreadyExist);
        }


        [Fact]
        public async void CreateNewCustomer_WithNullParameters_ReturnsException()
        {

            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByCustomerNumber(It.IsAny<string>())).Returns(true);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.CreateNewCustomer(It.IsAny<Customer>())).Returns(Task.FromResult(Guid.NewGuid()));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.CreateNewCustomer(null));



            //Assert
            Assert.Equal(exception.Message, ErrorMessages.NullParemeter);
        }
    }
}
