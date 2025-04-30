using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    //variables
    //score de ambos jugadores
    [SerializeField] int scorePlayer1;
    [SerializeField] int scorePlayer2;
    //texto para mostrar los 2 score
    [SerializeField] TextMeshProUGUI textScore1;
    [SerializeField] TextMeshProUGUI textScore2;
    //imagen en la UI de los jugadores(se usaran para feedback de obtener huevos)
    [SerializeField] Transform posIconPlayer1;
    [SerializeField] Transform posIconPlayer2;
    //tiempo que va a durar la partida
    [SerializeField] float gameTime;
    //variable que se usara como cronometro
    float timer;
    //variable de texto para mostrar el tiempo en pantalla
    [SerializeField] TextMeshProUGUI textTime;

    public static event System.Action OnGameOver;
    //properties
    protected override bool persistent => false;

    //propiedades para los puntajes de los jugadores, de esa manera poder verlo desde otro script
    public int ScorePlayer1
    {
        get => scorePlayer1;

        private set => scorePlayer1 = value;
    }

    public int ScorePlayer2
    {
        get => scorePlayer2;

        private set => scorePlayer2 = value;
    }

    //methods
    protected override void Awake()
    {
        base.Awake();
        timer = gameTime;
    }

    private void Update()
    {
        if(GameManager.CurrentState == GameState.Gameplay)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
        }
        
        //cambiar el timer a entero y asignarselo a textTime
        int time = (int)timer;
        textTime.text = time.ToString();

        if(timer <= 0)
        {
            OnGameOver?.Invoke();
        }
    }

    //funcion para aumentar el score
    public void GetScore(int _playerID)
    {
        //revisar si el id ingresado es 0 o 1 para saber a que jugador añadirle el Score
        if(_playerID == 0)
        {
            scorePlayer1++;
            textScore1.text = scorePlayer1.ToString();
        }
        else if(_playerID == 1)
        {
            scorePlayer2++;
            textScore2.text = scorePlayer2.ToString();
        }
    }

    public Transform GetPositionIcon(int _id)
    {
        if(_id == 0)
        {
            return posIconPlayer1;
        }
        else { return posIconPlayer2; }
    }
}
