using System;
using MultipleRegression.Core.Factories;
using MultipleRegression.Core.Factories.Interfaces;
using MultipleRegression.Core.Interfaces;
using MultipleRegression.Core.SolutionMethods;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class SolutionMethodFactoryTests
    {
        private ISolutionMethodFactory factory;
        
        [SetUp]
        public void TestSetup()
        {
            this.factory = new SolutionMethodFactory();
        }

        [Test]
        public void GetSolutionMethod_GaussianEliminationType_ReturnsGaussianEliminationSolutionMethod()
        {
            var methodType = SolutionMethodType.GaussianElimination;
            var expectedSolutionMethod = typeof(GaussianEliminationSolutionMethod);

            ISolutionMethod method = this.factory.GetSolutionMethod(methodType);

            Assert.IsNotNull(method);
            Assert.AreEqual(expectedSolutionMethod, method.GetType());
        }

        [Test]
        public void GetSolutionMethod_NonExistentMethodType_ThrowsNotSupportedException()
        {
            var methodType = (SolutionMethodType)421;

            Assert.Throws<NotSupportedException>(() => this.factory.GetSolutionMethod(methodType));
        }
    }
}
