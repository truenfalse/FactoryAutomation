using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAutomation.DataStructure
{
    [Serializable]
    public struct XYT
    {
        public double X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }
        double m_X;
        public double Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }
        double m_Y;
        public double T
        {
            get
            {
                return m_T;
            }
            set
            {
                m_T = value;
            }
        }
        double m_T;

        public XYT(double _X, double _Y, double _T)
        {
            m_X = _X;
            m_Y = _Y;
            m_T = _T;
        }
    }
}
