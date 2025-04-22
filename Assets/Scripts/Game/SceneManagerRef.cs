using UnityEngine;

public class SceneManagerRef : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.instance.LoadScene(sceneName);
    }
}
