using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Dialogue : MonoBehaviour
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
                case "F4-1":
                    /* Entering Level*/
                    break;
                case "F4-2":
                    /* Communications Array*/
                    break;
                case "F4-3":
                    /* Navigation Center*/
                    break;
                default:
                    
                    break;
            }
        }
    }
}
