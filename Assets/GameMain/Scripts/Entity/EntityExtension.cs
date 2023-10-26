//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public static class EntityExtension
    {
        //Note:
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }
        

        private static void ShowEntity(this EntityComponent entityComponent, Type logicType , int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            IDataTable<DREntityGroup> dtEntityGroup = GameEntry.DataTable.GetDataTable<DREntityGroup>();
            DREntityGroup drEntityGroup = dtEntityGroup.GetDataRow(drEntity.EntityGroupId);
            string entityGroup = drEntityGroup.EntityGroupName;

            //实体组在需要的时候会创建 不需要自己在Entity中手动添加了
            GameEntry.Entity.AddEntityGroup(entityGroup, drEntityGroup.InstanceAutoReleaseInterval,
                drEntityGroup.InstanceCapacity, drEntityGroup.InstanceExpireTime, drEntityGroup.InstancePriority);
            
            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetType ,drEntity.AssetName), entityGroup, priority, data);
        }

        

        public static void ShowCharacter(this EntityComponent entityComponent, ThiefData data)
        {
            entityComponent.ShowEntity(typeof(Thief),  Constant.AssetPriority.ThiefAsset, data);
        }

        public static void ShowNewLevel(this EntityComponent entityComponent, LevelData data)
        {
            entityComponent.ShowEntity(typeof(Level), Constant.AssetPriority.LevelAsset, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        
        
    }
}
