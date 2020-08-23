using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Microsoft.Xrm.Sdk;
using FakeXrmEasy;
using System.Reflection;

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
            Assert.IsTrue(targetEntity["acca_name"] == "TEST");
        }
    }
}
