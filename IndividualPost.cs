/*
Skapar intern klass som representerar information om enskilda inlägg. Varje 
inlägg har egenskaper (Author och Content) av typen string för vilka värden 
krävs vid initiering (init). Det är också möjligt att läsa ut (get) 
egenskapernas värden.
*/
internal class IndividualPost
{
    public required string Author { get; init; }
    public required string Content { get; init; }
}