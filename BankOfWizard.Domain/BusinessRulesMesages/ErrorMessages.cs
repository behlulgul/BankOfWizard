namespace BankOfWizard.Domain.BusinessRulesMesages
{
    public static class ErrorMessages
    {

        public static readonly string AccountIdNoNull = "Account Id field cannot be null";
        public static readonly string TotalMoneyAmountCannotNegative = "TotalMoneyAmount cannot be negative";
        public static readonly string DescriptionNoNull = "Description cannot be null";
        public static readonly string AccountTypeNoNull = "Account Type cannot be null";
        public static readonly string AccountCouldNotCreated = "Account could not be created";
        public static readonly string NotEnoughTotalMoneyAmount = "Not enough totalMoneyAmount";
        public static readonly string AmountOfMoneyCannotNegativeOrZero = "Amount of money can not be  negative or zero";


        public static readonly string NameNoNullMessage = "Name field cannot be null!";
        public static readonly string SurnameNoNullMessage = "Surname field cannot be null!";
        public static readonly string CityNoNullMessage = "City field cannot be null!";
        public static readonly string CountyNoNullMessage = "County field cannot be null!";
        public static readonly string PhoneNoNoNullMessage = "Phone field  cannot be null!";
        public static readonly string CustomerAlreadyExist = "This Customer already exists";
        public static readonly string CustomerNumberLengthIs4 = "Customer Number Length should be 4";
        public static readonly string AccountAndCustomerNotMatch = "Account and customer are not matching!";



        public static readonly string ZeroCount = "List contains zero elements";
        public static readonly string CustomerNotFound = "Customer could not be found";
        public static readonly string AccountNotFound = "Account could not be found";

        public static readonly string NullParemeter = "Parameters cannot be null!";
        public static readonly string MissingParemeter = "Parameter is missing";


    }
}
