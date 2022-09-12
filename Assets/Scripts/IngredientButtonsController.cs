using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButtonsController : MonoBehaviour
{
    [SerializeField]
    private IngredientButton _ingredientButtonPrefab;
    private List<IngredientButton> _ingredientBtns = new List<IngredientButton>();

    public void SetupIngredientButtons(LevelData currentLevelData)
    {
        foreach (var item in currentLevelData.CurrentLevelIngredients)
        {
            IngredientButton btn = Instantiate(_ingredientButtonPrefab, transform);
            btn.ingredientData = item;
            _ingredientBtns.Add(btn);
        }
    }
    public void DoInteractableBtns()
    {
        foreach (var item in _ingredientBtns)
        {
            item.Button.interactable = true;
        }
    }

    public void DoUninteractableBtns()
    {
        foreach (var item in _ingredientBtns)
        {
            item.Button.interactable = false;
        }
    }

    public void HideBtns()
    {
        gameObject.SetActive(false);
    }
    public void ShowBtns()
    {
        gameObject.SetActive(true);
    }
}
