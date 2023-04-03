using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenePanel : MonoBehaviour
{
    private Image fadeOutImage;

    private void Awake()
    {
        fadeOutImage = GetComponent<Image>();
    }
    public void FadeOutAndProceed()
    {

        fadeOutImage.DOFade(1, 1).OnComplete(() =>
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextLevel); 
        });
    }
}
