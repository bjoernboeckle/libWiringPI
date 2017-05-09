using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libWiringPi
{
    // WPI mode
    public enum WPIMode
    {
        WPI_MODE_PINS = 0,
        WPI_MODE_GPIO,
        WPI_MODE_GPIO_SYS,
        WPI_MODE_PHYS,
        WPI_MODE_PIFACE,
        WPI_MODE_UNINITIALISED
    }

    // Pin modes
    public enum PinModes
    {
        INPUT = 0,
        OUTPUT,
        PWM_OUTPUT,
        GPIO_CLOCK,
        SOFT_PWM_OUTPUT,
        SOFT_TONE_OUTPUT,
        PWM_TONE_OUTPUT
    };

    // Pin states 
    public enum PinState
    {
        LOW = 0,
        HIGH
    };

    // Pin Pull up/down modes
    public enum PullUpDpwnMode
    {
        PUD_OFF = 0,
        PUD_DOWN,
        PUD_UP
    }

    // PWM
    public enum PWMMode
    {
        PWM_MODE_MS = 0,
        PWM_MODE_BAL
    }


    // Interrupt levels
    public enum InterruptLevel
    {
        INT_EDGE_SETUP = 0,
        INT_EDGE_FALLING,
        INT_EDGE_RISING,
        INT_EDGE_BOTH
    }
}
