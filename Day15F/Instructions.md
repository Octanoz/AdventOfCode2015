# Day 15: Science for Hungry People

Today, you set out on the task of perfecting your milk-dunking cookie recipe. All you have to do is find the right balance of ingredients.

## Rules

Your recipe leaves room for exactly 100 teaspoons of ingredients.
You make a list of the remaining ingredients you could use to finish the recipe (your puzzle input) and their properties per teaspoon:

1. **Capacity** (how well it helps the cookie absorb milk)
2. **Durability** (how well it keeps the cookie intact when full of milk)
3. **Flavor** (how tasty it makes the cookie)
4. **Texture** (how it improves the feel of the cookie)
5. **Calories** (how many calories it adds to the cookie)

You can only measure ingredients in whole-teaspoon amounts accurately, and you have to be accurate so you can reproduce your results in the future.
The total score of a cookie can be found by adding up each of the properties
*(negative totals become 0)*
and then multiplying together everything **except calories**.

## Examples

Suppose you have these two ingredients:

* Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
* Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3

Then, choosing to use 44 teaspoons of butterscotch and 56 teaspoons of cinnamon (because the amounts of each ingredient must add up to 100)
would result in a cookie with the following properties:

* A capacity of 44 x -1 + 56 x 2 = 68
* A durability of 44*-2 + 56 x 3 = 80
* A flavor of 44 x 6 + 56 x -2 = 152
* A texture of 44 x 3 + 56 x -1 = 76

Multiplying these together (68 * 80 * 152 * 76, ignoring calories for now) results in a total score of 62842880, which happens to be the best score possible given these ingredients.
If any properties had produced a negative total, it would have instead become zero, causing the whole score to multiply to zero.

## Challenge 1

Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make?

_Answer: `21367368`_

# Part Two

Your cookie recipe becomes wildly popular! Someone asks if you can make another recipe that has exactly 500 calories per cookie (so they can use it as a meal replacement). Keep the rest of your award-winning process the same (100 teaspoons, same ingredients, same scoring system).

## Examples

Given the ingredients above,
if you had instead selected 40 teaspoons of butterscotch and 60 teaspoons of cinnamon (which still adds to 100),
the total calorie count would be (40 x 8) + (60 x 3) = 500.
The total score would go down, though: only 57600000, the best you can do in such trying circumstances.

## Challenge

Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make with a calorie total of 500?

_Answer: `1766400`_
