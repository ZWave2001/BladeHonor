// Author: ZWave
// Time: 2023/10/27 16:22
// --------------------------------------------------------------------------

using System;
using GameFramework;
using UnityEngine;

namespace BladeHonor
{
    [Serializable]
    public class LevelParams : IReference
    {
        public DRLevel DrLevel
        {
            get;
            set;
        }

        public SelectLevelForm SelectLevelForm
        {
            get;
            set;
        }
        
        public int Index
        {
            get;
            set;
        }

        public static LevelParams Create(DRLevel drLevel, SelectLevelForm selectLevelForm, int index)
        {
            LevelParams levelParams = ReferencePool.Acquire<LevelParams>();
            levelParams.DrLevel = drLevel;
            levelParams.SelectLevelForm = selectLevelForm;
            levelParams.Index = index;
            return levelParams;
        }
        
        public void Clear()
        {
            DrLevel = null;
            SelectLevelForm = null;
            Index = 0;
        }
    }
}