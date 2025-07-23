# Day 9: All in a Single Night

Every year, Santa manages to deliver all of his presents in a single night.

## Rules

This year, however, he has some new locations to visit; 
his elves have provided him the distances between every pair of locations. 
He can start and end at any two (different) locations he wants, but he must visit each location exactly once.

## Examples
```
London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141
```
The possible routes are therefore:
```
Dublin -> London -> Belfast = 982
London -> Dublin -> Belfast = 605
London -> Belfast -> Dublin = 659
Dublin -> Belfast -> London = 659
Belfast -> Dublin -> London = 605
Belfast -> London -> Dublin = 982
```
The shortest of these is London -> Dublin -> Belfast = 605, and so the answer is 605 in this example.

## Challenge 1

What is the distance of the shortest route?

# Part Two

The next year, just to show off, Santa decides to take the route with the longest distance instead.

## Rules

He can still start and end at any two (different) locations he wants, and he still must visit each location exactly once.

## Examples

Given the distances above, the longest route would be 982 via (for example) Dublin -> London -> Belfast.

## Challenge 2

What is the distance of the longest route?