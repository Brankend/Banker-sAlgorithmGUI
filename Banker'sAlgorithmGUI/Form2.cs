namespace Banker_sAlgorithmGUI
{



    public partial class Form2 : Form
    {
        public static List<int> available = new List<int> { };
        public static List<int> total = new List<int> { };
        static List<Proc> executeSequence = new List<Proc>();
        static List<Proc> runningProcs = new List<Proc> { };

        private class Proc
        {
            public static int totalProcs = 0;
            public int procNum;
            public int[] allocated;
            public int[] max;
            public int[] needed;
            public bool isFinished;
            public Proc(int[] allocated, int[] max)
            {
                procNum = totalProcs;
                totalProcs++;
                this.allocated = allocated;
                this.max = max;
                needed = new int[3];
                isFinished = false;
            }

            public void CalculateNeeded()
            {
                for (int i = 0; i < allocated.Length; i++)
                {
                    needed[i] = max[i] - allocated[i];
                }
            }

            public bool CanFinish()
            {
                for (int i = 0; i < available.Count; i++)
                {
                    return !(available[i] < needed[i]);
                }
                isFinished = true;
                return true;
            }
            public override string ToString()
            {
                return ("p" + procNum);
            }
            public static string PrintExecuteSequence()
            {
                string execSeq = "(";
                if (executeSequence.Count != 0)
                {
                    for (int i = 0; i < executeSequence.Count; i++)
                    {
                        execSeq += executeSequence[i].ToString() + " ";
                    }
                }
                execSeq += ")";
                return execSeq;
            }

        }

        private static void calcAvailable(DataGridView dg5, DataGridView dg1, DataGridView dg2)
        {
            List<int> tempTotal = new List<int>();
            List<int> tempUsed = new List<int>();
            for (int i = 0; i < Form1.numOfResources; i++)
            {
                tempTotal.Add(int.Parse(dg5.Rows[i].Cells[1].Value.ToString()));
                tempUsed.Add(0);
                for (int j = 0; j < dg2.Rows.Count; j++)
                {
                    tempUsed[i] += int.Parse(dg2.Rows[j].Cells[i + 1].Value.ToString());
                }
            }
            for (int i = 0; i < tempUsed.Count; i++)
            {
                dg1.Rows[i].Cells[1].Value = (tempTotal[i] - tempUsed[i]).ToString();
            }
            //for(int i = 0; i < Form1.numOfResources; i++)
            //{
            //    for(int j = 0; j < runningProcs.Count; j++)
            //    {
            //        tempUsed[i] += runningProcs[j].allocated[i];
            //    }
            //}

        }

        private static void updateAvailable(DataGridView dg1)
        {
            for (int i = 0; i < available.Count; i++)
            {
                dg1.Rows[i].Cells[1].Value = available[i].ToString();
            }
        }



        private static bool Banker_sAlgorithm(List<Proc> runningProcs, DataGridView dg1, DataGridView dg4)
        {
            int lastNumOfRunningProcs = 0;
            while (lastNumOfRunningProcs != runningProcs.Count)
            {
                for (int i = 0; i < runningProcs.Count; i++)
                {
                    if (runningProcs[i].CanFinish())
                    {


                        for (int j = 0; j < runningProcs[i].allocated.Length; j++)
                        {
                            available[j] += runningProcs[i].allocated[j];
                        }
                        updateAvailable(dg1);
                        dg4.Rows.Add(runningProcs[i].ToString(), " Can be finished");
                        MessageBox.Show(runningProcs[i].ToString() + " Can be finished");
                        executeSequence.Add(runningProcs[i]);
                        runningProcs.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        dg4.Rows.Add(runningProcs[i].ToString(), " Can't be finished");
                        MessageBox.Show(runningProcs[i].ToString() + " Can't be finished");
                    }
                }
            }
            return runningProcs.Count == 0;
        }


        public Form2()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView5.ColumnCount = 2;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Name = "Resource Name";
            dataGridView1.Columns[1].Name = "Resource Value";
            for (int i = 0; i < Form1.numOfResources; i++)
            {
                dataGridView1.Rows.Add("Resource" + i, "");
            }
            for (int i = 0; i < Form1.numOfResources; i++)
            {
                dataGridView5.Rows.Add("Resource" + i, "");
            }



            dataGridView2.ColumnCount = Form1.numOfResources + 1;
            dataGridView2.Columns[0].Name = "Process";
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].Name = "Resource " + (i - 1);
            }
            for (int i = 0; i < Form1.numOfProcesses; i++)
            {
                dataGridView2.Rows.Add("Process " + i);
            }


            dataGridView3.ColumnCount = Form1.numOfResources + 1;
            dataGridView3.Columns[0].Name = "Process";
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView3.Columns[i].Name = "Resource " + (i - 1);
            }
            for (int i = 0; i < Form1.numOfProcesses; i++)
            {
                dataGridView3.Rows.Add("Process " + i);
            }


            dataGridView4.ColumnCount = 2;
            dataGridView4.Columns[0].Name = "Process";
            dataGridView4.Columns[1].Name = "Value";

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<Proc> runningProcs = new List<Proc> { };
            //for (int i = 0; i < Form1.numOfResources; i++)
            //{

            //    available.Add(int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            //}
            calcAvailable(dataGridView5, dataGridView1, dataGridView2);
            for (int i = 0; i < Form1.numOfResources; i++)
            {

                available.Add(int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }
            for (int i = 0; i < Form1.numOfResources; i++)
            {

                total.Add(int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));
            }


            for (int i = 0; i < Form1.numOfProcesses; i++)
            {
                List<int> allocatedTemp = new List<int> { };
                List<int> maxTemp = new List<int> { };

                for (int j = 1; j <= Form1.numOfResources; j++)
                {

                    allocatedTemp.Add(int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString()));


                    maxTemp.Add(int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()));

                }

                Proc procTemp = new Proc(allocatedTemp.ToArray(), maxTemp.ToArray());
                runningProcs.Add(procTemp);
            }

            for (int i = 0; i < runningProcs.Count; i++)
            {
                runningProcs[i].CalculateNeeded();
            }

            if (Banker_sAlgorithm(runningProcs, dataGridView1, dataGridView4))
            {
                txtBoxTest.Text = ("Safe Sequence" + Proc.PrintExecuteSequence());
            }
            else
            {
                txtBoxTest.Text = "Unsafe Sequence";
            }
        }
    }
}
