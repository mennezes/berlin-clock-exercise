# The Berlin Clock

The Berlin Uhr (Clock) is a rather strange way to show the time. On the top of the clock there is a yellow lamp that
blinks on/off every two seconds. The time is calculated by adding rectangular lamps.
 
The top two rows of lamps are red. These indicate the hours of a day. In the top row there are 4 red lamps. Every lamp
represents 5 hours. In the lower row of red lamps every lamp represents 1 hour. So if two lamps of the first row and
three of the second row are switched on that indicates 5+5+3=13h or 1 pm.
 
The two rows of lamps at the bottom count the minutes. The first of these rows has 11 lamps, the second 4. In the
first row every lamp represents 5 minutes. In this first row the 3rd, 6th and 9th lamp are red and indicate the first
quarter, half and last quarter of an hour. The other lamps are yellow. In the last row with 4 lamps every lamp
represents 1 minute.

## The Implementation
Two string arrays are created at the construction of the TimeConverter. One is a pattern with the lights **ON**, and the other, with the lights **OFF**. The time provided is then parsed throught a custom Time parser and then, each row is calculated and the Berlin Clock string is built. A helper method was created that receives the current row and the amount of lights that should be ON.

## Remarks
At first, the .NET built in DateTime class was used to parse the time, however, as one of the tests uses a `24:00:00` time as an input, the parser fails. Upon research, it was discovered that this format is rarely used, but exists. This is the reason a custom time parser was implemented, as there was none built in which could handle that data.
