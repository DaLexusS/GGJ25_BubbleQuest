using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;
    public TMP_Text pauseText;
    private bool _isPaused=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseText.text = "Pause"; // uses the placeholder text before we move to icons
        
        pauseButton.onClick.AddListener(TogglePause);
    }

    
    private void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0;
            pauseText.text = "Play";
        }
        else
        {
            Time.timeScale = 1;
            pauseText.text = "Pause";
        }
    }
}
