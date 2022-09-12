using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField]
    private Button _btnStart,
        _btnBack,
        _btnRestart;
    [SerializeField]
    private GameObject
        _percent;
    [SerializeField] IngredientButtonsController _ingredientBtnsController;

    private void Awake()
    {
        _btnBack.gameObject.SetActive(false);
        _btnRestart.gameObject.SetActive(false);
        _percent.SetActive(false);
        _btnStart.onClick.AddListener(() =>
        {
            _levelController.StartMixColors();
            _btnStart.gameObject.SetActive(false);
            _ingredientBtnsController.SetupIngredientButtons(_levelController.CurrentLevelData);
            _ingredientBtnsController.ShowBtns();
            _btnBack.gameObject.SetActive(true);
            _btnRestart.gameObject.SetActive(true);
            _percent.SetActive(true);
        });
        _btnBack.onClick.AddListener(() =>
        {
            _levelController.BackToMenu();
            _btnStart.gameObject.SetActive(true);
            _ingredientBtnsController.HideBtns();
            _btnBack.gameObject.SetActive(false);
            _btnRestart.gameObject.SetActive(false);
            _percent.SetActive(false);
        });
        _btnRestart.onClick.AddListener(_levelController.RestartLevel);
    }
}
