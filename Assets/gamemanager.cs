using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int index;
    public GameObject[] cars;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CarIndex"); 
        GameObject selectedCar = Instantiate(cars[index], Vector3.zero, Quaternion.identity);
    }
}
