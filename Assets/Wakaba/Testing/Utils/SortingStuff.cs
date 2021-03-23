using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wakaba.Utils.Comparers;
using Wakaba.Utils.Extensions;
public class SortingStuff : MonoBehaviour
{
    private int stuffCount = 20;

    private List<GameObjectComparer> gameObjects = new List<GameObjectComparer>();

    private GameObject prefab;

    private void Start()
    {
        GenerateObjects();
    }

    private void GenerateObjects()
    {
        for (int i = 0; i < stuffCount; i++)
        {
            //gameObjects.Add(new GameObjectComparer());
        }
    }

    private void DisplayStuff()
    {
        string formated = "";
        foreach (GameObjectComparer go in gameObjects) formated += go.ToString() + ", ";
        print(formated);
    }
}
