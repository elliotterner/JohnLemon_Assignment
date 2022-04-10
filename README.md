# JohnLemon_Assignment

I used the dot product to determine direction the player is in moving towards and if the angle is within a range that is towards the wrong direction (not towards the exit) a text will pop up on screen to tell the player they are moving in the wrong direction and to try a different path.

I used linear interpolation to compute a speed increase/decrease for johnlemon to thereby make the game harder/easier. I set the range within 0 (anything less than 1 is a decrease) and 2 (anything more than 1 is an increase) and the alpha was computed randomly within this range using the random method. This speed increase/decrease was then multiplied in the moveposition method.

for the particle effect, I added particles that would mark the starting position of john lemon, so that there was no opprotunity for the person playing the game to get lost. I thought of it as a way for the player to keep track of where they are.

