using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImanEgg : PickableObject
{
    protected override void AudioPicked()
    {
        base.AudioPicked();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.PickObject(this);
            Spawner.instance.EggsCount--;
            AudioPicked();
            gameObject.SetActive(false);
        }
    }
    public override void ObjectEffect(InputAction.CallbackContext context, Player player)
    {
        //al precionar el boton, hacer un area visible que muestre el area donda afectara la habilidad
        if(context.started)
        {
            player.TargetArea();
        }
        //al soltar el boton, esa area desaparece y todos los huevos en dicha area son recolectados
        if(context.canceled)
        {
            Collider2D[] coll = Physics2D.OverlapCircleAll(player.transform.position, 5f);
            foreach(Collider2D coll2 in coll)
            {
                if(coll2.TryGetComponent(out Egg egg))
                {
                    egg.Collected(player);
                }
            }
            player.TargetArea();
            Debug.Log("haz usado el objeto del iman");
        }
    }
}
