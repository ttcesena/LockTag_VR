using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class WireMinigame_Handler : MonoBehaviour {
        static protected WireMinigame_Handler instance;
        static public WireMinigame_Handler Instance { get { return instance; } }
        public enum WireColor
        {
            Null = -1,
            Green = 0,
            Blue = 1,
            Yellow = 2
        }
        [Serializable]

        public struct Wires
        {
            public WireColor CorrectWireColor;

            public WireColor WrongWireColor1;
            public WireColor WrongWireColor2;

            public Material material;
        }
        public Wires[] wireTypes;

        public WireColor wire1;
        public WireColor wire2;
        public WireColor wire3;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning(this.GetType().Name + " is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            { instance = this; }
        }
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
