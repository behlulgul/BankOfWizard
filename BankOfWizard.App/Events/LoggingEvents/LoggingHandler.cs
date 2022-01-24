using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;


namespace BankOfWizard.App.TransactionEvents
{
    class LoggingHandler : INotificationHandler<LoggingEvent>
    {
        private readonly ILogger<LoggingHandler> _logger;

        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(LoggingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Customer  created at ");

            return Task.CompletedTask;
        }


    }
}
