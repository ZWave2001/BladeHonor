// Author: ZWave
// Time: 2023/09/13 10:17
// --------------------------------------------------------------------------

using UnityEngine;

namespace BladeHonor
{
    
    public class DefaultCharacterData
    {
        public static float JumpHeight = 2.1f;
        public static float JumpUpGravity = 3f;
        public static float JumpDownGravity = 4f;
        
        public static float JumpVelocity = Mathf.Sqrt(Physics2D.gravity.y * -2 * JumpHeight * JumpUpGravity);
        
    }
    
}