using System;
using Mod2HW5.Exceptions;
using Mod2HW5.Interfaces;

namespace Mod2HW5.Services
{
    public class ActionService : IActions
    {
        private readonly ILogger _logger;

        public ActionService(ILogger logger)
        {
            _logger = logger;
        }

        public bool Method_1()
        {
            _logger.LogInfo("Start method: Method_1()");
            return true;
        }

        public bool Method_2()
        {
            throw new BusinessException("Skiped logic in method");
        }

        public bool Method_3()
        {
            throw new Exception("I Broke my logic");
        }
    }
}
