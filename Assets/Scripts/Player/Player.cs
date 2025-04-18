using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    //identificador del jugador, para separar a los 2 jugadores
    [SerializeField] int playerID;

    //properties
    public int PlayerID
    {
        get => playerID;
    }
}
