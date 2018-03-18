namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;

    public class Gloves : MonoBehaviour
    {
        public GameObject hand;
        public GameObject controller;
        public bool buttonTwoPressed = false;
        public GameObject handController;
        public GameObject controllerModel;

        private void Update()
        {
            var controllerEvents = GetComponent<VRTK_ControllerEvents>();
            GetComponentInParent<VRTK_InteractUse>().UseButtonPressed += new ControllerInteractionEventHandler(DoUseOn);
            if (controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress)) {
                //Do something on button 2 press
                buttonTwoPressed = true;
            }
        }

        private void SetParent(GameObject Controller)
        {
            controller = Controller;
            hand.transform.parent = Controller.transform;
        }

        private void DoUseOn(object sender, ControllerInteractionEventArgs e)
        {
            buttonTwoPressed = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (buttonTwoPressed == true && other.tag == "rightTrigger")
            {
                SetParent(controller);
                handController.SetActive(false);
                controllerModel.SetActive(false);
                hand.SetActive(false);
            }
            else if (buttonTwoPressed == true && other.tag == "leftTrigger")
            {
                SetParent(controller);
                handController.SetActive(false);
                controllerModel.SetActive(false);
                hand.SetActive(false);
            }
        }
    }
    }