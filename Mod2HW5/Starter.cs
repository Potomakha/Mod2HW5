using System;
using Mod2HW5.Exceptions;
using Mod2HW5.Interfaces;

namespace Mod2HW5
{
    public class Starter
    {
        private readonly ILogger _logger;
        private readonly IActions _actions;

        public Starter(ILogger logger, IActions actions)
        {
            _logger = logger;
            _actions = actions;
        }

        public void Run()
        {
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    switch (random.Next(3))
                    {
                        case 0:
                            _actions.Method_1();
                            break;
                        case 1:
                            _actions.Method_2();
                            break;
                        case 2:
                            _actions.Method_3();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _logger.LogWarning($"Action got this custom exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Action failed by a reason: {ex}");
                }
            }
        }
    }
}
