using System.Diagnostics;
using System.Threading;

namespace DIskusiCrossThreadWinforms
{
    public partial class FrmCrossThreadWinforms : Form
    {
        public FrmCrossThreadWinforms()
        {
            InitializeComponent();
        }

        private async Task ContohAsynchronousProcess()
        {
            // non blocking for approximately 30 seconds
            await Task.Delay(30000);
        }

        private async Task ContohAsynchronousProcessWithCrossThread()
        {
            // non blocking for approximately 30 seconds
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await Task.Delay(10000);
            sw.Stop();
            lblReproCrossThread.Text =
                "Selesai async process, durasi= " + sw.ElapsedMilliseconds.ToString() + " ms";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // do nothing
        }

        private void timerCheckForBlocking_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private async void btnRunAsyncMethodAsync_Click(object sender, EventArgs e)
        {
            await ContohAsynchronousProcess();
        }

        private async void btnRunAsyncMethodCrossThread_Click(object sender, EventArgs e)
        {
            await ContohAsynchronousProcessWithCrossThread();
        }

        private void btnCreateNewThread_Click(object sender, EventArgs e)
        {
            Thread thread2 =
                new Thread(new ThreadStart(() =>
                {
                    if (lblUnsafeCrossThread.InvokeRequired)
                    {
                        this.Invoke(() =>
                        {
                            lblUnsafeCrossThread.Text = "This text was set unsafely.";
                        });
                    }
                    else
                    {
                        lblUnsafeCrossThread.Text = "This text was set unsafely.";
                    }
                }));
            thread2.Start();
        }

        private void FrmCrossThreadWinforms_Load(object sender, EventArgs e)
        {
            timerCheckForBlocking.Enabled = true;
        }

        private void btnRunAsyncInParallel_Click(object sender, EventArgs e)
        {
            Parallel.For(1, 10, async (iteration) => await ContohAsynchronousProcess());
        }
    }
}
