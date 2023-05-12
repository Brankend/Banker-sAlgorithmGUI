# Banker's Algorithm GUI in C#

The Banker's Algorithm GUI is a windows forms application that implements the banker's algorithm for resource allocation and deadlock avoidance. The application consists of two forms: Form1 and Form2.

## Form1

Form1 takes the number of processes and resources from the user and passes them to Form2. It has the following controls:

- Two text boxes (`txtBoxNumResources` and `txtBoxNumProcesses`) for entering the number of resources and processes, respectively.
- A button (`btnOK`) for creating Form2. When the button is clicked, it parses the text boxes values and assigns them to two static variables (`numOfResources` and `numOfProcesses`). Then it creates an instance of Form2 and shows it as a dialog.

## Form2

Form2 allows the user to input the table of total available resources, currently allocated resources, and maximum needed resources for each process. It also calculates the currently available resources and the needed resources for each process and then tries to find a safe sequence while showing the steps to the user. It has the following controls:

- Five data grid views (`dataGridView1`, `dataGridView2`, `dataGridView3`, `dataGridView4`, and `dataGridView5`) for displaying the input and output tables.
  - `dataGridView1` shows the currently available resources for each resource type.
  - `dataGridView2` shows the currently allocated resources for each process and resource type.
  - `dataGridView3` shows the maximum needed resources for each process and resource type.
  - `dataGridView4` shows the steps of finding a safe sequence, including which process can or cannot finish.
  - `dataGridView5` shows the total available resources for each resource type.
- A button (`btnStart`) for starting the algorithm. When the button is clicked, it initializes some static variables and lists (`available`, `total`, `executeSequence`, and `runningProcs`) that store the data structures for the algorithm. Then it creates a list of `Proc` objects that represent each process with its allocated, max, and needed resources. Then it calls a static method (`Banker_sAlgorithm`) that implements the safety algorithm and determines if there is a safe sequence or not. Finally, it displays the result in a text box (`txtBoxTest`).

## Data Structures

The following data structures are used to implement the banker's algorithm:

- A class (`Proc`) that represents a process with its allocated, max, and needed resources. It also has some methods to calculate its needed resources, check if it can finish with the available resources, and print its name.
- A list (`available`) that stores the number of available resources of each type.
- A list (`total`) that stores the number of total available resources of each type.
- A list (`executeSequence`) that stores the safe sequence of processes that can finish without exceeding the available resources.
- A list (`runningProcs`) that stores the list of processes that are not finished yet.

## Algorithm

The algorithm for finding out whether or not a system is in a safe state can be described as follows:

- Let `Work` and `Finish` be vectors of length `m` and `n` respectively.
- Initialize: `Work = Available`, `Finish[i] = false` for `i = 1, 2, ..., n`.
- Find an `i` such that both:
  - `Finish[i] = false`
  - `Need_i <= Work`
- If no such `i` exists, go to step (4).
- `Work = Work + Allocation_i`
- `Finish[i] = true`
- Go to step (2).
- If `Finish[i] = true` for all `i`, then the system is in a safe state.

Safe sequence is the sequence in which the processes can be safely executed.
