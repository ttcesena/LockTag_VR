using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LockTag
{
    public class Machine : MonoBehaviour
    {
        [SerializeField] SystemInfo.PowerState powerState; 
        [SerializeField] EnergySource[] energySources;

        // As it stands currently; Will probably get more 
        // complex when minigames are added
        [SerializeField] bool isRepaired;

        // storedPower values are from 0 to 1;
        private Dictionary<EnergySource, float> storedEnergy;

        private void Awake()
        {
            foreach (EnergySource eS in energySources)
            {
                eS.AddMachineReference(this);
                if (eS.isOn) storedEnergy.Add(eS, 1);
            }
        }

        /// <summary>
        /// Run any action on this object.
        /// </summary>
        /// <param name="action">Any UnityAction, block inputed as ()=>{ [code here] }</param>
        public void Action(UnityAction action)
        {
            action.Invoke();
        }
    }
}
