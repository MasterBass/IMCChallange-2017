using NUnit.Framework;

namespace IMCChallange.FirstRound
{
    public class Domino
    {
        public int solution(int[] a, int[] b)
        {
            var doubles = new int[7];

            var diffs = new int[7];

            var result = 0;

            for (var i = 0; i < a.Length; i++)
                if (a[i] == b[i])
                {
                    doubles[a[i]]++;
                }
                else
                {
                    diffs[a[i]]++;
                    diffs[b[i]]++;
                }

            for (var i = 0; i < 7; i++)
            {
                var temp = doubles[i] * 2;
                if (diffs[i] == 1)
                    temp++;
                else if (diffs[i] > 1)
                    temp = temp + 2;

                if (temp > result)
                    result = temp;
            }

            return result;
        }

        [Test]
        public void GetResutTest()
        {
            int[] a = {1, 5, 4, 5, 2};
            int[] b = {2, 5, 5, 5, 2};
            Assert.AreEqual(5, solution(a, b));
        }
    }
}