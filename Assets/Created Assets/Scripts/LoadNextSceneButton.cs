using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadNextSceneButton : MonoBehaviour, IPointerClickHandler
{
    public string nextSceneName; // Name of the next scene to load

    private bool isCardboardReticleSelected; // Flag to indicate if the button is selected by the CardboardReticle script

    private void Update()
    {
        // Check if the button is selected by the CardboardReticle script
        if (isCardboardReticleSelected)
        {
            // Call the custom functionality for the button
            CustomFunctionality();
            Debug.Log("Loading next scene");
            // Reset the selection flag
            isCardboardReticleSelected = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Set the selection flag when the button is clicked
        isCardboardReticleSelected = true;
    }

    public void CustomFunctionality()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}