using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    public float Speed {
        get { return _speed; }
        set {
            if (_speed != value && value >= 0) {
                _speed = value;
            }
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -7) {
            Destroy(gameObject);
        }

    }
}
