using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NS.Percepton;

namespace NS
{
    public partial class Form1 : Form
    {
        private LoadXML XML = new LoadXML();
        private NS.Percepton.Percepton _percepton;
        private NS.Percepton.ShowPercepton _showPercepton;

        public Form1()
        {
            InitializeComponent();
            Application.DoEvents();

            this.Invalidate();
            _showPercepton = new ShowPercepton(pictureBox1);
            
        }

        
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eventLogShow(object sender, string Text)
        {
            richTextBox1.AppendText(Text);
            richTextBox1.ScrollToCaret();
        }

        private void ChangeWGrid()
        {
            dataGridViewWeight.Rows.Clear();
            dataGridViewWeight.Columns.Clear();
            dataGridViewWeight.Columns.Add("Weights", "Weights");

            for (int i = 0; i < _percepton.weights.Count; i++)
            {
                int rowId = dataGridViewWeight.Rows.Add();

                DataGridViewRow row = dataGridViewWeight.Rows[rowId];

                row.Cells["Weights"].Value = _percepton.weights[i];


            }

            labelBias.Text = "Bias: " + _percepton.bias;
            labelLrate.Text = "Learning rate: " + _percepton.learning;
        }
        private void buttonLoadXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();

            
            XML = new LoadXML();
            _percepton = new Percepton.Percepton();
            _showPercepton = new ShowPercepton(pictureBox1);

            dataGridViewTrain.Rows.Clear();
            dataGridViewTrain.Columns.Clear();

            dataGridViewTest.Rows.Clear();
            dataGridViewTest.Columns.Clear();

            dataGridViewWeight.Rows.Clear();
            dataGridViewWeight.Columns.Clear();
            
            if (File.ShowDialog() == DialogResult.OK)
            {
                XML.ReadXML(File.FileName);
            }

            _percepton = new NS.Percepton.Percepton(XML._weights,XML._learning);
            //_percepton.eventHandler += eventLogShow;
            //_percepton.eventDrawHandler += percepton_changeWeight;

            
            for (int i = 0; i < XML._names.Count; i++)
            {
                dataGridViewTest.Columns.Add(XML._names[i], XML._names[i]);
                dataGridViewTrain.Columns.Add(XML._names[i], XML._names[i]);

            }
            dataGridViewTrain.Columns.Add("Output","Output");
            dataGridViewWeight.Columns.Add("Weights", "Weights");


            for (int i = 0; i < XML._testSet.Count; i++)
            {
                int rowId = dataGridViewTest.Rows.Add();

                DataGridViewRow row = dataGridViewTest.Rows[rowId];

                for (int j = 0; j < XML._testSet[i].Count; j++)
                {
                    row.Cells[XML._names[j]].Value = XML._testSet[i][j];
                }

            }

            for (int i = 0; i < _percepton.weights.Count; i++)
            {
                int rowId = dataGridViewWeight.Rows.Add();

                DataGridViewRow row = dataGridViewWeight.Rows[rowId];

                row.Cells["Weights"].Value = _percepton.weights[i] ;
            

            }

            for (int i = 0; i < XML._trainSet.Count; i++)
            {
                int rowId = dataGridViewTrain.Rows.Add();

                DataGridViewRow row = dataGridViewTrain.Rows[rowId];

                for (int j = 0; j < XML._trainSet[i].Count; j++)
                {
                    row.Cells[XML._names[j]].Value = XML._trainSet[i][j];
                }

                row.Cells["Output"].Value = XML._trainOutput[i];
            }

            labelBias.Text = "Bias: " + _percepton.bias;
            labelLrate.Text = "Learning rate: " + _percepton.learning;

            _showPercepton.max = XML._max.ToArray();
            _showPercepton.min = XML._min.ToArray();
            _showPercepton._points = XML._trainSet.ConvertAll(x => new List<double>(x));
            _showPercepton._expectedPoint =new List<double>( XML._trainOutput);
            _showPercepton.percepton = _percepton;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            
            for (int E = 0; E < 2000; E++)
            {
                int sum = 0;
                for (int i = 0; i < XML._trainSet.Count; i++)
                {
                   

                    List<double> Input = new List<double>();
                    for (int j = 0; j < XML._trainSet[i].Count; j++)
                        Input.Add(Percepton.Percepton.ConverMaxMin(XML._trainSet[i][j], XML._min[j], XML._max[j], 0, 1));

                    var output = _percepton.Predict(Input);
                    sum = (output == (int)XML._trainOutput[i]) ? sum + 1 : 0;

                    _percepton.Train(Input, (int)XML._trainOutput[i]);

                    _showPercepton.Draw();
                    ChangeWGrid();
                    this.Invalidate();
                    this.Update();
                }

                if (sum == XML._trainSet.Count)
                    break;

            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            /*
            for (int i = 0; i < XML._testSet .Count; i++)
            {
                string s = "\n";
                for (int j = 0; j < XML._testSet[i].Count; j++)
                {
                    s += ($"[{XML._testSet[i][j]}] " );
                    
                }
                s += ($" OUTPUT ==> {_percepton.Predict(XML._testSet[i])} ");

                richTextBox1.AppendText(s);
                richTextBox1.ScrollToCaret();
            }
            */
            richTextBox1.AppendText("\n ============CHECK============\n");
            for (int i = 0; i < XML._trainSet.Count; i++)
            {
                List<double> Input = new List<double>();
                string s = "\n";
                for (int j = 0; j < XML._trainSet[i].Count; j++)
                {
                    s += ($"[{XML._trainSet[i][j]}] ");
                    Input.Add(Percepton.Percepton.ConverMaxMin(XML._trainSet[i][j], XML._min[j], XML._max[j], 0, 1));
                }


                var output = _percepton.Predict(Input);
                s += ($" OUTPUT ==> {output} ");

                richTextBox1.AppendText(s);
                richTextBox1.ScrollToCaret();
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _showPercepton.Draw();
            ((PictureBox)(sender)).Invalidate();
        }

        private void percepton_changeWeight(object sender,List<double> e)
        {
            _showPercepton.Draw();
            //pictureBox1.Invalidate();
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\n ===========TEST============\n");
            for (int i = 0; i < XML._testSet.Count; i++)
            {
                string s = "\n";
                for (int j = 0; j < XML._testSet[i].Count; j++)
                {
                    s += ($"[{XML._testSet[i][j]}] ");

                }
                s += ($" OUTPUT ==> {_percepton.Predict(XML._testSet[i])} ");

                richTextBox1.AppendText(s);
                richTextBox1.ScrollToCaret();
            }
        }
    }
}
