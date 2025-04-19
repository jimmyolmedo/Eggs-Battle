using System.Collections;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : Singleton<SceneManager>
{
    //variables
    private bool isLoading = false;

    //properties
    protected override bool persistent => true;

    //methods
    public void LoadScene(string sceneName)
    {
        if (isLoading) return;
        isLoading = true;

        StartCoroutine(AsyncLoad(sceneName));
    }

    //coroutines
     IEnumerator AsyncLoad(string sceneName)
    {
        // Primero cargaremos la escena utilizando la función LoadSceneAsync del SceneManager de Unity
        // y guardaremos esa operación en una variable de tipo AsyncOperation.
        AsyncOperation asyncOperation = UnitySceneManager.LoadSceneAsync(sceneName);

        // Luego le quitaremos el permiso para cargar hasta que nosotros volvamos a activar la variable.
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        // Y finalmente, como la escena ya cargó habilitaremos la transición a ella y estableceremos que 
        // ya no estamos cargando una escena para habilitar la función LoadAsync de nuevo.
        asyncOperation.allowSceneActivation = true;
        isLoading = false;

    }



}
