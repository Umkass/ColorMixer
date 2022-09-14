using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels = new List<LevelData>();
    private int _levelNumber = 0;
    [SerializeField] private LevelData _currentLevelData;

    [SerializeField] private ClientUpdater _client;
    [SerializeField] private ClientRequestLiquid _requestLiquid;
    [SerializeField] private ColorMixer _colorMixer;

    [SerializeField]
    private GameObject _mainCamera,
        _mixerCamera;

    public LevelData CurrentLevelData { get => _currentLevelData; private set => _currentLevelData = value; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            _levelNumber = PlayerPrefs.GetInt("level") - 1;
        }
        else
        {
            PlayerPrefs.SetInt("level", _levelNumber + 1);
        }
        if (_levels != null && _levels.Count > 0)
            _currentLevelData = _levels[_levelNumber];
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
        _mainCamera.SetActive(true);
        _mixerCamera.SetActive(false);
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
        _levelNumber++;
        if (_levelNumber > _levels.Count - 1)
            _levelNumber = 0;

        PlayerPrefs.SetInt("level", _levelNumber + 1);
        _currentLevelData = _levels[_levelNumber];
        _client.UpdateClientModel();
        _requestLiquid.SetRequestLiquidColor(_currentLevelData.ResultColor);
        _requestLiquid.Show();
        _mainCamera.SetActive(true);
        _mixerCamera.SetActive(false);
        _colorMixer.ResetLiquid();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("level", _levelNumber + 1);
    }
}
