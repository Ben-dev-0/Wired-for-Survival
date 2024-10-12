using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{
    [SerializeField] public UnityEvent onButton;
    [SerializeField] public UnityEvent<int> onNumber;

    void Start() {
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onButton.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            onNumber.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            onNumber.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            onNumber.Invoke(2);
        }
    }
}