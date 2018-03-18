using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LockTag.Util
{



    //https://pastebin.com/JciBvGP2
    public static class GameObjectHelpers
    {
        public static GameObject[] FindGameObjectsWithTag(string tag, bool activesOnly = true)
        {
            if (activesOnly)
                return GameObject.FindGameObjectsWithTag(tag);
            else
            {
                List<GameObject> RetVal = new List<GameObject>();

                for (int i = SceneManager.sceneCount - 1; i >= 0; --i)
                {
                    var Scene = SceneManager.GetSceneAt(i);
                    if (Scene.isLoaded)
                        foreach (var RootGO in Scene.GetRootGameObjects())
                            foreach (var T in RootGO.GetComponentsInChildren<Transform>(true))
                                if (T.CompareTag(tag))
                                    RetVal.Add(T.gameObject);
                }
                
                return RetVal.ToArray();
            }
        }
    }
}