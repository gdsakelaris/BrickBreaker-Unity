using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheatManager : MonoBehaviour
{
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("WinScene");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Start");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Instructions");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
