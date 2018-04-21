using System;
using System.Windows.Forms;
using PlaylistExtractor.Services;
using PlaylistExtractor.Contracts;

namespace DemoProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
                treeView1.Nodes.Clear();

            Cursor.Current = Cursors.WaitCursor;

            var videos = ExtractorService.GetInstance().ExtractVideos(textBox1.Text);

            foreach (IVideo video in videos)
            {
                var node = new TreeNode(video.Title);
                node.Nodes.Add(video.Url);

                treeView1.Nodes.Add(node);
            }

            Cursor.Current = Cursors.Default;

            toolStripStatusLabel1.Text = $"{treeView1.Nodes.Count} videos found.";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(treeView1.SelectedNode.Text);
        }
    }
}
