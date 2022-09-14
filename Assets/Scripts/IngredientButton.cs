using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private IngredientButtonsController _ingredientBtnsController;
    [HideInInspector] public IngredientData ingredientData;
    private ColorMixer _colorMixer;
    private MixButton _mixButton;

    [SerializeField] private Image _image;
    private Button _button;
    private Vector3 _spawnPosition = new Vector3(-7.039f, 1.1f, -2.58f);

    public Button Button { get => _button; private set => _button = value; }

    private void Awake()
    {
        _ingredientBtnsController = GetComponentInParent<IngredientButtonsController>();
        _colorMixer = FindObjectOfType<ColorMixer>();
        _mixButton = FindObjectOfType<MixButton>();
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
        StartCoroutine(WaitAnimations());
        _colorMixer.OpenCoverAnimation();
        Ingredient newIngredient = Instantiate(ingredientData.Prefab, _spawnPosition, ingredientData.Prefab.transform.rotation);
        newIngredient.color = ingredientData.Color;
    }

    private IEnumerator WaitAnimations()
    {
        _mixButton.isInteractable = false;
        _ingredientBtnsController.DoUninteractableIngredientButtons();
        yield return new WaitForSeconds(1.75f); //there are several animations, so I chose the time
        _ingredientBtnsController.DoInteractableIngredientButtons();
        _mixButton.isInteractable = true;
    }

    private void OnDisable()
    {
        _mixButton.isInteractable = true;
    }

    private void OnDestroy()
    {
        _mixButton.isInteractable = true;
    }
}
