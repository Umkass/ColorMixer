using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Ingredient/New Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private Ingredient _prefab;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;

    public Ingredient Prefab { get => _prefab; private set => _prefab = value; }
    public Sprite Sprite { get => _sprite; private set => _sprite = value; }
    public Color Color { get => _color; private set => _color = value; }
}
