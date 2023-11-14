# Day 4: The Ideal Stocking Stuffer

Santa needs help mining some AdventCoins (very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.

## Rules

To do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes. <br>
The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. <br>

## Examples

If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so. <br>
If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....

## Challenge 1

Your puzzle input is bgvyzdsv. <br>
To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: 1, 2, 3, ...) that produces an MD5 hash.

## Challenge 2

Now find one with 6 starting zeroes