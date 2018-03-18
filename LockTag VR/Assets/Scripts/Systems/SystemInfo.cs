using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class SystemInfo : ScriptableObject
    {
        public enum EnergyType
        {
            NULL     = -1,
            ELECTRIC =  0,
            WATER    =  1,
            GAS      =  2,
            AIR      =  3
        }

        public enum PowerState
        {
            NULL    = -1,
            OFF     =  0,
            ON      =  1,
            NEUTRAL =  2
        }
    }
}
