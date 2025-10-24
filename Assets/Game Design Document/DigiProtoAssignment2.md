


# Tennis for One GDD: 

## Desired Game Mechanic: 

Single player tennis game, where the player tries to last as long as possible. The mechanic specifically revolves around the players tennis paddle moving in a radial motion, alongside the inclusion of a time slowing mechanic rewarded for paddle hits.

## Objective Statement: 

Does the inclusion of a time slowing mechanic for a single player game enhance infinite pong game?

## Detail design rationale: 

The experience that we are aiming for revolves around the player attempting to last as long possible in an infinite pong game. The player can get extra lives via hitting the ball with their paddle, and can slow down time by using their power bar, this is filled via hitting the ball.


## Mechanic Details

Controls:  
 \- A, D : Rotate the paddle
\- Spacebar : Slow down time, whilst retaining the players paddle speed

Technical Aspects:

1. When the game starts, the ball starts in the center of the screen
2. When the player loses all of their lives, they are sent to a replay screen with a score counter.
3. When the player has a non-empty power bar, the player can hold space to slow down everything except their paddle. This is accomplished via multiplying the speed of all objects minus the player paddle.

## Target Audience

Game is intended for audiences that enjoy small single player games. Specifically targeting the offline single player market.

