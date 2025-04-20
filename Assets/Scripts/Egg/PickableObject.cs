using UnityEngine;
using UnityEngine.InputSystem;

public class PickableObject : MonoBehaviour
{
    [SerializeField] protected AudioClip pickedAudioClip;
    protected virtual void AudioPicked()
    {
        AudioManager.instance.PlayAudio(pickedAudioClip);
    }

    //funcion del objeto, cada objeto la heredara y definira
    public virtual void ObjectEffect(InputAction.CallbackContext context, Player player)
    {
        Destroy(gameObject);
    }
}
