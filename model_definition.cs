// --- Definisi ENUM dan Kelas Monitor (di luar Form1) ---

public enum FSM_State
{
    S0_NotOccupied,
    S1_Warning,
    S2_Resting,
    S3_Emergency
}

public class VitalSignMonitor
{
    public FSM_State CurrentState { get; private set; }

    public VitalSignMonitor()
    {
        CurrentState = FSM_State.S0_NotOccupied; // Inisialisasi awal
    }

    // Metode Update FSM (Menerapkan Logika Prioritas)
    public void UpdateState(bool SE, bool SW, bool OTAR)
    {
        FSM_State nextState;

        if (SE)
        {
            nextState = FSM_State.S3_Emergency;
        }
        else if (SW)
        {
            nextState = FSM_State.S1_Warning;
        }
        else if (OTAR)
        {
            nextState = FSM_State.S2_Resting;
        }
        else
        {
            nextState = FSM_State.S0_NotOccupied;
        }

        CurrentState = nextState;
    }

    // Metode Output: Menghitung Output Aktuator
    public (bool Buzzer, bool LED, bool Motor, bool HMD, bool FAN, bool HTR) GetOutputs(bool RH_IN)
    {
        bool buzzer = false;
        bool led = false;
        bool mot = false;
        bool hmd = false;
        bool fan = false;
        bool htr = false;

        // Logika Aktuator (Kombinasional dalam Status)
        switch (CurrentState)
        {
            case FSM_State.S3_Emergency:
                buzzer = true; led = true;
                break;
            case FSM_State.S1_Warning:
                led = true;
                break;
            case FSM_State.S2_Resting: // Posisi Lying
                mot = true;
                hmd = !RH_IN; fan = RH_IN; htr = RH_IN;
                break;
            case FSM_State.S0_NotOccupied: // Posisi Sitting
                mot = false;
                hmd = !RH_IN; fan = RH_IN; htr = RH_IN;
                break;
        }

        return (buzzer, led, mot, hmd, fan, htr);
    }
}