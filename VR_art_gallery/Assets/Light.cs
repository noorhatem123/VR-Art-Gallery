using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabAndEnableObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;  // Object to enable when this one is grabbed.
    [SerializeField] private AudioClip grabSound;        // Sound to play when the object is grabbed.
    private AudioSource audioSource;                     // AudioSource to play the sound.
    private XRGrabInteractable grabInteractable;         // Reference to XR Grab Interactable component.

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = gameObject.AddComponent<AudioSource>();  // Add AudioSource dynamically.

        if (grabSound != null)
        {
            audioSource.clip = grabSound;
        }

        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);  // Ensure the object starts disabled.
        }

        // Subscribe to grab and release events.
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks.
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);  // Enable the target object.
            Debug.Log("Object grabbed! Target object enabled.");
        }

        if (audioSource != null && grabSound != null)
        {
            audioSource.Play();  // Play grab sound.
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);  // Optional: disable the object on release.
            Debug.Log("Object released! Target object disabled.");
        }
    }
}