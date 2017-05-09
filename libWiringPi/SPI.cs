using System.Runtime.InteropServices;

namespace libWiringPi
{
    public static class SPI
    {
        const string SPI_LIBRARY = "libwiringPiSPI.so";
        

        [DllImport(SPI_LIBRARY, EntryPoint = "wiringPiSPIGetFd")]
        public static extern int wiringPiSPIGetFd(int channel);


        [DllImport(SPI_LIBRARY, EntryPoint = "wiringPiSPIDataRW")]
        public static extern int wiringPiSPIDataRW(int channel, [In Out] byte[] data, int len);


        [DllImport(SPI_LIBRARY, EntryPoint = "wiringPiSPISetupMode")]
        public static extern int wiringPiSPISetupMode(int channel, int speed, int mode);


        [DllImport(SPI_LIBRARY, EntryPoint = "wiringPiSPISetup")]
        public static extern int wiringPiSPISetup(int channel, int speed);
    }
}
