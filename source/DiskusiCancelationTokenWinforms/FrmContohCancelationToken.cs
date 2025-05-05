using System.Diagnostics;
using System.Threading.Tasks;

namespace DiskusiCancelationTokenWinforms
{
    public partial class FrmContohCancelationToken : Form
    {
        private CancellationTokenSource _cancellationTokenSource;

        public FrmContohCancelationToken()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void RunLongBlockingProcess(CancellationToken token)
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(400);
                if (lblIterationSequence.InvokeRequired)
                {
                    Invoke(() => lblIterationSequence.Text = $"Iteration sequence: {i}");
                }
                else
                {
                    lblIterationSequence.Text = $"Iteration sequence: {i}";
                }
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
            if (lblTaskStatus.InvokeRequired)
            {
                Invoke(() => lblTaskStatus.Text = "Task completed");
            }
            else
            {
                lblTaskStatus.Text = "Task completed";
            }
        }

        private async void btnRunAsyncCancelation_Click(object sender, EventArgs e)
        {
            CancellationToken token = _cancellationTokenSource.Token;
            try
            {
                await Task.Run(() => RunLongBlockingProcess(token)).ConfigureAwait(false);
                lblTaskStatus.Text = "Task completed";
            }
            catch (OperationCanceledException oex)
            {
                lblTaskStatus.Text = "Task canceled!";
                lblIterationSequence.Text += ". Now it is canceled.";
            }
        }

        private void btnCancelAsync_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void FrmContohCancelationToken_Load(object sender, EventArgs e)
        {
            timerJam.Enabled = true;
        }

        private void timerJam_Tick(object sender, EventArgs e)
        {
            lblJamSekarang.Text = "Jam saat ini: " + DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
