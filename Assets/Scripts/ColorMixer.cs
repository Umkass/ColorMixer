using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    [SerializeField] private List<Color> _ingredientColours = new List<Color>();
    [SerializeField] private Color _resultColor; //удалить

    private Animator _animator;
    private int _openCoverClip,
        _shakeBlender;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _openCoverClip = Animator.StringToHash("OpenCover");
        _shakeBlender = Animator.StringToHash("ShakeBlender");
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
        _resultColor = new Color(totalRed / numColours, totalGreen / numColours, totalBlue / numColours);
        return new Color(totalRed / numColours, totalGreen / numColours, totalBlue / numColours);
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
            _ingredientColours.Add(newIngredient.color);
            ShakeBlender();
        }
    }
}
