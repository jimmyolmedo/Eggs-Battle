using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] AudioClip pickedAudio;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Count)];
    }
    public void Collected(Player _player)
    {
        Spawner.instance.EggsCount--;
        ScoreManager.instance.GetScore(_player.PlayerID);
        AudioManager.instance.PlayAudio(pickedAudio);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Collected(player);
        }
    }
}
