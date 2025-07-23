# Day 11: Corporate Policy

Santa's previous password expired, and he needs help choosing a new one.

To help him remember his new password after the old one expires,
Santa has devised a method of coming up with a password based on the previous one.
Corporate policy dictates that passwords must be exactly eight lowercase letters (for security reasons),
so he finds his new password by incrementing his old password string repeatedly until it is valid.

Incrementing is just like counting with numbers: `xx`, `xy`, `xz`, `ya`, `yb`, and so on.
Increase the rightmost letter one step;
if it was `z`, it wraps around to `a`,
and repeat with the next letter to the left until one doesn't wrap around.

Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:

## Rules

1) Passwords must include _one increasing straight_ of at least **three letters**,
    - `abc`, `bcd`, `cde`, and so on, up to `xyz`.
    - Cannot skip letters - `abd` doesn't count.

2) Passwords may not contain forbidden letters as these letters can be mistaken for other characters and are therefore confusing.
    - `i`, `o`, or `l`

3) Passwords must contain at least two different, non-overlapping pairs of letters
    - `aa`, `bb`, or `zz`.

## Examples

- `hijklmmn`
    - Passes _first requirement_ with straight `hij`
    - Fails _second requirement_ with `i` and `l`
- `abbceffg`
    - Passes _third requirement_ repeating `bb` and `ff`
    - Fails _first requirement_
- `abbcegjk`
    - Fails _third requirement_ repeating only `bb`

The next password after `abcdefgh` is `abcdffaa`.
The next password after `ghijklmn` is `ghjaabcc`, because you eventually skip all the passwords that start with `ghi...`, since `i` is not allowed.

## Input

**Your puzzle input is `cqjxjnds`.**

## Challenge 1

Given Santa's current password (your puzzle input), what should his next password be?

_Answer was `cqjxxyzz`_

## Challenge 2

Santa's password expired again, what is his next password?

_Answer was `cqkaabcc`_
