using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public  void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public IEnumerator LoadAsync(string nameScene)
    {
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(nameScene);

        yield return waitLoading.isDone;
    }
}