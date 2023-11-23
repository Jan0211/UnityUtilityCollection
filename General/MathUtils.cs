using UnityEngine;

namespace UnityTools.General
{
    /// <summary>
    /// This script provides utilities that the standard <see cref="Mathf"/> collection lacks.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Maps a value from a source range to a target range.
        /// 
        /// <para>Created by @LeHoppel.</para>
        /// </summary>
        /// <param name="sourceMin">The original range's lower bound.</param>
        /// <param name="sourceMax">The original range's upper bound.</param>
        /// <param name="targetMin">The target range's lower bound.</param>
        /// <param name="targetMax">The target range's upper bound.</param>
        public static float MapToRange(float value, float sourceMin, float sourceMax, float targetMin, float targetMax)
        {
            return (value - sourceMin) / (sourceMax - sourceMin) * (targetMax - targetMin) + targetMin;
        }
        
        /// <summary>
        /// Returns the angle between two rotations. Checks with an epsilon approximation.
        ///
        /// <para>Created by @LeHoppel. Inspired by Unity Forums.</para>
        /// </summary>
        /// <param name="a">The first rotation quaternion.</param>
        /// <param name="b">The first rotation quaternion.</param>
        /// <returns>The angle between rotation a and b.</returns>
        public static float AngleBetweenQuaternions(Quaternion a, Quaternion b) 
        {     
            Vector4 A = new Vector4(a.x, a.y, a.z, a.w);
            Vector4 B = new Vector4(b.x, b.y, b.z, b.w);
            
            float dotProduct = Vector4.Dot(A, B);
            
            // A and -A represent the same rotation
            if (dotProduct < 0)
            {
                A = -A;
                dotProduct = -dotProduct;
            }
            
            if (dotProduct < 0.9999)
                return Mathf.Acos(dotProduct) * 360 / Mathf.PI;

            // Small angle approximation
            return Vector4.Distance(A, B) * 360 / Mathf.PI;
        }
        
        /// <summary>
        /// Returns a random Vector in the cube defined between minPos and maxPos.
        /// 
        /// <para>Created by @LeHoppel.</para>
        /// </summary>
        /// <param name="minPos">The minimum position.</param>
        /// <param name="maxPos">The maximum position.</param>
        /// <returns>A random point in the cube defined by <see cref="minPos"/> and <see cref="maxPos"/>.</returns>
        public static Vector3 RandomVectorInACube(Vector3 minPos, Vector3 maxPos)
        {
            Vector3 result = new()
            {
                x = Random.Range(minPos.x, maxPos.x),
                y = Random.Range(minPos.y, maxPos.y),
                z = Random.Range(minPos.z, maxPos.z)
            };

            return result;
        }
    }
}