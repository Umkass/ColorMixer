using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    private List<Color> _ingredientColours = new List<Color>();
    private List<Ingredient> _ingredients = new List<Ingredient>();

    private Animator _animator;
    private int _openCoverClip,
        _shakeBlender,
        _mixActionWithFill,
        _mixAction;

    [SerializeField]
    private Renderer _liquidRenderer;
    private bool isFilled = false;

    private Color _currentMixedColor;

    public Color CurrentMixedColor { get => _currentMixedColor; private set => _currentMixedColor = value; }
    public List<Color> IngredientColours { get => _ingredientColours; private set => _ingredientColours = value; }

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _openCoverClip = Animator.StringToHash("OpenCover");
        _shakeBlender = Animator.StringToHash("ShakeBlender");
        _mixActionWithFill = Animator.StringToHash("MixActionWithFill");
        _mixAction = Animator.StringToHash("MixAction");
    }

    public void MixColours()
    {
        float totalRed = 0f;
        float totalGreen = 0f;
        float totalBlue = 0f;

        foreach (Color colour in _ingredientColours)
        {
            totalRed += colour.r;
            totalGreen += colour.g;
            totalBlue += colour.b;
        }

        float numColours = _ingredientColours.Count;
        _currentMixedColor = new Color(totalRed / numColours, totalGreen / numColours, totalBlue / numColours);
        StartMixAnimation();
        _liquidRenderer.material.SetColor("_Color", _currentMixedColor);
    }

    private void StartMixAnimation()
    {
        if (!isFilled)
        {
            _animator.Play(_mixActionWithFill);
            isFilled = true;
        }
        else
        {
            _animator.Play(_mixAction);
        }
        foreach (var item in _ingredients)
        {
            Destroy(item.gameObject);
        }
        _ingredients.Clear();
    }

    public void ResetLiquid()
    {
        isFilled = false;
        _ingredients.Clear();
        _ingredientColours.Clear();
        _liquidRenderer.material.SetColor("_Color", Color.white);
    }

    public void OpenCoverAnimation()
    {
        _animator.Play(_openCoverClip);
    }

    private void ShakeBlenderAnimation()
    {
        _animator.Play(_shakeBlender);
    }
    private void OnTriggerEnter(Collider other)
    {
        Ingredient newIngredient = null;

        if (other.GetComponent<Ingredient>() != null)
            newIngredient = other.GetComponent<Ingredient>();

        if (newIngredient != null && !newIngredient.isInBlender)
        {
            newIngredient.isInBlender = true; //multiple trigger protection
            _ingredients.Add(newIngredient);
            _ingredientColours.Add(newIngredient.color);
            ShakeBlenderAnimation();
        }
    }
}
