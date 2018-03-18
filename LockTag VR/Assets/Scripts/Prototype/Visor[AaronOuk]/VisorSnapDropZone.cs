using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace LockTag
{
    public class VisorSnapDropZone : VRTK_SnapDropZone
    {
        public override void OnObjectSnappedToDropZone(SnapDropZoneEventArgs e)
        { // doesnt work for some reason
            base.OnObjectSnappedToDropZone(e);
            highlightContainer.gameObject.SetActive(false);
            highlightObjectPrefab.gameObject.SetActive(false);
        }

        public void SetActiveHighlightContainer(bool trueFalse)
        {
            highlightContainer.gameObject.SetActive(trueFalse);
        }
    }
}
