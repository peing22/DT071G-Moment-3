/*
Skapar klass som representerar information om enskilda inlägg. Varje inlägg har 
automatiska egenskaper (Author och Content) av typen string, för vilka värden 
krävs vid tilldelning (set). Det är också möjligt att returnera värden (get).
*/
class Post
{
    public required string Author { get; set; }
    public required string Content { get; set; }
}