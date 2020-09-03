using MediatR;
using MediatR.Pipeline;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Common.Behaviors
{
    class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        //Serilog logger
        private readonly ILogger _logger = Log.Logger;
        public LoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.Information("Got new request: {@Request}", request.GetType().Name, request);
        }
    }
}
