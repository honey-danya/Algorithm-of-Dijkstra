using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphVertex : MonoBehaviour
{
    /// <summary>
    /// Название вершины
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список ребер соединенных с вершиной
    /// </summary>
    public List<GraphEdge> Edges { get; set; }

    /// <summary>
    /// Добавить ребро (функционал для невзвешенного графа)
    /// </summary>
    /// <param name="newEdge">Ребро</param>
    public void AddEdge(GraphEdge newEdge)
    {
        Edges.Add(newEdge);
    }

    /// <summary>
    /// Добавить ребро с весом
    /// </summary>
    /// <param name="vertex">Вершина</param>
    /// <param name="edgeWeight">Вес</param>
    public void AddEdge(GraphVertex vertex, int edgeWeight)
    {
        AddEdge(gameObject.AddComponent<GraphEdge>().Initialize(vertex, edgeWeight));
    }

    /// <summary>
    /// Преобразование в строку
    /// </summary>
    /// <returns>Имя вершины</returns>
    public override string ToString() => Name;
    // Start is called before the first frame update
    void Start()
    {
        Name =  gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
        Edges = new List<GraphEdge>();
    }
}
