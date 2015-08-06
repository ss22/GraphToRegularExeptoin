using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiplomProject
{
    /// <summary>
    /// The <c>Graph</c> describes the structure of the graph.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// List of vertices in current <c>DiplomProject.Graph</c>.
        /// </summary>
        List<Vertex> vertices;

        
        /// <summary>
        /// Gets all vertices in current <c>DiplomProject.Graph</c>.
        /// </summary>
        /// <return>List of vertices in current graph.</return>
        [XmlArray("Vertices"), XmlArrayItem(typeof(Vertex))]
        public List<Vertex> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }

        /// <summary>
        /// List of edges in current <c>DiplomProject.Graph</c>.
        /// </summary>
        List<Edge> edges;

        /// <summary>
        /// Gets all edges in current <c>DiplomProject.Graph</c>.
        /// </summary>
        /// <return>List of edges in current graph.</return>
        [XmlArray("Edges"), XmlArrayItem(typeof(Edge))]
        public List<Edge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        /// <summary>
        /// Start vertex in current <c>DiplomProject.Graph</c>.
        /// </summary>
        Vertex firstVertex;

        /// <summary>
        /// Gets start vertex in current <c>DiplomProject.Graph</c>.
        /// </summary>
        /// <return>Object of class <c>DiplomProject.Vertex</c>.</return>
        [XmlElement("FirstVertex")]
        public Vertex FirstVertex
        {
            get { return firstVertex; }
            set { firstVertex = value; }
        }

        /// <summary>
        /// Finish vertex in current <c>DiplomProject.Graph</c>.
        /// </summary>
        Vertex lastVertex;

        /// <summary>
        /// Gets finish vertex in current <c>DiplomProject.Graph</c>.
        /// </summary>
        /// <return>Object of class <c>DiplomProject.Vertex</c>.</return>
        [XmlElement("LastVertex")]
        public Vertex LastVertex
        {
            get { return lastVertex; }
            set { lastVertex = value; }
        }

        /// <summary>
        /// Set first and last vertex in current <c>DiplomProject.Graph</c>.
        /// </summary>
        /// <param name="first">Number of first vertex for current
        /// <c>DiplomProject.Graph</c> object.</param>
        /// <param name="last">Number of last vertex for current
        /// <c>DiplomProject.Graph</c> object.</param>
        /// <returns>True if set first and last vertex was success; otherwise, false.</returns>
        private bool SetFirstAndLastVertices(int first, int last)
        {
            int countVertices = 0;

            foreach (Vertex vertex in vertices)
            {
                if (vertex.Name == first)
                {
                    firstVertex = vertex;
                    countVertices++;
                }
                if (vertex.Name == last)
                {
                    lastVertex = vertex;
                    countVertices++;
                }
            }
            if (countVertices == 2)
            {
                vertices.Remove(firstVertex);
                vertices.Remove(lastVertex);
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// Initializes a new empty <c>DiplomProject.Graph</c> object.
        /// </summary>
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            firstVertex = new Vertex();
            lastVertex = new Vertex();
        }

        /// <summary>
        /// Initializes a new <c>DiplomProject.Graph</c> object which based on the collections
        /// of vertices and edges.
        /// </summary>
        /// <param name="verticesList">Collection of vertices.</param>
        /// <param name="firstVertexName">Name of first vertex in current
        /// <c>DiplomProject.Graph</c> object.</param>
        /// <param name="lastVertexName">Name of last vertex in current
        /// <c>DiplomProject.Graph</c> object.</param>
        /// <param name="edgesList">Collection of edges.</param>
        public Graph(List<Vertex> verticesList, int firstVertexName, int lastVertexName,
                     List<Edge> edgesList)
        {
            vertices = verticesList;

            if(SetFirstAndLastVertices(firstVertexName, lastVertexName))
                edges = edgesList;
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes a new <c>DiplomProject.Graph</c> object which based on the other <c>DiplomProject.Graph</c> object.
        /// </summary>
        /// <param name="otherGraph"><c>DiplomProject.Graph</c> object.</param>
        public Graph(Graph otherGraph)
        {
            vertices = otherGraph.vertices;
            edges = otherGraph.edges;
            firstVertex = otherGraph.firstVertex;
            lastVertex = otherGraph.lastVertex;
        }

        /// <summary>
        /// Find, delete and integrate to edges, which contact with vertices where was
        /// find the loops, all loops in current graph.
        /// </summary>
        public void RidOfLoops()
        {
            List<Edge> Loops = new List<Edge>();

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].IsLoop())
                {
                    Loops.Add(Edges[i]);

                    if (firstVertex.Name == edges[i].InitialVertex)
                    { 
                        firstVertex.DecreaseNumberOfEdges(2); 
                    }
                    else if (lastVertex.Name == edges[i].InitialVertex)
                    { 
                        lastVertex.DecreaseNumberOfEdges(2); 
                    }
                    else
                    {
                        vertices.Find(vertex => (vertex.Name == edges[i].InitialVertex)).DecreaseNumberOfEdges(2);
                    }
                    edges.RemoveAt(i);
                }
            }

            foreach(Edge loop in Loops)
            {
                foreach(Edge edge in edges)
                {
                    if (loop.InitialVertex == edge.InitialVertex)
                    {
                        edge.IntegrateLoopToEdge(loop);
                    }
                }
            }
        }

        /// <summary>
        /// Find in current graph all parallel edges, and on their base creates one new edge. 
        /// </summary>
        public void RidOfParallelEdges()
        {
            int i = 0;

            while (i < (edges.Count - 1))
            {
                if (edges[i].IsParallelEdge(edges[i + 1]))
                {
                    string newReg = edges[i].CombineWithParallelEdge(edges[i + 1]);
                    int oneParallelVertex = edges[i].InitialVertex;
                    int otherParallelVertex = edges[i].FinalVertex;

                    Edge newEdge = new Edge(edges[i].InitialVertex, edges[i].FinalVertex, newReg);
                    edges.Add(newEdge);

                    edges.RemoveAt(i);
                    edges.RemoveAt(i);

                    if (firstVertex.Name == oneParallelVertex || firstVertex.Name == otherParallelVertex)
                        firstVertex.DecreaseNumberOfEdges();
                    if (lastVertex.Name == oneParallelVertex || lastVertex.Name == otherParallelVertex)
                        lastVertex.DecreaseNumberOfEdges();
                    foreach (Vertex vertex in vertices)
                    {
                        if (vertex.Name == oneParallelVertex || vertex.Name == otherParallelVertex)
                            vertex.DecreaseNumberOfEdges();
                    }
                }
                else i++;
            }
        }

        /// <summary>
        /// Remove from graph vertex and redistributes the eges.
        /// </summary>
        /// <param name="vertex">Removable vertex.</param>
        public void DeleteVertex(Vertex vertex)
        {
            List<Edge> inEdges = new List<Edge>();
            List<Edge> outEdges = new List<Edge>();

            int i = 0;

            // Determining all edges belonging to the removed vertex.
            while (i < edges.Count)
            {
                if (edges[i].IsRelateToVertex(vertex))
                {
                    // If edge comes from the removed vertex add it to the <c>outEdges</c> list;
                    // otherwise, add it to the <c>inEdges</c> list.
                    if (vertex.Name == edges[i].InitialVertex)
                    {
                        outEdges.Add(edges[i]);
                    }
                    else
                    {
                        inEdges.Add(edges[i]);
                    }

                    if (edges[i].IsRelateToVertex(firstVertex))
                        firstVertex.DecreaseNumberOfEdges();
                    if (edges[i].IsRelateToVertex(lastVertex))
                        lastVertex.DecreaseNumberOfEdges();
                    foreach(Vertex v in vertices)
                    {
                        if (edges[i].IsRelateToVertex(v))
                            v.DecreaseNumberOfEdges();
                    }

                    edges.RemoveAt(i);
                }
                else i++;
            }

            vertices.Remove(vertex);

            if (outEdges.Count > 0 && inEdges.Count > 0)
            {
                // Create string of new regular expression and add new edges to list.
                List<Edge> newEdges = new List<Edge>();

                foreach (Edge outEdge in outEdges)
                {
                    foreach (Edge inEdge in inEdges)
                    {
                        string newRegular = "(" + inEdge.RegularExpression + "*/" + vertex.Name + "/*"
                                                + outEdge.RegularExpression + ")";
                        Edge newEdge = new Edge(inEdge.InitialVertex, outEdge.FinalVertex, newRegular);

                        newEdges.Add(newEdge);
                        edges.Add(newEdge);
                    }
                }

                foreach(Edge ne in newEdges)
                {
                    if (ne.InitialVertex == firstVertex.Name)
                        firstVertex.IncreaseNumberOfEdges();
                    if (ne.InitialVertex == lastVertex.Name)
                        lastVertex.IncreaseNumberOfEdges();
                    if (ne.FinalVertex == firstVertex.Name)
                        firstVertex.IncreaseNumberOfEdges();
                    if (ne.FinalVertex == lastVertex.Name)
                        lastVertex.IncreaseNumberOfEdges();
                    foreach(Vertex v in vertices)
                    {
                        if (ne.InitialVertex == v.Name)
                            v.IncreaseNumberOfEdges();
                        if (ne.FinalVertex == v.Name)
                            v.IncreaseNumberOfEdges();
                    }
                }
            }
            else
            {
                foreach (Edge inEdge in inEdges)
                {
                    if (firstVertex.Name == inEdge.InitialVertex)
                        firstVertex.DecreaseNumberOfEdges();
                    if (lastVertex.Name == inEdge.InitialVertex)
                        lastVertex.DecreaseNumberOfEdges();
                    foreach (Vertex v in vertices)
                    {
                        if (v.Name == inEdge.InitialVertex)
                            v.DecreaseNumberOfEdges();
                    }
                }

                foreach (Edge outEdge in outEdges)
                {
                    if (firstVertex.Name == outEdge.FinalVertex)
                        firstVertex.DecreaseNumberOfEdges();
                    if (lastVertex.Name == outEdge.FinalVertex)
                        lastVertex.DecreaseNumberOfEdges();
                    foreach (Vertex v in vertices)
                    {
                        if (v.Name == outEdge.FinalVertex)
                            v.DecreaseNumberOfEdges();
                    }
                }
            }

        }

        /// <summary>
        /// Sort list of vertices in current <c>DiplomProject.Graph</c> by descending.
        /// </summary>
        public void SortVertices()
        {
            vertices.Sort();
        }

        /// <summary>
        /// Sort list of edges in current <c>DiplomProject.Graph</c> by descending.
        /// </summary>
        public void SortEdges()
        {
            edges.Sort();
        }
        
        /// <summary>
        /// Get string wich is the regular egpression of corrent graph.
        /// </summary>
        public void GetGraphRegularExpression()
        {
            RidOfParallelEdges();
            RidOfLoops();
            SortEdges();
            SortVertices();
            while (vertices.Count > 0)
            {
                DeleteVertex(vertices[0]);
                SortEdges();
                RidOfParallelEdges();
                RidOfLoops();
                SortVertices();
            }
            if(edges.Count == 2)
            {
                Edge firstEdge = edges.Find(e => e.InitialVertex == firstVertex.Name);
                Edge lastEdge = edges.Find(e => e.InitialVertex == lastVertex.Name);

                if(firstEdge != null && lastEdge != null)
                {
                    edges.Clear();

                    firstVertex.DecreaseNumberOfEdges();
                    lastVertex.DecreaseNumberOfEdges();

                    string newRegular = "(" + firstEdge.RegularExpression + "*" + lastEdge.RegularExpression + ")v" + lastEdge.RegularExpression;
                    Edge newEdge = new Edge(firstVertex.Name, lastVertex.Name, newRegular);
                    edges.Add(newEdge);
                }
            }
        }

        public void Step()
        {
            RidOfParallelEdges();
            RidOfLoops();
            SortEdges();
            SortVertices();
            DeleteVertex(vertices[0]);
            SortEdges();
            RidOfParallelEdges();
            RidOfLoops();
            SortEdges();
            SortVertices();
        }
    }
}
