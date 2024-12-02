using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyFreddy : MonoBehaviour
{
    public GameObject toyFreddy; // Toy Freddy's placeholder (white box)
    public bool isSpazzingOut = false; // To check if he's spazzing out
    public float spazzOutDuration = 2f; // Duration before jumpscare if mask isn't put on
    private float spazzOutTimer = 0f; // Timer for the spazzing effect
    public int spazzOutCounter = 0; // Counter to track how long Toy Freddy has been spazzing out
    private bool jumpscareTriggered = false; // Flag to check if jumpscare was triggered

    // Reference to the MaskManager
    public MaskManager maskManager;

    void Update()
    {
        // If Toy Freddy is spazzing out, we change the color
        if (isSpazzingOut)
        {
            spazzOutTimer += Time.deltaTime;

            // Shaking effect (change color rapidly)
            float lerpValue = Mathf.PingPong(Time.time * 10f, 1f); // Makes the color switch fast
            toyFreddy.GetComponent<SpriteRenderer>().color = new Color(lerpValue, lerpValue, lerpValue); // White and black effect

            // Increase the counter and check for jumpscare
            spazzOutCounter += 1;

            // If counter reaches the spazzOutDuration and no mask has been put on, trigger jumpscare
            if (spazzOutCounter > spazzOutDuration && !maskManager.maskOn && !jumpscareTriggered)
            {
                TriggerJumpscare();
            }
        }
    }

    // Call this function when Toy Freddy is triggered to spaz out
    public void TriggerSpazzOut()
    {
        isSpazzingOut = true;

        // Reset counter when Toy Freddy starts to spazz out
        spazzOutCounter = 0;

        // Trigger the mask mechanic (make sure the mask is put on when he spazzes out)
        if (maskManager != null)
        {
            maskManager.PutOnMask(); // Automatically put the mask on (in case Toy Freddy starts spazzing out immediately)
        }
    }

    // Function to trigger the jumpscare
    void TriggerJumpscare()
    {
        jumpscareTriggered = true;

        // Make Toy Freddy's box shake (you can add a shaking animation here)
        toyFreddy.GetComponent<SpriteRenderer>().color = Color.red; // Change to red for jumpscare effect

        // Optionally play a jumpscare sound here
        // AudioSource.PlayClipAtPoint(jumpscareSound, transform.position);

        // Wait for a short duration (to simulate jumpscare effect) and reset
        Invoke("ResetAfterJumpscare", 1f); // Reset after 1 second
    }

    // Function to reset after jumpscare
    void ResetAfterJumpscare()
    {
        jumpscareTriggered = false;
        toyFreddy.GetComponent<SpriteRenderer>().color = Color.white; // Reset to white after jumpscare
        isSpazzingOut = false; // Stop spazzing out
    }
}
