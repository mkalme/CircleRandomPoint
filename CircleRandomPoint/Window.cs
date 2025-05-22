using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CircleRandomPoint {
    public partial class Window : Form {
        BackgroundWorker BackgroundWorker { get; set; }
        private CirclePoints CirclePoints { get; set; }

        public Window(){
            InitializeComponent();

            InitializeCirclePoints();
            InitializeBackgroundWorker();
        }

        private void InitializeCirclePoints() {
            CirclePoints = new CirclePoints(500);
        }
        private void InitializeBackgroundWorker() {
            BackgroundWorker = new BackgroundWorker();

            BackgroundWorker.DoWork += RenderLoop;
            BackgroundWorker.ProgressChanged += UpdateGUI;
            BackgroundWorker.WorkerReportsProgress = true;

            BackgroundWorker.RunWorkerAsync();
        }

        //Loop
        private void RenderLoop(object sender, DoWorkEventArgs e){
            int wait_ms = 0;

            Random rand = new Random();

            int nPoints = 250000;

            for (int i = 0; i < nPoints; i++) {
                //CirclePoints.Circle.RandomPoints.Add(new Point(i / (float)nPoints, 0.5F));
                CirclePoints.Circle.RandomPoints.Add(new Point(rand.Next(int.MaxValue) / (float)int.MaxValue, rand.Next(int.MaxValue) / (float)int.MaxValue));
            }

            //for (int i = 0; i < nPoints; i++) {
            //    Thread.Sleep(wait_ms);

            //    CirclePoints.Circle.RandomPoints.Add(new Point(rand.Next(int.MaxValue) / (float)int.MaxValue, rand.Next(int.MaxValue) / (float)int.MaxValue));

            //    if ((i + 1) % 1000 == 0) {
            //        Bitmap bitmap = CirclePoints.RenderCircle();

            //        BackgroundWorker.ReportProgress(0, bitmap);
            //    }
            //}

            BackgroundWorker.ReportProgress(0, CirclePoints.RenderCircle());
        }
        private void UpdateGUI(object sender, ProgressChangedEventArgs e){
            ImageBox.Image = (Bitmap)e.UserState;
        }
    }
}
