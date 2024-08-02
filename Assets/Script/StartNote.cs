using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNote : MonoBehaviour, IClick
{
    [SerializeField] MoveDown _moveDown;
    [SerializeField] BeatManager _beatManager;
    [SerializeField] GameObject _tutHand;
    public void Clicked() {
        _moveDown.enabled = true;
        _beatManager.StartMusic();
        Destroy(_tutHand);
    }
}
