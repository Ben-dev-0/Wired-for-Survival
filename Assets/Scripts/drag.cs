using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public GameObject placeHolderObject; // Reference to the placeholder object
    public bool rightSpot = false;

    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        if(rightSpot==false){
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
            rightSpot = false;
        }
        
    }

    private void OnMouseUp()
    {
        dragging = false;

        // Check if the object is over the placeHolderObject
        if (placeHolderObject != null && IsOverPlaceHolder())
        {
            // Snap the draggable object to the placeholder position
            transform.position = placeHolderObject.transform.position;
        }
    }

    // This method checks if the object is over the placeholder
    private bool IsOverPlaceHolder()
    {
        // Check if the draggable object's position is close to the placeholder's position
        // You can adjust the threshold for what is considered "over" the placeholder
        float snapThreshold = 40.0f; // Customize this threshold based on your needs
        if(Vector3.Distance(transform.position, placeHolderObject.transform.position) < snapThreshold){
            rightSpot=true;
        }
       
        return Vector3.Distance(transform.position, placeHolderObject.transform.position) < snapThreshold;
        
    }
}
