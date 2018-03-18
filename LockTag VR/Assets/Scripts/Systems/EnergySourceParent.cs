using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class EnergySourceParent : MonoBehaviour
    {
        [SerializeField] EnergySource[] childSources;

        public bool isOn;

        private void Awake()
        {
            PowerChildren(isOn);
        }

        public void PowerChildren(bool onOff)
        {
            foreach(EnergySource eS in childSources)
            {
                eS.Power(onOff);
            }
        }
    }
}
