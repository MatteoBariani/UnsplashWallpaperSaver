using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UnsplashAppContext());
        }
    }

    public class UnsplashAppContext : ApplicationContext
    {
        private NotifyIcon trayIcon;        
        private Worker worker;

        public UnsplashAppContext()
        {            
            InitConfig();
            InitTrayIconProcess();
            InitBackgroundWorkerWithTimer();
        }       

        private void InitTrayIconProcess()
        {
            // Initialize Tray Icon
            this.trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Update folder", UpdateFolder),
                    new MenuItem("Settings", OpenSettings),
                    new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        private void UpdateFolder(object sender, EventArgs e)
        {
            UnsplashAPI api = UnsplashAPI.GetInstance();

            api.GetPhotos();
        }

        private void InitBackgroundWorkerWithTimer()
        {
            this.worker = new Worker();
        }

        private void InitConfig()
        {
            if (string.IsNullOrEmpty(Utils.GetSetting("defaultFolder")))
            {
                MessageBox.Show("Wallpaper folder not selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void OpenSettings(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();

            form.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            if (worker.IsBusy)
            {
                worker.Kill();
            }

            Application.Exit();
        }
    }
}
