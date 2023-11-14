# Day 22: Wizard Simulator 20XX

Little Henry Case decides that defeating bosses with swords and stuff is boring. Now he's playing the game with a wizard. Of course, he gets stuck on another boss and needs your help again.

## Rules

In this version, combat still proceeds with the player and the boss taking alternating turns.
* The player still goes first.
* You start with 50 health and 500 mana
* You don't get any equipment
* You must choose one of your spells to cast. 
* The first character at or below 0 hit points loses.
* Lowest possible damage is 1


### Magic

* Magic damage ignores armour
* Effects apply at the start of the player's and the opponent's turn
* You must select a spell to cast every turn
* You lose if you cannot afford to cast a spell
* Starting mana is 500
* You can't cast a spell if their effect is already active
    * You can cast it again in the same turn that the effect wears off

### Spells

| Name | Mana | Effect |
|------|------|--------|
| Magic Missile | 53 | 4 Damage |
| Drain | 73 | 2 Damage <br> 2 Health |
| Shield | 113 | +7 Armour <br> 6 turns |
| Poison | 173 | 3 Damage <br> 6 turns |
| Recharge | 229 | +101 Mana <br> 5 turns |

## Examples

1. Suppose the player has 10 hit points and 250 mana, and that the boss has 13 hit points and 8 damage:

**-- Player turn --**
> Player has 10 hit points, 0 armor, 250 mana <br>
Boss has 13 hit points <br>
*Player casts Poison*.

**-- Boss turn --**
> Player has 10 hit points, 0 armor, 77 mana <br>
Boss has 13 hit points <br>
*Poison deals 3 damage*; its timer is now 5. <br>
Boss attacks for 8 damage.

**-- Player turn --**
> Player has 2 hit points, 0 armor, 77 mana <br>
Boss has 10 hit points <br>
Poison deals 3 damage; its timer is now 4. <br>
Player casts Magic Missile, dealing 4 damage.

**-- Boss turn --**
> Player has 2 hit points, 0 armor, 24 mana <br>
Boss has 3 hit points <br>
*Poison deals 3 damage.* <br>
This kills the boss, and the player wins.
---

2. Suppose the same initial conditions, except that the boss has 14 hit points instead:

**-- Player turn --**
> Player has 10 hit points, 0 armor, 250 mana <br>
Boss has 14 hit points <br>
*Player casts Recharge.*

**-- Boss turn --**
> Player has 10 hit points, 0 armor, 21 mana <br>
Boss has 14 hit points <br>
*Recharge provides 101 mana; its timer is now 4.* <br>
Boss attacks for 8 damage!

**-- Player turn --**
> Player has 2 hit points, 0 armor, 122 mana <br>
Boss has 14 hit points <br>
*Recharge provides 101 mana; its timer is now 3.* <br>
*Player casts Shield*, increasing armor by 7.

**-- Boss turn --**
> Player has 2 hit points, 7 armor, 110 mana <br>
Boss has 14 hit points <br>
*Shield's timer is now 5*. <br>
*Recharge provides 101 mana; its timer is now 2.* <br>
Boss attacks for 8 - 7 = 1 damage!

**-- Player turn --**
> Player has 1 hit point, 7 armor, 211 mana <br>
Boss has 14 hit points <br>
*Shield's timer is now 4.* <br>
*Recharge provides 101 mana; its timer is now 1.* <br>
Player casts Drain, dealing 2 damage, and healing 2 hit points.

**-- Boss turn --**
> Player has 3 hit points, 7 armor, 239 mana
Boss has 12 hit points <br>
*Shield's timer is now 3.* <br>
*Recharge provides 101 mana; its timer is now 0.* <br>
*Recharge wears off.* <br>
Boss attacks for 8 - 7 = 1 damage! <br>

**-- Player turn --**
> Player has 2 hit points, 7 armor, 340 mana <br>
Boss has 12 hit points <br>
*Shield's timer is now 2.* <br>
*Player casts Poison.*

**-- Boss turn --**
> Player has 2 hit points, 7 armor, 167 mana <br>
Boss has 12 hit points <br>
*Shield's timer is now 1.* <br>
*Poison deals 3 damage*; its timer is now 5. <br>
Boss attacks for 8 - 7 = 1 damage!

**-- Player turn --**
> Player has 1 hit point, 7 armor, 167 mana <br>
Boss has 9 hit points <br>
*Shield's timer is now 0.* <br>
*Shield wears off*, decreasing armor by 7. <br>
*Poison deals 3 damage*; its timer is now 4. <br>
*Player casts Magic Missile*, dealing 4 damage.

**-- Boss turn --**
> Player has 1 hit point, 0 armor, 114 mana <br>
Boss has 2 hit points <br>
*Poison deals 3 damage*. <br>
This kills the boss, and the player wins.
---

## Challenge

You start with 50 hit points and 500 mana points. <br>
The boss's actual stats are in your puzzle input. <br>
What is the least amount of mana you can spend and still win the fight? <br>
*Mana recharge effects do not count as negative mana.*

# Part Two

On the next run through the game, you increase the difficulty to hard.

## Rules

At the start of each player turn (before other effects apply), you lose 1 hitpoint. <br>
If this brings you to or below 0 hitpoints, you lose.

## Challenge 2

With the same starting stats for you and the boss, what is the least amount of mana you can spend and still win the fight?