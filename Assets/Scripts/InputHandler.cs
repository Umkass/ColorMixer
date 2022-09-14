using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera _mixerCamera;
    private LayerMask _layerMask = 1 << 6;

    private void FixedUpdate()
    {
        if (_mixerCamera.isActiveAndEnabled)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                RaycastMixButton(Input.mousePosition);
            }
#elif UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    RaycastMixButton(touch.position);
                }
            }
#endif
        }
    }

    private void RaycastMixButton(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = _mixerCamera.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out hit, _layerMask))
        {
            MixButton mixerButton = hit.collider.gameObject.GetComponent<MixButton>();
            if (mixerButton != null && mixerButton.isInteractable)
            {
                mixerButton.PressButton();
            }
        }
    }
}
