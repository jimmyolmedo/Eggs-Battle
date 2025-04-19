using System.Collections;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : Singleton<SceneManager>
{
    //variables
    private bool isLoading = false;

    //properties
    protected override bool persistent => false;

    //methods
    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(string sceneName)
    {
        UnitySceneManager.LoadScene(sceneName);
        Debug.Log("haz cambiado a la escena " + (sceneName));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
