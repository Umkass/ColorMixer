using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation)), DisallowMultipleComponent]
public class MixButton : MonoBehaviour
{
    [SerializeField] private ColorMixer _colorMixer;
    [SerializeField] private PercentCounter _percentCounter;
    private Animation _animPressButton;
    public bool isInteractable = true;

    private void Awake()
    {
        _animPressButton = GetComponent<Animation>();
    }

    public void PressButton()
    {
        if (_colorMixer.IngredientColours.Count > 0)
        {
            _colorMixer.MixColours();
            _animPressButton.Play();
            StartCoroutine(WaitAnimations());
        }
    }

    private IEnumerator WaitAnimations()
    {
        isInteractable = false;
        yield return new WaitForSeconds(2f); //there are several animations, so I chose the time
        _percentCounter.CheckPercent(_colorMixer.CurrentMixedColor);
        isInteractable = true;
    }
}
