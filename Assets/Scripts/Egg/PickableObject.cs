using UnityEngine;
using UnityEngine.InputSystem;

public class PickableObject : MonoBehaviour
{


    //funcion del objeto, cada objeto la heredara y definira
    public virtual void ObjectEffect(InputAction.CallbackContext context, Player player)
    {
        Destroy(gameObject);
    }
}
