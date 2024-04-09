
using UnityEngine;
using UnityEngine.SceneManagement;
public class DisableCollisionOnKeyPress : MonoBehaviour
{
    private bool collisionDisabled = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.L))

        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle collision state
            collisionDisabled = !collisionDisabled;

            // If collision should be disabled, set all colliders in the scene to ignore collision with each other
            if (collisionDisabled)
            {
                // Find all colliders in the scene
                Collider[] allColliders = FindObjectsOfType<Collider>();

                // Disable collision between all colliders
                foreach (Collider collider in allColliders)
                {
                    collider.enabled = false;
                }
            }
            else // If collision should be enabled, re-enable all colliders in the scene
            {
                // Find all colliders in the scene
                Collider[] allColliders = FindObjectsOfType<Collider>();

                // Enable collision between all colliders
                foreach (Collider collider in allColliders)
                {
                    collider.enabled = true;
                }
            }
        }
    }
}

