using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlayAudio(hoverSound);
    }
}
