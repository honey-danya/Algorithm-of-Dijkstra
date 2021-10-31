using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    
    [SerializeField] Vector3[] Edges;
    [SerializeField] GameObject prefabEdge;
    public bool oriented;

    /// <summary>
    /// Список вершин графа
    /// </summary>
    public List<GameObject> Vertex;

    /// <summary>
    /// Поиск вершины
    /// </summary>
    /// <param name="vertexName">Название вершины</param>
    /// <returns>Найденная вершина</returns>
    public GameObject FindVertex(string vertexName)
    {
        foreach (var v in Vertex)
        {
            if (v.GetComponent<GraphVertex>().Name.Equals(vertexName))
            {
                return v;
            }
        }

        return null;
    }

    /// <summary>
    /// Добавление ребра
    /// </summary>
    /// <param name="firstName">Имя первой вершины</param>
    /// <param name="secondName">Имя второй вершины</param>
    /// <param name="weight">Вес ребра соединяющего вершины</param>
    public void AddEdge(string firstName, string secondName, int weight)
    {
        var v1 = FindVertex(firstName);
        var v2 = FindVertex(secondName);
        if (v2 != null && v1 != null)
        {
            GraphVertex gV1 = v1.GetComponent<GraphVertex>();
            GraphVertex gV2 = v2.GetComponent<GraphVertex>();
            if (!oriented)
            {
                gV2.AddEdge(gV1, weight);
            }

            GameObject edge = Instantiate(prefabEdge);
            Vector3[] pointsPosition = { v1.transform.position, v2.transform.position };
            edge.GetComponent<LineRenderer>().SetPositions(pointsPosition); // добавили ребро между вершинами на сцене
            edge.GetComponent<GraphEdge>().SetWeightOnScene(pointsPosition, weight); //добавили вес ребру на сцене
            edge.name = "Edge " + gV1.Name + " " + gV2.Name; //добавили нужное имя ребру
            gV1.AddEdge(gV2, weight);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Vector3 e in Edges)
        {
            AddEdge(Vertex[(int)e.x].GetComponent<GraphVertex>().Name, Vertex[(int)e.y].GetComponent<GraphVertex>().Name, (int)e.z);
            
        }
        
    }
}
