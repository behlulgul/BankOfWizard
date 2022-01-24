using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Transactions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfWizard.App.TransactionEvents
{
    public class TransactionOccuredHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionOccuredHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
        {

            _unitOfWork.TransactionRepository.AddMoneyTransaction(new BankingTransaction
                (notification.AccountId,
                 notification.AmountOfMoney,
                 notification.TotalMoneyAmount,
                 notification.TranType,
                 DateTime.Now,
                 notification.Info));
            _unitOfWork.Complete();
            return Task.CompletedTask;
        }


    }
}
