# Sector-12
 A top-down factory building roguelite... with combat mechanics?
 
The idea for this game started after several long play sessions of Risk of Rain 2 and Mindustry. The item system in Risk of Rain that allows for infinitely stacking
items as your run progresses, punished by more and more quickly increasing enemy level. Mindustry is a tower defense resource management and building game, and the 
games have very little in common other than the motif of protecting yourself against waves of enemies.

Together, however, these games sparked the idea of a game with roguelike mechanics similar to RoR (mainly the items and stage progression) and building similar to 
Mindustry (spawning units, mining resources, and so on). This repository is a compilation of all of the code I have written to get these systems working. The big
things these scripts do can be separated into three categories: generic characters with external controllability, building structures and allowing them to interact 
with neighboring structures, and an item and attack storage, manipulation, and event system that works for any character (including buildings).

The goal is to have turrets and unit spawners that the player can give their own items. The items have their own behaviors and can invoke and subscribe to events like 
OnKill, OnDamage, OnReceiveDamage, OnHeal, and so on and so forth. Attacks are also flexible; the controller just needs to pass in the appropriate parameter to the 
character's attack method, and the character needs to have access to the attack.

Currently, you can build a basic drill and conveyors going right (which work), you can shoot bullets that invoke OnDamage if they hit something, and you can have items 
(although almost no items have actually been made, they can currently offer a percent buff to basically every stat a character has).

I hope this works.
