using UnityEngine;
using UnityEngine.Events;

public class DeathOnTouch : MonoBehaviour
{
    static public UnityAction onPlayerDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }
        onPlayerDeath.Invoke();
    }
}
