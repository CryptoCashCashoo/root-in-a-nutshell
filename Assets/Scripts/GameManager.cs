using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Get;
    TreeComposer _tc;

    void Awake()
    {
        Get = this;
        Debug.Log(SystemInfo.graphicsDeviceType);
        _tc = GameObject.FindObjectOfType<TreeComposer>();
    }

    public void StartGame()
    {
        Tree tree = _tc.Create(10, 10);
        Debug.Log(tree._numberOfRows);
        Debug.Log(tree.height);
    }
}
