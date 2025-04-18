using UnityEngine;

public class Egg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Spawner.instance.EggsCount--;
            Debug.Log("he tomado un huevo");
            ScoreManager.instance.GetScore(player.PlayerID);
            Destroy(gameObject);
        }
    }
}
