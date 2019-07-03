namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var stack = new StackOfStrings<string>();

            stack.PushRange("1", "2", "3");
        }
    }
}
