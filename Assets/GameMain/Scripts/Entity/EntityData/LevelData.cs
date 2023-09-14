// Author: ZWave
// Time: 2023/09/14 16:54
// --------------------------------------------------------------------------

using System;
using GameFramework.DataTable;
using UnityEngine;

namespace BladeHonor
{
    [Serializable]
    public class LevelData : EntityData
    {
        public Vector2[] PlayerSpawnPos
        {
            get;
            set;
        }
        
        public Vector2[] EnemySpawnPos
        {
            get;
            set;
        }
        
        public int[] EnemySpawnId
        {
            get;
            set;
        }
        
        public int LevelStartPos
        {
            get;
            set;
        }
        
        public int LevelEndPos
        {
            get;
            set;
        }
        
        public LevelData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DRLevel> dtLevel = GameEntry.DataTable.GetDataTable<DRLevel>();
            DRLevel drLevel = dtLevel.GetDataRow(typeId);
            PlayerSpawnPos = drLevel.PlayerSpawnPos;
            EnemySpawnPos = drLevel.EnemySpawnPos;
            EnemySpawnId = drLevel.EnemySpawnId;
            LevelStartPos = drLevel.LevelStartPos;
            LevelEndPos = drLevel.LevelEndPos;
        }
        
        
    }
}