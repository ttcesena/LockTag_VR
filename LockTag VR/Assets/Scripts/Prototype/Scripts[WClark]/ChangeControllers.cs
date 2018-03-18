namespace VRTK.Examples
{
    using UnityEngine;
    public class ChangeControllers : VRTK_InteractableObject
    {
        MeshRenderer glovesRendLeft;
        MeshRenderer glovesRendRight;
        MeshRenderer fakerendLeft;
        MeshRenderer fakerendRight;

        public GameObject glovesMesh;
        public GameObject gloveL;
        public GameObject gloveR;
        public GameObject handL;
        public GameObject handR;

        private void Start()
        {
            glovesRendLeft = gloveL.GetComponent<MeshRenderer>();
            glovesRendRight = gloveR.GetComponent<MeshRenderer>();

            fakerendLeft = handL.GetComponent<MeshRenderer>();
            fakerendRight = handR.GetComponent<MeshRenderer>();

            glovesRendLeft.enabled = false;
            glovesRendRight.enabled = false;

        }

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            changeControllers();
        }


        private void changeControllers()
        {
            fakerendLeft.enabled = false;
            fakerendRight.enabled = false;

            glovesRendLeft.enabled = true;
            glovesRendRight.enabled = true;
            
            glovesMesh.SetActive(false);
        }
    }
}

