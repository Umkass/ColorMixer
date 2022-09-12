using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Level/New Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private string _levelName;
    [Tooltip("the same are possible")]
    [SerializeField] private List<IngredientData> _currentLevelIngredients = new List<IngredientData>();
    [SerializeField] private Color _resultColor;

    public string LevelName { get => _levelName; private set => _levelName = value; }
    public List<IngredientData> CurrentLevelIngredients { get => _currentLevelIngredients; private set => _currentLevelIngredients = value; }
    public Color ResultColor { get => _resultColor; private set => _resultColor = value; }
}