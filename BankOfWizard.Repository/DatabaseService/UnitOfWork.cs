using BankOfWizard.App.Interfaces;


namespace BankOfWizard.Repository.DatabaseService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public IAccountRepository AccountRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
      
        public UnitOfWork(IAccountRepository accountRepository,
                          ICustomerRepository customerRepository,
                          ITransactionRepository transactionRepository,
                          ApplicationDbContext context)
        {
                     
            AccountRepository = accountRepository;
            CustomerRepository = customerRepository;
            TransactionRepository = transactionRepository;
            _context = context;
        }
  
        public void Complete()
        {           
            _context.SaveChanges();
        }

        public void Dipsose()
        {
            _context.Dispose();
        }
    }
}
