using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAutomation.DataStructure
{
    [Serializable]
    public struct XYZ
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
        public double Z
        {
            get
            {
                return m_Z;
            }
            set
            {
                m_Z = value;
            }
        }
        double m_Z;
    }
}
