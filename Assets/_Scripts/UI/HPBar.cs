using System;
using UnityEngine;
public class HPBar : MonoBehaviour
{
    private Vector3 _initialScale;
    private Vector3 _currentScale;
    private void Start()
    {
        _initialScale=GetComponent<RectTransform>().sizeDelta;
    }
    private void LateUpdate()
    {
        GetComponent<RectTransform>().sizeDelta=_initialScale;
    }
}
