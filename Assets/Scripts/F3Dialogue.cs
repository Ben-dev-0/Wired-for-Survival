using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string spriteName = gameObject.name;

            switch (spriteName)
            {
                case "F3-1":
                    /* Life Support*/
                    break;
                case "F3-2":
                    /* Life Support End*/
                    break;
                case "F3-3":
                    /* Escape Pods*/
                    break;
                case "F3-4":
                    /* Note*/
                    break;
                case "F3-5":
                    /* Next Level*/
                    break;
                default:
                    
                    break;
            }
        }
    }
}
