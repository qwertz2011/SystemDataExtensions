using System;
using System.Linq;
using SystemDataExtensions;

namespace UnitTest
{
    public class Dummy
    {
        [DataRowAlias("Test")]
        public string Name { get; set; }

    }
}
