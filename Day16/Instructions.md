# Day 16: Aunt Sue

Your Aunt Sue has given you a wonderful gift, and you'd like to send her a thank you card.  
However, there's a small problem: she signed it "From, Aunt Sue".

You have 500 Aunts named "Sue".

So, to avoid sending the card to the wrong person, you need to figure out which Aunt Sue (which you conveniently number 1 to 500, for sanity) gave you the gift.  
You open the present and, as luck would have it, good ol' Aunt Sue got you a My First Crime Scene Analysis Machine! Just what you wanted. Or needed, as the case may be.

## Rules

The My First Crime Scene Analysis Machine (MFCSAM for short) can detect a few specific compounds in a given sample,  
as well as how many distinct kinds of those compounds there are.  
According to the instructions, these are what the MFCSAM can detect:

* Children, by human DNA age analysis.
* Cats. It doesn't differentiate individual breeds.
* Several seemingly random breeds of dog: 
    * samoyeds
    * pomeranians
    * akitas 
    * vizslas
* Goldfish. No other kinds of fish.
* Trees, all in one group.
* Cars, presumably by exhaust or gasoline or something.
* Perfumes, which is handy, since many of your Aunts Sue wear a few kinds.

In fact, many of your Aunts Sue have many of these. You put the wrapping from the gift into the MFCSAM. It beeps inquisitively at you a few times and then prints out a message on ticker tape:

* Children: 3
* Cats: 7
* Samoyeds: 2
* Pomeranians: 3
* Akitas: 0
* Vizslas: 0
* Goldfish: 5
* Trees: 3
* Cars: 2
* Perfumes: 1


## Challenge 1

You make a list of the things you can remember about each Aunt Sue.  
Things missing from your list aren't zero - you simply don't remember the value.

What is the number of the Sue that got you the gift?

# Part Two

As you're about to send the thank you note, something in the MFCSAM's instructions catches your eye.  
Apparently, it has an outdated retroencabulator, and so the output from the machine isn't exact values - some of them indicate ranges.

## Rules

* The cats and trees readings indicates that there are greater than that many (due to the unpredictable nuclear decay of cat dander and tree pollen),  
* the pomeranians and goldfish readings indicate that there are fewer than that many (due to the modial interaction of magnetoreluctance).

## Challenge 2

What is the number of the real Aunt Sue?