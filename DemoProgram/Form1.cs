using System;
using System.Windows.Forms;
using System.Linq;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
                treeView1.Nodes.Clear();

            var videos = await ExtractorService.GetInstance().ExtractVideosAsync(textBox1.Text);

            foreach (IVideo video in videos)
            {
                var node = new TreeNode(video.Title);
                node.Nodes.Add(video.Url);

                treeView1.Nodes.Add(node);
            }

            toolStripStatusLabel1.Text = $"{videos.Count()} videos found.";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(treeView1.SelectedNode.Text);
        }
    }
}
