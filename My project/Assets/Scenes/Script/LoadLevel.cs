using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoadLevel;

    void Start()
    {

    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("YeaDeDaDo");
       if(other.gameObject.name == "Player")
        {
            LoadScene();
        }

    }
    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
