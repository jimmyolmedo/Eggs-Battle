using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    Vector2 move;


    //methods

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move.x, move.y) * speed * Time.deltaTime;
    }
    public void Move(InputAction.CallbackContext context)
    {
        if(GameManager.CurrentState != GameState.Gameplay) { return; }

        move =context.ReadValue<Vector2>();
    }

}
