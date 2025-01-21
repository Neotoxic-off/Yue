# Yue
📚 Yue is a library made to simplify lisibility reading of .NET projects

## Condition
- [ ] Or: Returns true if the value matches any of the provided options (e.g., Or(value, 1, 2, 3)).
- [ ] And: Returns true if the value satisfies all conditions (e.g., And(value > 0, value < 10)).
- [ ] Nor: Returns true if the value matches none of the provided options (logical NOT of Or).
- [ ] Xnor
- [ ] Xor (Exclusive Or): Returns true if the value matches exactly one of the provided options (e.g., Xor(value, 1, 2, 3) returns true if value is only 1, 2, or 3).
- [ ]Xand (Exclusive And): Returns true if the value satisfies exactly one and only one condition in a set of boolean conditions (e.g., Xand(condition1, condition2) is true if only one of the conditions is true).
- [ ] Nand: Returns true if not all conditions are satisfied (logical NOT of And).
- [ ] EqualsAny: Returns true if the value equals any of the provided options (similar to Or but for equality checks).
- [ ] EqualsAll: Returns true if the value equals all of the provided options (useful for strict comparison scenarios).
- [ ] Between: Returns true if a numeric value lies between two bounds (with options for inclusive or exclusive bounds).
- [ ] InSet: A more general version of Or that works with any collection to check if a value exists in the set (e.g., InSet(value, mySet)).
- [ ] Not: Returns true if a condition is not met (logical negation, Not(condition)).
- [ ] InRange: Determine if a numeric value falls within a given range.
- [ ] AllMatch: Verify that all values in a list meet a condition.
- [ ] AnyMatch: Check if any value in a list meets a condition.
- [ ] NoneMatch: Ensure no values in a list meet a condition.
- [ ] CustomMatch: Accept a custom function (Func<T, bool>) to determine a match.

## Loop
- [ ] Map: Transform each item in a collection and return a new collection (e.g., Map(collection, x => x * 2)).
- [ ] Filter: Return items from a collection that satisfy a condition (e.g., Filter(collection, x => x > 10)).
- [ ] Reduce: Aggregate values in a collection into a single result (e.g., sum, max).
- [ ] Repeat: Execute a function or action a specified number of times (e.g., Repeat(5, () => DoSomething())).
- [ ] WhileTrue: Continuously execute a block while a condition is true (useful for dynamic break conditions).
- [ ] Chunk: Divide a collection into smaller chunks of a given size (e.g., Chunk(collection, 5)).

## Variable
- [ ] Swap: Swap the values of two variables (Swap(ref x, ref y)).
- [ ] DefaultIfNull: Return a default value if the variable is null.
- [ ] Coalesce: Return the first non-null value from a list of variables (e.g., Coalesce(var1, var2, defaultValue)).
- [ ] LazyLoad: Initialize a variable only when it’s accessed for the first time.
- [ ] MinMax: Find both the minimum and maximum in a single pass of a collection.
- [ ] Clamp: Ensure a value stays within a specific range (e.g., Clamp(value, min, max)).
- [ ] Toggle: Flip a boolean value (e.g., Toggle(ref isActive)).
- [ ] RoundToNearest: Round a number to the nearest specified increment (e.g., nearest 0.5 or 10).
- [ ] CastOrDefault: Safely cast a variable to a type, with a fallback if the cast fails.
