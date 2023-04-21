using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class agent : MonoBehaviour
{
    [SerializeField]
    private Node startNode;
    [SerializeField]
    private Node targetNode;
    private List<Node> path;

    private int moves = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        //keep moving towards the next node
        if(path != null)
        {
            transform.position = Vector3.Lerp(transform.position, path[moves].transform.position, Time.deltaTime);
        }
    }

    void UpdatePath()
    {
        //If we don't have any start or target, don't run
        if (startNode == null || targetNode == null)
        {
            return;
        }

        //A* algorithm
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        
        openList.Add(startNode);
        this.startNode.setFCost(Vector3.Distance
            (
                this.startNode.transform.position,
                this.targetNode.transform.position
            ));

        while (true) {
            openList = openList.OrderBy(node => node.getFCost()).ToList();
            Node current = openList[0];
            openList.RemoveAt(0);
            closedList.Add(current);

            if (current.Equals(this.targetNode))
            {
                this.path = collectPath(current, new List<Node>());
                break;
            }

            foreach (var item in current.getConnections())
            {
                if (closedList.Contains(item.Value))
                {
                    continue;
                }

                //key in the connections Dictionary is a precalculated gcost, which in this case is just distance between the two nodes
                float tempFCost = item.Key + Vector3.Distance(item.Value.transform.position, this.targetNode.transform.position);
                if (item.Value.getFCost() > tempFCost || !openList.Contains(item.Value))
                {
                    item.Value.setFCost(tempFCost);
                    item.Value.setParent(current);
                    if (!openList.Contains(item.Value))
                    {
                        openList.Add(item.Value);
                    }
                }
            }
        }
    }

    List<Node> collectPath(Node node, List<Node> list)
    {
        list.Add(node);
        if (node.getParent() != null)
        {
            return collectPath(node.getParent(), list);
        }
        list.Reverse();
        return list;

    }

    //coroutine to move towards target every 5 seconds using A* algorithm
    IEnumerator move()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            UpdatePath();
            moves++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        var reverseList = new List<Node>(this.path);
        foreach (var item in reverseList)
        {
            Gizmos.DrawLine(item.transform.position, item.getParent().transform.position);
        }
    }
}
