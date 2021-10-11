using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScene : MonoBehaviour
{
    [SerializeField]
    protected string _nextSceneName;

    [SerializeField]
    private LoadSceneMode _loadMode = LoadSceneMode.Single;

    [SerializeField]
    private Button _buttonLoadScene;

    [SerializeField]
    private Button _buttonLoadSceneAsync;

    private void OnEnable()
    {
        _buttonLoadScene.onClick.RemoveListener(LoadScene);
        _buttonLoadScene.onClick.AddListener(LoadScene);

        _buttonLoadSceneAsync.onClick.RemoveListener(LoadSceneAsync);
        _buttonLoadSceneAsync.onClick.AddListener(LoadSceneAsync);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_nextSceneName, _loadMode);
    }

    private void LoadSceneAsync()
    {
        SceneManager.LoadSceneAsync(_nextSceneName, _loadMode);
    }
}