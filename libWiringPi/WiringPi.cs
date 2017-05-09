using System.Runtime.InteropServices;

namespace libWiringPi
{
    public static class WiringPi
    {
        const string WIRINGPI_LIBRARY = "libwiringPi.so";

        #region Setup functions

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "wiringPiSetup")]
        public static extern int wiringPiSetup();

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "wiringPiSetupSys")]
        public static extern int wiringPiSetupSys();

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "wiringPiSetupGpio")]
        public static extern int wiringPiSetupGpio();

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "wiringPiSetupPhys")]
        public static extern int wiringPiSetupPhys();

        #endregion


        #region Pin control

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pinModeAlt")]
        public static extern void pinModeAlt(int pin, PinModes mode);
        
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pinMode")]
        public static extern void pinMode(int pin, PinModes mode);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pullUpDnControl")]
        public static extern void pullUpDnControl(int pin, PullUpDpwnMode pud);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "digitalRead")]
        public static extern PinState digitalRead(int pin);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "digitalWrite")]
        public static extern void digitalWrite(int pin, PinState value);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pwmWrite")]
        public static extern void pwmWrite(int pin, int value);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "analogRead")]
        public static extern int analogRead(int pin);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "analogWrite")]
        public static extern void analogWrite(int pin, int value);


        #endregion


        #region Hardware specific

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piBoardRev")]
        public static extern int piBoardRev();

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piBoardId")]
        public static extern void piBoardId(out int model, out int rev, out int mem, out int maker, out int overVolted);
        
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "wpiPinToGpio")]
        public static extern int wpiPinToGpio(int wpiPin);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "physPinToGpio")]
        public static extern int physPinToGpio(int physPin);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "setPadDrive")]
        public static extern void setPadDrive(int group, int value);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "getAlt")]
        public static extern PinModes getAlt(int pin);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pwmToneWrite")]
        public static extern void pwmToneWrite(int pin, int freq);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "digitalWriteByte")]
        public static extern void digitalWriteByte(int value);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pwmSetMode")]
        public static extern void pwmSetMode(int mode);
        
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pwmSetRange")]
        public static extern void pwmSetRange(uint range);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "pwmSetClock")]
        public static extern void pwmSetClock(int divisor);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "gpioClockSet")]
        public static extern void gpioClockSet(int pin, int freq);


        #endregion


        #region Interrupt

        // deprecated
        [DllImport("libwiringPi.so", EntryPoint = "waitForInterrupt")]
        public static extern int waitForInterrupt(int pin, int timeout);

        //This is the C# equivelant to "void (*function)(void))" required by wiringPi to define a callback method
        public delegate void ISRCallback();
        [DllImport("libwiringPi.so", EntryPoint = "wiringPiISR")]
        public static extern int wiringPiISR(int pin, InterruptLevel mode, ISRCallback method);

        #endregion
        

        #region Threads / Timing

        public delegate void WiringThreadFunc();
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piThreadCreate")]
        public static extern int piThreadCreate(WiringThreadFunc threadfunction);

        
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piLock")]
        public static extern void piLock(int key);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piUnlock")]
        public static extern void piUnlock(int key);

        // Schedulling priority
        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "piHiPri")]
        public static extern int piHiPri(int pri);


        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "delay")]
        public static extern void delay(uint howLong_ms);

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "delay")]
        public static extern void delayMicroseconds(uint howLong_us);


        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "millis")]
        public static extern uint millis();

        [DllImport(WIRINGPI_LIBRARY, EntryPoint = "micros")]
        public static extern uint micros();

        #endregion
    }
}
