using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Wielowatkowosc.Class1;

namespace Wielowatkowosc
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            await Task.Run(() => {
                while (!cts.IsCancellationRequested)
                {
                    string result = Obliczenia();
                    textBox1.Invoke(new Action(() => textBox1.AppendText(result)));
                }
            }, cts.Token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                bool isVisible = PokazOkno(pictureBox1.Visible);
                pictureBox1.Invoke(new Action(() => pictureBox1.Visible = isVisible));
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            var api = new OpenAI_API.OpenAIAPI("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");
            var results = await api.Completions.GetCompletion("Give me name and second name for character for fantasy rpg session");

            int count = default;

            StringBuilder sb = new StringBuilder();

            foreach (var item in results)
            {
                count++;

                if (count % 20 == 0)
                    sb.Append($"\n");

                sb.Append($"{item}");
            }

            await Task.Run(() =>
            {
                textBox2.Invoke(new Action(() => textBox2.AppendText(sb.ToString())));
                textBox2.Invoke(new Action(() => textBox2.AppendText($"{Environment.NewLine}->")));
            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            await Task.Run(() => {
                while (!cts.IsCancellationRequested)
                {
                    (int, int, int) Colors = RGB();
                    textBox3.Invoke(new Action(() => {
                        textBox3.BackColor = Color.FromArgb(Colors.Item1, Colors.Item2, Colors.Item3);
                        textBox3.Refresh();
                    }));
                }
            }, cts.Token);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

    }
}