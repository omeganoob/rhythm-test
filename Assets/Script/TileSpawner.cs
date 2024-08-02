using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    [SerializeField] TextAsset _timeLine;
    [SerializeField] GameObject _tilePrefab;
    [SerializeField] GameObject _tileHolder;
    [SerializeField] float _timer = 1f;
    [SerializeField] private float _tileSpeed = 2f;
    private List<GameObject> _tiles;
    public float TileSPeed {
        get { return _tileSpeed; }
        set {
            if (_tileSpeed != value && _tileSpeed > 0) {
                _tileSpeed = value;
            }
        }
    }
    [SerializeField] bool _autoSpawn;
    private Vector2 size;
    private float[] _timings;
    void Awake()
    {
        size = new Vector2(
            GetWidth(_tilePrefab.GetComponent<SpriteRenderer>()),
            GetHeight(_tilePrefab.GetComponent<SpriteRenderer>())
        );
        ParseNoteData();
    }
    void Start()
    {
        _tiles = new List<GameObject>();
    }
    void Update()
    {
        if (_autoSpawn)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                Spawn();
                _timer = size.y / _tileSpeed;
            }
        }
    }
    
    void ParseNoteData() {
        string[] textTimings = _timeLine.text.Split(',');
        _timings = new float[textTimings.Length];
        for(int i = 0; i < textTimings.Length; ++i) {
            if(float.TryParse(textTimings[i], out float time)) {
                _timings[i] = time;
            }
        }
    }
    public void Spawn()
    {
        int r = Random.Range(0, 4);
        Vector3 offSet = new Vector3(
            size.x * (0.5f + r - 2),
            0
        );
        Vector3 spawnPos = transform.position + offSet;
        GameObject tile = Instantiate(_tilePrefab, spawnPos, Quaternion.identity, _tileHolder.transform);
        tile.GetComponent<MoveDown>().Speed = _tileSpeed;
    }

    public static float GetHeight(SpriteRenderer sprite)
    {
        return Mathf.Abs((sprite.bounds.min - sprite.bounds.max).y);
    }

    public static float GetWidth(SpriteRenderer sprite)
    {
        return Mathf.Abs((sprite.bounds.min - sprite.bounds.max).x);

    }
}