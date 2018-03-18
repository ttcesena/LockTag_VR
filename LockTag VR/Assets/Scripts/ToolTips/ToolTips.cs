using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace LockTag

{
	public class ToolTips : MonoBehaviour
	{

		void Start()
		{
			/*//Examples
			ToolTipsManager.Instance.AllToolTipsOn(true);//true will enable, false will disable
			ToolTipsManager.Instance.ToolTipSolo("RGripTooltip", true);//Input tag name of tooltip child (object that is child of tooltip object) , true will enable and false will disable
			*/

			//Test enabling all tool tips
			StartCoroutine(EnableAllToolTips(1f));  

			//Leave this on to disable controller tool tips on start of scene
			StartCoroutine(DisableAllToolTips(.5f));

			//Test enabling individual tool tip
			//StartCoroutine(EnableToolTipSolo(3f));

			//Test disabling individual tool tip
			//StartCoroutine(DisableToolTipSolo(7f));

		}



		private IEnumerator EnableAllToolTips(float waitTime)
		{

			yield return new WaitForSeconds(waitTime);
			ToolTipsManager.Instance.AllToolTipsOn(true);


		}

		private IEnumerator DisableAllToolTips(float waitTime)
		{

			yield return new WaitForSeconds(waitTime);
			ToolTipsManager.Instance.AllToolTipsOn(false);


		}

		private IEnumerator EnableToolTipSolo(float waitTime)
		{

			yield return new WaitForSeconds(waitTime);
			ToolTipsManager.Instance.ToolTipSolo("RGripTooltip", true);
            

		}

		private IEnumerator DisableToolTipSolo(float waitTime)
		{

			yield return new WaitForSeconds(waitTime);
			ToolTipsManager.Instance.ToolTipSolo("RGripTooltip", false);


		}

	}
}
