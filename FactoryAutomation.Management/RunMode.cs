using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Management
{
    public enum RunMode
    {
        Auto, // 자재 있음 , 물류 진행, 공정 진행
        Dry, // 자재 없이 이동만
        Logistic, // 자재 있음, 물류만 진행
    }
}
