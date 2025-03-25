using UnityEngine;

public class ArtworkInteraction : MonoBehaviour
{
    public GameObject infoPanel;  // The UI panel that will show artwork details

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player has entered the trigger area
        {
            infoPanel.SetActive(true);  // Show the panel when player is near the artwork
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player leaves the trigger area
        {
            infoPanel.SetActive(false);  // Hide the panel when player moves away
        }
    }
}
