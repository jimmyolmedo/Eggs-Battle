using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool inPause;

    private void Start()
    {
        inPause = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPauseState();
        }
    }


    public void SwitchPauseState()
    {
        if (inPause)
        {
            UIManager.Instance.SwitchPanel("GameStatus");
            GameManager.SwitchState(GameState.Gameplay);
            Time.timeScale = 1f;
            inPause = false;
        }
        else
        {
            UIManager.Instance.SwitchPanel("Pause");
            Time.timeScale = 0f;
            inPause = true;
        }
    }
}
