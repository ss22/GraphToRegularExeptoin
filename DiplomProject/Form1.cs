using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace DiplomProject
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        CreateGraph NewGraph;
        Graph graph;

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetNewGraph(Graph newGraph)
        {
            graph = new Graph(newGraph);
        }

        private void ShowGraph()
        {
            if (graph != null)
            {
                tbVertices.Clear();
                tbEdges.Clear();

                tbVertices.AppendText(graph.FirstVertex.ToString() + "\r\n");
                foreach (Vertex vertex in graph.Vertices)
                {
                    tbVertices.AppendText(vertex.ToString() + "\r\n");
                }
                tbVertices.AppendText(graph.LastVertex.ToString() + "\r\n");

                foreach(Edge edge in graph.Edges)
                {
                    tbEdges.AppendText(edge.ToString() + "\r\n");
                }
            }
            else
                MessageBox.Show("Please, open or create graph!", "No graph!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Vertex> tmpVertex = new List<Vertex>();
            List<Edge> tmpEdge = new List<Edge>();
           
            Vertex v1 = new Vertex(1, 2);
            Vertex v2 = new Vertex(2, 3);
            Vertex v3 = new Vertex(3, 6);
            Vertex v4 = new Vertex(4, 5);
            Vertex v5 = new Vertex(5, 2);

            
            tmpVertex.Add(v1);
            tmpVertex.Add(v2);
            tmpVertex.Add(v3);
            tmpVertex.Add(v4);
            tmpVertex.Add(v5);

            Edge e1 = new Edge(1, 3, "0");
            Edge e2 = new Edge(1, 2, "1");
            Edge e3 = new Edge(2, 4, "0");
            Edge e4 = new Edge(3, 3, "0");
            Edge e5 = new Edge(3, 2, "1");
            Edge e6 = new Edge(3, 4, "10");
            Edge e7 = new Edge(3, 5, "11");
            Edge e8 = new Edge(4, 4, "0");
            Edge e9 = new Edge(4, 5, "1");

            tmpEdge.Add(e1);
            tmpEdge.Add(e2);
            tmpEdge.Add(e3);
            tmpEdge.Add(e4);
            tmpEdge.Add(e5);
            tmpEdge.Add(e6);
            tmpEdge.Add(e7);
            tmpEdge.Add(e8);
            tmpEdge.Add(e9);
            
            Graph g1 = new Graph(tmpVertex, 1, 5, tmpEdge);

            graph = new Graph(g1);

            ShowGraph();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graph != null)
                ShowGraph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graph.GetGraphRegularExpression();
            ShowGraph();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGraph = new CreateGraph();
            this.Visible = false;
            NewGraph.ShowDialog();

            if (NewGraph.DialogResult == DialogResult.OK)
            {
                this.Visible = true;
                graph = NewGraph.ReturnGraph();
                if (graph != null)
                    ShowGraph();
            }
            else
            {
                this.Visible = true;
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Graph));
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                xmlSerializer.Serialize(writer, graph);
                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Graph));
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                graph = (Graph)reader.Deserialize(file);
                file.Close();
                if(graph != null)
                    ShowGraph();
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            graph.Step();
            ShowGraph();
        }
    }
}
