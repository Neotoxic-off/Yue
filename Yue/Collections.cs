namespace Yue
{
    /// <summary>
    /// Provides utilities for common collection operations such as mapping, filtering, reducing, and more.
    /// </summary>
    public static class Collections
    {
        /// <summary>
        /// Transforms each item in a collection using the provided function and returns a new collection.
        /// </summary>
        /// <typeparam name="TInput">The type of elements in the input collection.</typeparam>
        /// <typeparam name="TOutput">The type of elements in the output collection.</typeparam>
        /// <param name="collection">The collection to transform.</param>
        /// <param name="transform">The function to apply to each item in the collection.</param>
        /// <returns>
        /// A new collection with the transformed items.
        /// </returns>
        public static IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> collection, Func<TInput, TOutput> transform)
        {
            return collection.Select(transform);
        }

        /// <summary>
        /// Filters the items in a collection that satisfy a given condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to filter.</param>
        /// <param name="predicate">The condition to filter items by.</param>
        /// <returns>
        /// A new collection containing only the elements that satisfy the condition.
        /// </returns>
        public static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate);
        }

        /// <summary>
        /// Reduces the collection into a single value by applying an accumulator function.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="collection">The collection to reduce.</param>
        /// <param name="accumulator">The function to accumulate values in the collection.</param>
        /// <param name="initialValue">The initial value of the accumulator.</param>
        /// <returns>
        /// A single value resulting from the reduction of the collection.
        /// </returns>
        public static TAccumulate Reduce<T, TAccumulate>(IEnumerable<T> collection, Func<TAccumulate, T, TAccumulate> accumulator, TAccumulate initialValue)
        {
            return collection.Aggregate(initialValue, accumulator);
        }

        /// <summary>
        /// Repeatedly executes a given action a specified number of times.
        /// </summary>
        /// <param name="times">The number of times to repeat the action.</param>
        /// <param name="action">The action to execute.</param>
        public static void Repeat(int times, Action action)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }

        /// <summary>
        /// Continuously executes a block of code while a condition is true.
        /// </summary>
        /// <param name="condition">The condition to check before executing the block.</param>
        /// <param name="action">The block of code to execute as long as the condition is true.</param>
        public static void WhileTrue(Func<bool> condition, Action action)
        {
            while (condition())
            {
                action();
            }
        }

        /// <summary>
        /// Divides a collection into smaller chunks of a specified size.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to split into chunks.</param>
        /// <param name="chunkSize">The size of each chunk.</param>
        /// <returns>
        /// A collection of chunks, where each chunk is an enumerable of items.
        /// </returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(IEnumerable<T> collection, int chunkSize)
        {
            for (int i = 0; i < collection.Count(); i += chunkSize)
            {
                yield return collection.Skip(i).Take(chunkSize);
            }
        }
    }
}
