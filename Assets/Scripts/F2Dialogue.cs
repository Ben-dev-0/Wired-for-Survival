using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Dialogue : MonoBehaviour
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
                case "F2-1":
                    /* Entering Level*/
                    break;
                case "F2-2":
                    /* Engine Room*/
                    break;
                case "F2-3":
                    /* Lore Note*/
                    break;
                case "F2-4":
                    /* Stun Gun*/
                    break;
                case "F2-5":
                    /* Next Level*/
                    break;
                default:
                    
                    break;
            }
        }
    }
}