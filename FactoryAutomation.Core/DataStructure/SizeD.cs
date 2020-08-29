using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FactoryAutomation.DataStructure
{
    [Serializable]
    public struct SizeD
    {
        public double Width
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }
        public double Height
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }
        double m_Width;
        double m_Height;
        public SizeD(double _Width , double _Height)
        {
            m_Width = _Width;
            m_Height = _Height;
        }
    }
}
