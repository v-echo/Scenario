using Implementation2.Db;
using System.Linq;

namespace Implementation2.Tests
{
    public static class TestExtensionMethods
    {
        /// <summary>
        /// A lightweight wrapper around the <see cref="I2Context.Divide(int, string, string)"/> user-defined function, to enable calling it directly. Workaround for the frankly stupid restriction that EF sets on scalar UDFs.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static string TestDivide(this I2Context context, int value, string first, string last) => context.GenerateIntegers(1, 2).Select(f => context.Divide(value, first, last)).First();
    }
}
