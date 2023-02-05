using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;


public class Tree : MonoBehaviour
{
    [SerializeField] GameObject _treeScaler;
    [SerializeField] Material _goodMaterial;
    [SerializeField] Material _badMaterial;

    public float _ROW_HEIGHT = 5f;

    [Header("DEBUG INFO")]
    GameObject _piece;
    public int _fraction;
    public int _numberOfRows;


    public float height => _treeScaler.transform.localScale.y;

    UnityEvent _onGameOver;

    public void Awake()
    {
        _onGameOver = new UnityEvent();
        _onGameOver.AddListener(() => { GameManager.Get.GameOver(); });
    }


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
        int elapsed = Random.Range(0, _fraction);
        for (int k = 0; k < _fraction; k++)
        {
            if (k == elapsed)
                continue;
            GameObject obj = Instantiate(_piece, new Vector3(0, i * _ROW_HEIGHT, 0), Quaternion.Euler(0, k * 360 / _fraction, 0), this.transform);
            MeshRenderer var = obj.GetComponentInChildren<MeshRenderer>();
            var.material = _goodMaterial;
            if (Random.Range(0, 100) <= 10)
            {
                var.material = _badMaterial;
                obj.GetComponentInChildren<PizzaSlide>()._onCollision = _onGameOver;
            }
        }
    }

}
