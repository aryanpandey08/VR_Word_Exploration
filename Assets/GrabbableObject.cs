using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableObject : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;  // Reference to XRGrabInteractable
    private bool isGrabbed = false;

    private void Start()
    {
        // Ensure that XRGrabInteractable is assigned
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
        }

        // Subscribe to the selectEntered event (when the object is grabbed)
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    // This method will be called when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            ScoreManager.instance.AddScore(10); // Add 10 points to the score immediately
            Invoke("DestroyObject", 10f); // Call DestroyObject method after 10 seconds
        }
    }

    // This method will destroy the object
    private void DestroyObject()
    {
        Destroy(gameObject);  // Destroy the object after 10 seconds
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid potential memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}
