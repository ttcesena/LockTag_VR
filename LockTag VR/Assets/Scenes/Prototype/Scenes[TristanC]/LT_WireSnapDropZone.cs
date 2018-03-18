using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;
namespace LockTag
{
    public class LT_WireSnapDropZone : VRTK_SnapDropZone
    {
        Material[]  wireMaterial;
        public WireMinigame_Handler.WireColor correctWireColor;
        new Renderer renderer;
        bool colorCheck; 

        //if the wire snapped to the zone is correct, then it no longer becomes interactable
        public override void OnObjectSnappedToDropZone(SnapDropZoneEventArgs e)
        {
            
            base.OnObjectSnappedToDropZone(e);
           Debug.Log(currentSnappedObject);
            if(colorCheck)
                currentSnappedObject.GetComponent<LT_Wire>().isGrabbable = false;
            //WireMaterial = GetComponent<Renderer>().materials;

        }

        /*public override void OnObjectEnteredSnapDropZone(SnapDropZoneEventArgs e)
        {
           // highlightColor = Color.magenta;
            base.OnObjectEnteredSnapDropZone(e);
            //Debug.Log("actually did this");
           

        }*/

       
            //if the wire is correct the zone highlights green, incorrect highlihts red
        public void InitialiseHighlightColor(WireMinigame_Handler.WireColor wireColor)
        {
            if(correctWireColor == wireColor)
            {
                colorCheck = true;
                highlightColor = Color.green;
                InitialiseHighlighter();
            }
            else {
                colorCheck = false;
                highlightColor = Color.red;
                InitialiseHighlighter();
            }
        }
    }
}
