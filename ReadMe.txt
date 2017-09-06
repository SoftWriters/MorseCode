This is my solution to the Softwriters Morse Code challenge.

I found everything about this code challenge to be well within my wheel house.  
I decided to implment in two parts.  One as a library assembly that could used independantly of this particular solution.
The other, a "user interface" that would consume this assembly and allow the user to open and convert Morse Code files

Originally, I planned to make the library in C# and the UI in Visual Basic.  However, I don't have Visual Basic
installed on my machine and I think Softwriters typically writes in C#.  So I proceeded to write the UI in C#.

In keeping with the spirit of a solution that was part of a larger whole, I created a class that can convert from
plain text to morse code as well as morse code to text.  Having both functions was useful to expitie testing.

I tested the application using the following cases:

Example provided in the code challenge

"The quick brown dog jumped over the lazy dog's back."

"Now is the time for all good men to come to the aid of their country."

"abcdefghijklmnopqrstuvwxyz 0123456789"

Thank you for reviewing this solution.  I hope to hear from you soon.