
using BankOfWizard.Domain.Customers;
using BankOfWizard.Domain.BusinessRulesMesages;
using System;
using Xunit;

namespace BankOfWizard.Tests.ValidationTests
{
    public class CustomerValidationTests
    {

        [Fact]
        public void CustomerDomainCreate_WithNullId_ThrowsError()
        {
            //Arrange
            var id = Guid.Empty;
            string customerNumber = "4433";
            string name = "behlul";
            string surname = "gul";
            string phoneNumber = "523123";
            string city = "Maltepe";
            string county = "Aydınevler";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, customerNumber, name, surname, phoneNumber, city, county));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.AccountIdNoNull);

        }


        [Fact]
        public void CustomerDomainCreate_WithNullName_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string customerNumber = "4433";
            string name = null;
            string surname = "gul";
            string phoneNumber = "523123";
            string city = "Maltepe";
            string county = "Aydınevler";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, customerNumber, name, surname, phoneNumber, city, county));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.NameNoNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullSurname_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string customerNumber = "4433";
            string name = "behlul";
            string surname = null;
            string phoneNumber = "523123";
            string city = "Maltepe";
            string county = "Aydınevler";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, customerNumber, name, surname, phoneNumber, city, county));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.SurnameNoNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullCity_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string customerNumber = "4433";
            string name = "behlul";
            string surname = "gul";
            string phoneNumber = "523123";
            string city = null;
            string county = "Aydınevler";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, customerNumber, name, surname, phoneNumber, city, county));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.CityNoNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullcounty_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string customerNumber = "4433";
            string name = "behlul";
            string surname = "gul";
            string phoneNumber = "523123";
            string city = "istanbul";
            string county = null;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, customerNumber, name, surname, phoneNumber, city, county));

            //Assert
            Assert.Equal(exception.Message, ErrorMessages.CountyNoNullMessage);
        }


    }
}

