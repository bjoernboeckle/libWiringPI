using libWiringPi;
using System;
using System.Windows.Forms;

namespace Forms_Example
{
    public partial class Form1 : Form
    {
        const int GREEN_LED = 0;
        const int YELLOW_LED = 2;
        const int RED_LED = 3;
        private int[] LEDS = { GREEN_LED, YELLOW_LED, RED_LED };

        static void DEBUG_PRINT(string text)
        {
            Console.WriteLine(text);
        }

        public Form1()
        {
            InitializeComponent();
            checkBoxGreen.Tag = GREEN_LED;
            checkBoxYellow.Tag = YELLOW_LED;
            checkBoxRed.Tag = RED_LED;
            SetupPins();
        }

        private void SetupPins()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if ( chk != null)
            {
                WiringPi.digitalWrite((int)chk.Tag, chk.Checked ? PinState.HIGH : PinState.LOW);                
            }
        }
    }
}
