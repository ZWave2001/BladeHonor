using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BladeHonor
{
    public class CameraFollow : MonoBehaviour
    {
        public static GameObject Player;
        private Camera _camera;
        
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                _camera.transform.SetLocalPositionX(Player.transform.position.x); 
            }
        }
    }

}
