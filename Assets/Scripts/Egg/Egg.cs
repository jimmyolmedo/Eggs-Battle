using UnityEngine;

public class Egg : MonoBehaviour
{

    public void Collected(Player _player)
    {
        Spawner.instance.EggsCount--;
        ScoreManager.instance.GetScore(_player.PlayerID);
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
