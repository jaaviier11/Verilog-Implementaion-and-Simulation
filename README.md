# FSM and C#: About the project

This project implements a **Hierarchical Finite State Machine (FSM)** designed for real-time patient monitoring and automated bed adjustment, prioritizing medical safety above all else. The logic is verified using HDL (Verilog) for hardware implementation and C# for interactive software simulation.

---

## 1. Project Overview and Logic Hierarchy

The system operates based on three core priority signals derived from six multi-modal sensors (HR, BP, BT, LC, A).

### 1.1. Core FSM Logic

The system state is controlled by a 4-state FSM implemented with **JK Flip-Flop** logic.

| State Name | Code (Q1Q0) | Priority Trigger | Actuator Action |
| :--- | :---: | :--- | :--- |
| **S3\_EMERGENCY** | 11 | **S_E** ($\text{Risk Count} \ge 2$) | Buzzer, LED ON; Motor OFF |
| **S1\_WARNING** | 01 | **S_W** ($\text{Risk Count} = 1$) | LED ON; Motor OFF |
| **S2\_RESTING** | 10 | **O_TAR** ($\text{LC} \land \text{A} = 1$) | Motor ON ($\text{Lying}$); RH Control ON |
| **S0\_NOT\_OCCUPIED** | 00 | **$\overline{\text{O}}_{\text{TAR}}$** ($\text{LC} \land \text{A} = 0$) | Motor OFF ($\text{Sitting}$); RH Control ON |

### 1.2. Input Signal Logic (Logic\_Input.v)

This module converts sensor inputs into FSM priority signals.

| Sensor Input | Logika Risiko (1) | FSM Priority Output |
| :---: | :--- | :---: |
| **HR, BP, BT** | $\text{Risk} = \text{Out of Safe Range}$ | **S_E** (Emergency) or **S_W** (Warning) |
| **LC** $\land$ **A** | $\text{LC} \land \text{A} = 1$ | **O_TAR** (Occupancy Target) |
| **RH** | $\text{RH} > 60\%$ (1) or $\text{RH} < 40\%$ (0) | **RH\_IN** (Environmental Control) |

---

## 2. Hardware Implementation (Verilog) 🖥️

### 2.1. Module Structure

The FSM logic is split into two modules:

1.  **`Logic_Input.v`:** Handles combinatorial logic for risk summation and priority signal calculation.
2.  **`FSM_Core.v`:** Implements the sequential state machine using calculated $\text{J}/\text{K}$ logic and controls actuators based on the stable `current_state`.

### 2.2. Key Verilog Equations (Derived from QM)

The core sequential memory is managed by the following optimized $\text{JK}$ equations:

$$J_1 = S_E + (\overline{S_E} \cdot \overline{S_W} \cdot O_{\text{TAR}})$$
$$K_1 = (\overline{S_E} \cdot S_W) + (\overline{S_E} \cdot \overline{O_{\text{TAR}}})$$
$$J_0 = S_E + (\overline{S_E} \cdot S_W)$$
$$K_0 = \overline{S_E} \cdot \overline{S_W}$$

### 2.3. Execution and Verification

The hardware design is verified via a hierarchical testbench and synthesized for an FPGA (e.g., Intel Cyclone V).

* **Compiler:** Icarus Verilog (`iverilog`)
* **Simulator:** VVP
* **Waveform Analysis:** GTKWave (using the generated VCD file)
    * Verification confirms that the $\text{MOT}$ signal correctly switches to $\text{1}$ only when entering state $\text{S2}$ (Resting), and immediately switches to $\text{0}$ if $\text{S}_E$ or $\text{S}_W$ becomes active.

---

## 3. Software Simulation (C# Console/Forms) 💻

The C# component serves as an interactive simulation environment to validate the FSM's hierarchical logic before final hardware commitment.

### 3.1. Class Structure

* **`FSM_State` (Enum):** Defines the four discrete states ($\text{S0, S1, S2, S3}$).
* **`VitalSignMonitor` (Class):** Holds the `CurrentState` memory and implements the sequential `UpdateState` method and the combinatorial `GetOutputs` method.

### 3.2. Simulation Logic

The C# application simulates time by running the `UpdateState` method upon a defined event (e.g., a button click or a loop cycle), using boolean variables for input instead of digital hardware signals.

```csharp
// Logic to calculate priority signals:
int riskCount = (HR ? 1 : 0) + (BP ? 1 : 0) + (BT ? 1 : 0);
bool SE_sig = (riskCount >= 2);
bool SW_sig = (riskCount == 1) && !SE_sig;

// FSM Update (Sequential step)
monitor.UpdateState(SE_sig, SW_sig, OTAR_sig);

// Output Check (Combinatorial step)
var outputs = monitor.GetOutputs(RH_IN);