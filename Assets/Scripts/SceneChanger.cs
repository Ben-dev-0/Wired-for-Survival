using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            string spriteName = gameObject.name;
            if (spriteName == "LevelUp") {
                GoUp();
            } else if (spriteName == "LevelDown") {
                GoDown();
            } else {
                Debug.Log("Wrongly Named Sprite?");
            }
        }
    }

    private void GoUp()
    {
        string spriteName = gameObject.name;
        string currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("Level3");
                break;
            case "Level3":
                SceneManager.LoadScene("Level4");
                break;
            default:
                Debug.Log("No other levels.");
                break;
        }
    }

    private void GoDown()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "Level2":
                SceneManager.LoadScene("Level1");
                break;
            case "Level3":
                SceneManager.LoadScene("Level2");
                break;
            case "Level4":
                SceneManager.LoadScene("Level3");
                break;
            default:
                Debug.Log("No other levels.");
                break;
        }
    }
}
