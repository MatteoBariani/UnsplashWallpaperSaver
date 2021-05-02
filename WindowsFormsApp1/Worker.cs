using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    public class Worker : BackgroundWorker
    {
        private static System.Timers.Timer aTimer;
        private BackgroundWorker worker;
        private UnsplashAPI api;

        public Worker()
        {
            SetTimer(int.Parse(Utils.GetSetting("defaultUpdateInterval")) * 60 * 1000);

            api = UnsplashAPI.GetInstance();

            worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            if (bw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            api.GetPhotos();
        }

        public void Kill()
        {
            worker.CancelAsync();
            worker.Dispose();
            aTimer.Stop();
            aTimer.Dispose();

            GC.Collect();
        }

        private void SetTimer(int delay)
        {
            aTimer = new System.Timers.Timer(delay);

            aTimer.Elapsed += OnTimerElapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimerElapsed(Object source, ElapsedEventArgs e)
        {
            if (!Directory.Exists(Utils.GetSetting("defaultFolder")))
            {
                return;
            }                

            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }
    }
}
