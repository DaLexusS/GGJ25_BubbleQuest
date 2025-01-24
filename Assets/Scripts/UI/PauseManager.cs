using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;
    public TMP_Text pauseText;
    private bool _isPaused=false;
    void Start()
    {
        pauseText.text = "Pause"; // uses the placeholder text before we move to icons
    }
    public void TogglePause()
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
