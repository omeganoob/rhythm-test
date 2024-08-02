using System.Collections;
using UnityEngine;

public class MusicTile : MonoBehaviour, IClick
{
    private bool _isPassed = false;
    [SerializeField] private ParticleSystem _hitSpark;
    private LimitLine _lines;
    private PerformancText _performText;
    void Start()
    {
        _lines = LimitLine.Instance;
        _performText = PerformancText.Instance;
    }

    void Update()
    {
        if(transform.position.y < -4 && !_isPassed) {
            GameManager.Instance.GameOver();
        }

    }
    public void Clicked()
    {
        if(_isPassed) return;
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.35f);
        StartCoroutine(SpawnSparks());
        var dis = Mathf.Abs(transform.position.y - LimitLine.Instance.gameObject.transform.position.y);
        if (dis <= 0.2f)
        {
            _performText.OnHitPerform(EHitPerform.PERFECT);
            GameManager.Instance.AddScore(3);
        }
        else if (dis <= 0.4)
        {
            _performText.OnHitPerform(EHitPerform.GREAT);
            GameManager.Instance.AddScore(2);
        }
        else
        {
            _performText.OnHitPerform(EHitPerform.COOL);
            GameManager.Instance.AddScore(1);
        }
        _lines.SetNewPosY(transform.position.y);
        _isPassed = true;
    }

    IEnumerator SpawnSparks()
    {
        ParticleSystem spark = Instantiate<ParticleSystem>(_hitSpark, transform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(spark);
    }
}
