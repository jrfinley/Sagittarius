﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Validator;
using Random = UnityEngine.Random;

public class Grid
{
    private int _width;
    private int _height;
    public float _nodeUnitSize;

    private FindPath _path = null;
    private Node[,] _grid = null;
    private HashSet<Node> _unwalkableNodes = new HashSet<Node>();

    public Grid(int width, int height, float nodeUnitSize)
    {
        _width = width;
        _height = height;
        _nodeUnitSize = nodeUnitSize;

        _grid = new Node[_width, _height];
        _path = new FindPath(this, _width * _height);
        _CreateGrid();
    }

    private void _CreateGrid()
    {
        GameObject parent = new GameObject("Nodes");
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3 position = new Vector3(x, 0f, y);
                _CreateNode(position, x, y, parent);
            }
        }
    }

    private void _CreateNode(Vector3 position, int x, int y, GameObject parent)
    {
        //GameObject visualNode = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //visualNode.transform.position = position;
        //visualNode.transform.parent = parent.transform;
        //visualNode.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);
        //Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
        //visualNode.transform.rotation = rotation;

        _grid[x, y] = new Node(position, x, y, 1f);

        if (Random.value > 0.5f)
            _grid[x, y].movementPenalty = 500;
        else
            _grid[x, y].movementPenalty = UnityEngine.Random.Range(0, 100);

        //if (_grid[x, y].movementPenalty == 500)
        //    visualNode.GetComponent<MeshRenderer>().material.color = Color.black;
        //else if (_grid[x, y].movementPenalty > 75)
        //    visualNode.GetComponent<MeshRenderer>().material.color = Color.red;
        //else if (_grid[x, y].movementPenalty > 50)
        //    visualNode.GetComponent<MeshRenderer>().material.color = Color.yellow;
        //else if (_grid[x, y].movementPenalty > 25)
        //    visualNode.GetComponent<MeshRenderer>().material.color = Color.green;
        //else
        //    visualNode.GetComponent<MeshRenderer>().material.color = Color.cyan;
    }

    public List<Node> GetNeighbours(Node currentNode)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (Mathf.Abs(x) != Mathf.Abs(y))
                    continue;

                if (IsWalkable(x + currentNode.x, y + currentNode.y, GetNodeFromPoint(x + currentNode.x, y + currentNode.y)))
                    neighbours.Add(_grid[x + currentNode.x, y + currentNode.y]);
            }
        }
        return neighbours;
    }

    public Node GetNodeFromPoint(int nodeX, int nodeY)
    {
        float percentX = nodeX / ((float)_width);
        float percentY = nodeY / ((float)_height);
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((((_width / _nodeUnitSize)) * percentX));
        int y = Mathf.RoundToInt((((_height / _nodeUnitSize)) * percentY));
        x = Mathf.Clamp(x, 0, _width - 1);
        y = Mathf.Clamp(y, 0, _height - 1);
        return _grid[x, y];
    }

    public List<Node> GetPath(Vector3 startPosition, Vector3 targetPosition, Vector3 start, Vector3 target)
    {
        Node startNode = GetNodeFromPoint((int)startPosition.x, (int)startPosition.z);
        Node targetNode = GetNodeFromPoint((int)targetPosition.x, (int)targetPosition.z);
        _unwalkableNodes.Add(GetNodeFromPoint((int)start.x, (int)start.z));
        _unwalkableNodes.Add(GetNodeFromPoint((int)target.x, (int)target.z));
        return _path.GetPath(startNode, targetNode);
    }

    public bool IsWalkable(int x, int y, Node node)
    {
        return (x >= 0 && x < _width) && (y >= 0 && y < _height) && !_unwalkableNodes.Contains(node);
    }
}