//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Localization;
using System;
using System.Xml;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    /// <summary>
    /// XML 格式的本地化辅助器。
    /// </summary>
    public class BladeHonorLocalizationHelper : DefaultLocalizationHelper
    {
        /// <summary>
        /// 解析字典。
        /// </summary>
        /// <param name="dictionaryString">要解析的字典字符串。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析字典成功。</returns>
        
        //Localizatoin.txt中语言类别对应的行数索引
        private const int LanguageRowIndex = 1; 
        private static readonly string[] ColumnSplitSeparator = new string[] { "\t" };
        
        public override bool ParseData(ILocalizationManager localizationManager, string dictionaryString, object userData)
        {
           try
            {
                int position = 0;
                int currentRow = -1;
                //当前语言对应在Language.txt中的列数索引
                int currentLanguageColumnIndex = -1;
                
                string dictionaryLineString = null;
                while ((dictionaryLineString = dictionaryString.ReadLine(ref position)) != null)
                {
                    currentRow++;
                    if (dictionaryLineString[0] == '#')
                    {
                        if (currentRow == LanguageRowIndex)
                        {
                            string[] LanguagesLine = dictionaryLineString.Split(ColumnSplitSeparator, StringSplitOptions.None);
                            for (int i = 0; i < LanguagesLine.Length; i++)
                            {
                                if (LanguagesLine[i] == localizationManager.Language.ToString())
                                {
                                    currentLanguageColumnIndex = i;
                                    break;
                                }
                            }
                        }
                        continue;
                    }

                    string[] splitedLine = dictionaryLineString.Split(ColumnSplitSeparator, StringSplitOptions.None);

                    string dictionaryKey = splitedLine[1];
                    string dictionaryValue = splitedLine[currentLanguageColumnIndex];
                    
                    if (!localizationManager.AddRawString(dictionaryKey, dictionaryValue))
                    {
                        Log.Warning("Can not add raw string with dictionary key '{0}' which may be invalid or duplicate.", dictionaryKey);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Warning("Can not parse dictionary string with exception '{0}'.", exception);
                return false;
            }
        }
    }
}
