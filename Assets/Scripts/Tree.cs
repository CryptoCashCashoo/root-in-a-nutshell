using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class Tree : MonoBehaviour
{
    [SerializeField] GameObject _treeScaler;
    [SerializeField] Material _goodMaterial;
    [SerializeField] Material _badMaterial;

    public float _ROW_HEIGHT = 2f;

    [Header("DEBUG INFO")]
    GameObject _piece;
    public float _fraction;
    public int _numberOfRows;


    public float height => _treeScaler.transform.localScale.y;


    public void Create(int numberOfRows, int fraction, GameObject piece)
    {
        _piece = piece;
        _fraction = fraction;
        _numberOfRows = numberOfRows;
        _Create();
    }

    private void _Create()
    {
        _treeScaler.transform.localScale = new Vector3(1, _ROW_HEIGHT * _numberOfRows, 1);
        for (int i = 0; i < _numberOfRows; i++)
            _CreateRow(i);
    }

    private void _CreateRow(int i)
    {



    }

}
