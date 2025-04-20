using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] AudioClip pickedAudio;
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
