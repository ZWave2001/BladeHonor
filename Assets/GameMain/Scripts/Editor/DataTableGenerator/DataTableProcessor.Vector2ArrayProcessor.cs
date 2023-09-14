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
        private sealed class Vector2ArrayProcessor : GenericDataProcessor<Vector2[]>
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
                    return "Vector2[]";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "vector2[]",
                    "unityengine.vector2[]"
                };
            }

            public override Vector2[] Parse(string value)
            {
                string[] splitedValue = value.Split(';');
                Vector2[] res = new Vector2[splitedValue.Length];
                for (int i = 0; i < res.Length; i++)
                {
                    string[] tempSplitedValue = splitedValue[i].Split(',');
                    Vector2 temp = new Vector2(float.Parse(tempSplitedValue[0]), float.Parse(tempSplitedValue[1]));
                    res[i] = temp;
                }

                return res;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                Vector2[] vector2Array = Parse(value);
                binaryWriter.Write(vector2Array.Length);
                foreach (var vector2 in vector2Array)
                {
                    binaryWriter.Write(vector2.x);
                    binaryWriter.Write(vector2.y);
                }
                
            }
        }
    }
}