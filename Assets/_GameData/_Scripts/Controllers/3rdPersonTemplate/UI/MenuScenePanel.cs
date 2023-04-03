using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenePanel : MonoBehaviour
{
    [SerializeField] private Image fadeOutImage;
    [SerializeField] private FadeType fadeType;


    private void Start()
    {
        if (fadeType == FadeType.FADEIN)
        {
            fadeOutImage.DOFade(0, 1);
        }
    }

    public void FadeOutAndProceed()
    {

        fadeOutImage.DOFade(1, 1).OnComplete(() =>
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
