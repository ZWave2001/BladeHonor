// Author: ZWave
// Time: 2023/09/14 17:07
// --------------------------------------------------------------------------

using UnityEngine;

namespace BladeHonor
{
    public class Level : Entity
    {
        [SerializeField] private LevelData _levelData;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            _levelData = (LevelData)userData;
        }
    }
}