namespace VRTK.Examples
{
    using UnityEngine;

    public class Menu_Object_Spawner : VRTK_InteractableObject
    {


        public enum PrimitiveTypes
        {
            Cube,
            Sphere
        }

        public PrimitiveTypes shape;
        private Color selectedColor;

        public void SetSelectedColor(Color color)
        {
            selectedColor = color;
            gameObject.GetComponent<MeshRenderer>().material.color = color;
        }

		public VRTK_BasicTeleport teleporter; //What I added

		public GameObject teleportTo; //What I added


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);

            if (shape == PrimitiveTypes.Cube)
            {
				
				teleporter.ForceTeleport(teleportTo.transform.position); //What I added

				//CreateShape(PrimitiveType.Cube, selectedColor); //Kept what was originally there just in case

            }
            
			else if (shape == PrimitiveTypes.Sphere)
            {
				teleporter.ForceTeleport(teleportTo.transform.position); //What I added

				//CreateShape(PrimitiveType.Sphere, selectedColor); //Kept what was originally there just in case
            }
            ResetMenuItems();
        }

        private void CreateShape(PrimitiveType shape, Color color)
        {
            GameObject obj = GameObject.CreatePrimitive(shape);
            obj.transform.position = transform.position;
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            obj.GetComponent<MeshRenderer>().material.color = color;
            obj.AddComponent<Rigidbody>();
        }

        private void ResetMenuItems()
        {
            foreach (Menu_Object_Spawner menuObjectSpawner in FindObjectsOfType<Menu_Object_Spawner>())
            {
                menuObjectSpawner.StopUsing();
            }
        }
			
    }

}