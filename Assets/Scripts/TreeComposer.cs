using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class TreeComposer : MonoBehaviour
{
    [SerializeField] Tree _treePrefab;
    [SerializeField] GameObject _piece10;

    public Tree Create(int numberOfRows, int fraction)
    {
        Tree tree = Instantiate(_treePrefab, Vector3.zero, Quaternion.identity);
        tree.Create(numberOfRows, 10, _piece10);
        return tree;
    }
}
