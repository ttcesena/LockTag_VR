using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class ARManager : MonoBehaviour
    {
        #region Variables

        static protected ARManager _instance;
        static public ARManager Instance { get { return _instance; } }

        private bool isOn = false;

        #endregion

        #region Functions

        #region Unity Functions

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning(this.GetType().Name+" is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            { _instance = this; }
        }

        #endregion

        #region Public Functions

        public void Power(bool onOff)
        {
            isOn = onOff;
            OnPower(isOn);
        }

        #endregion

        #region Private Functions

        private void OnPower(bool onOff)
        {
            if (onOff)
            {
                // turn on sequence
            }
            else
            {
                // turn off sequence
            }
        }

        #endregion
  
        #endregion
    }
}
