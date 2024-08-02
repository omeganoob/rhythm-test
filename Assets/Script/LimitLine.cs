using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLine : MonoBehaviour
{
    public static LimitLine Instance {get; private set;}

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetNewPosY(float y) {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
