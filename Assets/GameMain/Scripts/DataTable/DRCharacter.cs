//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-09-15 17:56:49.534
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    /// <summary>
    /// 角色初始属性表。
    /// </summary>
    public class DRCharacter : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取角色编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取攻击力。
        /// </summary>
        public float Attack
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取防御力。
        /// </summary>
        public float Defense
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取生命值。
        /// </summary>
        public float Health
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取护甲值。
        /// </summary>
        public float Armor
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取速度。
        /// </summary>
        public float Speed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取冲刺距离。
        /// </summary>
        public float DashDistance
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            Attack = float.Parse(columnStrings[index++]);
            Defense = float.Parse(columnStrings[index++]);
            Health = float.Parse(columnStrings[index++]);
            Armor = float.Parse(columnStrings[index++]);
            Speed = float.Parse(columnStrings[index++]);
            DashDistance = float.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    Attack = binaryReader.ReadSingle();
                    Defense = binaryReader.ReadSingle();
                    Health = binaryReader.ReadSingle();
                    Armor = binaryReader.ReadSingle();
                    Speed = binaryReader.ReadSingle();
                    DashDistance = binaryReader.ReadSingle();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
