using UnityEngine;
using UnityEngine.InputSystem;

public class FrozenEgg : PickableObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickObject(this);
            Spawner.instance.EggsCount--;
            gameObject.SetActive(false);
        }
    }

    public override void ObjectEffect(InputAction.CallbackContext context, Player player)
    {
        //al presionar el boton tiene que mostrar un area donde afectara el objeto
        if (context.started)
        {
            player.TargetArea();
        }
        //al soltar el boton, si el otro jugador esta en esa area lo congelara
        if(context.canceled)
        {
            Collider2D[] coll = Physics2D.OverlapCircleAll(player.transform.position, 5f);
            foreach (Collider2D coll2 in coll)
            {
                if (coll2.TryGetComponent(out Player _player))
                {
                    if(_player != player)
                    {
                        _player.FrostPlayer();
                    }
                }
            }
            player.TargetArea();
            Debug.Log("haz usado el objeto del iman");
        }
    }
}
