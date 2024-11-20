using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragDrop : MonoBehaviour
{
    public GameObject ObjectDragToPos; // Target position to drag to
    public float Dropdistance;         // Allowed snapping distance
    public bool isLocked;              // Is the object locked at its position?

    private VisualElement draggableElement;  // The UI element to drag
    private Vector2 objectInitPos;           // Initial position of the object
    private VisualElement rootVisualElement; // Root of the UI hierarchy

    void Start()
    {
        // Ensure UIDocument is attached to this GameObject
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument component not found on the GameObject!");
            return;
        }

        // Get the rootVisualElement from the UIDocument
        rootVisualElement = uiDocument.rootVisualElement;
        if (rootVisualElement == null)
        {
            Debug.LogError("Root Visual Element is null. Check your UIDocument setup.");
            return;
        }

        // Find the draggable element by its name
        draggableElement = rootVisualElement.Q<VisualElement>("DraggableElement");
        if (draggableElement == null)
        {
            Debug.LogError("DraggableElement not found in the UI hierarchy. Check the element's name in the UI Builder.");
            return;
        }

        // Save the initial position
        objectInitPos = draggableElement.transform.position;

        // Register drag events
        draggableElement.RegisterCallback<PointerDownEvent>(OnPointerDown);
        draggableElement.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        draggableElement.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        // Capture pointer events to ensure smooth dragging
        draggableElement.CapturePointer(evt.pointerId);
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        if (isLocked) return;

        // Update position during dragging
        var newPosition = draggableElement.transform.position + evt.deltaPosition;
        draggableElement.style.left = newPosition.x;
        draggableElement.style.top = newPosition.y;
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        // Release the pointer capture
        draggableElement.ReleasePointer(evt.pointerId);

        // Check distance to drop position
        var targetVisualElement = rootVisualElement.Q<VisualElement>("TargetElement");
        if (targetVisualElement == null)
        {
            Debug.LogError("TargetElement not found in the UI hierarchy. Check the element's name in the UI Builder.");
            return;
        }

        var targetPosition = targetVisualElement.transform.position;
        float distance = Vector2.Distance(draggableElement.transform.position, targetPosition);

        if (distance < Dropdistance)
        {
            isLocked = true;
            draggableElement.style.left = targetPosition.x;
            draggableElement.style.top = targetPosition.y;
        }
        else
        {
            // Reset to the initial position
            draggableElement.style.left = objectInitPos.x;
            draggableElement.style.top = objectInitPos.y;
        }
    }
}
