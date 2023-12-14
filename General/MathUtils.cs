using System;
using UnityEngine;

namespace UUC.General
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
        /// <param name="value">The value which gets mapped to the given range.</param>
        /// <param name="sourceLower">The original range's lower bound.</param>
        /// <param name="sourceUpper">The original range's upper bound.</param>
        /// <param name="targetLower">The target range's lower bound.</param>
        /// <param name="targetUpper">The target range's upper bound.</param>
        public static float MapToRange(float value, float sourceLower, float sourceUpper, float targetLower, float targetUpper)
        {
            if (Mathf.Approximately(sourceLower, sourceUpper) || Mathf.Approximately(targetLower, targetUpper))
                throw new ArgumentOutOfRangeException($"The ranges lower and upper bounds need to be different values!");
            
            return (value - sourceLower) / (sourceUpper - sourceLower) * (targetUpper - targetLower) + targetLower;
        }

        /// <summary>
        /// Maps a float value to a discrete range. Clamps values that are outside the given range.
        ///
        /// <para>Created by @LeHoppel.</para>
        /// </summary>
        /// <param name="value">The value which gets discretized to the given range.</param>
        /// <param name="lowerRangeBound">The lower bound of the target range.</param>
        /// <param name="upperRangeBound">The upper bound of the target range.</param>
        /// <param name="numberOfDiscreteValues">The number of discrete values of the target range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static float DiscretizeToRange(float value, float lowerRangeBound, float upperRangeBound, int numberOfDiscreteValues)
        {
            if (numberOfDiscreteValues <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(numberOfDiscreteValues)} needs to be bigger than zero!");

            if (lowerRangeBound >= upperRangeBound)
                throw new ArgumentOutOfRangeException($"{nameof(lowerRangeBound)} needs to be smaller than {nameof(upperRangeBound)}!");

            if (value <= lowerRangeBound) return lowerRangeBound;
            if (value >= upperRangeBound) return upperRangeBound;
            
            float binWidth = (upperRangeBound - lowerRangeBound) / numberOfDiscreteValues;

            return lowerRangeBound + Mathf.FloorToInt((value - lowerRangeBound) / binWidth) * binWidth + binWidth / 2;
        }
        
        /// <summary>
        /// Returns the angle between two rotations. Checks with an epsilon approximation.
        ///
        /// <para>Created by @LeHoppel. Inspired by Unity Forums.</para>
        /// </summary>
        /// <param name="rotationA">The first rotation quaternion.</param>
        /// <param name="rotationB">The first rotation quaternion.</param>
        /// <returns>The angle between rotation a and b.</returns>
        public static float AngleBetweenQuaternions(Quaternion rotationA, Quaternion rotationB) 
        {     
            Vector4 rotationVectorA = new Vector4(rotationA.x, rotationA.y, rotationA.z, rotationA.w);
            Vector4 rotationVectorB = new Vector4(rotationB.x, rotationB.y, rotationB.z, rotationB.w);
            
            float dotProduct = Vector4.Dot(rotationVectorA, rotationVectorB);
            
            // A and -A represent the same rotation
            if (dotProduct < 0)
            {
                rotationVectorA = -rotationVectorA;
                dotProduct = -dotProduct;
            }
            
            if (dotProduct < 0.9999)
                return Mathf.Acos(dotProduct) * 360 / Mathf.PI;

            //small angle approximation
            return Vector4.Distance(rotationVectorA, rotationVectorB) * 360 / Mathf.PI;
        }
        
        /// <summary>
        /// Returns a random Vector in the cube defined between minPos and maxPos.
        /// 
        /// <para>Created by @LeHoppel.</para>
        /// </summary>
        /// <param name="minPos">The minimum position.</param>
        /// <param name="maxPos">The maximum position.</param>
        /// <returns>A random point in the cube defined by <see cref="minPos"/> and <see cref="maxPos"/>.</returns>
        public static Vector3 RandomVectorInCube(Vector3 minPos, Vector3 maxPos)
        {
            Vector3 result = new()
            {
                x = UnityEngine.Random.Range(minPos.x, maxPos.x),
                y = UnityEngine.Random.Range(minPos.y, maxPos.y),
                z = UnityEngine.Random.Range(minPos.z, maxPos.z)
            };

            return result;
        }
    }
}