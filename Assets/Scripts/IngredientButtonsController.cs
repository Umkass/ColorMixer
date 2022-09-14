using System.Collections.Generic;
using UnityEngine;

public class IngredientButtonsController : MonoBehaviour
{
    [SerializeField] private IngredientButton _ingredientButtonPrefab;
    private List<IngredientButton> _ingredientButtons = new List<IngredientButton>();
    private LevelData _currentLevelData;

    private void OnEnable()
    {
        SetupIngredientButtons();
    }

    public void SetupIngredientButtons()
    {
        if(_currentLevelData != LevelController.CurrentLevelData)
        {
            if (_ingredientButtons.Count > 0)
            {
                foreach (var item in _ingredientButtons)
                {
                    Destroy(item.gameObject);
                }
                _ingredientButtons.Clear();
            }
            _currentLevelData = LevelController.CurrentLevelData;
            foreach (var item in _currentLevelData.CurrentLevelIngredients)
            {
                IngredientButton btn = Instantiate(_ingredientButtonPrefab, transform);
                btn.ingredientData = item;
                _ingredientButtons.Add(btn);
            }
        }
    }
    public void DoInteractableIngredientButtons()
    {
        foreach (var item in _ingredientButtons)
        {
            item.Button.interactable = true;
        }
    }

    public void DoUninteractableIngredientButtons()
    {
        foreach (var item in _ingredientButtons)
        {
            item.Button.interactable = false;
        }
    }
}
