using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private Song _song;
    private float _bpm;
    [SerializeField] private TileSpawner _tileSpawner;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;

    private bool _isPlaying = false;
    public bool IsPlaying { get { return _isPlaying; } private set { _isPlaying = value; } }
    public static BeatManager Instance {get; private set;}

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

    void Start()
    {
        _audioSource.clip = _song._audioClip;
        _bpm = _song.bpm;
        _tileSpawner.TileSPeed = _song.tempo;
    }

    void FixedUpdate()
    {
        if(!_isPlaying) return;
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = _audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm));
            interval.CheckForNewInterval(sampledTime);
        }
    }
    public void StartMusic() {
        _isPlaying = true;
        _audioSource.Play();
    }

    public void StopMusic() {
        _isPlaying = false;
        _audioSource.Stop();
    }
}

[System.Serializable]
public class Intervals {
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;
    public float GetIntervalLength(float bpm) {
        return 60f / (bpm * _steps);
    }
    public void CheckForNewInterval (float interval) {
        if(Mathf.FloorToInt(interval) != _lastInterval) {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
