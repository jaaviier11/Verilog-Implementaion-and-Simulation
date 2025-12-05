// File: FSM_Core.v
// Implementasi FSM 4-Status menggunakan logika transisi JK.

module FSM_Core (
    input  logic CLK, RESET_N,
    input  logic SE, SW, OTAR, RH_IN, 

    output logic BUZZER, LED, HMD, FAN, HTR, MOT
);

    // --- Definisi Status Biner ---
    parameter S0_NOT_OCCUPIED = 2'b00;
    parameter S1_WARNING      = 2'b01;
    parameter S2_RESTING      = 2'b10;
    parameter S3_EMERGENCY    = 2'b11;

    // --- Sinyal Status Internal ---
    reg [1:0] current_state, next_state;
    
    // Sinyal Biner Q1 dan Q0 (Output dari FF Status)
    wire Q1 = current_state[1];
    wire Q0 = current_state[0];
    
    // Sinyal Input JK (Untuk Next State Logic)
    wire J1, K1, J0, K0;

    // Sinyal Kalkulasi Next State (DIKOREKSI: Dideklarasikan sebagai wire di luar always)
    wire Q1_next_calc; 
    wire Q0_next_calc; 

    // ===================================================
    // BLOK 1: Register Status (Penyimpanan Status)
    // ===================================================
    always @(posedge CLK or negedge RESET_N) begin
        if (!RESET_N) begin
            current_state <= S0_NOT_OCCUPIED;
        end else begin
            current_state <= next_state;
        end
    end

    // ===================================================
    // BLOK 2: Logika Transisi JK (Kombinasional - Menggunakan ASSIGN)
    // ===================================================
    
    // Menghitung J dan K (Logika dari Penyederhanaan QM)
    assign J1 = SE | (~SE & ~SW & OTAR);
    assign K1 = (~SE & SW) | (~SE & ~OTAR);
    assign J0 = SE | (~SE & SW);
    assign K0 = ~SE & ~SW;
    
    // Menghitung Q(n+1) secara Biner (Next State Logic)
    // Q(n+1) = J * !Q(n) + !K * Q(n)
    // Ini adalah logika kombinatorial, DIBERI NILAI menggunakan ASSIGN
    assign Q1_next_calc = (J1 & ~Q1) | (~K1 & Q1);
    assign Q0_next_calc = (J0 & ~Q0) | (~K0 & Q0);
    
    // Konversi hasil biner ke tipe State_Type (Enum) - Blok Kombinasional
    always @(*) begin
        // next_state adalah reg, diberi nilai di sini
        case ({Q1_next_calc, Q0_next_calc})
            S0_NOT_OCCUPIED: next_state = S0_NOT_OCCUPIED;
            S1_WARNING:      next_state = S1_WARNING;
            S2_RESTING:      next_state = S2_RESTING;
            S3_EMERGENCY:    next_state = S3_EMERGENCY;
            default: next_state = S0_NOT_OCCUPIED;
        endcase
    end
    
    // ===================================================
    // BLOK 3: Logika Output (Kombinasional Berdasarkan Status)
    // ===================================================
    always @(*) begin
        // Reset default output 
        BUZZER = 1'b0; LED = 1'b0; HMD = 1'b0; FAN = 1'b0; HTR = 1'b0; MOT = 1'b0;

        case (current_state)
            S0_NOT_OCCUPIED: begin
                MOT = 1'b0; // Motor: Sitting
                HMD = ~RH_IN;
                FAN = RH_IN;
                HTR = RH_IN;
            end
            S1_WARNING: begin
                LED = 1'b1; // LED ON
            end
            S2_RESTING: begin
                MOT = 1'b1; // Motor: Lying
                HMD = ~RH_IN;
                FAN = RH_IN;
                HTR = RH_IN;
            end
            S3_EMERGENCY: begin
                BUZZER = 1'b1; // Buzzer & LED ON
                LED    = 1'b1;
            end
            default: begin end
        endcase
    end

endmodule