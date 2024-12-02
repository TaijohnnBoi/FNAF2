using UnityEngine;
using UnityEngine.UI;

public class MaskManager : MonoBehaviour
{
    public GameObject mask; // The mask object
    public Button maskButton; // The UI button to put on/remove the mask
    public bool maskOn = false; // Whether the mask is on or off

    // Reference to the ToyFreddy script
    public ToyFreddy toyFreddyScript;

    void Start()
    {
        // Set the initial state (mask is off)
        mask.SetActive(false);

        // Set up the button click listener
        maskButton.onClick.AddListener(ToggleMask);
    }

    // Function to toggle the mask on and off
    void ToggleMask()
    {
        maskOn = !maskOn; // Toggle the state

        // Set the mask active/inactive based on the toggle
        mask.SetActive(maskOn);
    }

    // Function to put the mask on programmatically (in case Toy Freddy attacks)
    public void PutOnMask()
    {
        maskOn = true;
        mask.SetActive(true);

        // If Toy Freddy is spazzing out, stop the spazzing (reset it)
        if (toyFreddyScript != null && toyFreddyScript.isSpazzingOut)
        {
            toyFreddyScript.isSpazzingOut = false; // Reset the spazzing effect when the mask is put on
            toyFreddyScript.GetComponent<SpriteRenderer>().color = Color.white; // Reset color
        }
    }

    // Function to take the mask off programmatically (in case you need to remove it)
    public void TakeOffMask()
    {
        maskOn = false;
        mask.SetActive(false);
    }
}
