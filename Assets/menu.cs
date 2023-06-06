using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public static bool GameISpause = true;
    public GameObject PauseUI;
    [SerializeField] public GameObject SettingsUI;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameISpause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Setting()
    {
        SettingsUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 0f;
        GameISpause = true;
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameISpause = false;
    }
   void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameISpause = true;
    }


    public void qUIT()
    {

    }
}
