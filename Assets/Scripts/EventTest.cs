using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{
    [SerializeField] public UnityEvent onButton;

    void Start() {
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onButton.Invoke();
        }
    }
}