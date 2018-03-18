using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class TableStateCheck : MonoBehaviour {

        [HideInInspector]
        public bool sodaOnTable = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!sodaOnTable && other.tag == "SodaCan")
            {
                if (other.gameObject.GetComponent<BurstCanScript>().sodaType == SodaGameHandler.Instance.chosenType)
                    sodaOnTable = true;
            }
        }
    }
}
