using Sat.Recruitment.Service.Utils;
using System;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("ReflectionHelperUnitTest", DisableParallelization = true)]
    public class ReflectionHelperUnitTest
    {

        /// <summary>
        ///   Instance valid type 
        /// </summary>
        [Fact]
        public void InstanceValidType()
        {
            Assert.IsType<TestRefection>( ReflectionHelper.GetInstance<TestRefection>("TestRefection"));

        }

        /// <summary>
        /// Instance valid type
        /// </summary>
        [Fact]
        public void InstanceInValidType()
        {
            Assert.Throws<TypeLoadException>(()=> ReflectionHelper.GetInstance<TestRefection>("PruebaMal"));

        }
    }
    /// <summary>
    /// Helper class to tester the ReflectionHelper class
    /// </summary>
    public class TestRefection { }
}
