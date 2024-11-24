using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    //[serializefield] private string scenetoload; // set the scene to load in the inspector

    //void oncollisionenter2d(collision2d other)
    //{
    //    if (other.gameobject.comparetag("player")) // check if the colliding object is the player
    //    {
    //        debug.log($"player interacted with {gameobject.name}");
    //        //scenemanager.loadscene(scenetoload); // load the specified scene
    //    }
    //}

    [SerializeField] private string sceneToLoad;           // Scene to load
    [SerializeField] private GameObject interactionPrompt; // Reference to the UI prompt (e.g., "Press E to interact")
  
    [SerializeField] private float activationDistance = 1.5f;  // Distance at which interaction is possible

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.Log("Player GameObject not found!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            //Debug.Log(distance);

            if (distance <= activationDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log($"player interacted with {gameObject.name}");
                    SceneManager.LoadSceneAsync(sceneToLoad);
                }
            }
        }
    }
}
