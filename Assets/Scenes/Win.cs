using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
     // Array of objects to check, populated using the Inspector.
    public GameObject[] objectsToCheck;

    // Boolean that will be true if all objects have 'rightSpot' set to true.
    public bool allCorrect = false;

    void Start()
    {
        // Load the lighting scene additively
        //SceneManager.LoadScene(Level1, LoadSceneMode.Additive);
    }

    void Update()
    {
        // Check if all objects in the array have 'rightSpot' set to true.
        allCorrect = AreAllObjectsInRightSpot();
        if(allCorrect==true){
            //EnableLighting();
            //SceneManager.LoadScene("Level1");
        }
    }

    /*public void EnableLighting()
    {
        // Find the loaded scene
        Scene selectedScene = SceneManager.GetSceneByName(Level1);
        if (selectedScene.isLoaded)
        {
            // Iterate through all root GameObjects in the lighting scene
            foreach (GameObject go in selectedScene.GetRootGameObjects())
            {
                // Find all Light components in the GameObject and its children
                Light[] lights = go.GetComponentsInChildren<Light>(true);
                foreach (Light light in lights)
                {
                    light.enabled = true; // Enable the light
                }
            }
        }
    }*/


    // Method that returns true if all objects have 'rightSpot' set to true.
    private bool AreAllObjectsInRightSpot()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            // Search all components on the GameObject for one with 'rightSpot'.
            bool hasRightSpot = TryGetRightSpot(obj, out bool isRight);

            // If no valid 'rightSpot' is found or it is false, return false.
            if (!hasRightSpot || !isRight)
            {
                return false;
            }
        }

        // If all objects passed the check, return true.
        return true;
    }

    // Try to find a component with a 'rightSpot' boolean on the GameObject.
    private bool TryGetRightSpot(GameObject obj, out bool rightSpotValue)
    {
        // Check all components attached to the GameObject.
        foreach (Component component in obj.GetComponents<Component>())
        {
            // Check if the component has a field named 'rightSpot' of type bool.
            var field = component.GetType().GetField("rightSpot");
            if (field != null && field.FieldType == typeof(bool))
            {
                rightSpotValue = (bool)field.GetValue(component);
                return true;
            }
        }

        // If no 'rightSpot' field is found, set default value and return false.
        rightSpotValue = false;
        return false;
    }
}