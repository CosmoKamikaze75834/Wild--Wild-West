using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//переходы между сценами
public class SceneLoader : MonoBehaviour
{
    public  void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public IEnumerator LoadAsync(string nameScene)
    {
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(nameScene);

        //поставь coroutine на паузу,пока сцена не догрузится
        yield return waitLoading.isDone;
    }
}