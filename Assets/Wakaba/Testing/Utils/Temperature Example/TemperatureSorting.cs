using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSorting : MonoBehaviour
{
    [SerializeField] private int temperatureCount = 17;

    private List<Temprature> tempeatures = new List<Temprature>();

    private void Start()
    {
        GenerateTemperatures();
        DisplayTemperatures();
        tempeatures.BubbleSort();
        DisplayTemperatures();
    }

    private void GenerateTemperatures()
    {
        for (int i = 0; i < temperatureCount; i++)
        {
            tempeatures.Add(new Temprature(Random.Range(-100.0f, 100.0f)));
        }
    }

    private void DisplayTemperatures()
    {
        string formated = "";
        foreach (Temprature temp in tempeatures)
        {
            formated += temp.ToString() + ", ";
        }

        Debug.Log(formated);
    }
}
