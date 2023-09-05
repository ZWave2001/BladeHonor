﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-09-05 16:29:48.235
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
    /// 测试用表。
    /// </summary>
    public class DRTest : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取配置ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取名称。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取描述。
        /// </summary>
        public string Des
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取防御力。
        /// </summary>
        public int Defense
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击力。
        /// </summary>
        public int Damage
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击频率。
        /// </summary>
        public float AttackRate
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取生命值。
        /// </summary>
        public int HealthPoint
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
            index++;
            Name = columnStrings[index++];
            Des = columnStrings[index++];
            Defense = int.Parse(columnStrings[index++]);
            Damage = int.Parse(columnStrings[index++]);
            AttackRate = float.Parse(columnStrings[index++]);
            HealthPoint = int.Parse(columnStrings[index++]);

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
                    Name = binaryReader.ReadString();
                    Des = binaryReader.ReadString();
                    Defense = binaryReader.Read7BitEncodedInt32();
                    Damage = binaryReader.Read7BitEncodedInt32();
                    AttackRate = binaryReader.ReadSingle();
                    HealthPoint = binaryReader.Read7BitEncodedInt32();
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
