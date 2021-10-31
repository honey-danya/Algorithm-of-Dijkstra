using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    [SerializeField] GameObject findShortestPath;
    [SerializeField] Material pathColor;
    public void onClick()
    {
        string path = findShortestPath.GetComponent<Dijkstra>().FindShortestPath();
        print(path);
        findShortestPath.GetComponent<Dijkstra>().DrawShorstetPath(path, pathColor);


    }
}
