using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PercentCounter _percentCounter;
    [SerializeField]
    private Button _btnStart,
        _btnBack,
        _btnRestart,
        _btnNext;
    [SerializeField] private GameObject _gameMenu,
        _levelCompleteMenu;

    private void OnEnable()
    {
        _percentCounter.levelComplete += LevelComplete;
    }
    private void Awake()
    {
        SetupMainMenuUI();
        _btnStart.onClick.AddListener(() =>
        {
            _levelController.StartGame();
            SetupGameUI();
        });
        _btnBack.onClick.AddListener(() =>
        {
            _levelController.BackToMenu();
            SetupMainMenuUI();
        });
        _btnRestart.onClick.AddListener(_levelController.RestartLevel);
        _btnNext.onClick.AddListener(() =>
        {
            _levelController.NextLevel();
            _percentCounter.ResetPercentCounter();
            SetupMainMenuUI();
        });
    }

    private void SetupMainMenuUI()
    {
        _gameMenu.SetActive(false);
        _levelCompleteMenu.SetActive(false);
        _btnStart.gameObject.SetActive(true);
    }
    private void SetupGameUI()
    {
        _gameMenu.SetActive(true);
        _btnStart.gameObject.SetActive(false);
    }

    private void LevelComplete()
    {
        _levelCompleteMenu.SetActive(true);
    }
    private void OnDisable()
    {
        _percentCounter.levelComplete -= LevelComplete;
    }
}
