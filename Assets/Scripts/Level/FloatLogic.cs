using UnityEngine;

public class FloatLogic : MonoBehaviour
{
    [SerializeField] public float floatSpeed = 2f;
    [SerializeField] public float maxHeight = 5f;

    private bool canFloat = false;
    
    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0);
        }
    }

    void StartFloating()
    {
        canFloat = true;
    }
}
