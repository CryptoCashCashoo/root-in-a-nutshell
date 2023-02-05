using System;
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
    public static GameManager Get;
    [SerializeField] GameObject _nutPrefab;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _winMenu;
    [SerializeField] GameObject _gameMenu;
    [SerializeField] GameObject _nutellaPrefab;

    TreeComposer _tc;
    CinemachineBrain _cmBrain;
    [SerializeField] CinemachineVirtualCamera _nutCam;
    [SerializeField] CinemachineVirtualCamera _nutellaCam;


    Tree _currentTree;
    GameObject _currentNut;
    GameObject _currentNutella;

    float _score;

    bool _isPlaying = false;

    public Action<float> _onChangeScore;
    public Action<string> _onChangeLevelName;

    public int _rows = 3;

    void Awake()
    {
        Get = this;
        _tc = GameObject.FindObjectOfType<TreeComposer>();
        _cmBrain = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();


    }

    public void StartGame()
    {
        if (_onChangeLevelName != null)
            _onChangeLevelName.Invoke(GetLevelName());

        _currentTree = _tc.Create(_rows, 10);
        _currentNut = Instantiate(_nutPrefab, new Vector3(0, _currentTree.height, 3.2f), Quaternion.identity);
        _currentNutella = Instantiate(_nutellaPrefab, new Vector3(0, -5f, 3.2f), Quaternion.identity);

        FocusOnNut();

        _isPlaying = true;
        _gameMenu.SetActive(true);
        _score = 0;
    }

    void Update()
    {
        if (_isPlaying == false)
            return;

        if (_onChangeScore != null)
            _onChangeScore.Invoke(GetScore());
    }

    public float GetScore()
    {
        float percentageCompleted = (1f - _currentNut.transform.position.y / _currentTree.height) * 100f;
        float currentScore = Mathf.Clamp(percentageCompleted, 0, 100);
        _score = Mathf.Max(currentScore, _score);
        return _score;
    }

    public string GetLevelName()
    {
        return "Level 1";
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if (_isPlaying == false)
            return;
        _isPlaying = false;
        _currentTree.GetComponent<Mover>().enabled = false;
        _gameMenu.SetActive(false);
        _gameOverMenu.SetActive(true);
    }

    public void WinGame()
    {
        if (_isPlaying == false)
            return;
        _isPlaying = false;
        _gameMenu.SetActive(false);
        _winMenu.SetActive(true);
    }


    public void NextLevel()
    {
        // increment difficulty by 1 point or something
        Destroy(_currentNut.gameObject);
        Destroy(_currentTree.gameObject);
        Destroy(_currentNutella.gameObject);
        StartGame();
    }

    public void ReTryLevel()
    {
        Destroy(_currentNut.gameObject);
        Destroy(_currentTree.gameObject);
        Destroy(_currentNutella.gameObject);
        StartGame();
    }

    public void FocusOnNut()
    {
        _nutCam.Priority = 10;
        _nutellaCam.Priority = 0;
        _nutCam.Follow = _currentNut.transform;
        _nutCam.LookAt = _currentNut.transform;
        _nutCam.transform.position = _currentNut.transform.position + 2 * Vector3.forward;
    }

    public void FocusOnNutella()
    {
        Transform camFocus = _currentNutella.transform.Find("CamFocus");
        _nutCam.Priority = 0;
        _nutellaCam.Priority = 10;
        _nutellaCam.Follow = camFocus;
        _nutellaCam.LookAt = camFocus;
        _nutellaCam.transform.position = camFocus.position + 2 * Vector3.forward;
    }

}
