using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_part2
{
    public class PasswordComplexityException : Exception
    {
        public PasswordComplexityException()
            : base("Password must be at least 8 characters long.") { }

        public PasswordComplexityException(string message)
            : base(message) { }
    }
}
