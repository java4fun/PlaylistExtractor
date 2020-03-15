using PlaylistExtractor.Models;
using PlaylistExtractor.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DemoProgram
{
    public partial class Form1 : Form
    {
        private readonly ExtractorService extractor;

        public Form1()
        {
            InitializeComponent();

            extractor = new ExtractorService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
                treeView1.Nodes.Clear();

            var videos = await extractor.ExtractVideosAsync(textBox1.Text);

            if (videos == null)
                return;

            foreach (Video video in videos)
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
