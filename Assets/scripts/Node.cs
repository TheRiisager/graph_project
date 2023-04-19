using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private List<Node> list = new List<Node>();
    private Dictionary<float, Node> connections = new Dictionary<float, Node>();
    private float fCost;
    private Node parent;
    // Start is called before the first frame update
    void Start()
    {
        //precalculate distance to connected nodes on init
        foreach (Node node in list)
        {  
            float distance = Vector3.Distance(node.GetTransform().position, this.transform.position);
            connections.Add(distance, node);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetTransform()
    {
        return this.gameObject.transform;
    }

    public float getFCost()
    {
        return this.fCost;
    }

    public void setFCost(float cost)
    {
        this.fCost = cost;
    }

    public Node getParent()
    {
        return this.parent;
    }

    public void setParent(Node node)
    {
        this.parent = node;
    }

    public Dictionary<float, Node> getConnections()
    {
        return this.connections;
    }
}
