using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class FixPosition : MonoBehaviour
{

    public bool _fixX = false;
    public bool _fixY = false;
    public bool _fixZ = false;

    Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 curr = transform.position;
        transform.position = new Vector3(_fixX ? _startPosition.x : curr.x, _fixY ? _startPosition.y : curr.y, _fixZ ? _startPosition.z : curr.z);
    }
}
