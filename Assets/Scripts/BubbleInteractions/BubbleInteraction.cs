using UnityEngine;

public enum BubbleType
{
    Destroy,
    Bounce,
}

public class BubbleInteraction : MonoBehaviour
{
    [SerializeField] public BubbleType myBubbleType;
    private bool isHoveringObject = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bubble_Interactable")) { return; }

        switch (myBubbleType)
        {
            case BubbleType.Destroy:
                Transform physicalObject = other.transform.Find("Physical");
                if (physicalObject.gameObject.activeSelf && !isHoveringObject)
                {
                    DestroyBubble(physicalObject.gameObject, true);
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Bubble_Interactable")) { return; }

        switch (myBubbleType)
        {
            case BubbleType.Destroy:
                Transform physicalObject = other.transform.Find("Physical");
                if (!physicalObject.gameObject.activeSelf)
                {
                    DestroyBubble(physicalObject.gameObject, false);
                }
                break;
            default:
                break;
        }
    }

    private void DestroyBubble(GameObject obj, bool state)
    {
        if (state) { obj.SetActive(false); isHoveringObject = true; }
        else { obj.SetActive(true); isHoveringObject = false; ;  }
    }
}
