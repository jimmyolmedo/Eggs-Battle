using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    //variables
    [SerializeField] GameObject player1Winner, player2Winner;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] GameObject EndGamePanel;
    
    //methods
    private void OnEnable()
    {
        ScoreManager.OnGameOver += GameOver;
        player1Winner.SetActive(false);
        player2Winner.SetActive(false);
    }

    private void OnDisable()
    {
        ScoreManager.OnGameOver -= GameOver;
    }

    void GameOver()
    {
        GameManager.SwitchState(GameState.GameOver);
        CalculateScore();
        UIManager.Instance.SwitchPanel("GameOver");
    }

    void CalculateScore()
    {
        if(ScoreManager.instance.ScorePlayer1 == ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Empate!!";
            player1Winner.SetActive(true);
            player2Winner.SetActive(true);
            player1Winner.GetComponent<RectTransform>().localPosition = new Vector3(75,0,0);
            player2Winner.GetComponent<RectTransform>().localPosition = new Vector3(-75, 0,0);
        }
        else if(ScoreManager.instance.ScorePlayer1 < ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Jugador 2 gana!!";
            player2Winner.SetActive(true);
            player2Winner.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        else if(ScoreManager.instance.ScorePlayer1 > ScoreManager.instance.ScorePlayer2)
        {
            winnerText.text = "Jugador 1 gana!!";
            player1Winner.SetActive(true);
            player1Winner.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
