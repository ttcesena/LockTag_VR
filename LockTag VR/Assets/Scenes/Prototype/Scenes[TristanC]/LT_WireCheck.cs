using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
namespace LockTag
{

    public class LT_WireCheck : MonoBehaviour
    {
        //checks if the gameobject is the correct type in the drop zone
        private void OnTriggerEnter(Collider other)
        {
            try
            {
                LT_WireSnapDropZone snapZone = transform.parent.gameObject.GetComponent<LT_WireSnapDropZone>();
                LT_Wire wire = other.gameObject.GetComponent<LT_Wire>();

                snapZone.InitialiseHighlightColor(wire.wireColor);

            }
            catch { }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}