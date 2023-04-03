using DG.Tweening;
using TMPro;
using UnityEngine;

public class PointUIEffect : MonoBehaviour
{
    public TMP_Text pointTextPrefabs;
    public RectTransform targetPos;

    private Camera _cam;
    public float duration;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    private void OnGameStartedHandler()
    {
        _cam = Camera.main;
    }

    public void OnPointCollectedHandler(Vector3 wordPoint,int point)
    {
        var ScreenPoint = _cam.WorldToScreenPoint(wordPoint);
        var pointText = Instantiate(pointTextPrefabs, ScreenPoint, Quaternion.identity, transform);
        pointText.text = "+"+point;
        pointText.transform.DOMove(targetPos.position, duration);
        pointText.transform.DOScale(Vector3.one * 1.25f, duration/2).OnComplete(()=>
        {
            pointText.transform.DOScale(Vector3.one *0.25f, duration / 2).OnComplete(() =>
            {
                //CurrencyManager.Instance.IncreaseCurrency(point);
                Destroy(pointText.gameObject);
            });
        });
    }
}
