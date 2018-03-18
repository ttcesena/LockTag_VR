using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace LockTag
{
    public class BurstCanScript : VRTK_InteractableObject
    {





        Material[] SodaCanMaterial;
        public Material lambert3;
        Material lambert4;

        [Header("Un-Inherited Variables")]
        public ParticleSystem burst;
        // VRTK_InteractableObject grabThing;
        // public GameObject rightHand;

        public SodaGameHandler.SodaType sodaType;
        new Renderer renderer;

        // Use this for initialization
        void Start()
        {
            renderer = GetComponent<Renderer>();
            /* Ron's boched code, delete if you must
             * foreach (SodaCan soda in sodaCanTypes)
            {
                if (soda.sodaType == sodaType)
                {
                    List<Material> matArr = new List<Material>();
                    matArr.AddRange(renderer.materials);
                    Debug.Log("huh?" + matArr);
                    if (matArr.Count == 1)
                    {
                        matArr.Add(soda.material);
                        renderer.materials = matArr.ToArray();
                    }
                    else
                        renderer.materials[1] = soda.material;
                }
            }*/
            //Debug.Log("?");
            //StopBurst();
            //grabThing = GetComponent<VRTK_InteractableObject>();
        }

        public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectGrabbed(e);
            SodaCanMaterial = GetComponent<Renderer>().materials;
            //Debug.Log("got this far" + SodaCanMaterial[1]);
            if (sodaType != SodaGameHandler.Instance.chosenType)//(SodaCanMaterial[1].name == lambert3.name + " (Instance)")
            {
                //Debug.Log("actually grabbed");
                burst.gameObject.SetActive(true);
                StartCoroutine(DropFromPlayer());
            }
            else
            {
                //Debug.Log("lul no");
            }
        }
        IEnumerator DropFromPlayer()
        {
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<BurstCanScript>().isGrabbable = false;
        }

        public override void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUngrabbed(e);
            //Debug.Log("actually dropped");
            StartCoroutine(Simmer());

            //burst.gameObject.SetActive(false);
        }

        IEnumerator Simmer()
        {
            yield return new WaitForSeconds(3f);
            burst.Stop();
            yield return new WaitForSeconds(2f);
            burst.gameObject.SetActive(false);
        }

        /* void OnTriggerEnter(Collider other)
         {
             if (other.gameObject.tag == "Player")
             {
                 Debug.Log("Can Touched");
                 //StartBurst();
             }

         }

          void OnTriggerExit(Collider other)
         {
             if (other.gameObject.tag == "Player")
             {
                 Debug.Log("Can Dropped");
                 StopBurst();
             }
         }


         void StartBurst()
         {
             burst.Play();
             Debug.Log("start");
         }

         void StopBurst()
         {
             burst.Stop();
             Debug.Log("end");
         }*/

        // Update is called once per frame
        void Update()
        {

        }
    }
}
