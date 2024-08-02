using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PerformancText : MonoBehaviour
{
    public static PerformancText Instance { get; private set; }

    [SerializeField] SpriteRenderer _text;
    [SerializeField] SpriteRenderer _bg;
    [SerializeField] List<Sprite> _textSprites;
    [SerializeField] float _alpha;
    [SerializeField] float _fadeTime;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _text.color = new Color(1f, 1f, 1f, 0);
        _bg.color = new Color(1f, 1f, 1f, 0);
    }

    void Update()
    {
        if(_alpha > 0) {
            _alpha -= Time.deltaTime;
        }
        _text.color = new Color(1f, 1f, 1f, _alpha);
        _bg.color = new Color(1f, 1f, 1f, _alpha);
    }

    public void OnHitPerform(EHitPerform eHitPerform)
    {
        _alpha = 1;
        switch (eHitPerform)
        {
            case EHitPerform.COOL:
                _text.sprite = _textSprites[0];
                break;
            case EHitPerform.GREAT:
                _text.sprite = _textSprites[1];
                break;
            case EHitPerform.PERFECT:
                _text.sprite = _textSprites[2];
                break;
        }
    }
}
