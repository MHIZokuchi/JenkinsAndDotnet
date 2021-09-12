using Asp.netCoreMVCCRUD;
using Asp.netCoreMVCCRUD.Controllers;
using Asp.netCoreMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Asp.netCoreMVCCRUD.Tests;

namespace XUnitTestProject1
{
    public class UnitTest1 
    {
    
        [Fact]
        public void Test1()
        {
            var testMethod = new TestService();

            var result = testMethod.GetNamesExceptJohn();

            Assert.NotNull(result);
        }
    }
}
    