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
    private bool atTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        if(atTarget)
        {
            StopAllCoroutines();
        }
    }

    //coroutine to move towards target every 5 seconds using A* algorithm
    IEnumerator move()
    {
        yield return new WaitForSeconds(5f);
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
                this.atTarget = true;
                break;
            }

            foreach (var item in current.getConnections())
            {
                
            }
        }
    }
}
