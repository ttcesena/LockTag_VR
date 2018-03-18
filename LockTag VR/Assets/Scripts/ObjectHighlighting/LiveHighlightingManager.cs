using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LockTag {

    public class LiveHighlightingManager : MonoBehaviour
    {


        private Material[] matArray;

        public bool isHighlighted;

        private bool doneOnce;

        private void Start()
        {
            //fill array with current materials on object to save, do this before changing size as this will delete original material or materials on object
            matArray = gameObject.GetComponent<MeshRenderer>().materials;
        }



        // Update is called once per frame
        void Update()
        {

            if (isHighlighted && !doneOnce)
            {

                OutlineManager.Instance.Outline(gameObject, true);
                
                doneOnce = true;

            }

            if (!isHighlighted)
            {

                gameObject.GetComponent<MeshRenderer>().materials = matArray;
                doneOnce = false;

            }

        }
    }
}



