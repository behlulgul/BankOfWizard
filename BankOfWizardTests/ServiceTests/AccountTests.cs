using AutoMapper;
using BankOfWizard.App.AccountServices;
using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Accounts;
using BankOfWizard.Domain.Customers;
using BankOfWizard.Domain.BusinessRulesMesages;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BankOfWizard.Tests.ServiceTests
{
    public class AccountTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMediator> _mediatoR;
        private readonly IAccountService _accountService;
        public AccountTests()
        {

            _mediatoR = new Mock<IMediator>();

            var customerMockRepo = new Mock<ICustomerRepository>();
            var AccountMockRepo = new Mock<IAccountRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(customerMockRepo.Object);
            _mockUnitOfWork.Setup(x => x.AccountRepository).Returns(AccountMockRepo.Object);

            var mockAutoMapper = new Mock<IMapper>();
            _accountService = new AccountService(_mockUnitOfWork.Object, _mediatoR.Object, mockAutoMapper.Object);

        }




        [Fact]
        public async void CreateNewAccount_WithNullParameters_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateNewAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.CreateNewAccount(null));


            //Assert
            Assert.Equal(exception.Message, ErrorMessages.NullParemeter);
        }

        [Fact]
        public async void CreateNewAccount_WithValidParameters_ReturnCorrectRecord()
        {
            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateNewAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var CustomerId = await _accountService.CreateNewAccount(new CreateAccountDto
            {
                CustomerId = Guid.NewGuid(),
                Info = "Test1",
                TotalMoneyAmount = 250
            });

            //Assert
            Assert.Equal(expectedGuid, CustomerId);

        }

        [Fact]
        public async void CreateNewAccount_WithWrongInsert_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateNewAccount(It.IsAny<Account>())).Returns(Task.FromResult(Guid.Empty));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.CreateNewAccount(new CreateAccountDto
            {
                CustomerId = Guid.NewGuid(),
                Info = "Test3",
                TotalMoneyAmount = 350
            }));


            //Assert
            Assert.Equal(exception.Message, ErrorMessages.AccountCouldNotCreated);

        }

        [Fact]
        public async void CreateNewAccount_WithInvalidCustomer_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();

            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(null));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateNewAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.CreateNewAccount(new CreateAccountDto
            {
                CustomerId = Guid.NewGuid(),
                Info = "Test2",
                TotalMoneyAmount = 250
            }));


            //Assert
            Assert.Equal(exception.Message, ErrorMessages.CustomerNotFound);

        }

    }
}

