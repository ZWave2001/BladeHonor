//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace BladeHonor
{
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 弹出框。
        /// </summary>
        PopupForm = 1,

        /// <summary>
        /// 主菜单。
        /// </summary>
        MenuForm = 101,
        
        /// <summary>
        /// 对话框。
        /// </summary>
        DialogForm = 102,

        /// <summary>
        /// 设置。
        /// </summary>
        SettingForm = 103,

        /// <summary>
        /// 关于。
        /// </summary>
        AboutForm = 104,
    }
}
