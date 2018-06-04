using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Restart()
    {
        //Application.LoadLevel(playGameLevel);
        SceneManager.LoadScene("FightScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
