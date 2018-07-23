using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakDetectionGit
{
    public class peakdetect
    {
        public List<int> MaxpeaksIdx { get; set; }
        public List<int> MinpeaksIdx { get; set; }

        public void FindLocalMinimaAndMaxima(List<double> values)
        {
            MaxpeaksIdx = new List<int>();
            MinpeaksIdx = new List<int>();
            double mn = double.PositiveInfinity;
            double mx = double.NegativeInfinity;
            int mnpos = 0;
            int mxpos = 0;
            double thisval;
            double m_delta = 0.01d;
            bool lookformax = false;
            for (int i = 1; i < values.Count - 20; i++)
            {
                thisval = values[i];

                if (thisval > mx)
                {
                    mx = thisval;
                    mxpos = i;
                }
                if (thisval < mn)
                {
                    mn = thisval;
                    mnpos = i;
                }

                if (lookformax)
                {
                    var range = values.GetRange(i + 1, 20);
                    if (thisval > range.Max() & thisval < mx - m_delta)
                    {
                        mn = thisval;
                        mnpos = i;
                        MaxpeaksIdx.Add(mxpos);
                        lookformax = false;
                    }
                }
                else
                {
                    var range = values.GetRange(i + 1, 20);
                    if (thisval < range.Min() & thisval > mn + m_delta)
                    {
                        mx = thisval;
                        mxpos = i;
                        MinpeaksIdx.Add(mnpos);
                        lookformax = true;
                    }
                }
            }
        }
    }
}
