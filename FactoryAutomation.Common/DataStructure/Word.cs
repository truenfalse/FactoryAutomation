using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAutomation.Common
{
    [Serializable]
    public struct Word
    {
        short m_Word;
        public short Value
        {
            get
            {
                return m_Word;
            }
            set
            {
                m_Word = value;
            }
        }
        public ushort UnsignedValue
        {
            get
            {
                return (ushort)m_Word;
            }
        }

        public Bit this[int Index]
        {
            get
            {
                int value = 0;
                value = m_Word >> Index;
                value = value & 0x01;
                return value;
            }
            set
            {
                if (value.IsOn == Bit.On)
                {
                    int temp = 1;
                    temp = temp << Index;
                    m_Word = (short)((int)m_Word | temp);
                }
                else
                {
                    int temp = 1;
                    temp = temp << Index;
                    temp = temp ^ 0xffff;
                    m_Word = (short)((int)m_Word & temp);
                }
            }
        }
        public Word(short _WordValue)
        {
            m_Word = _WordValue;
        }
        public Word(int _WordValue)
        {
            m_Word = (short)_WordValue;
        }
    }
}
