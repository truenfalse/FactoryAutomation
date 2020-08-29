using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FactoryAutomation.Common
{
    [Serializable]
    public struct Bit
    {
        public static readonly Bit On = new Bit(true);
        public static readonly Bit Off = new Bit(false);
        public bool IsOn
        {
            get
            {
                return m_IsOn;
            }
        }
        public bool IsOff
        {
            get
            {
                return !m_IsOn;
            }
        }
        public bool Value
        {
            get
            {
                return m_IsOn;
            }
            set
            {
                m_IsOn = value;
            }
        }
        bool m_IsOn;
        public Bit(bool _IsTrue)
        {
            m_IsOn = _IsTrue;
        }
        public static implicit operator Bit(bool _bit)
        {
            return new Bit(_bit);
        }
        public static implicit operator Bit(int _bit)
        {
            if (_bit == 0)
                return new Bit(false);
            else
                return new Bit(true);
        }
        public static implicit operator Bit(char _bit)
        {
            if (_bit == '0')
                return new Bit(false);
            else
                return new Bit(true);
        }
        public static bool operator ==(Bit _bit1, Bit _bit2)
        {
            if(_bit1.m_IsOn == _bit2.m_IsOn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Bit _bit1, Bit _bit2)
        {
            if (_bit1.m_IsOn != _bit2.m_IsOn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator |(Bit _bit1, Bit _bit2)
        {
            return _bit1.Value | _bit2.Value;
        }
        public static bool operator &(Bit _bit1, Bit _bit2)
        {
            return _bit1.Value & _bit2.Value;
        }
        public static bool operator ^(Bit _bit1, Bit _bit2)
        {
            return _bit1.Value ^ _bit2.Value;
        }
        public static bool operator !(Bit _bit1)
        {
            return !_bit1.Value;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
