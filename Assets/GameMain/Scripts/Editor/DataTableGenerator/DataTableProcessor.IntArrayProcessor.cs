//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;
using UnityEngine;

namespace BladeHonor.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class IntArrayProcessor : GenericDataProcessor<int[]>
        {
            public override bool IsSystem
            {
                get
                {
                    return false;
                }
            }

            public override string LanguageKeyword
            {
                get
                {
                    return "int[]";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "int[]",
                    "unityengine.int[]"
                };
            }

            public override int[] Parse(string value)
            {
                string[] splitedValue = value.Split(',');
                int[] res = new int[splitedValue.Length];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = int.Parse(splitedValue[i]);
                }
                return res;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                int[] intArray = Parse(value);
                binaryWriter.Write(intArray.Length);
                foreach (var intvalue in intArray)
                {
                    binaryWriter.Write(intvalue);
                }
                
            }
        }
    }
}