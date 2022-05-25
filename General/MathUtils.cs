namespace UnityTools.General
{
    public static class MathUtils
    {
        /// <summary>
        ///     Maps a value from an origin range to a target range.
        /// </summary>
        /// <param name="value">The value that will be mapped</param>
        /// <param name="originMin">The original range's lower bound.</param>
        /// <param name="originMax">The original range's upper bound.</param>
        /// <param name="targetMin">The target range's lower bound.</param>
        /// <param name="targetMax">The target range's upper bound.</param>
        private static float Remap(float value, float originMin, float originMax, float targetMin, float targetMax)
        {
            return (value - originMin) / (originMax - originMin) * (targetMax - targetMin) + targetMin;
        }
    }
}