using System.Text;
using System.Xml.Linq;

namespace DiskusiParallelAsyncWinforms
{
    public partial class FrmParallelAsync : Form
    {
        public FrmParallelAsync()
        {
            InitializeComponent();
        }

        private void tmrCurrentTime_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = "Current time: " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void FrmParallelAsync_Load(object sender, EventArgs e)
        {
            tmrCurrentTime.Enabled = true;
        }

        private void btnParallelForToCallSyncMethod_Click(object sender, EventArgs e)
        {
            List<Double> randomResult = new List<Double>();
            Parallel.For(1, 50, (Index) =>
            {
                var iterationResult = MiscelanousComputeProcess.ProcessIterateFor(60);
                iterationResult.ForEach((resultItem) => randomResult.Add(resultItem));
            });
            StringBuilder sb = new StringBuilder();
            randomResult.ForEach((item) =>
            {
                sb.Append($"{item};{Environment.NewLine}");
            });
            txtParalleForCallSync.Text = sb.ToString();
        }

        private async void btnAwaitTaskWhenAll_Click(object sender, EventArgs e)
        {
            txtTaskWhenAll.Text = "";
            // set the text of this button to "in process"
            string strBtnAwaitTaskWhenAll = btnAwaitTaskWhenAll.Text;
            btnAwaitTaskWhenAll.Text = "In process...";
            btnAwaitTaskWhenAll.Enabled = false;
            List<Task> tasklist = new List<Task>();
            List<Double> randomResult = new List<Double>();
            for (int i = 1; i <= 50; i++)
            {
                tasklist.Add(Task.Run(() =>
                {
                    var iterationResult = MiscelanousComputeProcess.ProcessIterateFor(60);
                    iterationResult.ForEach((resultItem) => randomResult.Add(resultItem));
                }));
            }
            await Task.WhenAll(tasklist);
            StringBuilder sb = new StringBuilder();
            randomResult.ForEach((item) =>
            {
                sb.Append($"{item};{Environment.NewLine}");
            });
            btnAwaitTaskWhenAll.Enabled = true;
            txtTaskWhenAll.Text = sb.ToString();
            btnAwaitTaskWhenAll.Text = strBtnAwaitTaskWhenAll;
        }

        private void btnClearParallelForText_Click(object sender, EventArgs e)
        {
            txtParalleForCallSync.Text = "";
        }

        private async void btnParallelForAsync_Click(object sender, EventArgs e)
        {
            txtParallelForAsync.Text = "";
            // set the text of this button to "in process"
            string strbtnParallelForAsync = btnParallelForAsync.Text;
            btnParallelForAsync.Text = "In process...";
            btnParallelForAsync.Enabled = false;
            List<Double> randomResult = new List<Double>();
            await Parallel.ForAsync(1, 50, async (index, cancelToken) =>
            {
                await Task.Run(() =>
                {
                    var iterationResult = MiscelanousComputeProcess.ProcessIterateFor(60);
                    iterationResult.ForEach((resultItem) => randomResult.Add(resultItem));
                }, cancelToken);
            });
            StringBuilder sb = new StringBuilder();
            randomResult.ForEach((item) =>
            {
                sb.Append($"{item};{Environment.NewLine}");
            });
            btnParallelForAsync.Enabled = true;
            txtParallelForAsync.Text = sb.ToString();
            btnParallelForAsync.Text = strbtnParallelForAsync;
        }
    }
}
