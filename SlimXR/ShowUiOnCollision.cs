using UnityEngine;
using UnityEngine.UI; // Add this if using UI elements like Text or Image

public class ShowUIOnCollision : MonoBehaviour
{
    public GameObject uiElement; // Assign your UI element in the Inspector

    void Start()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false); // Ensure the UI element is initially inactive
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            if (uiElement != null)
            {
                uiElement.SetActive(true); // Show the UI element
            }
        }
    }
}
