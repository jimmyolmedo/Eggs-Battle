using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] AudioClip pickedAudio;
    [SerializeField] Collider2D collider;
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
        collider.enabled = false;
        StartCoroutine(Collect(_player));
        Spawner.instance.EggsCount--;
        //ScoreManager.instance.GetScore(_player.PlayerID);
        //AudioManager.instance.PlayAudio(pickedAudio);
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Collected(player);
        }
    }

    IEnumerator Collect(Player player)
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = ScoreManager.instance.GetPositionIcon(player.PlayerID).position;
        AudioManager.instance.PlayAudio(pickedAudio);
        for (float i = 0; i < 1f ; i += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(startPos, endPos, i/1f);
            yield return null;
        }
        ScoreManager.instance.GetScore(player.PlayerID);
        Destroy(gameObject);

    }
}
