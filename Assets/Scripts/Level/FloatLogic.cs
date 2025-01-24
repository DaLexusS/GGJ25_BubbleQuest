using UnityEngine;

public class FloatLogic : MonoBehaviour
{ public float floatSpeed = 2f; // How fast the balloon floats upward
    public float maxHeight = 5f; // The height at which the balloon stops floating

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isFloating = true; // Tracks whether the balloon is still floating

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Continuously move up if below the maxHeight
        if (isFloating && transform.position.y < maxHeight)
        {
            transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0); // Move upward
        }
        else if (isFloating)
        {
            // Stop floating and freeze the balloon's movement
            isFloating = false;
            FreezeBalloon();
        }
    }

    private void FreezeBalloon()
    {
        // Freeze the Rigidbody to prevent any further movement
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("Balloon movement frozen.");
    }
}
