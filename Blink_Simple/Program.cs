using libWiringPi;
using System;


namespace Blink_Simple
{
    class Program
    {
        const int delay = 250;
        const int inPin = 1;         // switch  GPIO18 for pi rev2
        const int pinLed = 0;        // LED     GPIO17 for pi rev2

        static void DEBUG_PRINT(string text)
        {
            Console.WriteLine(text);
        }

        
        static void Main(string[] args)
        {
            try
            {
                // setup uisng wiringpi pin numbering
                int result = WiringPi.wiringPiSetup();
                DEBUG_PRINT("Setup " + result.ToString());
                result = WiringPi.piBoardRev();
                DEBUG_PRINT("Rev " + result.ToString());

                // set outpin mode for led
                WiringPi.pinMode(pinLed, PinModes.OUTPUT);
                WiringPi.digitalWrite(pinLed, PinState.LOW);

                // set input mode for switch
                WiringPi.pinMode(inPin, PinModes.INPUT);
                WiringPi.pullUpDnControl(inPin, PullUpDpwnMode.PUD_UP);


                while (true)
                {
                    DEBUG_PRINT("Wait key...");
                    while (WiringPi.digitalRead(inPin) == PinState.HIGH)
                        System.Threading.Thread.Sleep(20);

                    DEBUG_PRINT("Start Blink");
                    for (int i = 0; i <= 20; i++)
                    {
                        WiringPi.digitalWrite(pinLed, PinState.HIGH);
                        System.Threading.Thread.Sleep(delay);

                        WiringPi.digitalWrite(pinLed, PinState.LOW);
                        System.Threading.Thread.Sleep(delay);
                    }
                    DEBUG_PRINT("Blink finished");
                }
            }
            catch(Exception ex)
            {
                DEBUG_PRINT(ex.Message);
            }
        }
    }
}
