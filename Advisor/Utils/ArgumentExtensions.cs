using System;

namespace Advisor.Utils
{
    public static class ArgumentExtensions
    {
        public static void RequireNotNull(this object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
        public static void RequireNotNullOrWhiteSpace(this string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}
