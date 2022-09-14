using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    [SerializeField] private List<Color> _ingredientColours = new List<Color>();
    [SerializeField] private List<Ingredient> _ingredients = new List<Ingredient>();

    private Animator _animator;
    private int _openCoverClip,
        _shakeBlender,
        _mixActionWithFill,
        _mixAction;

    [SerializeField]
    private Renderer _liquidRenderer;

    private bool isFilled = false;
    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _openCoverClip = Animator.StringToHash("OpenCover");
        _shakeBlender = Animator.StringToHash("ShakeBlender");
        _mixActionWithFill = Animator.StringToHash("MixActionWithFill");
        _mixAction = Animator.StringToHash("MixAction");
    }

    public Color MixColours()   
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
        Color _resultColor = new Color(totalRed / numColours, totalGreen / numColours, totalBlue / numColours);
        MixAction();
        _liquidRenderer.material.SetColor("_Color", _resultColor);
        return _resultColor;
    }


    private void MixAction()
    {
        Debug.Log(isFilled);
        if (!isFilled)
        {
            Debug.Log("WithFill");
            _animator.Play(_mixActionWithFill);
            isFilled = true;
        }
        else
        {
            Debug.Log("MixAction");
            _animator.Play(_mixAction);
        }
        foreach (var item in _ingredients)
        {
            Destroy(item.gameObject);
        }
        _ingredients.Clear();
    }
    public void OpenCover()
    {
        _animator.Play(_openCoverClip);
    }

    private void ShakeBlender()
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
            ShakeBlender();
        }
    }
}
