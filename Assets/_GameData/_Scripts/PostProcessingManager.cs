using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager Instance {get; private set;}
    [SerializeField] private Volume generalVolume;
    [SerializeField] private ColorParameter biteVignetteColor;
    [SerializeField] private ColorParameter shootVignetteColor;
    [SerializeField] private ColorParameter defaultColor;
    [SerializeField] private ColorParameter nightColor;
    [SerializeField] private ColorParameter dayColor;
    private Tweener _damageVignetteTween;
    private Tweener _healVignetteTween;
    private Tweener _hideVignetteTween;
    private Vignette _vignette;
    private Bloom _bloom;
    private float _alpha;

    private void Awake()
    {
        Instance = this;

        if (generalVolume.profile.TryGet<Vignette>(out var vignette))
        {
            _vignette = vignette;
            vignette.intensity.overrideState = true;
            vignette.color.overrideState = true;
        }
        if (generalVolume.profile.TryGet<Bloom>(out var bloom))
        {
            _bloom = bloom;
            bloom.intensity.overrideState = true;
        }
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void OnSunnyZoneEnteredHandler()
    {
        _bloom.intensity.value = 3f;

        _vignette.intensity.value = 0f;
        _vignette.color.value = dayColor.value;
        defaultColor = dayColor;
    }

    private void OnSunnyZoneExitedHandlder()
    {
        _bloom.intensity.value = 1f;

        _vignette.intensity.value = .4f;
        _vignette.color.value = nightColor.value;
        defaultColor = nightColor;
    }

    private void OnDamageTakenHandler()
    {
        _vignette.color.value = shootVignetteColor.value;
        KillTweens();
        _damageVignetteTween = DOTween.To(() => _alpha, x => _alpha = x, 1f, 1f).OnUpdate(() =>
        {
            var color = Color.Lerp(_vignette.color.value, defaultColor.value, _alpha);
            _vignette.color.value = color;
        });
    }

    private void OnBiteOccuredHandler(bool _)
    {
        _vignette.color.value = biteVignetteColor.value;
        KillTweens();
        _healVignetteTween = DOTween.To(() => _alpha, x => _alpha = x, 1f, 8).OnUpdate(() =>
        {
            var color = Color.Lerp(_vignette.color.value, defaultColor.value, _alpha);
            _vignette.color.value = color;
        });
    }

    private void OnLevelEndedHandler()
    {
        _bloom.intensity.value = 1f;

        _vignette.intensity.value = .4f;
        _vignette.color.value = nightColor.value;
        defaultColor = nightColor;
    }

    private void KillTweens()
    {
        _alpha =0;
        _hideVignetteTween.Kill();
        _damageVignetteTween.Kill();
        _healVignetteTween.Kill();
    }
}