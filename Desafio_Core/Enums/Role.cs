using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Core.Enums
{
    public enum Role
    {
        Administrator,
        Default
    }

    public static class Scope
    {
        public const string Administrator = "Administrator";
        public const string Default = "Default";
    }
}
