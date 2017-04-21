using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Alea;
using Alea.Parallel;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class GPUvsCPUPerformanceTests
    {
        public int length = 10000000;

        [Test]
        public void WarmUp()
        {
            var array = new int[1000000];
            BigInteger sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += i;
            }
        }

        [GpuManaged, Test]
        public void Sum_GPUandCPU_InParallel()
        {
            var arg1 = Enumerable.Range(0, length).ToArray();
            var arg2 = Enumerable.Range(0, length).ToArray();
            var numbers = new int[length];

            var gpuTask = Task.Run(() => Gpu.Default.For(0, numbers.Length / 2, i => numbers[i] = arg1[i] + arg2[i]));

            var cpuTask = Task.Run(() => Parallel.For(numbers.Length / 2, numbers.Length, i => numbers[i] = arg1[i] + arg2[i]));

            Task.WaitAll(gpuTask, cpuTask);
            var expected = arg1.Zip(arg2, (x, y) => x + y);

            Assert.That(numbers, Is.EqualTo(expected));
        }

        [Test]
        public void Sum_CPU()
        {
            var arg1 = Enumerable.Range(0, length).ToArray();
            var arg2 = Enumerable.Range(0, length).ToArray();
            var numbers = new int[length];

            var cpuTask = Task.Run(() => Parallel.For(0, numbers.Length/2, i => numbers[i] = arg1[i] + arg2[i]));

            var cpuTask2 = Task.Run(() => Parallel.For(numbers.Length / 2, numbers.Length, i => numbers[i] = arg1[i] + arg2[i]));

            Task.WaitAll(cpuTask, cpuTask2);
            var expected = arg1.Zip(arg2, (x, y) => x + y);

            Assert.That(numbers, Is.EqualTo(expected));
        }
    }
}
