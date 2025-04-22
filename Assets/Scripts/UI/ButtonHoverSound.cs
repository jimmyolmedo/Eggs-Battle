using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSound;

    [SerializeField] Vector3 hoverScale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlayAudio(hoverSound);
        transform.localScale = new Vector3(transform.localScale.x + .5f, transform.localScale.y + .5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = hoverScale;
    }

}
