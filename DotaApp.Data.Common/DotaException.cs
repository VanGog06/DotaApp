using System;
using System.Globalization;

namespace DotaApp.Data.Common
{
    public class DotaException : Exception
    {
        public DotaException() : base() { }

        public DotaException(string message) : base(message) { }

        public DotaException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
