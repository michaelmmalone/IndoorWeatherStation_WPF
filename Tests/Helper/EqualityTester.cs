using System;
using FluentAssertions;

namespace Tests.Helper
{
    internal static class EqualityTester
    {
        public static void Act<T1, T2>(T1 obj1, T2 obj2, bool expectedResult) 
        {
            Object.Equals(obj1, obj2).Should().Be(expectedResult);
        }
    }
}