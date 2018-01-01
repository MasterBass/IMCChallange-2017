using System.Collections.Generic;
using NUnit.Framework;

namespace IMCChallange.FirstRound
{
    public class Candy
    {
        public int solution(int[] a, int[] b)
        {
            var golden = new HashSet<int>();
            var silver = new HashSet<int>();
            var common = new HashSet<int>();

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    golden.Remove(a[i]);
                    silver.Remove(a[i]);
                    common.Add(a[i]);
                }
                else
                {
                    if (silver.Contains(a[i]))
                    {
                        silver.Remove(a[i]);
                        common.Add(a[i]);
                    }

                    if (golden.Contains(b[i]))
                    {
                        golden.Remove(b[i]);
                        common.Add(b[i]);
                    }

                    if (!common.Contains(a[i]))
                        golden.Add(a[i]);

                    if (!common.Contains(b[i]))
                        silver.Add(b[i]);
                }

                if ((golden.Count > a.Length / 2 ? a.Length / 2 : golden.Count) +
                    (silver.Count > a.Length / 2 ? a.Length / 2 : silver.Count) +
                    common.Count >= a.Length)
                    return a.Length;
            }

            return (golden.Count > a.Length / 2 ? a.Length / 2 : golden.Count) +
                   (silver.Count > a.Length / 2 ? a.Length / 2 : silver.Count) + common.Count;
        }

        [Test]
        public void SampleTestOne()
        {
            int[] a = {1, 2, 3, 4};
            int[] b = {3, 3, 3, 7};
            Assert.AreEqual(4, solution(a, b));
        }

        [Test]
        public void SampleTestTwo()
        {
            int[] c = {2, 2, 2, 2, 2, 2};
            int[] d = {7, 4, 2, 5, 1, 2};
            Assert.AreEqual(4, solution(c, d));
        }

        [Test]
        public void CaseOneTest()
        {
            int[] c = {1, 2, 3, 4, 5, 2};
            int[] d = {6, 7, 8, 9, 1, 2};
            Assert.AreEqual(6, solution(c, d));
        }

        [Test]
        public void CaseTwoTest()
        {
            int[] c = {1, 2, 3, 5, 6, 7};
            int[] d = {1, 2, 3, 4, 6, 7};
            Assert.AreEqual(6, solution(c, d));
        }

        [Test]
        public void CaseThreeTest()
        {
            int[] c = {1, 2, 3, 4, 5, 5};
            int[] d = {1, 2, 9, 1, 2, 9};
            Assert.AreEqual(6, solution(c, d));
        }

        [Test]
        public void CaseAllDiffTest()
        {
            int[] c = {1, 2, 3, 4, 5, 6};
            int[] d = {7, 8, 9, 10, 11, 12};
            Assert.AreEqual(6, solution(c, d));
        }

        [Test]
        public void CaseAllSameTest()
        {
            int[] c = {1, 1, 1, 1, 1, 1};
            int[] d = {1, 1, 1, 1, 1, 1};
            Assert.AreEqual(1, solution(c, d));
        }

        [Test]
        public void CaseTwoDiffTest()
        {
            int[] c = {1, 2, 1, 2, 1, 2};
            int[] d = {2, 1, 2, 1, 2, 1};
            Assert.AreEqual(2, solution(c, d));
        }
    }
}