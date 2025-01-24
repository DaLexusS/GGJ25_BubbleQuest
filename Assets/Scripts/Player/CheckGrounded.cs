using UnityEngine;
using UnityEngine.Events;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded = false;
    static public UnityAction onLanded;
    static public UnityAction<bool> AirBorn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            AirBorn.Invoke(false);
            onLanded.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            AirBorn.Invoke(true);
        }
    }
}
