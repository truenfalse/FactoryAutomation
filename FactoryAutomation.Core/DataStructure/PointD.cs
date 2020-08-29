using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace FactoryAutomation.DataStructure
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public struct PointD
    {
        [DisplayName("X")]
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
        [DisplayName("Y")]
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
        public PointD(double _X,double _Y)
        {
            m_X = _X;
            m_Y = _Y;
        }
        public static explicit operator Point(PointD _P1)
        {
            return new Point((int)_P1.X, (int)_P1.Y);
        }
        public static explicit operator PointF(PointD _P1)
        {
            return new PointF((float)_P1.X, (float)_P1.Y);
        }
        public static implicit operator PointD(Point _P1)
        {
            return new PointD((int)_P1.X, (int)_P1.Y);
        }
        public static implicit operator PointD(PointF _P1)
        {
            return new PointD((float)_P1.X, (float)_P1.Y);
        }
        public static implicit operator XY(PointD _P1)
        {
            return new XY(_P1.X, _P1.Y);
        }
        public static bool operator ==(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X == _P2.X && _P1.Y == _P2.Y)
                result = true;
            return result;
        }
        public static bool operator <=(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X <= _P2.X && _P1.Y <= _P2.Y)
                result = true;
            return result;
        }
        public static bool operator >=(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X >= _P2.X && _P1.Y >= _P2.Y)
                result = true;
            return result;
        }
        public static bool operator <(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X < _P2.X && _P1.Y < _P2.Y)
                result = true;
            return result;
        }
        public static bool operator >(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X > _P2.X && _P1.Y > _P2.Y)
                result = true;
            return result;
        }
        public static bool operator !=(PointD _P1, PointD _P2)
        {
            bool result = false;
            if (_P1.X != _P2.X || _P1.Y != _P2.Y)
                result = true;
            return result;
        }
        public static PointD operator +(PointD _P1, PointD _P2)
        {
            PointD p = new PointD(_P1.X + _P2.X, _P1.Y + _P2.Y);
            return p;
        }
        public static PointD operator -(PointD _P1, PointD _P2)
        {
            PointD p = new PointD(_P1.X - _P2.X, _P1.Y - _P2.Y);
            return p;
        }
        public static PointD operator +(PointD _P1, double Value)
        {
            return new PointD(_P1.X + Value, _P1.Y + Value);
        }
        public static PointD operator -(PointD _P1, double Value)
        {
            return new PointD(_P1.X - Value, _P1.Y - Value);
        }
        public static PointD operator /(PointD _P1, double Value)
        {
            if (Value == 0)
                return new PointD(double.PositiveInfinity, double.PositiveInfinity);
            return new PointD(_P1.X / Value, _P1.Y / Value);
        }
        public static PointD operator *(PointD _P1, double Value)
        {
            return new PointD(_P1.X * Value, _P1.Y * Value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(X);
            sb.Append(',');
            sb.Append(Y);
            return sb.ToString();
        }
        public static PointD Parse(string PointDToString)
        {
            string[] SplitString = PointDToString.Split(',');
            double X = double.Parse(SplitString[0]);
            double Y = double.Parse(SplitString[1]);
            return new PointD(X, Y);
        }
    }
}
