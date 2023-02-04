using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class Mover : MonoBehaviour
{
    public float _rotationSpeed;
    private int _directionPressed;

    private Vector3 _mouseReference;
    public float _mouseSensivity;

    void Update()
    {
        _directionPressed = 0;

        if (IsMousePressed())
            MouseRotation();
        else
            KeyBoardRotation();
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, _directionPressed * _rotationSpeed * 60f * Time.fixedDeltaTime);
    }

    private void KeyBoardRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            _directionPressed += 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            _directionPressed -= 1;
    }


    private void MouseRotation()
    {
        Vector3 rotation = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - _mouseReference);
        rotation.y = -(mouseOffset.x + mouseOffset.y) * _mouseSensivity;

        transform.Rotate(rotation);
        _mouseReference = Input.mousePosition;
    }


    private bool _isMousePressed;
    bool IsMousePressed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMousePressed = true;
            _mouseReference = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
            _isMousePressed = false;
        return _isMousePressed;
    }

}
