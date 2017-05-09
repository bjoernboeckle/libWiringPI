using libWiringPi;
using System;


namespace Blink_Interrupt
{
    class Program
    {
        const int delay = 150;
        const int inPin = 1;          // switch  GPIO18
        const int pinGreen = 0;       // green   GPIO17
        const int pinYellow = 2;      // yellow  GPIO27
        const int pinRed = 3;         // red     GPIO22

        static int[] LEDS = { pinGreen, pinYellow, pinRed };

        static volatile bool Running = false;                   // threead safe
        static volatile bool StartSignaled = false;             // threead safe

        static void DEBUG_PRINT(string text)
        {
            Console.WriteLine(text);
        }

        static void SetState(int state)
        {
            for (int i=0; i<LEDS.Length; i++)
            {
                if ( state % ( LEDS.Length*2) < LEDS.Length )
                    WiringPi.digitalWrite(LEDS[i], ((state % LEDS.Length) == i ? PinState.HIGH : PinState.LOW));
                else
                    WiringPi.digitalWrite(LEDS[i], ((state % LEDS.Length) == LEDS.Length - i - 1 ? PinState.HIGH : PinState.LOW));
            }
        }

        static void StartWaitForInterrupt()
        {
            DEBUG_PRINT("Enable Interrupt...wait for key");
            WiringPi.wiringPiISR(inPin, InterruptLevel.INT_EDGE_FALLING, SetStartSignaled);
        }

        static void SetStartSignaled()
        {
            if (!Running && !StartSignaled)
                StartSignaled = true;
            else
            {
                if (StartSignaled)
                    DEBUG_PRINT("Start pending - Ignore key");
                else
                    DEBUG_PRINT("Still running - Ignore key");
            }
        }

        static void DoBlink()
        {
            if (Running)
                return;

            Running = true;
            DEBUG_PRINT("Start Blink");
            for (int i = 0; i <= 50; i++)
            {
                SetState(i);
                System.Threading.Thread.Sleep(delay);
            }
            Running = false;
            StartSignaled = false;

            DEBUG_PRINT("Blink finished, wait new key");
        }


        static void Main(string[] args)
        {
            try
            {
                
                int result = WiringPi.wiringPiSetup();
                DEBUG_PRINT("Setup " + result.ToString());
                result = WiringPi.piBoardRev();
                DEBUG_PRINT("Rev " + result.ToString());

                foreach (var led in LEDS)
                {
                    WiringPi.pinMode(led, PinModes.OUTPUT);
                    WiringPi.digitalWrite(led, PinState.LOW);
                }

                WiringPi.pinMode(inPin, PinModes.INPUT);
                WiringPi.pullUpDnControl(inPin, PullUpDpwnMode.PUD_UP);

                StartWaitForInterrupt();

                while (true)
                {
                    System.Threading.Thread.Sleep(20);
                    if (StartSignaled)
                        DoBlink();
                }
            }
            catch(Exception ex)
            {
                DEBUG_PRINT(ex.Message);
            }
        }
    }
}
