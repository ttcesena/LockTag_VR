using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class GameMaster : MonoBehaviour
    {
        public bool _DEBUG = false;

        static protected GameMaster _instance;
        static public GameMaster Instance { get { return _instance; } }

        public string _TEST_STRING = "Hello world!";
        public float _TEST_FLOAT = 4.20f;
        public Color _TEST_COLOR = Color.green;
        public Material _TEST_MATERIAL;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("Game Manager is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            { _instance = this; }
        }
    }
}
