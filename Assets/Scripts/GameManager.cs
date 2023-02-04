using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _nut;

    public static GameManager Get;

    TreeComposer _tc;
    [SerializeField] Cinemachine.CinemachineBrain _cmBrain;

    void Awake()
    {
        Get = this;
        Debug.Log(SystemInfo.graphicsDeviceType);
        _tc = GameObject.FindObjectOfType<TreeComposer>();
        _cmBrain = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();

    }

    public void StartGame()
    {
        Tree tree = _tc.Create(10, 10);
        GameObject nut = Instantiate(_nut, new Vector3(0, tree.height, 3.2f), Quaternion.identity);
        _cmBrain.ActiveVirtualCamera.Follow = nut.transform;
        _cmBrain.ActiveVirtualCamera.LookAt = nut.transform;
        _cmBrain.transform.position = nut.transform.position + 2 * Vector3.forward;

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
