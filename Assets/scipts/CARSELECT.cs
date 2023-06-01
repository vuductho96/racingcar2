using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CARSELECT : MonoBehaviour
{
    public GameObject[] carSelections;
    public Button nextButton;
    public Button prevButton;
    public Button raceButton;

    private int currentIndex;

    private void Start()
    {
        currentIndex = PlayerPrefs.GetInt("CarIndex");
        UpdateCarSelection();
    }

    private void UpdateCarSelection()
    {
        for (int i = 0; i < carSelections.Length; i++)
        {
            carSelections[i].SetActive(i == currentIndex);
        }

        nextButton.interactable = currentIndex < carSelections.Length - 1;
        prevButton.interactable = currentIndex > 0;
    }

    public void SelectNextCar()
    {
        currentIndex++;
        UpdateCarSelection();
    }

    public void SelectPreviousCar()
    {
        currentIndex--;
        UpdateCarSelection();
    }

    public void StartRace()
    {
        PlayerPrefs.SetInt("CarIndex", currentIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadingSence" +
            "");
    }

}
