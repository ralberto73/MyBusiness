using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBusiness.DataAccess;
using System;
using Xunit;
using Xunit.Sdk;

namespace MyBusiness.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task Test1Async()
        {
            string cnn = @"Data Source=LAPTOP-60J88C7D\LOCALDB;Initial Catalog=MyBusiness;Integrated Security=True;Pooling=False";
            DataRepository da = new DataRepository(cnn);
            await da.GetAllAsync();
            Xunit.Assert.True(true);
        }
    }
}
