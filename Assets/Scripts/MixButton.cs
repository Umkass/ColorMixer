using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation)), DisallowMultipleComponent]
public class MixButton : MonoBehaviour
{
    [SerializeField]
    private ColorMixer _colorMixer;
    [SerializeField]
    private PercentCounter _percentCounter;
    private Animation _animPressButton;

    private void Awake()
    {
        _animPressButton = GetComponent<Animation>();
    }

    public void PressButton()
    {
        _percentCounter.CheckPercent(_colorMixer.MixColours());
        _animPressButton.Play();
    }
}
