using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private IngredientButtonsController _ingredientBtnsController;
    [SerializeField] private PercentCounter _percentCounter;
    [SerializeField]
    private Button _btnStart,
        _btnBack,
        _btnRestart,
        _btnNext;
    [SerializeField] private GameObject _levelComplete;

    private void Awake()
    {
        _btnBack.gameObject.SetActive(false);
        _btnRestart.gameObject.SetActive(false);
        _percentCounter.gameObject.SetActive(false);
        _levelComplete.gameObject.SetActive(false);
        _btnStart.onClick.AddListener(() =>
        {
            _levelController.StartMixColors();
            _btnStart.gameObject.SetActive(false);
            _ingredientBtnsController.SetupIngredientButtons(_levelController.CurrentLevelData);
            _ingredientBtnsController.ShowIngredientButtons();
            _btnBack.gameObject.SetActive(true);
            _btnRestart.gameObject.SetActive(true);
            _percentCounter.gameObject.SetActive(true);
        });
        _btnBack.onClick.AddListener(() =>
        {
            _levelController.BackToMenu();
            _btnStart.gameObject.SetActive(true);
            _ingredientBtnsController.HideIngredientButtons();
            _btnBack.gameObject.SetActive(false);
            _btnRestart.gameObject.SetActive(false);
            _percentCounter.gameObject.SetActive(false);
        });
        _btnRestart.onClick.AddListener(_levelController.RestartLevel);
        _btnNext.onClick.AddListener(() =>
        {
            _levelComplete.gameObject.SetActive(false);
            _levelController.NextLevel();
            _btnStart.gameObject.SetActive(true);
            _ingredientBtnsController.HideIngredientButtons();
            _btnBack.gameObject.SetActive(false);
            _btnRestart.gameObject.SetActive(false);
            _percentCounter.gameObject.SetActive(false);
            _percentCounter.ResetPercentCounter();
        });
    }

    public void LevelComplete()
    {
        _levelComplete.gameObject.SetActive(true);
    }
}
