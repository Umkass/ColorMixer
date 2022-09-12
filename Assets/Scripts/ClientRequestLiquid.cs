using UnityEngine;
using UnityEngine.UI;

public class ClientRequestLiquid : MonoBehaviour
{
    [SerializeField] private Image _requestLiquid;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        FaceToCamera();
    }
    public void SetRequestLiquidColor(Color color)
    {
        _requestLiquid.color = color;
    }

    private void FaceToCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
