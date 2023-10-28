// Author: ZWave
// Time: 2023/10/28 10:03
// --------------------------------------------------------------------------

using GameFramework;
using GameFramework.Event;

namespace GameMain.Scripts.Event
{
    public class SelectLevelEventArgs : GameEventArgs
    {
        /// <summary>
        /// 选择关卡事件编号。
        /// </summary>
        public static readonly int EventId = typeof(SelectLevelEventArgs).GetHashCode();


        /// <summary>
        /// 获取选择关卡事件编号
        /// </summary>
        public override int Id
        {
            get { return EventId; }
        }


        /// <summary>
        /// 选择关卡编号
        /// </summary>
        public int LevelId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }


        public static SelectLevelEventArgs Create(int levelId, object userData = null)
        {
            SelectLevelEventArgs selectLevelEventArgs = ReferencePool.Acquire<SelectLevelEventArgs>();
            selectLevelEventArgs.LevelId = levelId;
            selectLevelEventArgs.UserData = userData;
            return selectLevelEventArgs;
        }
        
        public override void Clear()
        {
            LevelId = 0;
            UserData = null;
        }
        
        
    }
}