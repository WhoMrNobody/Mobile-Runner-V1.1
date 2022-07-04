using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpikeTraps : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, -0.5f, Space.Self);
    }
}
