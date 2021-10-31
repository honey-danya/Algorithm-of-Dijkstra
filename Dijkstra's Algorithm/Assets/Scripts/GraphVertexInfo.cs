using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphVertexInfo : MonoBehaviour
{
    /// <summary>
    /// Вершина
    /// </summary>
    public GraphVertex Vertex { get; set; }

    /// <summary>
    /// Не посещенная вершина
    /// </summary>
    public bool IsUnvisited { get; set; }

    /// <summary>
    /// Сумма весов ребер
    /// </summary>
    public int EdgesWeightSum { get; set; }

    /// <summary>
    /// Предыдущая вершина
    /// </summary>
    public GraphVertex PreviousVertex { get; set; }

    /// <summary>
    /// Аля Конструктор
    /// </summary>
    /// <param name="vertex">Вершина</param>
    public GraphVertexInfo Initialize(GameObject vertex)
    {
        Vertex = vertex.GetComponent<GraphVertex>();
        IsUnvisited = true;
        EdgesWeightSum = int.MaxValue;
        PreviousVertex = null;
        return this;
    }
}
