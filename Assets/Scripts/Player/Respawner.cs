using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector2 _initalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // store initial position
        _initalPosition = transform.position;

        // try to load checkpoint position
        if (PlayerPrefs.HasKey("checkpoint"))
        {
            string savedPosition = PlayerPrefs.GetString("checkpoint");
            transform.position = ParsePosition(savedPosition) ;
            Debug.Log("Player respawned at: " + transform.position);
        }
        
    }
    
    public void RespawnPlayer() // respawn method
    {
        //respawn animation
        PlayRespawnAnimation();

        //load checkpoint position
        if (PlayerPrefs.HasKey("checkpoint"))
        {
            string savedPosition = PlayerPrefs.GetString("checkpoint");
            transform.position = ParsePosition(savedPosition) ;
            Debug.Log("Player respawned at: " + transform.position);
        }
        else
        {
            //respawn at initial point if a checkpoint doesn't exist
            transform.position = _initalPosition;
            Debug.Log("player spawned at initial position" + transform.position);
        }
        
    }

    private Vector2 ParsePosition(string positionString)
    {
        string[] values = positionString.Split(','); // split saved string to x & y values
        float x= float.Parse(values[0]);
        float y= float.Parse(values[1]);
        return new Vector2(x, y);
    }

    public void PlayRespawnAnimation()
    {
        Debug.Log("Playing respawn animation");
    }
}
