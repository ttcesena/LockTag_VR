using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class SodaGameHandler : MonoBehaviour
    {
        static protected SodaGameHandler _instance;
        static public SodaGameHandler Instance { get { return _instance; } }
        public enum SodaType
        {
            NULL = -1,
            ORANGE = 0,
            COLA = 1,
            GRAPE = 2
        }

        [Serializable]
        public struct SodaCan
        {
            public SodaType sodaType;
            public Material material;
        }

        public SodaCan[] sodaCanTypes;// = new SodaCan[Enum.GetNames(typeof(SodaType)).Length];
                                      // Use this for initialization


        public SodaType chosenType;
        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning(this.GetType().Name + " is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            { _instance = this; }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
