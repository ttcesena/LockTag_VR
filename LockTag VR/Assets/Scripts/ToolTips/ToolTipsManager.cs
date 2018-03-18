using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LockTag
{
	public class ToolTipsManager : MonoBehaviour
	{
		#region Variables


		static protected ToolTipsManager _instance;

		static public ToolTipsManager Instance { get { return _instance; } }

		//Will print in conosle what too tip is on
		public bool refreshList;

		//Array for tool tips
		private GameObject[] goToolTips;


		//Array for children in tool tip objects
		private Transform[] goChildren;


        #endregion

        #region Functions

        #region Unity Functions

        private void Awake()
        {


            if (_instance != null)
            {
                Debug.LogWarning(this.GetType().Name + " is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);

            }

            goToolTips = GameObject.FindGameObjectsWithTag("Tooltip");

            

			//turns off all tool tips but not sufficient enough for controller tool tips
			AllToolTipsOn (false);

            
		}

		private void Update()
		{
			//Gives list of what tool tip is on
			if (refreshList)
			{
				List<GameObject> goList = new List<GameObject>();



				foreach (GameObject go in goToolTips)
				{
					if(go.activeSelf)
					{
							goList.Add(go);

					}
				}
			

				string temp = "";
				foreach (GameObject go in goList)
				{
					temp +=  "<" + go.name.ToString() + ">" + " " ; //maybe also + '\n' to put them on their own line.
				}

				print ("Tooltips that are on: " + "\n" + temp );


			}

			refreshList = false;
		}


		#endregion

		#region Public Functions


		#endregion

		#region Private Functions


		#endregion

		#endregion


		/// <summary>
		/// Turn on all tool tip objects in scene
		/// </summary>
		/// <param name="tip">True to turn on all or False to remove/turn off all</param>
		public void AllToolTipsOn(bool tip)
		{


			foreach (GameObject go in goToolTips)
			{
				
				ToolTip(go,tip);

			}

		}


		/// <summary>
		/// Turn tool tip on an Individual Object
		/// </summary>
		/// <param name="go">tag of object of your choosing whose tooltip will turn on goes here</param>
		/// <param name="tip">True to turn tool tip on game object or False to remove tool tip on game object</param>
		public void ToolTip( GameObject go, bool tip=true)
		{
			
			if (tip)
			{

                go.SetActive(true);
            }

			else
			{

				go.SetActive (false);

			}
		}


		public void ToolTipSolo(string s, bool tip)
		{

			if (tip)
			{


				foreach (GameObject gott in goToolTips) 
				{
                    
					goChildren = gott.GetComponentsInChildren<Transform>();


                    
					foreach (Transform tt in goChildren) 

					{
						
                        if (tt.tag == s)
                        {

                            gott.SetActive(true);
							//Debug.Log (gott.name);

                        }
                       
					}
				}
			}

			else
			{
				foreach (GameObject gott in goToolTips) 
				{

					goChildren = gott.GetComponentsInChildren<Transform>();



					foreach (Transform tt in goChildren) 

					{

						if (tt.tag == s)
						{

							gott.SetActive(false);
							//Debug.Log (gott.name);

						}

					}
				}

			}
		}
	}
}
	






