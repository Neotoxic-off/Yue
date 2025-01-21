namespace Yue
{
    /// <summary>
    /// Provides utilities for common variable operations such as swapping, null checks, clamping, etc.
    /// </summary>
    public static class Variables
    {
        /// <summary>
        /// Swaps the values of two variables.
        /// </summary>
        /// <typeparam name="T">The type of the variables.</typeparam>
        /// <param name="x">The first variable.</param>
        /// <param name="y">The second variable.</param>
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Returns the default value if the variable is null.
        /// </summary>
        /// <typeparam name="T">The type of the variable.</typeparam>
        /// <param name="variable">The variable to check.</param>
        /// <param name="defaultValue">The default value to return if the variable is null.</param>
        /// <returns>
        /// The value of the variable if it's not null, otherwise the default value.
        /// </returns>
        public static T DefaultIfNull<T>(T variable, T defaultValue)
        {
            return variable == null ? defaultValue : variable;
        }

        /// <summary>
        /// Returns the first non-null value from a list of variables.
        /// </summary>
        /// <typeparam name="T">The type of the variables.</typeparam>
        /// <param name="values">A list of variables to check.</param>
        /// <returns>
        /// The first non-null value or default if all values are null.
        /// </returns>
        public static T? Coalesce<T>(params T[] values)
        {
            return values.FirstOrDefault(v => v != null);
        }

        /// <summary>
        /// Lazily initializes a variable when it is accessed for the first time.
        /// </summary>
        /// <typeparam name="T">The type of the variable.</typeparam>
        /// <param name="initializer">The function to initialize the variable.</param>
        /// <returns>
        /// The lazily initialized variable.
        /// </returns>
        public static T LazyLoad<T>(Func<T> initializer) where T : class
        {
            T? value = null;

            return value ?? (value = initializer());
        }

        /// <summary>
        /// Finds both the minimum and maximum value in a collection in a single pass.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection of values.</param>
        /// <returns>
        /// A tuple containing the minimum and maximum values.
        /// </returns>
        public static (T? min, T? max) MinMax<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            T? min = collection.Min();
            T? max = collection.Max();

            return (min, max);
        }

        /// <summary>
        /// Ensures that a value stays within a specific range.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>
        /// The clamped value within the range [min, max].
        /// </returns>
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        /// <summary>
        /// Flips the value of a boolean variable.
        /// </summary>
        /// <param name="flag">The boolean value to toggle.</param>
        public static void Toggle(ref bool flag)
        {
            flag = !flag;
        }

        /// <summary>
        /// Rounds a number to the nearest specified increment.
        /// </summary>
        /// <param name="value">The number to round.</param>
        /// <param name="increment">The increment to round to.</param>
        /// <returns>
        /// The rounded value.
        /// </returns>
        public static double RoundToNearest(double value, double increment)
        {
            return Math.Round(value / increment) * increment;
        }
    }
}
