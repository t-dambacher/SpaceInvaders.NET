namespace SpaceInvaders.Debugging
{
    sealed public class Debugger
    {
        static public Debugger Instance { get; } = new Debugger();

        public DebugMode Mode { get; set; }
        private int frameCount;

        public Debugger()
        {
            Mode = DebugMode.EnableLogging | DebugMode.DisplayState;
        }

        public void Pause()
        {
            Mode |= DebugMode.StepByStep;
        }

        public void Continue()
        {
            Mode |= ~DebugMode.StepByStep;
        }

        public void StepOver(int frameCount)
        {
            Continue();
            this.frameCount = frameCount;
        }
        
        public void NotifyInstructionExecuted()
        {
            frameCount--;

            if (frameCount == 0)
                Pause();
        }
    }
}
