using System.Diagnostics;
using System.Threading.Tasks;

namespace DiskusiAwaitableWinforms
{
    public partial class FrmAwaitableWinforms : Form
    {
        public FrmAwaitableWinforms()
        {
            InitializeComponent();
        }

        private async void btnCallAsyncUIAwaitableFalse_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Before calling async task with ConfigureAwait(false)");
            await ClassInClassLib.DoSomethingAsync().ConfigureAwait(false);
            Debug.WriteLine("After calling async task with ConfigureAwait(false)");
        }

        private async void btnCallAsyncUIAwaitFalseWithAddUI_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Before calling async task with ConfigureAwait(false)");
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Text = "Status: task running..";
            await ClassInClassLib.DoSomethingAsync().ConfigureAwait(false);
            Debug.WriteLine("After calling async task with ConfigureAwait(false)");
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Text = "Status: task completed!";
        }

        private async void btnCallAsyncUIAwaitTrueWithAddUI_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Before calling async task with ConfigureAwait(true)");
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Text = "Status: task running..";
            await ClassInClassLib.DoSomethingAsync().ConfigureAwait(true);
            Debug.WriteLine("After calling async task with ConfigureAwait(true)");
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Text = "Status: task completed!";
        }

        private void btnCallAsyncUIThenWait_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Before calling async task with ConfigureAwait default");
            var task1 = ClassInClassLib.DoSomethingAsync();
            task1.Wait();
            Debug.WriteLine("After calling async task with ConfigureAwait default");
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Text = "Status: task completed!";
        }
    }
}
