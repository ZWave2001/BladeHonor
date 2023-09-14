using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BladeHonor
{
    public class CameraFollow : MonoBehaviour
    {
        public static GameObject Player;
        public static int startPosX;
        public static int endPosX;
        
        private Camera _camera;
        private float _halfCameraWidth;
        
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _halfCameraWidth = _camera.orthographicSize * _camera.aspect;
        }

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                if (Player.transform.position.x < startPosX + 2 * _halfCameraWidth)
                {
                    _camera.transform.SetLocalPositionX(startPosX + _halfCameraWidth);
                }

                else if (Player.transform.position.x > endPosX - 2 * _halfCameraWidth)
                {
                    _camera.transform.SetLocalPositionX(endPosX - _halfCameraWidth);
                }
                else
                {
                    _camera.transform.SetLocalPositionX(Player.transform.position.x);
                }
            }
        }
    }

}
