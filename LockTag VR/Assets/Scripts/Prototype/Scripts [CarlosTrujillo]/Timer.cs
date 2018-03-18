using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    
	public bool startTimer;

	[HideInInspector]
    public float t;
	[HideInInspector]
	public string min;
	[HideInInspector]
	public string sec;
    [HideInInspector]
    public string time;

    [SerializeField]
    private LockTag.InfoBoard infoBoard;

	

	void Update () 
	{

		//Timer code guts
		if (startTimer) 
		{
			//Debug.Log ("clock running");

			t += Time.deltaTime;

			min = ((int)t / 60).ToString ("0#");

			sec = (t % 60).ToString ("F2");
			if (t % 60 < 10)
				sec = "0" + sec;
            time = min + ":" + sec;
            SetTimerText(timerText, time);
		}



		//Start the timer from 0
		if (Input.GetKeyDown(KeyCode.LeftControl) && !startTimer)
		{

			startTimer = true;
            infoBoard.TurnOn();

        }

		//Stop the timer and reset to 0
		if (Input.GetKeyDown(KeyCode.Space) && startTimer)
		{

			startTimer = false;
			t = 0f;

            infoBoard.TurnOff();
        }
	}

    public void SetTimerText(Text textField, string str)
    {
        textField.text = str;
    }


}
