using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    Vector2 move;
    bool canMove = true;

    //properties
    //propiedad que señalara cuando el jugador esta presionando el boton de moverse
    public bool IsTryMoving {  get; set; }

    //methods
    private void OnEnable()
    {
        ScoreManager.OnGameOver += DisableMovement;
    }

    private void OnDisable()
    {
        ScoreManager.OnGameOver -= DisableMovement;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = new Vector2(move.x, move.y) * speed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        if(GameManager.CurrentState != GameState.Gameplay) { return; }

        move =context.ReadValue<Vector2>();
        Debug.Log("esoty moviendome");
        if(context.started)
        {
            IsTryMoving = true;
        }
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

}
