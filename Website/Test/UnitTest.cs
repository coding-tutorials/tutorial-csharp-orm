using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void LoadCourse()
        {
            Repository.Course repositoryCourse = new Repository.Course();
            repositoryCourse.x();
        }
    }
}
