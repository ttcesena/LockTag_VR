using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
 *  Please note that this script must run right after 
 *  DevPreload and so you might have to change the script 
 *  execution order to do so.
 */

namespace LockTag.Preload
{
    public class DevDebug : MonoBehaviour
    {
        [SerializeField]
        private bool debugging = false;

        private void Awake()
        {
            if (debugging)
                try {
                    GameMaster gm = GameMaster.Instance;
                    gm._DEBUG = debugging;
                    Debug.Log("Pre-load successful!");
                } catch {
                    Debug.Log("WARNING: GameMaster not found. Could not activate debugging. Trying again...");
                }
        }
    }
}
