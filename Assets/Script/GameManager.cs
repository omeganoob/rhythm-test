using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject _tileHolder;
    [SerializeField] TextMeshProUGUI _ScoreText;
    [SerializeField] GameObject _overPanel;
    private float _score = 0;
    [SerializeField] float _scoreMultiplier = 1;

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
    public void GameOver()
    {
        BeatManager.Instance.StopMusic();
        MoveDown[] moveDowns = _tileHolder.GetComponentsInChildren<MoveDown>();
        if (moveDowns.Length > 0)
        {
            foreach (MoveDown moveDown in moveDowns)
            {
                moveDown.Speed = 0;
            }
        }
        _overPanel.SetActive(true);
    }

    public void AddScore(float score)
    {
        _score += score * _scoreMultiplier;
        _ScoreText.text = _score.ToString();
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex);
        while (!load.isDone)
        {
            yield return null;
        }
    }
}
