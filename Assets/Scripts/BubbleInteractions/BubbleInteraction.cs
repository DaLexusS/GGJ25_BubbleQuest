using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public enum BubbleType
{
    Destroy,
    Bounce,
}

public class BubbleInteraction : MonoBehaviour
{
    static public UnityAction onLose;
    [SerializeField] public BubbleType myBubbleType;

    public BubbleDrag bubbleDrag;
    public GameObject LastObject;

    public void SetActiveState(GameObject target, bool state, bool includeSelf = true)
    {
        foreach (Transform child in target.transform)
        {
            child.gameObject.SetActive(state);
        }

        if (includeSelf)
        {
            target.SetActive(state);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("sex");
        if (!bubbleDrag.isDragging)
        {
            Debug.Log("sex shrek");
            if (LastObject != null) { return; }
            if (collision.gameObject.CompareTag("Bubble_Interactable") ||
                collision.gameObject.CompareTag("Player") ||
                collision.gameObject.CompareTag("EndGoal"))
            {
                ObjectDisappear bubbleObject = collision.gameObject.gameObject.GetComponent<ObjectDisappear>();
                bubbleObject.ToggleObject();
                LastObject = collision.gameObject.gameObject;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bubble_Interactable") ||
            other.CompareTag("Player") ||
            other.CompareTag("EndGoal"))
        {
            ObjectDisappear bubbleObject = other.gameObject.GetComponent<ObjectDisappear>();
            bubbleObject.ToggleObject();
            LastObject = null;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble_Interactable")) 
        {
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
        else if (other.CompareTag("Player"))
        {
            switch (myBubbleType)
            {
                case BubbleType.Destroy:
                    HidePlayer(true);
                    break;
                default:
                    break;
            }
        }
        else if (other.CompareTag("EndGoal"))
        {
            switch (myBubbleType)
            {
                case BubbleType.Destroy:
                    HideEndGoal(true);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bubble_Interactable")) 
        {
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

        else if (other.CompareTag("Player"))
        {
            switch (myBubbleType)
            {
                case BubbleType.Destroy:
                    HidePlayer(false);
                    break;
                default:
                    break;
            }
        }

        else if (other.CompareTag("EndGoal"))
        {
            switch (myBubbleType)
            {
                case BubbleType.Destroy:
                    HideEndGoal(false);
                    break;
                default:
                    break;
            }
        }
    }

    private void DestroyBubble(GameObject obj, bool state)
    {
        if (state) 
        { 
            obj.SetActive(false);
            isHoveringObject = true;
            if (!bubbleDrag.isDragging)
            {
                colliderBubble.gameObject.SetActive(true);
            }
            else
            {
                colliderBubble.gameObject.SetActive(false);
            }
        }
        else { obj.SetActive(true); isHoveringObject = false; ;  }
    }

    private void HidePlayer(bool state)
    {
        if (state)
        {
            playerMovement.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            visual.SetActive(true);
            playerMovement.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private void HideEndGoal(bool state)
    {
        if (state)
        {
            endGoal.SetActive(false);
            EndGoalVisual.SetActive(false);
        }
        else
        {
            endGoal.SetActive(true);
            EndGoalVisual.SetActive(true);
        }
    }*/
}
