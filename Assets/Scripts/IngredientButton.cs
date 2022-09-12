using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private IngredientButtonsController _ingredientBtnsController;
    [SerializeField]
    private Image _image;
    private Button _button;
    [HideInInspector]
    public IngredientData ingredientData;
    private ColorMixer _colorMixer;

    private Vector3 _spawnPosition = new Vector3(-7.039f, 1.1f, -2.58f);

    public Button Button { get => _button; private set => _button = value; }

    void Awake()
    {
        _ingredientBtnsController = GetComponentInParent<IngredientButtonsController>();
        _colorMixer = FindObjectOfType<ColorMixer>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            AddIngredient();
        });
    }

    private void Start()
    {
        _image.sprite = ingredientData.Sprite;
    }

    private void AddIngredient()
    {
        StartCoroutine(waitAnimations());
        _colorMixer.OpenCover();
        Ingredient newIngredient = Instantiate(ingredientData.Prefab, _spawnPosition, ingredientData.Prefab.transform.rotation);
        newIngredient.color = ingredientData.Color;
    }

    IEnumerator waitAnimations()
    {
        _ingredientBtnsController.DoUninteractableBtns();
        yield return new WaitForSeconds(1.1f);
        _ingredientBtnsController.DoInteractableBtns();
    }
}
