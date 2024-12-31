using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public Color nativeColor;
    public float duration = .3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();

        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }

        spriteRenderers.ForEach(i => nativeColor = i.color);
    }

    private void Update()
    {
        if(_currentTween == null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = nativeColor);
        }
    }

    public void Flash()
    {
        foreach(var s in spriteRenderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }

        _currentTween = null;
    }
}
