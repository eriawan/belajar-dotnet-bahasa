using System.Threading.Tasks;

namespace DiskusiAsyncAwaitDenganContohWinforms
{
    public partial class FrmContohAsyncSederhana : Form
    {
        public FrmContohAsyncSederhana()
        {
            InitializeComponent();
        }

        private void btnRunSyncProc_Click(object sender, EventArgs e)
        {
            // call synchronous process
            ContohSynchronousProcess();
        }

        #region Simulate asynchronous and synchronous process

        private void ContohSynchronousProcess()
        {
            // block for approximately 40 seconds
            Thread.Sleep(30000);
        }

        private async Task ContohAsynchronousProcess()
        {
            // non blocking for approximately 30 seconds
            await Task.Delay(30000);
        }

        private async Task ContohAsynchronousProcessCrossThreadUI()
        {
            // non blocking for approximately 30 seconds
            await Task.Delay(20000);
            lblRunAsyncCrossThreadUI.Text = 
                $"ContohAsynchronousProcessDebug finished Task.Delay, time = {DateTime.Now.ToString("HH:mm:ss")}";
            //if (lblRunAsyncCrossThreadUI.InvokeRequired)
            //{
            //    lblRunAsyncCrossThreadUI.Invoke(new Action(() => lblRunAsyncCrossThreadUI.Text = "ContohAsynchronousProcessDebug finished Task.Delay"));
            //}
            //else
            //{
            //    lblRunAsyncCrossThreadUI.Text = "ContohAsynchronousProcessDebug finished Task.Delay";
            //}
        }

        #endregion

        private void Process01()
        {
            // Simulate a process that takes time
            Thread.Sleep(2000);
        }

        private void Process02()
        {
            // Simulate a process that takes time
            Thread.Sleep(2000);
        }

        private void Process03()
        {
            // Simulate a process that takes time
            Thread.Sleep(2000);
        }
        private async void btnRunAsync_Click(object sender, EventArgs e)
        {
            await ContohAsynchronousProcess();
            lblRunAsyncProcess.Text =
                $"ContohAsynchronousProcess finished Task.Delay, time = {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void timerBlockingTest_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = $"Current time : {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void FrmContohAsyncSederhana_Load(object sender, EventArgs e)
        {
            //Process01();
            //Process02();
            //Process03();
            // start timer
            timerBlockingTest.Enabled = true;
        }

        private void btnRunAsyncSynchronously_Click(object sender, EventArgs e)
        {
            // call existing async method, but we are trying to run it synchronously
            Task.Run(() => ContohAsynchronousProcess()).GetAwaiter().GetResult();
            //ContohAsynchronousProcess().GetAwaiter().GetResult();
            //ContohAsynchronousProcess().Wait();
        }

        private async void btnRunAsyncInCrossThread_Click(object sender, EventArgs e)
        {
            await ContohAsynchronousProcessCrossThreadUI();
        }
    }
}
