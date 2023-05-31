using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CARSELECTION : MonoBehaviour
{
    [SerializeField] public GameObject[] CARSELLECTIONs;
    public Button Next;
    public Button Prev;
    public Button Race;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CarIndex");

        for (int i = 0; i < CARSELLECTIONs.Length; i++)
        {
            CARSELLECTIONs[i].SetActive(false);
            CARSELLECTIONs[index].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 2)
        {
            Next.interactable = false;
        }
        else
        {
            Next.interactable = false;
        }

        if (index <= 0)
        {
            Prev.interactable = false;
        }
        else
        {
            Prev.interactable = true;
        }
    }
    public void Prev2()
    {
        index--;
        for (int i = 0; i < CARSELLECTIONs.Length; i++)
        {
            CARSELLECTIONs[i].SetActive(false);
            CARSELLECTIONs[index].SetActive(true);
        }
        PlayerPrefs.SetInt("CarIndex", index);
        PlayerPrefs.Save();
    }
    public void Next2()
    {
        index++;
        for (int i = 0; i < CARSELLECTIONs.Length; i++)
        {
            CARSELLECTIONs[i].SetActive(false);
            CARSELLECTIONs[index].SetActive(true);
        }
        PlayerPrefs.SetInt("CarIndex", index);
        PlayerPrefs.Save();
    }
    public void Race2()
    {
        SceneManager.LoadSceneAsync("GamePlay");
    }
}
   

    