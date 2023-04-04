using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOutEffect : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private FadeType fadeType;


    private void Start()
    {
        if (fadeType == FadeType.FADEIN)
        {
            fadeImage.enabled = true;
            fadeImage.DOFade(0, 1).OnComplete(() =>
            {
                fadeImage.enabled = false;
            });
        }
    }

    public void FadeOutAndProceed()
    {

        fadeImage.DOFade(1, 1).OnComplete(() =>
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextLevel); 
        });
    }

    public enum FadeType
    {
        FADEOUT,
        FADEIN
    }
}
