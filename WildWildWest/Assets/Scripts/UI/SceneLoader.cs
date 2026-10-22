using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.HDROutputUtils;

//переходы между сценами
public class SceneLoader : MonoBehaviour
{
    public  void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public IEnumerator LoadAsync(string nameScene, Action<float> onProgress)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            onProgress?.Invoke(progress);

            yield return null;
        }
    }
}