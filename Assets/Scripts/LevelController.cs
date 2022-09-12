using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels = new List<LevelData>();
    private int _levelNum = 0;
    [SerializeField] private LevelData _currentLevelData;

    [SerializeField] private Client _client;
    [SerializeField] private ClientRequestLiquid _requestLiquid;

    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _mixerCamera;

    public LevelData CurrentLevelData { get => _currentLevelData; private set => _currentLevelData = value; }

    private void Awake()
    {
        if (_levels != null && _levels.Count > 0)
            _currentLevelData = _levels[_levelNum];
    }
    private void Start()
    {
        StartLevel();
    }
    private void StartLevel()
    {
        _client.UpdateClientModel();
        _requestLiquid.SetRequestLiquidColor(_currentLevelData.ResultColor);
        _requestLiquid.Show();
        _mixerCamera.SetActive(false);
        _mainCamera.SetActive(true);
    }

    public void BackToMenu()
    {
        _mainCamera.SetActive(true);
        _mixerCamera.SetActive(false);
        _requestLiquid.Show();
    }

    public void StartMixColors()
    {
        _mixerCamera.gameObject.SetActive(true);
        _mainCamera.gameObject.SetActive(false);
        _requestLiquid.Hide();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        _levelNum++;
        _currentLevelData = _levels[_levelNum];
        StartLevel();
    }
}
