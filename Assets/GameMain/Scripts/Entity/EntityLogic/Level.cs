// Author: ZWave
// Time: 2023/09/14 17:07
// --------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Serialization;

namespace BladeHonor
{
    public class Level : Entity
    {
        [SerializeField] private LevelData _levelData;
        [FormerlySerializedAs("_canSpawnEnemyIds")] [SerializeField] private int[] _enemySpawnId;
        [FormerlySerializedAs("_spawnEnemyPos")] [SerializeField] private Vector2[] _enemySpawnPos;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            _levelData = (LevelData)userData;
            _enemySpawnId = _levelData.EnemySpawnId;
            _enemySpawnPos = _levelData.EnemySpawnPos;

        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            var playerPositionX = GlobalVariables.Player;
        }
    }
}