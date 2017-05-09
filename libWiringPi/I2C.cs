using System.Runtime.InteropServices;

namespace libWiringPi
{
    public class I2C
    {
        //Changes done to new branch

        const string I2C_LIBRARY = "libwiringPiI2C.so";

        #region read

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CRead")]
        public static extern int wiringPiI2CRead(int fd);


        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CReadReg8")]
        public static extern int wiringPiI2CReadReg8(int fd, int reg);


        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CReadReg16")]
        public static extern int wiringPiI2CReadReg16(int fd, int reg);

        #endregion

        #region write

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CWrite")]
        public static extern int wiringPiI2CWrite(int fd, int data);

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CWriteReg8")]
        public static extern int wiringPiI2CWriteReg8(int fd, int reg, int data);

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CWriteReg16")]
        public static extern int wiringPiI2CWriteReg16(int fd, int reg, int data);

        #endregion


        #region setup

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CSetupInterface")]
        public static extern int wiringPiI2CSetupInterface(string device, int devId);

        [DllImport(I2C_LIBRARY, EntryPoint = "wiringPiI2CSetup")]
        public static extern int wiringPiI2CSetup(int devId);

        #endregion
    }
}
