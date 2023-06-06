using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingSpeed = 0.5f;
   [SerializeField] public string nextSceneName; // Name of the scene to transition to

    private void Start()
    {
        loadingSlider.value = 0f;
    }

    private void Update()
    {
        if (loadingSlider.value < 1f)
        {
            loadingSlider.value += loadingSpeed * Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Transition to the next scene
        }
    }



}
