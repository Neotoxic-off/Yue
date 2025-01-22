namespace Yue
{
    /// <summary>
    /// A utility class providing logical functions for condition evaluation.
    /// </summary>
    public static class Conditions
    {
        /// <summary>
        /// Performs a logical OR operation to check if the given value equals any of the provided options.
        /// </summary>
        /// <typeparam name="T">The type of the value and options.</typeparam>
        /// <param name="value">The value to compare against the options.</param>
        /// <param name="options">The options to check the equality against.</param>
        /// <returns>
        /// Returns <c>true</c> if the value equals any of the provided options; otherwise, <c>false</c>.
        /// </returns>
        public static bool Or<T>(T value, params T[] options)
        {
            return options.Contains(value);
        }

        /// <summary>
        /// Performs a logical OR operation to check if any of the provided boolean options is <c>true</c>.
        /// </summary>
        /// <param name="options">An array of boolean values to evaluate.</param>
        /// <returns>
        /// Returns <c>true</c> if any of the provided options is <c>true</c>; otherwise, <c>false</c>.
        /// </returns>
        public static bool Or(params bool[] options)
        {
            return options.Contains(true);
        }

        /// <summary>
        /// Performs a logical AND operation on multiple conditions. 
        /// Returns <c>true</c> if all conditions are <c>true</c>.
        /// </summary>
        /// <param name="conditions">An array of conditions represented by Func delegates.</param>
        /// <returns>
        /// Returns <c>true</c> if all conditions evaluate to <c>true</c>, otherwise <c>false</c>.
        /// </returns>
        public static bool And(params Func<bool>[] conditions)
        {
            return conditions.All(condition => condition());
        }

        /// <summary>
        /// Performs a logical equality check to see if the given value equals any of the provided options.
        /// Equivalent to an OR operation on equality checks.
        /// </summary>
        /// <typeparam name="T">The type of the value and options.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="options">The list of options to compare against.</param>
        /// <returns>
        /// Returns <c>true</c> if the value is equal to any of the provided options, otherwise <c>false</c>.
        /// </returns>
        public static bool EqualsAny<T>(T value, params T[] options)
        {
            return options.Contains(value);
        }

        /// <summary>
        /// Performs a logical equality check to see if the given value equals all of the provided options.
        /// Equivalent to an AND operation on equality checks.
        /// </summary>
        /// <typeparam name="T">The type of the value and options.</typeparam>
        /// <param name="value">The value to compare against.</param>
        /// <param name="options">The list of options to compare with.</param>
        /// <returns>
        /// Returns <c>true</c> if the value is equal to all of the provided options, otherwise <c>false</c>.
        /// </returns>
        public static bool EqualsAll<T>(T value, params T[] options)
        {
            return options.All(option => EqualityComparer<T>.Default.Equals(value, option));
        }

        /// <summary>
        /// Determines whether a numeric value lies between two bounds.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="lower">The lower bound.</param>
        /// <param name="upper">The upper bound.</param>
        /// <param name="inclusive">Determines whether the bounds are inclusive (default is <c>true</c>).</param>
        /// <returns>
        /// Returns <c>true</c> if the value lies between the lower and upper bounds (inclusive or exclusive based on the inclusive parameter).
        /// </returns>
        public static bool Between(int value, int lower, int upper, bool inclusive = true)
        {
            return inclusive ? value >= lower && value <= upper : value > lower && value < upper;
        }

        /// <summary>
        /// Checks if a value is present within a given set of values.
        /// </summary>
        /// <typeparam name="T">The type of the value and set.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="set">The collection to check if the value exists in.</param>
        /// <returns>
        /// Returns <c>true</c> if the value is contained in the set, otherwise <c>false</c>.
        /// </returns>
        public static bool InSet<T>(T value, IEnumerable<T> set)
        {
            return set.Contains(value);
        }

        /// <summary>
        /// Performs a logical negation of a condition.
        /// </summary>
        /// <param name="condition">The condition to negate.</param>
        /// <returns>
        /// Returns <c>true</c> if the condition is <c>false</c>, otherwise <c>false</c>.
        /// </returns>
        public static bool Not(bool condition)
        {
            return !condition;
        }

        /// <summary>
        /// Determines whether a numeric value falls within a specific range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="lower">The lower bound of the range.</param>
        /// <param name="upper">The upper bound of the range.</param>
        /// <param name="inclusive">Determines whether the bounds are inclusive (default is <c>true</c>).</param>
        /// <returns>
        /// Returns <c>true</c> if the value falls within the range (inclusive or exclusive bounds based on the inclusive parameter).
        /// </returns>
        public static bool InRange(int value, int lower, int upper, bool inclusive = true)
        {
            return inclusive ? value >= lower && value <= upper : value > lower && value < upper;
        }

        /// <summary>
        /// Checks if all elements in a collection satisfy a given condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="values">The collection of values.</param>
        /// <param name="condition">The condition to check for each element.</param>
        /// <returns>
        /// Returns <c>true</c> if all elements satisfy the condition, otherwise <c>false</c>.
        /// </returns>
        public static bool AllMatch<T>(IEnumerable<T> values, Func<T, bool> condition)
        {
            return values.All(condition);
        }

        /// <summary>
        /// Checks if any element in a collection satisfies a given condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="values">The collection of values.</param>
        /// <param name="condition">The condition to check for each element.</param>
        /// <returns>
        /// Returns <c>true</c> if any element satisfies the condition, otherwise <c>false</c>.
        /// </returns>
        public static bool AnyMatch<T>(IEnumerable<T> values, Func<T, bool> condition)
        {
            return values.Any(condition);
        }

        /// <summary>
        /// Ensures that no element in a collection satisfies a given condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="values">The collection of values.</param>
        /// <param name="condition">The condition to check for each element.</param>
        /// <returns>
        /// Returns <c>true</c> if no element satisfies the condition, otherwise <c>false</c>.
        /// </returns>
        public static bool NoneMatch<T>(IEnumerable<T> values, Func<T, bool> condition)
        {
            return !values.Any(condition);
        }
    }
}
