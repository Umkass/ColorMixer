using UnityEngine;

public class WobbleLiquid : MonoBehaviour
{
    private Renderer _rend;
    private Vector3 _lastPos;
    private Vector3 _velocity;
    private Vector3 _lastRot;
    private Vector3 _angularVelocity;
    [SerializeField] private float _maxWobble = 0.03f;
    [SerializeField] private float _wobbleSpeed = 1f;
    [SerializeField] private float _recovery = 1f;
    private float _wobbleAmountX;
    private float _wobbleAmountZ;
    private float _wobbleAmountToAddX;
    private float _wobbleAmountToAddZ;
    private float _pulse;
    private float _time = 0.5f;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        _time += Time.deltaTime;
        // decrease wobble over time
        _wobbleAmountToAddX = Mathf.Lerp(_wobbleAmountToAddX, 0, Time.deltaTime * (_recovery));
        _wobbleAmountToAddZ = Mathf.Lerp(_wobbleAmountToAddZ, 0, Time.deltaTime * (_recovery));

        // make a sine wave of the decreasing wobble
        _pulse = 2 * Mathf.PI * _wobbleSpeed;
        _wobbleAmountX = _wobbleAmountToAddX * Mathf.Sin(_pulse * _time);
        _wobbleAmountZ = _wobbleAmountToAddZ * Mathf.Sin(_pulse * _time);

        // send it to the shader
        _rend.material.SetFloat("_WobbleX", _wobbleAmountX);
        _rend.material.SetFloat("_WobbleZ", _wobbleAmountZ);

        // velocity
        _velocity = (_lastPos - transform.position) / Time.deltaTime;
        _angularVelocity = transform.rotation.eulerAngles - _lastRot;


        // add clamped velocity to wobble
        _wobbleAmountToAddX += Mathf.Clamp((_velocity.x + (_angularVelocity.z * 0.2f)) * _maxWobble, -_maxWobble, _maxWobble);
        _wobbleAmountToAddZ += Mathf.Clamp((_velocity.z + (_angularVelocity.x * 0.2f)) * _maxWobble, -_maxWobble, _maxWobble);

        // keep last position
        _lastPos = transform.position;
        _lastRot = transform.rotation.eulerAngles;
    }
}