using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Color color;
    public bool isInBlender = false;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //using in Animation Event
    public void MakeNonKinematic()
    {
        _rigidbody.isKinematic = false;
    }
    //using in Animation Event
    public void MakeKinematic()
    {
        _rigidbody.isKinematic = true;
    }
}
