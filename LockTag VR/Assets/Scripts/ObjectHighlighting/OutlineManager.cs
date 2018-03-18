using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LockTag
{
    public class OutlineManager : MonoBehaviour
    {
        #region Variables

       
        static protected OutlineManager _instance;

        static public OutlineManager Instance { get { return _instance; } }


        public bool refreshList;

        private string matName = "ObjectOutlineMaterial";


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

            //Load custom made material from resource file
            Material customOutLineMat = Resources.Load(matName, typeof(Material)) as Material;


        }

        private void Update()
        {
            if (refreshList)
            {
                List<GameObject> goList = new List<GameObject>();
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Highlightable");
               

                foreach (GameObject go in gos)
                {
                    //fill array with current materials on object to save, do this before changing size as this will delete original material or materials on object
                    Material[] matArray = go.GetComponent<MeshRenderer>().materials;

                    foreach (Material ma in matArray)
                    {
                        

                        if (ma.name == matName +" (Instance)")
                        {

                            goList.Add(go);
                           
                        }
                    }
                }

                string temp = "";
                foreach (GameObject go in goList)
                {
                    temp +=  "<" + go.name.ToString() + ">" + " " ; //maybe also + '\n' to put them on their own line.
                }

               print ("Highlighted Objects are: " + "\n" + temp );


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
        /// Highlight objects through inspector
        /// </summary>
        public void LiveHighlighting()
        {
            //putting highlightable Game Objects into an array 
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Highlightable");

            foreach (GameObject go in gos)
            {
                go.AddComponent<LiveHighlightingManager>();

            }

        }

        /// <summary>
        /// Hightlight all highlightable objects in scene
        /// </summary>
        /// <param name="highlight">True to highlight all or False to un-highlight all</param>
        public void OutlineAll(bool highlight)
        {
   
            //putting highlightable Game Objects into an array 
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Highlightable");
            
            foreach (GameObject go in gos)
            {

                Outline(go, highlight);
                
            }

        }

        /// <summary>
        /// Highlight an Individual Object
        /// </summary>
        /// <param name="go">object of your choosing to be highligted goes here</param>
        /// <param name="highlight">True to highlight game objec or False to un-highlight game object</param>
        public void Outline(GameObject go, bool highlight=true)
        {
            Material[] origMatArray = go.GetComponent<MeshRenderer>().materials;

            if (highlight)
            {

                if (go.transform.tag == "Highlightable")
                {




                    //Get size of objects original material array
                    int size = go.GetComponent<MeshRenderer>().materials.Length;

                    //object is found so find material array size and increment to prepare for new outline material
                    size += 1;


                    //fill array with current materials on object to save, do this before changing size as this will delete original material or materials on object
                   origMatArray = go.GetComponent<MeshRenderer>().materials;

                    //making material list to copy current Game Object materials into
                    List<Material> matList = new List<Material>();


                    //put those materials into a list
                    foreach (Material ma in origMatArray)
                    {
                        matList.Add(ma);
                    }


                    //change size of objects material array
                    go.GetComponent<MeshRenderer>().materials = new Material[size];

                    //Load custom made material from resource file
                    Material customOutLineMat = Resources.Load(matName, typeof(Material)) as Material;

                    //place custom made material into list
                    //List allow for resizing(adding) of array without knowing size
                    matList.Add(customOutLineMat);

                    //Now convert Array list into regular Array so we can put it all in
                    Material[] finalMaterials = matList.ToArray();

                    //Put it all in!
                    go.GetComponent<MeshRenderer>().materials = finalMaterials;
                }
                else
                {
                    Debug.Log(go.name + " is not tagged with \"Highlightable\"");
                }
            }
           else
            {
                if ( origMatArray[origMatArray.Length-1].name == matName +" (Instance)"  )
                {
                    Debug.Log("else");
                    Material[] newMatArray = new Material[origMatArray.Length - 1];

                    for (int i = 0; i < newMatArray.Length; ++i)
                    {

                        newMatArray[i] = origMatArray[i];

                    }

                    go.GetComponent<MeshRenderer>().materials = newMatArray;
                }
            }
        }
    }
}




