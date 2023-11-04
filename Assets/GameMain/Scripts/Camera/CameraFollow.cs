using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BladeHonor
{
    public class CameraFollow : MonoBehaviour
    {
        public static int startPosX;
        public static int endPosX;
        
        private Camera _camera;
        private float _halfCameraWidth;
        
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _halfCameraWidth = _camera.orthographicSize * _camera.aspect;
            GlobalVariables.FiledOfView = _halfCameraWidth;
        }

        // Update is called once per frame
        void Update()
        {
            if (GlobalVariables.Player != null)
            {
                if (GlobalVariables.Player.transform.position.x < startPosX +  _halfCameraWidth)
                {
                    _camera.transform.SetLocalPositionX(startPosX + _halfCameraWidth);
                }

                else if (GlobalVariables.Player.transform.position.x > endPosX -  _halfCameraWidth)
                {
                    _camera.transform.SetLocalPositionX(endPosX - _halfCameraWidth);
                }
                else
                {
                    _camera.transform.SetLocalPositionX(GlobalVariables.Player.transform.position.x);
                }
            }
        }
    }

}
