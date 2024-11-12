using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject ObjectToDrag;
    public GameObject ObjectDragToPos;

    public float Dropdistance;
    public bool isLocked;


    Vector2 objectInitPos;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = ObjectToDrag.transform.position;
    }

    public void DragObject(){
        if(!isLocked){
            ObjectToDrag.transform.position =Input.mousePosition;
        }
    }
    public void DropObject(){
        float Distance = Vector3.Distance(ObjectToDrag.transform.position, ObjectDragToPos.transform.position);
        if(Distance<Dropdistance){
            isLocked=true;
            ObjectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
        else {
            ObjectToDrag.transform.position= objectInitPos;
        }
    }
}
