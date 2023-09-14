using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BladeHonor
{
    public class ScrollBackGround : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private Transform[] _backgroundImgs;

        private Camera _camera;
        private float _backGroundImgHalfWidth;
        private float _cameraHalfWidth;
        
        
        void Start()
        {
            _camera = Camera.main;
            _backgroundImgs = new[] { transform.GetChild(0).transform, transform.GetChild(1).transform };
            
            _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
            _backGroundImgHalfWidth = _backgroundImgs[0].GetComponent<SpriteRenderer>().bounds.size.x / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (_camera.transform.position.x >=
                (_backgroundImgs[1].position.x + _backGroundImgHalfWidth - _cameraHalfWidth ))
            {
                _backgroundImgs[0].SetLocalPositionX(_backgroundImgs[0].position.x + _backGroundImgHalfWidth * 4);
                _backgroundImgs = _backgroundImgs.OrderBy(trans => trans.position.x).ToArray();
            }

            if (_camera.transform.position.x <=
                (_backgroundImgs[0].position.x - (_backGroundImgHalfWidth - _cameraHalfWidth)))
            {
                _backgroundImgs[1].SetLocalPositionX(_backgroundImgs[1].position.x - _backGroundImgHalfWidth * 4);
                _backgroundImgs = _backgroundImgs.OrderBy(trans => trans.position.x).ToArray();
            }
        }
    }
}
