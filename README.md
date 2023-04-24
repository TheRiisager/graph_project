
## A* pathfinding algorithm in the unity game engine

![scene view](/images/network.PNG)

This project is a very simple implementation of the A* algorithm, that can be used to traverse a network of nodes in 3D space.


## Theory
The A* algorithm can be seen as an extension of Dijkstra's shortest path algorithm.<br>
Where dijkstra's algorithm works by simply evaluating a cost to travel between nodes in a graph, A* includes a heuristic to determine if moving to a given node will actually take it closer to the end goal.

A node in the A* algorithm will have two values: A Gcost, which represents the cost of moving from one node to another, and a Hcost, which is the heuristic value used to guide the algorithm towards the target. There's also an Fcost, which is the Gcost + Hcost.

In greater detail, A* works as follows:<br>
- Initialize two lists, open and closed
- add the start node to the open list
- Until the target node has been found, do the following:
  - find the node in the open list with the lowest Fcost
  - move it to the closed list
  - if it's the target, end the loop and return the path.
  - else do the following for each neighbor of the current node:
    - if the neighbor is in the closed list, skip it
    - if the new path for the neighbor has a lower fcost:
      - set fcost of neighbor to the new value
      - set the parent of the neighbor to the current node
      - add the neighbor to the open list if it is not already there 

## Implementation
This implementation simply uses the unity Vector3 distance function as a heuristic, measuring the distance between the node it is currently evaluating and the target node.
It can only support one agent moving on the graph, as the fcost is saved on the nodes.

## Code walkthrough
https://youtu.be/XSuiMrDMGMY
