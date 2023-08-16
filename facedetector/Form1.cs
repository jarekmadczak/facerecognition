using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace facedetector
{

  

    public partial class Form1 : Form
    { 
        //declare 
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX,0.6d,0.6d);
        HaarCascade facedetected;
        Image<Bgr, Byte> Frame;
        Capture camera;
        Image<Gray, Byte> result;
        Image<Gray, Byte> TrainedFace = null;
        Image<Gray, Byte> grayFace = null;
        List<Image<Gray, Byte>> trainingImages= new List<Image<Gray, Byte>>();
        List <string> labels = new List<string>();
        List<string> Users = new List<string>();
        int Count, NumLables, t;
        string names=null, name;

      

        public Form1()
        {
            InitializeComponent();
            //hearcasade - rozpoznawanie twarzy 
            facedetected = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string Labelsinf = File.ReadAllText(Application.StartupPath + "/twarze/twarze.txt");
                string[] Labels = Labelsinf.Split(',');
                //tutaj mamy podpisy 
                NumLables = Convert.ToInt16(Labels[0]);
                Count = NumLables;
                string FacesLoad;
                for(int i = 1; i< NumLables+1; i++)
                {
                    FacesLoad = "twarz:" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, Byte>(Application.StartupPath + $"/twarze/{FacesLoad}"));
                    labels.Add(Labels[i]);
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show("nic w bazie :( sadeg ");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void start_Click(object sender, EventArgs e)
        {
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);

        }
        private void save_Click_1(object sender, EventArgs e)
        {
            Count++;
            grayFace = camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(facedetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in DetectedFaces[0])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray, byte>();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(textBox1.Text);
            File.WriteAllText(Application.StartupPath + "/twarze/twarze.txt", trainingImages.ToArray().Length.ToString() + ",");
            for(int i = 1; i < trainingImages.ToArray().Length+1; i++)
            {
                trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/twarze/twarze.txt" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/twarze/twarze.txt", labels.ToArray()[i - 1] + ",");

            }
            MessageBox.Show(textBox1.Text+" dodano 😎😎😎");

        }

        private void FrameProcedure( object sender, EventArgs e)
        {
            Users.Add("");
            Frame = camera.QueryFrame().Resize(320, 240,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayFace = Frame.Convert<Gray, Byte>();
            MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(facedetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in faceDetectedNow[0])
            {
                result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Frame.Draw(f.rect, new Bgr(Color.Pink), 3);
                if(trainingImages.ToArray().Length != 0) 
                {

                    MCvTermCriteria termCriteria = new MCvTermCriteria(Count,0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(),1500,ref termCriteria);
                    name = recognizer.Recognize(result);
                    Frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Blue));

                }
                //Users[t - 1] = name;
                Users.Add("");

            }
            cameraBox.Image = Frame;
            names = "";
            Users.Clear();
        }

       
    }
}
