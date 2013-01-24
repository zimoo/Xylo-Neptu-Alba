using System;

namespace XnaFramework.Demos.InputDemo
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (InputDemoGame inputDemoGame = new InputDemoGame())
            {
                inputDemoGame.Run();
            }
        }
    }
#endif
}

