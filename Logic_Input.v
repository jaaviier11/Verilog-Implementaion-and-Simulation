// File: Logic_Input.v

module Logic_Input (
    // Deklarasi Port
    input  HR_bin, BP_bin, BT_bin, LC_bin, A_bin, RH_IN,

    // OUTPUT dideklarasikan sebagai 'output wire'
    output wire SE_out, SW_out, OTAR_out, RH_FSM 
);

    // Risk_Count adalah sinyal kombinatorial
    wire [1:0] Risk_Count_wire; 
    
    // Logika Penjumlahan Risiko (Kombinasional)
    assign Risk_Count_wire = HR_bin + BP_bin + BT_bin;
    
    // Logika Sinyal Prioritas FSM (Menggunakan assign)
    
    // SE (Emergency): Risk_Count >= 2
    assign SE_out = (Risk_Count_wire >= 2); // Baris 18 diperbaiki
    
    // SW (Warning): Risk_Count = 1 DAN tidak Emergency
    assign SW_out = (Risk_Count_wire == 1) & (!SE_out); // Baris 21 diperbaiki

    // OTAR (Occupancy Target): LC AND A
    assign OTAR_out = LC_bin & A_bin; // Baris 24 diperbaiki
    
    // RH diteruskan
    assign RH_FSM = RH_IN; // Baris 27 diperbaiki

endmodule