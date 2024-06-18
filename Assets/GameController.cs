using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    Pathfinding pathfinding;
    Grid grid;

    [SerializeField] private float updateInterval = 1f;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        grid = GetComponent<Grid>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (true)
        {
            grid.UpdateGrid();
            pathfinding.StartFindPath(startPoint.position, endPoint.position);
            yield return new WaitForSeconds(updateInterval); // Adjust the interval as needed
        }
    }
}

