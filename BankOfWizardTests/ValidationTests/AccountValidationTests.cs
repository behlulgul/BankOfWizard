
using BankOfWizard.Domain.Accounts;
using BankOfWizard.Domain.BusinessRulesMesages;
using System;
using Xunit;

namespace BankOfWizard.Tests.ValidationTests
{
    public class AccountValidationTests
    {
      

        [Fact]
        public void CreateNewAccount_WithNullId_ThrowsError()
        {
            //Arrange
            var id = Guid.Empty;
            var customerId = Guid.NewGuid();
            var description = "TestAccount";
            var totalMoneyAmount = 350;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, totalMoneyAmount));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.AccountIdNoNull);

        }




        [Fact]
        public void CreateNewAccount_WithNullDescription_ThrowsError()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();
            string description = null;
            decimal totalMoneyAmount = 100;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, totalMoneyAmount));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.DescriptionNoNull);
        }

        [Fact]
        public void CreateNewAccount_WithNullCustomerId_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            var customerId = Guid.Empty;
            string description = "TestAccount";
            decimal totalMoneyAmount = 355;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, totalMoneyAmount));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.AccountIdNoNull);
        }



        [Fact]
        public void CreateNewAccount_GivenCorrectValues_CreatesCorrectDomain()
        {
            //Arrange
            var id = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var info = "TestAccount";
            var totalMoneyAmount = 400;

            //Act
            var account = Account.Create(id, customerId, info, totalMoneyAmount);

            //Assert
            Assert.Equal(account.Id, id);
            Assert.Equal(account.CustomerId, customerId);
            Assert.Equal(account.Info, info);
            Assert.Equal(account.TotalMoneyAmount, totalMoneyAmount);

        }

    }
}
