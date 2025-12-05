// File: FSM_Core_tb.v
// Testbench untuk FSM_Core

`timescale 1ns / 1ps

module FSM_Core_tb;

    // Signal Declarations
    reg CLK, RESET_N, RH_tb;
    reg HR_tb, BP_tb, BT_tb; // Input Medis
    reg LC_tb, A_tb;         // Input Occupancy

    wire SE_sig, SW_sig, OTAR_sig, RH_FSM_sig;
    wire BUZZER_out, LED_out, HMD_out, FAN_out, HTR_out, MOT_out;

    // Clock Period Definition
    parameter CLK_PERIOD = 10; // 10 ns period

    // ----------------------------------------------------
    // Instansiasi Modul Logic_Input
    // ----------------------------------------------------
    Logic_Input I_LOGIC (
        .HR_bin(HR_tb), .BP_bin(BP_tb), .BT_bin(BT_tb),
        .LC_bin(LC_tb), .A_bin(A_tb), .RH_IN(RH_tb),
        .SE_out(SE_sig), .SW_out(SW_sig), .OTAR_out(OTAR_sig), 
        .RH_FSM(RH_FSM_sig)
    );

    // ----------------------------------------------------
    // Instansiasi Modul FSM_Core (Unit Under Test)
    // ----------------------------------------------------
    FSM_Core UUT_FSM (
        .CLK(CLK), .RESET_N(RESET_N),
        .SE(SE_sig), .SW(SW_sig), .OTAR(OTAR_sig), .RH_IN(RH_FSM_sig),
        .BUZZER(BUZZER_out), .LED(LED_out), .HMD(HMD_out),
        .FAN(FAN_out), .HTR(HTR_out), .MOT(MOT_out)
    );

    // Clock Generation
    initial begin
        CLK = 0;
        forever #(CLK_PERIOD / 2) CLK = ~CLK;
    end

    // Dump VCD File for GTKWave
    initial begin
        $dumpfile("fsm_dump.vcd");
        $dumpvars(0, FSM_Core_tb);
    end

    // Stimulus Generation
    initial begin
        // 1. Reset Awal
        RESET_N = 0;
        HR_tb = 0; BP_tb = 0; BT_tb = 0; LC_tb = 0; A_tb = 0; RH_tb = 0;
        # (CLK_PERIOD * 2) RESET_N = 1;
        # (CLK_PERIOD * 2) ; 

        // 2. Skenario A: S0 -> S2 (Resting/Lying)
        // Input: Medis Aman, Target Lying (OTAR=1), RH=1
        // Expected: S2, MOT=1, FAN/HTR=1
        LC_tb = 1; A_tb = 1; RH_tb = 1; 
        # (CLK_PERIOD * 4) ; 

        // 3. Skenario B: S2 -> S0 (Not Occupied/Sitting)
        // Input: Medis Aman, Target Sitting (OTAR=0), RH=0
        // Expected: S0, MOT=0, HMD=1
        LC_tb = 0; A_tb = 0; RH_tb = 0;
        # (CLK_PERIOD * 4) ;

        // 4. Skenario C: S0 -> S1 (Warning)
        // Input: HR=1 (SW=1), Medis Risiko 1, RH=1
        // Expected: S1, LED=1, Lingkungan OFF
        HR_tb = 1; BP_tb = 0; BT_tb = 0;
        LC_tb = 0; A_tb = 0; RH_tb = 1; 
        # (CLK_PERIOD * 4) ;

        // 5. Skenario D: S1 -> S3 (Emergency Override)
        // Input: HR=1, BP=1 (SE=1)
        // Expected: S3, BUZZER=1, LED=1
        BP_tb = 1;
        # (CLK_PERIOD * 4) ;
        
        // 6. Skenario E: Kembali Normal (S3 -> S0)
        // Input: Medis Aman (SE=0, SW=0)
        // Expected: S0, Semua OFF
        HR_tb = 0; BP_tb = 0;
        # (CLK_PERIOD * 4) ;

        $finish; 
    end
endmodule