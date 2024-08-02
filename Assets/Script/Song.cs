using UnityEngine;

[CreateAssetMenu(fileName = "Song", menuName = "Song/New song", order = 1)]
public class Song : ScriptableObject
{
    public AudioClip _audioClip;
    public float bpm;
    public float tempo;
}