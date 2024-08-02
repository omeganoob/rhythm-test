using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] Sprite _clickedSprite;
    // [SerializeField] LayerMask _tileLayer;
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 100);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<IClick>().Clicked();
                }
                else {
                    if(BeatManager.Instance.IsPlaying) {
                        GameManager.Instance.GameOver();
                    }
                }
            }
        }
    }
}
