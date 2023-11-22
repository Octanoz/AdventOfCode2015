# Day 2: I Was Told There Would Be No Math

The elves are running low on wrapping paper, and so they need to submit an order for more. 
They have a list of the dimensions (length l, width w, and height h) of each present, and only want to order exactly as much as they need.

## Rules

Fortunately, every present is a box (a perfect right rectangular prism), 
which makes calculating the required wrapping paper for each gift a little easier: 
* Find the surface area of the box, which is 2 x l x w + 2 x w x h + 2 x h x l. 
* The elves also need a little extra paper for each present: the area of the smallest side.

## Examples

* A present with dimensions 2 x 3 x 4 requires 2 x 6 + 2 x 12 + 2 x 8 = 52 square feet of wrapping paper 
    * plus 6 square feet of slack, for a total of 58 square feet.
* A present with dimensions 1 x 1 x 10 requires 2 x 1 + 2 x 10 + 2 x 10 = 42 square feet of wrapping paper 
    * plus 1 square foot of slack, for a total of 43 square feet.

All numbers in the elves' list are in feet. 

## Challenge 1

How many total square feet of wrapping paper should they order?

# Part Two

The elves are also running low on ribbon. 
Ribbon is all the same width, so they only have to worry about the length they need to order, which they would again like to be exact.

## Rules

The ribbon required to wrap a present is the shortest distance around its sides, 
or the smallest perimeter of any one face. <br>
Each present also requires a bow made out of ribbon as well; 
the feet of ribbon required for the perfect bow is equal to the cubic feet of volume of the present. <br>
Don't ask how they tie the bow, though; they'll never tell.

## Examples

* A present with dimensions 2 x 3 x 4 requires 2 + 2 + 3 + 3 = 10 feet of ribbon to wrap the present 
    * Plus 2 x 3 x 4 = 24 feet of ribbon for the bow, for a total of 34 feet.
* A present with dimensions 1 x 1 x 10 requires 1 + 1 + 1 + 1 = 4 feet of ribbon to wrap the present 
    * Plus 1 x 1 x 10 = 10 feet of ribbon for the bow, for a total of 14 feet.

## Challenge 2

How many total feet of ribbon should they order?
