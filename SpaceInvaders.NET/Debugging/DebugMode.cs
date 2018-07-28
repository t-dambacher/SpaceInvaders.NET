using System;

namespace SpaceInvaders.Debugging
{
    [Flags]
    public enum DebugMode
    {
        None = 0,
        EnableLogging = 1,
        StepByStep = 2,
        DisplayState = 4,
        All = EnableLogging | StepByStep | DisplayState
    }
}
