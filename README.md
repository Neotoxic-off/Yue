# Yue
📚 Yue is a library made to simplify lisibility reading of .NET projects

1. [Yue Library Overview](#yue)
2. [Namespace: `Yue`](#namespace-yue)
3. [Available Methods](#available-methods)
    1. [Or<T>(T value, params T[] options)](#1-ort-value-t-value-params-t-options)
    2. [And(params Func<bool>[] conditions)](#2-andparams-funcbool-conditions)
    3. [EqualsAny<T>(T value, params T[] options)](#3-equalsanyt-value-t-value-params-t-options)
    4. [EqualsAll<T>(T value, params T[] options)](#4-equalsallt-value-t-value-params-t-options)
    5. [Between(int value, int lower, int upper, bool inclusive = true)](#5-betweenint-value-int-lower-int-upper-bool-inclusive--true)
    6. [InSet<T>(T value, IEnumerable<T> set)](#6-insett-value-t-value-ienumerablet-set)
    7. [Not(bool condition)](#7-notbool-condition)
    8. [InRange(int value, int lower, int upper, bool inclusive = true)](#8-inrangeint-value-int-lower-int-upper-bool-inclusive--true)
    9. [AllMatch<T>(IEnumerable<T> values, Func<T, bool> condition)](#9-allmatcht-ienumerablet-values-funct-bool-condition)
    10. [AnyMatch<T>(IEnumerable<T> values, Func<T, bool> condition)](#10-anymatcht-ienumerablet-values-funct-bool-condition)
    11. [NoneMatch<T>(IEnumerable<T> values, Func<T, bool> condition)](#11-nonematcht-ienumerablet-values-funct-bool-condition)
4. [Collections Utilities](#collections-utilities)
    1. [Map<TInput, TOutput>(IEnumerable<TInput> collection, Func<TInput, TOutput> transform)](#maptinput-toutputienumerabletinput-collection-functinput-toutput-transform)
    2. [Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate)](#filtert-ienumerablet-collection-functbool-predicate)
    3. [Reduce<T, TAccumulate>(IEnumerable<T> collection, Func<TAccumulate, T, TAccumulate> accumulator, TAccumulate initialValue)](#reducet-taccumulateienumerablet-collection-functaccumulatet-t-taccumulate-accumulator-taccumulate-initialvalue)
    4. [Repeat(int times, Action action)](#repeatint-times-action-action)
    5. [WhileTrue(Func<bool> condition, Action action)](#whiletruefunctbool-condition-action-action)
    6. [Chunk<T>(IEnumerable<T> collection, int chunkSize)](#chunkt-ienumerablet-collection-int-chunksize)
5. [Variables Utilities](#variables-utilities)
    1. [Swap<T>(ref T x, ref T y)](#swapt-ref-t-x-ref-t-y)
    2. [DefaultIfNull<T>(T variable, T defaultValue)](#defaultifnullt-t-variable-t-defaultvalue)
    3. [Coalesce<T>(params T[] values)](#coalescet-t-params-t-values)
    4. [LazyLoad<T>(Func<T> initializer)](#lazyloadt-funct-initializer)
    5. [MinMax<T>(IEnumerable<T> collection)](#minmaxt-ienumerablet-collection)
    6. [Clamp<T>(T value, T min, T max)](#clampt-t-value-t-min-t-max)
    7. [Toggle(ref bool flag)](#toggleref-bool-flag)
    8. [RoundToNearest(double value, double increment)](#roundtonearestdouble-value-double-increment)

The `Conditions` class in the `Yue` namespace provides the following logical functions:

## Available Methods

### 1. `Or<T>(T value, params T[] options)`

**Usage**: Checks if the provided value is equal to any of the options.

```csharp
bool result = Conditions.Or(5, 1, 3, 5, 7); // Returns true because 5 is one of the options.
```

- **Parameters**:
  - `value` (T): The value to compare.
  - `options` (T[]): A list of options to compare against.
  
- **Returns**: 
  - `true` if the value matches any of the options, otherwise `false`.

---

### 2. `And(params Func<bool>[] conditions)`

**Usage**: Checks if all provided conditions are `true`.

```csharp
bool result = Conditions.And(() => 5 > 3, () => "Hello" == "Hello"); // Returns true.
```

- **Parameters**:
  - `conditions`: An array of conditions represented by `Func<bool>` delegates.

- **Returns**: 
  - `true` if all conditions evaluate to `true`, otherwise `false`.

---

### 3. `EqualsAny<T>(T value, params T[] options)`

**Usage**: Checks if the provided value is equal to any of the options.

```csharp
bool result = Conditions.EqualsAny(10, 5, 10, 15); // Returns true because 10 is one of the options.
```

- **Parameters**:
  - `value` (T): The value to check.
  - `options` (T[]): A list of options to compare against.

- **Returns**: 
  - `true` if the value is equal to any of the options, otherwise `false`.

---

### 4. `EqualsAll<T>(T value, params T[] options)`

**Usage**: Checks if the provided value is equal to all of the options.

```csharp
bool result = Conditions.EqualsAll(10, 10, 10, 10); // Returns true because all options are equal to 10.
```

- **Parameters**:
  - `value` (T): The value to compare against.
  - `options` (T[]): A list of options to compare with.

- **Returns**: 
  - `true` if the value is equal to all of the options, otherwise `false`.

---

### 5. `Between(int value, int lower, int upper, bool inclusive = true)`

**Usage**: Determines whether a numeric value lies between two bounds.

```csharp
bool result = Conditions.Between(7, 5, 10); // Returns true because 7 is between 5 and 10.
bool resultExclusive = Conditions.Between(5, 5, 10, false); // Returns false because the bound is exclusive.
```

- **Parameters**:
  - `value` (int): The value to check.
  - `lower` (int): The lower bound.
  - `upper` (int): The upper bound.
  - `inclusive` (bool, default = `true`): Determines whether the bounds are inclusive or exclusive.
  
- **Returns**: 
  - `true` if the value lies between the lower and upper bounds (inclusive or exclusive based on the `inclusive` parameter).

---

### 6. `InSet<T>(T value, IEnumerable<T> set)`

**Usage**: Checks if a value is present within a given set of values.

```csharp
bool result = Conditions.InSet(5, new List<int> { 1, 2, 5, 8 }); // Returns true because 5 is in the set.
```

- **Parameters**:
  - `value` (T): The value to check.
  - `set` (IEnumerable<T>): The set to check if the value exists in.
  
- **Returns**: 
  - `true` if the value is in the set, otherwise `false`.

---

### 7. `Not(bool condition)`

**Usage**: Performs a logical negation of a condition.

```csharp
bool result = Conditions.Not(true); // Returns false because the condition is negated.
```

- **Parameters**:
  - `condition` (bool): The condition to negate.
  
- **Returns**: 
  - `true` if the condition is `false`, otherwise `false`.

---

### 8. `InRange(int value, int lower, int upper, bool inclusive = true)`

**Usage**: Determines whether a numeric value falls within a specific range.

```csharp
bool result = Conditions.InRange(8, 5, 10); // Returns true because 8 is in the range 5 to 10.
```

- **Parameters**:
  - `value` (int): The value to check.
  - `lower` (int): The lower bound of the range.
  - `upper` (int): The upper bound of the range.
  - `inclusive` (bool, default = `true`): Determines whether the bounds are inclusive or exclusive.

- **Returns**: 
  - `true` if the value falls within the range (inclusive or exclusive based on the `inclusive` parameter).

---

### 9. `AllMatch<T>(IEnumerable<T> values, Func<T, bool> condition)`

**Usage**: Checks if all elements in a collection satisfy a given condition.

```csharp
bool result = Conditions.AllMatch(new List<int> { 1, 2, 3 }, v => v > 0); // Returns true because all values are greater than 0.
```

- **Parameters**:
  - `values` (IEnumerable<T>): The collection of values to check.
  - `condition` (Func<T, bool>): The condition to apply to each element.

- **Returns**: 
  - `true` if all elements satisfy the condition, otherwise `false`.

---

### 10. `AnyMatch<T>(IEnumerable<T> values, Func<T, bool> condition)`

**Usage**: Checks if any element in a collection satisfies a given condition.

```csharp
bool result = Conditions.AnyMatch(new List<int> { 1, 2, 3 }, v => v == 2); // Returns true because 2 is in the collection.
```

- **Parameters**:
  - `values` (IEnumerable<T>): The collection of values to check.
  - `condition` (Func<T, bool>): The condition to apply to each element.

- **Returns**: 
  - `true` if any element satisfies the condition, otherwise `false`.

---

### 11. `NoneMatch<T>(IEnumerable<T> values, Func<T, bool> condition)`

**Usage**: Ensures that no element in a collection satisfies a given condition.

```csharp
bool result = Conditions.NoneMatch(new List<int> { 1, 2, 3 }, v => v == 5); // Returns true because no elements are equal to 5.
```

- **Parameters**:
  - `values` (IEnumerable<T>): The collection of values to check.
  - `condition` (Func<T, bool>): The condition to apply to each element.

- **Returns**: 
  - `true` if no elements satisfy the condition, otherwise `false`.


## Collections Utilities

### `Map<TInput, TOutput>(IEnumerable<TInput> collection, Func<TInput, TOutput> transform)`
Transforms each item in a collection using the provided function and returns a new collection.

**Example usage:**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var doubled = Collections.Map(numbers, x => x * 2);
// Output: { 2, 4, 6, 8, 10 }
```

### `Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate)`
Filters the items in a collection that satisfy a given condition.

**Example usage:**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = Collections.Filter(numbers, x => x % 2 == 0);
// Output: { 2, 4 }
```

### `Reduce<T, TAccumulate>(IEnumerable<T> collection, Func<TAccumulate, T, TAccumulate> accumulator, TAccumulate initialValue)`
Reduces the collection into a single value by applying an accumulator function.

**Example usage:**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var sum = Collections.Reduce(numbers, (acc, x) => acc + x, 0);
// Output: 15
```

### `Repeat(int times, Action action)`
Repeatedly executes a given action a specified number of times.

**Example usage:**
```csharp
Collections.Repeat(3, () => Console.WriteLine("Hello, World!"));
// Output: Hello, World! (printed 3 times)
```

### `WhileTrue(Func<bool> condition, Action action)`
Continuously executes a block of code while a condition is true.

**Example usage:**
```csharp
int counter = 0;
Collections.WhileTrue(() => counter < 5, () => { counter++; Console.WriteLine(counter); });
// Output: 1 2 3 4 5
```

### `Chunk<T>(IEnumerable<T> collection, int chunkSize)`
Divides a collection into smaller chunks of a specified size.

**Example usage:**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
var chunks = Collections.Chunk(numbers, 3);
// Output: { {1, 2, 3}, {4, 5, 6}, {7, 8} }
```

## Variables Utilities

### `Swap<T>(ref T x, ref T y)`
Swaps the values of two variables.

**Example usage:**
```csharp
int a = 5, b = 10;
Variables.Swap(ref a, ref b);
// After swapping, a = 10, b = 5
```

### `DefaultIfNull<T>(T variable, T defaultValue)`
Returns the default value if the variable is null.

**Example usage:**
```csharp
string name = null;
var result = Variables.DefaultIfNull(name, "Default Name");
// Output: "Default Name"
```

### `Coalesce<T>(params T[] values)`
Returns the first non-null value from a list of variables.

**Example usage:**
```csharp
string a = null, b = "Hello", c = "World";
var result = Variables.Coalesce(a, b, c);
// Output: "Hello"
```

### `LazyLoad<T>(Func<T> initializer)`
Lazily initializes a variable when it is accessed for the first time.

**Example usage:**
```csharp
var lazyValue = Variables.LazyLoad(() => "This is lazy loaded");
// Output: "This is lazy loaded" (initialized when accessed)
```

### `MinMax<T>(IEnumerable<T> collection)`
Finds both the minimum and maximum value in a collection in a single pass.

**Example usage:**
```csharp
var numbers = new List<int> { 1, 3, 2, 7, 4 };
var (min, max) = Variables.MinMax(numbers);
// Output: min = 1, max = 7
```

### `Clamp<T>(T value, T min, T max)`
Ensures that a value stays within a specific range.

**Example usage:**
```csharp
int value = 10;
var clampedValue = Variables.Clamp(value, 5, 8);
// Output: 8 (since 10 is outside the range 5-8)
```

### `Toggle(ref bool flag)`
Flips the value of a boolean variable.

**Example usage:**
```csharp
bool isActive = true;
Variables.Toggle(ref isActive);
// Output: isActive = false
```

### `RoundToNearest(double value, double increment)`
Rounds a number to the nearest specified increment.

**Example usage:**
```csharp
double result = Variables.RoundToNearest(7.24, 0.5);
// Output: 7.0
```
