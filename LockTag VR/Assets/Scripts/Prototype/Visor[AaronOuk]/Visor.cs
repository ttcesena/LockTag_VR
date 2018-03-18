using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace LockTag
{
	public class Visor : VRTK_InteractableObject {

        public VisorSnapDropZone visorSnapDropZone;
        [HideInInspector]
        public bool equipped = false;

        public override void OnInteractableObjectEnteredSnapDropZone(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectEnteredSnapDropZone(e);
            TurnOff();
            equipped = true;
            visorSnapDropZone.SetActiveHighlightContainer(false);
        }

        public void TurnOff()
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }

        // Use this for initialization
        void Start () {

		}

		// Update is called once per frame
		void Update () {
			if (snappedInSnapDropZone == true) {
                Debug.Log("Snapped");
				gameObject.SetActive (false);
			}
		}
	}
}