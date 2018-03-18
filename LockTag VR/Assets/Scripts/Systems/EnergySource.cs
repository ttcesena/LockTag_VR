using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LockTag
{
    public class EnergySource : MonoBehaviour
    {
        public SystemInfo.EnergyType energyType;
        public bool isOn;
        public bool isLocked;

        private List<Machine> machines;

        public void Power(bool onOff)
        {
            isOn = onOff;
        }

        public void Lock(bool onOff)
        {
            isLocked = onOff;
        }

        public void AddMachineReference(Machine mach)
        {
            if (!machines.Contains(mach))
                machines.Add(mach);
        }

        private void CallActionOnMachine(Machine mach, UnityAction action)
        {
            mach.Action(action);
        }

        private void CallActionOnAllMachines(UnityAction action)
        {
            foreach(Machine mach in machines)
            {
                CallActionOnMachine(mach, action);
            }
        }
    }
}
