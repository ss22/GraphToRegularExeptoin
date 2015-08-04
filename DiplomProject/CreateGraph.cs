using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomProject
{
    /// <summary>
    /// Form for creating new <c>DiplomProject.Graph</c> object.
    /// </summary>
    public partial class CreateGraph : Form
    {
        /// <summary>
        /// Initialize <c>DiplomProject.CreateGraph</c> object.
        /// </summary>
        public CreateGraph()
        {
            InitializeComponent();
        }

        Graph newGraph;
        List<Vertex> vertices;
        List<Edge> edges;

        /// <summary>
        /// Return created <c>DiplomProject.Graph</c> object.
        /// </summary>
        /// <returns><c>DiplomProject.Graph</c> object.</returns>
        public Graph ReturnGraph()
        {
            return newGraph;
        }

        private void btnInitVertices_Click(object sender, EventArgs e)
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();

            tbVertices.Clear();
            tbEdges.Clear();

            for(int i = 1; i <= numVerticesSum.Value; i++)
            {
                Vertex newVertex = new Vertex(i, 0);
                vertices.Add(newVertex);
                tbVertices.AppendText(newVertex.ToString() + "\r\n");
            }

            btnAddEge.Enabled = true;
            btnCreateGraph.Enabled = true;
            tbRegularExpression.Enabled = true;

            numInitVertex.Enabled = true;
            numFinalVertex.Enabled = true;
            numStartGraphVertex.Enabled = true;
            numFinishGraphVertex.Enabled = true;
            numInitVertex.Maximum = numVerticesSum.Value;
            numFinalVertex.Maximum = numVerticesSum.Value;
            numStartGraphVertex.Maximum = numVerticesSum.Value;
            numFinishGraphVertex.Maximum = numVerticesSum.Value;
            numStartGraphVertex.Value = 1;
            numFinishGraphVertex.Value = numVerticesSum.Value;
        }

        private void btnAddEge_Click(object sender, EventArgs e)
        {
            int initVertex = Convert.ToInt32(numInitVertex.Value);
            int finVertex = Convert.ToInt32(numFinalVertex.Value);
            string regularExpression = tbRegularExpression.Text;

            if(regularExpression == "")
                regularExpression = Convert.ToString(vertices.Find(vertex => vertex.Name == initVertex).EdgesNumber, 2);

            vertices.Find(vertex => vertex.Name == initVertex).IncreaseNumberOfEdges();
            vertices.Find(vertex => vertex.Name == finVertex).IncreaseNumberOfEdges();

            Edge newEdge = new Edge(initVertex, finVertex, regularExpression);
            tbEdges.AppendText(newEdge.ToString() + "\r\n");
            edges.Add(newEdge);

            tbVertices.Clear();
            tbRegularExpression.Clear();

            foreach(Vertex vertex in vertices)
            {
                tbVertices.AppendText(vertex.ToString() + "\r\n");
            }
        }

        private void btnCreateGraph_Click(object sender, EventArgs e)
        {
            if(edges.Count == 0)
            {
                MessageBox.Show("No edges in graph! Please add edges!", "Error!");
            }
            else
            {
                
                int startGraphV = Convert.ToInt32(numStartGraphVertex.Value);
                int finGraphV = Convert.ToInt32(numFinishGraphVertex.Value);
                newGraph = new Graph(vertices, startGraphV, finGraphV, edges);
                this.DialogResult = DialogResult.OK;
            }
        }


    }
}
