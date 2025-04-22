using System.Collections;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : Singleton<SceneManager>
{
    //variables
    private bool isLoading = false;
    [SerializeField] Animator animator;

    //properties
    protected override bool persistent => true;

    //methods
    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AnimationChangeScene(sceneName));
        Debug.Log("haz cambiado a la escena " + (sceneName));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator AnimationChangeScene(string _sceneName)
    {
        animator.Play("changeScene");
        yield return new WaitForSeconds(.55f);
        UnitySceneManager.LoadScene(_sceneName);
    }
}
