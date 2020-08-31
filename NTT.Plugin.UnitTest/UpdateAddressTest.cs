using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Microsoft.Xrm.Sdk;
using FakeXrmEasy;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace NTT.PlugIn.UnitTest
{
    [TestClass]
    public class UpdateAddressTest
    {
        [TestMethod]
        public void UpdateAddress()
        {
            var xrmFakeContext = new XrmFakedContext();
            xrmFakeContext.ProxyTypesAssembly = Assembly.GetExecutingAssembly();
            var guid = Guid.NewGuid();
            var targetEntity = new Entity("acca_devops") { Id = guid };

            ParameterCollection inputParameter = new ParameterCollection();
            inputParameter.Add("Target", targetEntity);

            xrmFakeContext.ExecutePluginWith<UpdateAddress.Update>(inputParameter, null, null, null);
            var accadevops = (from ad in xrmFakeContext.CreateQuery("acca_devops")
                              select ad).ToList();
            Assert.IsNotNull(accadevops);
            Assert.AreEqual(0, accadevops.Count());
            //Assert.IsTrue(accadevops["acca_name"] == "Test26");
        }
    }
}
