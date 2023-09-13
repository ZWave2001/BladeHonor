using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image[] _backgroundImgs;

    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
        _backgroundImgs = gameObject.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera.a)
    }
}
