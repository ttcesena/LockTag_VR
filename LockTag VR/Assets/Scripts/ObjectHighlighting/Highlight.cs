using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace LockTag

{
    public class Highlight : MonoBehaviour
    {

        void Start()
        {
            //OutlineManager.Instance.Outline(GameObject.Find("Capsule"));
            //OutlineManager.Instance.OutlineAll(true);
              OutlineManager.Instance.LiveHighlighting();
            //StartCoroutine(DisableAllOutlines(3f));
            //StartCoroutine(DisableOutline(3f));


        }



        private IEnumerator DisableAllOutlines(float waitTime)
        {

            yield return new WaitForSeconds(waitTime);
            OutlineManager.Instance.OutlineAll(false);
            

        }

        private IEnumerator DisableOutline(float waitTime)
        {

            yield return new WaitForSeconds(waitTime);
            OutlineManager.Instance.Outline(GameObject.Find("Capsule"),false);


        }

    }
}
