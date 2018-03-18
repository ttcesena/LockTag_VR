using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LockTag
{
    public class InfoBoard : MonoBehaviour
    {
        [SerializeField] Timer timer;
        [SerializeField] Text timeText;
        [SerializeField] Text distanceText;
        [SerializeField] Text displacementText;
        [SerializeField] Text speedText;
        [SerializeField] Text velocityText;
        [SerializeField] Renderer boardRenderer;

        [System.Serializable]
        struct BoardMaterials
        {
            public Material onMaterial;
            public Material offMaterial;
        }

        [SerializeField] BoardMaterials boardMaterials;

        [SerializeField] IF_Prototype IF;

        private bool isPaused;




        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeText.text = timer.time;
        }

        public void TurnOn()
        {
            Debug.Log("On");
            boardRenderer.material = boardMaterials.onMaterial;
            IF.OnStart();
        }

        public void TurnOff()
        {
            Debug.Log("Off");
            boardRenderer.material = boardMaterials.offMaterial;
            IF.OnStop();
            IFHandler();
        }

        void IFHandler()
        {
            distanceText.text = IF.transformationDistanceMagnitude.ToString("F2");
            displacementText.text = IF.transformationDisplacementMagnitude.ToString("F2");
            speedText.text = IF.speed.ToString("F2") + " u/s";
            velocityText.text = IF.velocity.magnitude.ToString("F2") + " u/s @ " + IF.velocity.direction.ToString("F2") + "°";
        }
    }
}
