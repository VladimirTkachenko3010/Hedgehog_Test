using System.Diagnostics;

class Program
{
    public static int MeetingsCount(int[] hedgehogs, int colour)
    {

        // Step 1: Shift the `hedgehogs` array elements to change the color order
        // Rotation is performed `colour` times so that the target color is at position 0
        for (int i = 0; i < colour; i++)
            (hedgehogs[0], hedgehogs[1], hedgehogs[2]) = (hedgehogs[1], hedgehogs[2], hedgehogs[0]);

        // Step 2: Calculate the minimum number of encounters that are possible
        // Take the minimum of the remaining two positions (hedgehogs[1] and hedgehogs[2])
        var totalMeetings = Math.Min(hedgehogs[1], hedgehogs[2]);

        // If there are no encounters and all hedgehogs are already in the target color, return -1
        if (totalMeetings == 0 && hedgehogs[0] == 0) return -1;

        // Step 3: Calculate the difference between the maximum and minimum quantity (delta)
        var delta = Math.Max(hedgehogs[1], hedgehogs[2]) - totalMeetings;

        // Step 4: Check if the difference can be equalized over three times the number of meetings
        // If yes, add delta to totalMeetings, otherwise return -1
        return delta % 3 == 0 ? totalMeetings + delta : -1;
    }

    static void Main()
    {
        RunTestCases();
    }


    private static void RunTestCases()
    {
        var testCases = new (int[] hedgehogs, int colour, int expected)[]
        {
            (new[] { 8, 1, 9 }, 2, -1),
            (new[] { 3, 3, 0 }, 1, 3),
            (new[] { 1, 0, 1 }, 0, -1),
            (new[] { 1, 1, 0 }, 2, 1),
            (new[] { 0, 0, 1 }, 2, 0),
            (new[] { 2, 2, 2 }, 0, 2),
            (new[] { 1, 1, 1 }, 0, 1),
        };

        Stopwatch stopwatch = new Stopwatch();

        foreach (var (hedgehogs, colour, expected) in testCases)
        {
            stopwatch.Restart();
            int result = MeetingsCount(hedgehogs, colour);
            stopwatch.Stop();

            Console.WriteLine($"Input: {string.Join(", ", hedgehogs)}, Colour: {colour}");
            Console.WriteLine($"Expected: {expected}, Result: {result}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms\n");
        }
    }
}
