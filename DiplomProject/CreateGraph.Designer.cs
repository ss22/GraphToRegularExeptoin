namespace DiplomProject
{
    partial class CreateGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numVerticesSum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInitVertices = new System.Windows.Forms.Button();
            this.tbVertices = new System.Windows.Forms.TextBox();
            this.numFinalVertex = new System.Windows.Forms.NumericUpDown();
            this.numInitVertex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEdges = new System.Windows.Forms.TextBox();
            this.btnAddEge = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRegularExpression = new System.Windows.Forms.TextBox();
            this.btnCreateGraph = new System.Windows.Forms.Button();
            this.numFinishGraphVertex = new System.Windows.Forms.NumericUpDown();
            this.numStartGraphVertex = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinishGraphVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartGraphVertex)).BeginInit();
            this.SuspendLayout();
            // 
            // numVerticesSum
            // 
            this.numVerticesSum.Location = new System.Drawing.Point(94, 12);
            this.numVerticesSum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numVerticesSum.Name = "numVerticesSum";
            this.numVerticesSum.Size = new System.Drawing.Size(50, 20);
            this.numVerticesSum.TabIndex = 0;
            this.numVerticesSum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vertex count";
            // 
            // btnInitVertices
            // 
            this.btnInitVertices.Location = new System.Drawing.Point(15, 38);
            this.btnInitVertices.Name = "btnInitVertices";
            this.btnInitVertices.Size = new System.Drawing.Size(130, 23);
            this.btnInitVertices.TabIndex = 2;
            this.btnInitVertices.Text = "Set vertices count";
            this.btnInitVertices.UseVisualStyleBackColor = true;
            this.btnInitVertices.Click += new System.EventHandler(this.btnInitVertices_Click);
            // 
            // tbVertices
            // 
            this.tbVertices.Location = new System.Drawing.Point(15, 67);
            this.tbVertices.Multiline = true;
            this.tbVertices.Name = "tbVertices";
            this.tbVertices.ReadOnly = true;
            this.tbVertices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVertices.Size = new System.Drawing.Size(130, 183);
            this.tbVertices.TabIndex = 3;
            // 
            // numFinalVertex
            // 
            this.numFinalVertex.Enabled = false;
            this.numFinalVertex.Location = new System.Drawing.Point(270, 38);
            this.numFinalVertex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFinalVertex.Name = "numFinalVertex";
            this.numFinalVertex.Size = new System.Drawing.Size(50, 20);
            this.numFinalVertex.TabIndex = 4;
            this.numFinalVertex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numInitVertex
            // 
            this.numInitVertex.Enabled = false;
            this.numInitVertex.Location = new System.Drawing.Point(270, 12);
            this.numInitVertex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitVertex.Name = "numInitVertex";
            this.numInitVertex.Size = new System.Drawing.Size(50, 20);
            this.numInitVertex.TabIndex = 5;
            this.numInitVertex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Final vertex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Initial vertex";
            // 
            // tbEdges
            // 
            this.tbEdges.Location = new System.Drawing.Point(170, 119);
            this.tbEdges.Multiline = true;
            this.tbEdges.Name = "tbEdges";
            this.tbEdges.ReadOnly = true;
            this.tbEdges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEdges.Size = new System.Drawing.Size(150, 131);
            this.tbEdges.TabIndex = 8;
            // 
            // btnAddEge
            // 
            this.btnAddEge.Enabled = false;
            this.btnAddEge.Location = new System.Drawing.Point(170, 90);
            this.btnAddEge.Name = "btnAddEge";
            this.btnAddEge.Size = new System.Drawing.Size(150, 23);
            this.btnAddEge.TabIndex = 9;
            this.btnAddEge.Text = "Add edge";
            this.btnAddEge.UseVisualStyleBackColor = true;
            this.btnAddEge.Click += new System.EventHandler(this.btnAddEge_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Regular expression";
            // 
            // tbRegularExpression
            // 
            this.tbRegularExpression.Enabled = false;
            this.tbRegularExpression.Location = new System.Drawing.Point(270, 64);
            this.tbRegularExpression.Name = "tbRegularExpression";
            this.tbRegularExpression.Size = new System.Drawing.Size(50, 20);
            this.tbRegularExpression.TabIndex = 11;
            // 
            // btnCreateGraph
            // 
            this.btnCreateGraph.Enabled = false;
            this.btnCreateGraph.Location = new System.Drawing.Point(388, 67);
            this.btnCreateGraph.Name = "btnCreateGraph";
            this.btnCreateGraph.Size = new System.Drawing.Size(149, 23);
            this.btnCreateGraph.TabIndex = 12;
            this.btnCreateGraph.Text = "Create graph";
            this.btnCreateGraph.UseVisualStyleBackColor = true;
            this.btnCreateGraph.Click += new System.EventHandler(this.btnCreateGraph_Click);
            // 
            // numFinishGraphVertex
            // 
            this.numFinishGraphVertex.Enabled = false;
            this.numFinishGraphVertex.Location = new System.Drawing.Point(487, 41);
            this.numFinishGraphVertex.Name = "numFinishGraphVertex";
            this.numFinishGraphVertex.Size = new System.Drawing.Size(50, 20);
            this.numFinishGraphVertex.TabIndex = 13;
            // 
            // numStartGraphVertex
            // 
            this.numStartGraphVertex.Enabled = false;
            this.numStartGraphVertex.Location = new System.Drawing.Point(487, 12);
            this.numStartGraphVertex.Name = "numStartGraphVertex";
            this.numStartGraphVertex.Size = new System.Drawing.Size(50, 20);
            this.numStartGraphVertex.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Start graph vertex";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Finish graph vertex";
            // 
            // CreateGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 262);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numStartGraphVertex);
            this.Controls.Add(this.numFinishGraphVertex);
            this.Controls.Add(this.btnCreateGraph);
            this.Controls.Add(this.tbRegularExpression);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddEge);
            this.Controls.Add(this.tbEdges);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numInitVertex);
            this.Controls.Add(this.numFinalVertex);
            this.Controls.Add(this.tbVertices);
            this.Controls.Add(this.btnInitVertices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numVerticesSum);
            this.Name = "CreateGraph";
            this.Text = "Create";
            ((System.ComponentModel.ISupportInitialize)(this.numVerticesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinishGraphVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartGraphVertex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numVerticesSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInitVertices;
        private System.Windows.Forms.TextBox tbVertices;
        private System.Windows.Forms.NumericUpDown numFinalVertex;
        private System.Windows.Forms.NumericUpDown numInitVertex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEdges;
        private System.Windows.Forms.Button btnAddEge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRegularExpression;
        private System.Windows.Forms.Button btnCreateGraph;
        private System.Windows.Forms.NumericUpDown numFinishGraphVertex;
        private System.Windows.Forms.NumericUpDown numStartGraphVertex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}