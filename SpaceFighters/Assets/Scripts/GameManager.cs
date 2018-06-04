using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.KeypadEnter))
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("PreBattle");
            foreach (GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }
        }
    }
}
