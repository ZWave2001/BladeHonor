//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-10-30 15:01:56.258
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
    /// 关卡数据。
    /// </summary>
    public class DRLevel : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取关卡编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取玩家生成位置。
        /// </summary>
        public Vector2[] PlayerSpawnPos
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取敌人生成位置。
        /// </summary>
        public Vector2[] EnemySpawnPos
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取可生成敌人编号。
        /// </summary>
        public int[] EnemySpawnId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取关卡开始位置。
        /// </summary>
        public int LevelStartPos
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取关卡结束位置。
        /// </summary>
        public int LevelEndPos
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
            PlayerSpawnPos = DataTableExtension.ParseVector2Array(columnStrings[index++]);
            EnemySpawnPos = DataTableExtension.ParseVector2Array(columnStrings[index++]);
            EnemySpawnId = DataTableExtension.ParseInt32Array(columnStrings[index++]);
            LevelStartPos = int.Parse(columnStrings[index++]);
            LevelEndPos = int.Parse(columnStrings[index++]);

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
                    PlayerSpawnPos = binaryReader.ReadVector2Array();
                    EnemySpawnPos = binaryReader.ReadVector2Array();
                    EnemySpawnId = binaryReader.ReadInt32Array();
                    LevelStartPos = binaryReader.Read7BitEncodedInt32();
                    LevelEndPos = binaryReader.Read7BitEncodedInt32();
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
