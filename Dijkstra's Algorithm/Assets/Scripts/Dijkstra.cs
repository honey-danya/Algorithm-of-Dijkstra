using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    [SerializeField] GameObject graph;
    [SerializeField] GameObject startVertex;
    [SerializeField] GameObject finishVertex;

    List<GraphVertexInfo> infos;

    /// <summary>
    /// Инициализация информации
    /// </summary>
    void InitInfo()
    {
        infos = new List<GraphVertexInfo>();
        foreach (var v in graph.GetComponent<Graph>().Vertex)
        {
            infos.Add(gameObject.AddComponent<GraphVertexInfo>().Initialize(v));
        }
    }

    /// <summary>
    /// Получение информации о вершине графа
    /// </summary>
    /// <param name="v">Вершина</param>
    /// <returns>Информация о вершине</returns>
    GraphVertexInfo GetVertexInfo(GraphVertex v)
    {
        foreach (var i in infos)
        {
            if (i.Vertex.Equals(v))
            {
                return i;
            }
            print(i.Vertex.Name);
        }
        return null;
    }

    /// <summary>
    /// Поиск непосещенной вершины с минимальным значением суммы
    /// </summary>
    /// <returns>Информация о вершине</returns>
    public GraphVertexInfo FindUnvisitedVertexWithMinSum()
    {
        var minValue = int.MaxValue;
        GraphVertexInfo minVertexInfo = null;
        foreach (var i in infos)
        {
            if (i.IsUnvisited && i.EdgesWeightSum < minValue)
            {
                minVertexInfo = i;
                minValue = i.EdgesWeightSum;
            }
        }

        return minVertexInfo;
    }

    /// <summary>
    /// Поиск кратчайшего пути по вершинам
    /// </summary>
    /// <param name="startVertex">Стартовая вершина</param>
    /// <param name="finishVertex">Финишная вершина</param>
    /// <returns>Кратчайший путь</returns>
    public string FindShortestPath()
    {
        InitInfo();
        var first = GetVertexInfo(startVertex.GetComponent<GraphVertex>());
        first.EdgesWeightSum = 0;
        while (true)
        {
            var current = FindUnvisitedVertexWithMinSum();
            if (current == null)
            {
                break;
            }

            SetSumToNextVertex(current);
        }

        return GetPath(startVertex.GetComponent<GraphVertex>(), finishVertex.GetComponent<GraphVertex>());
    }

    /// <summary>
    /// Вычисление суммы весов ребер для следующей вершины
    /// </summary>
    /// <param name="info">Информация о текущей вершине</param>
    void SetSumToNextVertex(GraphVertexInfo info)
    {
        info.IsUnvisited = false;
        foreach (var e in info.Vertex.Edges)
        {
            var nextInfo = GetVertexInfo(e.ConnectedVertex);
            var sum = info.EdgesWeightSum + e.EdgeWeight;
            if (sum < nextInfo.EdgesWeightSum)
            {
                nextInfo.EdgesWeightSum = sum;
                nextInfo.PreviousVertex = info.Vertex;
            }
        }
    }

    /// <summary>
    /// Формирование пути
    /// </summary>
    /// <param name="startVertex">Начальная вершина</param>
    /// <param name="endVertex">Конечная вершина</param>
    /// <returns>Путь</returns>
    string GetPath(GraphVertex startVertex, GraphVertex endVertex)
    {
        var path = endVertex.ToString();
        while (startVertex != endVertex)
        {
            endVertex = GetVertexInfo(endVertex).PreviousVertex;
            path = endVertex.ToString() + path;
        }
        return path;
    }

    /// <summary>
    /// Рисуем путь используя имя ребра
    /// </summary>
    /// <param name="path">путь из вершин</param>
    /// <param name="pathColor">материал для окраса пути</param>
    public void DrawShorstetPath(string path, Material pathColor)
    {
        string edgeName;
        for (int i = 0; i < path.Length - 1; i ++)
        {
            edgeName = "Edge " + path[i].ToString() + " " + path[i + 1].ToString();
            print(edgeName);
            if(!graph.GetComponent<Graph>().oriented && GameObject.Find(edgeName) == null)
            {
                edgeName = "Edge " + path[i + 1].ToString() + " " + path[i].ToString();
            }
            GameObject.Find(edgeName).GetComponent<LineRenderer>().material = pathColor;
        }
    }
}
