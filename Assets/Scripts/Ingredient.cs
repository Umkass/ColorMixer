using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Color color;
    public bool isInBlender = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //using in Animation Event
    public void MakeNonKinematic()
    {
        rb.isKinematic = false;
    }
    public void MakeKinematic()
    {
        rb.isKinematic = true;
    }
}
