using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simulasi_Eldig
{
    public partial class Form1 : Form
    {
        // Objek monitor diinisialisasi secara global untuk mempertahankan status FSM
        private VitalSignMonitor monitor = new VitalSignMonitor();

        public Form1()
        {
            InitializeComponent();
            // Panggil update awal saat form dimuat
            UpdateUI(monitor.CurrentState, monitor.GetOutputs(false), 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Baca Input Sensor Mentah (Asumsi CheckBox tersedia)
            bool HR = chkHR.Checked;
            bool BP = chkBP.Checked;
            bool BT = chkBT.Checked;
            bool LC = chkLC.Checked;
            bool A = chkA.Checked;

            // Asumsi: RH_IN menggunakan CheckBox BT (atau harus dibuat CheckBox terpisah)
            // *Untuk tujuan simulasi ini, kita buat RH_IN menggunakan CheckBox BT*
            bool RH_IN = chkBT.Checked;

            // 2. Hitung Sinyal Prioritas FSM (S_E, S_W, OTAR)
            int riskCount = (HR ? 1 : 0) + (BP ? 1 : 0) + (BT ? 1 : 0);

            bool SE_sig = (riskCount >= 2);
            bool SW_sig = (riskCount == 1) && !SE_sig;
            bool OTAR_sig = LC && A;

            // 3. Update FSM Status (Logika Sekuensial)
            monitor.UpdateState(SE_sig, SW_sig, OTAR_sig);

            // 4. Dapatkan Output Aktuator (Logika Kombinasional)
            var outputs = monitor.GetOutputs(RH_IN);

            // 5. Update UI 
            UpdateUI(monitor.CurrentState, outputs, riskCount);
        }

        // --- Metode untuk Update Tampilan UI ---
        private void UpdateUI(FSM_State state, (bool Buzzer, bool LED, bool Motor, bool HMD, bool FAN, bool HTR) outputs, int riskCount)
        {
            // --- Area Status ---
            lblCurrentState.Text = state.ToString();
            lblRiskCount.Text = riskCount.ToString();

            // --- Area Output Aktuator ---

            // Buzzer (S3)
            lblBuzzer.Text = outputs.Buzzer ? "1 (ON)" : "0 (OFF)";
            lblBuzzer.BackColor = outputs.Buzzer ? Color.Red : SystemColors.Control;

            // LED (S1, S3)
            lblLED.Text = outputs.LED ? "1 (ON)" : "0 (OFF)";
            lblLED.BackColor = outputs.LED ? Color.Yellow : SystemColors.Control;

            // Motor (MOT)
            lblMOT.Text = outputs.Motor ? "1 (Lying)" : "0 (Sitting)";

            // Kontrol Lingkungan RH
            lblHMD.Text = outputs.HMD ? "1" : "0";
            lblFAN.Text = outputs.FAN ? "1" : "0";
            lblHTR.Text = outputs.HTR ? "1" : "0";

            // Tambahan visual untuk Fan/Heater
            lblFAN.BackColor = outputs.FAN ? Color.Aqua : SystemColors.Control;
            lblHTR.BackColor = outputs.HTR ? Color.Orange : SystemColors.Control;
        }

        // --- Event handler lainnya (dibiarkan kosong sesuai template) ---
        private void Form1_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
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

            // Logika Prioritas FSM: SE > SW > OTAR (Occupancy Target)
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
                nextState = FSM_State.S2_Resting; // Target Lying
            }
            else
            {
                nextState = FSM_State.S0_NotOccupied; // Target Sitting
            }

            // Transisi Status
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

            // Logika Aktuator Berdasarkan Status
            switch (CurrentState)
            {
                case FSM_State.S3_Emergency:
                    buzzer = true; led = true;
                    // Kontrol lingkungan dimatikan
                    break;
                case FSM_State.S1_Warning:
                    led = true;
                    // Kontrol lingkungan dimatikan
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
}