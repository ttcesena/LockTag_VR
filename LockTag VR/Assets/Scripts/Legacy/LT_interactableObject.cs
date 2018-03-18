using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LT_interactableObject : VRTK_InteractableObject {
    public float timetoreturn = 5;

    [Header("PS Type")]
    public ParticleSystem poof;


    new Renderer renderer;
    new Transform transform;
    Vector3 startposition;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        startposition = transform.position;
        renderer = GetComponent<Renderer>();
    }
    public override void OnInteractableObjectGrabbed( InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectGrabbed(e);

        StopCoroutine(WaitandReturn(timetoreturn));
    }

    public override void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUngrabbed(e);
        poof.gameObject.SetActive(true);
        StartCoroutine(WaitandReturn(timetoreturn));
       // StartCoroutine(TurnPoofOff());
        Debug.Log("is working");
   
        
        
    }
    IEnumerator WaitandReturn(float second)
    {
        yield return new WaitForSeconds(second);
       
        transform.position = startposition;
    }

   /* IEnumerator TurnPoofOff()
    {
        yield return new WaitForSeconds(3f);
        poof.gameObject.SetActive(false);
    }*/
}
