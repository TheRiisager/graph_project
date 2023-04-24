
## A* pathfinding algorithm in the unity game engine

![scene view](/images/network.PNG)

This project is a very simple implementation of the A* algorithm, that can be used to traverse a network of nodes in 3D space.
It simply uses the unity Vector3 distance function as a heuristic, measuring the distance between the node it is currently evaluating and the target node.

## Theory
The A* algorithm can be seen as an extension of Dijkstra's shortest path algorithm.<br>
Where dijkstra's algorithm works by simply evaluating a cost to travel between nodes in a graph, A* includes a heuristic to determine if moving to a given node will actually take it closer to the end goal.

