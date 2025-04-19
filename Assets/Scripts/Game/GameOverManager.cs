using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    //variables
    [SerializeField] TextMeshProUGUI winnerText;

    //methods
    private void OnEnable()
    {
        ScoreManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        ScoreManager.OnGameOver += GameOver;
    }

    void GameOver()
    {
        GameManager.SwitchState(GameState.GameOver);
        CalculateScore();
        winnerText.gameObject.SetActive(true);
    }

    void CalculateScore()
    {
        if(ScoreManager.instance.ScorePlayer1 == ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Empate!!";
        }
        else if(ScoreManager.instance.ScorePlayer1 < ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Jugador 2 gana!!";
        }
        else if(ScoreManager.instance.ScorePlayer1 > ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Jugador 1 gana!!";
        }
    }
}
