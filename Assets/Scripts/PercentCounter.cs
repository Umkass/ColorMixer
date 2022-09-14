using System;
using UnityEngine;
using UnityEngine.UI;

public class PercentCounter : MonoBehaviour
{
    [SerializeField] private Text _txtPecent;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private UIManager _uiManager;
    private int _percent = 0;

    private void Awake()
    {
        _txtPecent.text = _percent.ToString();
    }

    private void UpdatePercent(int percent)
    {
        _percent = percent;
        _txtPecent.text = _percent.ToString();
        if (percent >= 90)
        {
            _uiManager.LevelComplete();
        }
    }

    public void ResetPercentCounter()
    {
        _percent = 0;
        _txtPecent.text = _percent.ToString();
    }

    public void CheckPercent(Color mixedColor)
    {
        Color resultColor = _levelController.CurrentLevelData.ResultColor;
        Vector3 resultColorVector = new Vector3(resultColor.r, resultColor.g, resultColor.b); //Color RGB as Vector3
        Vector3 mixedColorVector = new Vector3(mixedColor.r, mixedColor.g, mixedColor.b); //Color RGB as Vector3
        // Vector3.Distance is distance between  colors
        // 100 - distance*100 = percent of similarity
        UpdatePercent(Convert.ToInt32(100f - Vector3.Distance(resultColorVector, mixedColorVector) * 100f));
    }
}
