using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBalance : MonoBehaviour
{
    void Awake()
    {
        int numSceneBalance = FindObjectsOfType<SceneBalance>().Length;
        if (numSceneBalance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetSceneBalance()
    {
        Destroy(gameObject);
    }

}
