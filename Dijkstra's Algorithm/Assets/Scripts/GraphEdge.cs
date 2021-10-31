using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphEdge : MonoBehaviour
{
    /// <summary>
    /// Связанная вершина (инцидентная вершина)
    /// </summary>
    public GraphVertex ConnectedVertex { get; set; }

    /// <summary>
    /// Вес ребра
    /// </summary>
    public int EdgeWeight { get; set; }

    /// <summary>
    /// Аля Конструктор
    /// </summary>
    /// <param name="connectedVertex">Связанная вершина</param>
    /// <param name="weight">Вес ребра</param>
    public GraphEdge Initialize(GraphVertex connectedVertex, int weight)
    {
        ConnectedVertex = connectedVertex;
        EdgeWeight = weight;
        return this;
    }

    /// <summary>
    /// Установка веса ребра на сцене
    /// </summary>
    /// <param name="points">координаты точек начала и конца ребра</param>
    /// <param name="weight">Вес ребра</param>
    public void SetWeightOnScene(Vector3[] points, int weight)
    {
        Vector3 midPosition = (points[0] + points[1]) / (float)2; //середина ребра
        gameObject.transform.GetChild(0).GetComponent<Canvas>().transform.position = midPosition;
        gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = weight.ToString();
    }
}
