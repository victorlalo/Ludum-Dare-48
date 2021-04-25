using System;
using System.Collections.Generic;
using System.Linq;

public static class Thoughts
{
    private static readonly Random Random = new Random();

    public static List<string> AllThoughts = new List<string>
    {
        "I should really water my dog...",
        "Next week I'll start on veganism",
        "Whose birthday is today? Is someone's birthday today??",
        "Do my friends think I wear the same clothes all the time?",
        "Now that I think about it, James Cameron's Avatar was pretty dope",
        "Epstein didn't kill himself",
        "Mmm purple",
        "Why are all the Simpsons yellow except Apu",
        "Teriyaki is from Seattle?",
        "I will go to sleep early tonight",
        "What does SPF even do?",
        "Gotta complete that assignment...",
        "Should probably get back to the jam",
        "Gotta run to the grocery store tonight",
        "Taxes are coming uuuuuup"
    };

    private static List<string> UsedThoughts = new List<string>();

    public static string GetRandomThought()
    {
        if (UsedThoughts.Count == AllThoughts.Count)
        {
            UsedThoughts.Clear();
        }

        string thought;

        do
        {
            thought = AllThoughts.ElementAt(Random.Next(AllThoughts.Count));
        } while (UsedThoughts.Contains(thought));
        
        UsedThoughts.Add(thought);

        return thought;
    }
}