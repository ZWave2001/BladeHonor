// Author: ZWave
// Time: 2023/10/27 15:09
// --------------------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace BladeHonor
{
    /// <summary>
    /// 动态生成UI所包含的参数
    /// </summary>
    public class DynamicUIParams : IReference
    {
        /// <summary>
        /// 父组件
        /// </summary>
        public Transform Parent
        {
            get;
            set;
        }

        /// <summary>
        /// 是否保持最初的组件设置
        /// </summary>
        public bool KeepOriginalSetting
        {
            get;
            set;
        }


        /// <summary>
        /// 用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            set;
        }

        public static DynamicUIParams Create(Transform parent, bool keepOriginalSetting, object userData)
        {
            DynamicUIParams dynamicUIParams = ReferencePool.Acquire<DynamicUIParams>();
            dynamicUIParams.Parent = parent;
            dynamicUIParams.KeepOriginalSetting = keepOriginalSetting;
            dynamicUIParams.UserData = userData;
            return dynamicUIParams;
        }

        public void Clear()
        {
            Parent = null;
            UserData = null;
            KeepOriginalSetting = false;
        }
    }
}