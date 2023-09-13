// Author: ZWave
// Time: 2023/09/13 10:17
// --------------------------------------------------------------------------

using UnityEngine;

namespace BladeHonor
{
    public static partial class Constant
    {
        public static class DefaultEntityData
        {
            public static float JumpHeight = 1.5f;
            public static float JumpUpGravity = 0.8f;
            public static float JumpDownGravity = 1.5f;
            
            public static float JumpVelocity = Mathf.Sqrt(Physics2D.gravity.y * -2 * JumpHeight * 0.8f);
            
        }
    }
}