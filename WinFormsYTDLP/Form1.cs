using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WinFormsYTDLP {
    public partial class YTLPD : Form {
        public string DestinationPath;

        public YTLPD() {
            InitializeComponent();
        }

        private void YTLPD_Load(object sender, EventArgs e) {
            textBox2.Text = "C:\\Windows\\System32\\yt-dlp.exe";
            
            DestinationPath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            label3.Text = "destination: " + DestinationPath;

            if (Clipboard.GetText().Contains("https://")) {
                textBox1.Text = Clipboard.GetText();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            String url = textBox1.Text;
            String ytDLPPath = textBox2.Text;

            var Download = new Process {
                StartInfo = {
                    FileName = ytDLPPath,
                    Arguments = " -x --audio-format mp3 -P home:" + DestinationPath + " " + url
                    // yt-dlp.exe -x --audio-format mp3 -P home:C:\\...\\...\\... https://...
                }
            };

            Download.Start();
        }

        private void button2_Click(object sender, EventArgs e) {
            String url = textBox1.Text;
            String ytDLPPath = textBox2.Text;

            var Download = new Process {
                StartInfo = {
                    FileName = ytDLPPath,
                    Arguments = " -f 137+140 --write-sub -P home:" + DestinationPath + " " + url
                    // yt-dlp.exe -P home:C:\\...\\...\\... https://...
                }
            };

            Download.Start();
        }

        private void button3_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                label3.Text = "destination: " + folderBrowserDialog1.SelectedPath;
                DestinationPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox1_Click(object sender, EventArgs e) {
            if (Clipboard.GetText().Contains("https://")) textBox1.Text = Clipboard.GetText();
        }
    }
}