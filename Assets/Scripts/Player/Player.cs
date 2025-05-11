using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //variables
    //identificador del jugador, para separar a los 2 jugadores
    [SerializeField] int playerID;
    //zona en la que funcionara el objeto que unilice el jugador
    [SerializeField] SpriteRenderer effectZone;
    //referencia al movimiento del jugador
    [SerializeField] PlayerMovement pM;
    //variable para guardar el objeto obtenido
    [SerializeField] PickableObject pickedObject;
    [Header("variables de congelar")]
    //contador de veces que el jugador tiene que precionar botones
    [SerializeField] int freezeCount;
    //tiempo que puede pasar como maximo antes de que el jugador se pueda mover nuevamente
    [SerializeField] float freezeTime;

    [SerializeField] private GameObject frostVisuals;
    [SerializeField] private UnityEngine.UI.Image eggUI;

    //properties
    public int PlayerID
    {
        get => playerID;
    }

    //methods
    //funcion para obtener un objeto
    public void PickObject(PickableObject _obj)
    {
        pickedObject = _obj;
        eggUI.gameObject.SetActive(true);
        eggUI.sprite = pickedObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(GameManager.CurrentState != GameState.Gameplay) { return; }

        if(context.started && pickedObject != null)
        {
            pickedObject.ObjectEffect(context, this);
        }

        if(context.canceled && pickedObject != null)
        {
            pickedObject.ObjectEffect(context, this);
            pickedObject = null;
            eggUI.gameObject.SetActive(false);
        }
    }

    //funcion para prender y apagar el area de effecto
    public void TargetArea()
    {
        effectZone.enabled = !effectZone.enabled;
    }

    //funcion para congelar al jugador
    public void FrostPlayer()
    {
        freezeCount = 5;
        freezeTime = 0;
        pM.DisableMovement();
        StartCoroutine(FrostState());
    }

    IEnumerator FrostState()
    {
        frostVisuals.SetActive(true);
        while(true)
        {
            if (pM.IsTryMoving)
            {
                freezeCount--;
                pM.IsTryMoving = false;
                yield return new WaitForSeconds(0.3f);
            }

            freezeTime += Time.deltaTime;
            if(freezeTime >= 10 || freezeCount == 0)
            {
                pM.EnableMovement();
                frostVisuals.SetActive(false);
                break;
            }
            yield return null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
