using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadingBAR : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    public Transform loadingBar; // Reference to the loading bar transform
    public float fillSpeed = 0.5f; // Speed at which the loading bar fills

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private System.Collections.IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f; // Normalize the progress value
            float targetFillAmount = Mathf.Clamp01(progress);

            float currentFillAmount = loadingBar.localScale.x;
            float newFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, fillSpeed * Time.deltaTime);
            loadingBar.localScale = new Vector3(newFillAmount, loadingBar.localScale.y, loadingBar.localScale.z);

            yield return null;
        }
    }
}
