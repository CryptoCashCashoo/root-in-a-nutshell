using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Get;

    void Awake()
    {
        Get = this;
        Debug.Log(SystemInfo.graphicsDeviceType);
    }

    public void StartGame()
    {

    }
}
