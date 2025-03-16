
using System.Diagnostics.Tracing;
using System;
using System.IO;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Diagnostics.Eventing.Reader;
namespace aplicatieMatrice2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap source, destination;

        string inputPath = "", outputPath;
        public Color red = Color.FromArgb(255, 0, 0);
        public Color green = Color.FromArgb(0, 255, 0);
        public Color blue = Color.FromArgb(0, 0, 255);
        public Color grey = SystemColors.AppWorkspace;
        public Random rnd = new Random();
        private bool aprox(int a, int b, int epsilon = 255 / 3)
        {
            if (Math.Abs(a - b) < epsilon) { return true; }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                inputPath = textBox1.Text;
                source = new Bitmap(Image.FromFile(inputPath));
                destination = new Bitmap(source.Width, source.Height);
                pictureBox1.Image = source;

                for (int i = 0; i < destination.Width; i++)
                {
                    for (int j = 0; j < destination.Height; j++)
                    {
                        destination.SetPixel(i, j, grey);
                    }
                }
                pictureBox2.Image = destination;

            }
            catch (Exception t2)
            {
                ;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color fillColor;
            int redCount = 0;
            int greenCount = 0;
            int blueCount = 0;
            List<int[]> toFill = new List<int[]>();

            int count = 0;
            int[,] ToRgb = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ToRgb[i, j] = -1;
                }
            }
            if (destination != null)
            {
                for (int i = 0; i < source.Width; i++)
                {
                    for (int j = 0; j < source.Height; j++)
                    {
                        Color color = source.GetPixel(i, j);
                        int r = color.R;
                        int g = color.G;
                        int b = color.B;

                        if (count == 0 && ToRgb[0, 0] == -1 && ToRgb[0, 1] == -1 && ToRgb[0, 2] == -1)
                        {
                            count += 1;
                            ToRgb[0, 0] = r; ToRgb[0, 1] = g; ToRgb[0, 2] = b;
                            destination.SetPixel(i, j, red);

                        }
                        else if (count == 1 && (!aprox(ToRgb[0, 0], r) || !aprox(ToRgb[0, 1], g) || !aprox(ToRgb[0, 2], b)) && ToRgb[1, 0] == -1 && ToRgb[1, 1] == -1 && ToRgb[1, 2] == -1)
                        {
                            count += 1;
                            ToRgb[1, 0] = r;
                            ToRgb[1, 1] = g;
                            ToRgb[1, 2] = b;
                            destination.SetPixel(i, j, green);
                        }
                        else if (count == 2 && (!aprox(ToRgb[0, 0], r) || !aprox(ToRgb[0, 1], g) || !aprox(ToRgb[0, 2], b)) && (!aprox(ToRgb[1, 0], r) || !aprox(ToRgb[1, 1], g) || !aprox(ToRgb[1, 2], b)) && ToRgb[2, 0] == -1 && ToRgb[2, 1] == -1 && ToRgb[2, 2] == -1)
                        {
                            count += 1;
                            ToRgb[2, 0] = r;
                            ToRgb[2, 1] = g;
                            ToRgb[2, 2] = b;
                            destination.SetPixel(i, j, blue);
                        }
                        else
                        {
                            if (aprox(r, ToRgb[0, 0]) && aprox(g, ToRgb[0, 1]) && aprox(b, ToRgb[0, 2]))
                            {
                                destination.SetPixel(i, j, red);
                                redCount++;
                            }
                            else if (aprox(r, ToRgb[1, 0]) && aprox(g, ToRgb[1, 1]) && aprox(b, ToRgb[1, 2]))
                            {
                                destination.SetPixel(i, j, green);
                                greenCount++;
                            }
                            else if (aprox(r, ToRgb[2, 0]) && aprox(g, ToRgb[2, 1]) && aprox(b, ToRgb[2, 2]))
                            {
                                destination.SetPixel(i, j, blue);
                                blueCount++;
                            }
                            else
                            {
                                toFill.Add(new int[] { i, j });
                            }


                        }
                    }


                }
            }
            int minCount = Math.Min(redCount, Math.Min(greenCount, blueCount));
            if (minCount == redCount) { fillColor = Color.FromArgb(255, 0, 0); }
            else if (minCount == greenCount) { fillColor = Color.FromArgb(0, 255, 0); }
            else { fillColor = Color.FromArgb(0, 0, 255); }
            foreach (int[] fillArr in toFill)
            {
                int ifill = fillArr[0], jfill = fillArr[1];
                destination.SetPixel(ifill, jfill, fillColor);
            }
            pictureBox2.Image = destination;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputPath = textBox2.Text;
            int start = 0, end = outputPath.Length - 1;
            for (int i = outputPath.Length - 1; i >= 0; i--)
            {
                if (outputPath[i] == '\\')
                {
                    end = i;
                    break;
                }
            }
            try
            {
                string beforeLastBackSlash = outputPath.Substring(0, end);



                try { Directory.CreateDirectory(beforeLastBackSlash); }
                catch (Exception exception) {; }
                if (destination != null && !string.IsNullOrWhiteSpace(outputPath)) { }
                destination?.Save(outputPath);





            }
            catch (Exception t1) {; }
            finally
            {
                if (destination != null)
                {
                    for (int i = 0; i < destination.Width; i++)
                    {
                        for (int j = 0; j < destination.Height; j++)
                        {
                            destination.SetPixel(i, j, grey);
                        }
                    }
                    pictureBox2.Image = destination;
                }
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region varianta veche
            /* Cod vechi:
             * 
             * 
            //purple is (102,51,153) in rgb
            Color purple = Color.FromArgb(102, 51, 153);
            //gold is rgb(255,215,0)
            Color gold = Color.FromArgb(255, 215, 0);
            int[] nextPurple = new int[] { -1, -1, -1 };
            int[] nextGold = new int[] { -1, -1, -1 };
            int purpleCount = 0;
            int goldCount = 0;

            int count = 0;
            if (source == null) { return; }
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;
                    if (count == 0)
                    {
                        count++;
                        nextPurple[0] = r;
                        nextPurple[1] = g;
                        nextPurple[2] = b;

                    }
                    else if (count == 1 && (!aprox(r, nextPurple[0]) || !aprox(g, nextPurple[1]) || !aprox(b, nextPurple[2])))
                    {
                        count++;
                        nextGold[0] = r;
                        nextGold[1] = g;
                        nextGold[2] = b;

                    }
                    else
                    {
                        ;
                    }
                    if (aprox(r, nextPurple[0]) && aprox(g, nextPurple[1]) && aprox(b, nextPurple[2]))
                    {

                        destination.SetPixel(i, j, purple);
                        purpleCount++;
                    }
                    else if (aprox(r, nextGold[0]) && aprox(g, nextGold[1]) && aprox(b, nextGold[2]))
                    {
                        destination.SetPixel(i, j, gold);
                        goldCount++;
                    }
                    else
                    {
                        Color fillColor;
                        if (goldCount > purpleCount)
                        {
                            fillColor = purple;
                        }
                        else { fillColor = gold; }
                        destination.SetPixel(i, j, fillColor);
                    }
                }
            }
         
            pictureBox2.Image = destination;
            */
            #endregion


            //Varianta noua:
            button5_Click(sender,e,true,true);
        }

        #region TO_SKY_OVERLOAD_OF:      button5_Click()    function
        private void button5_Click(object sender, EventArgs e,bool inSky=false)
        {
            
            if (source == null) { return; }
            destination = new Bitmap(source.Width,source.Height);
            
            int razaX = source.Width / 6;
            int razaY = source.Width / 6;
            int[,] backgroundColors = new int[9, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    backgroundColors[i, j] = -1;
                }
            }
            int[] counts = new int[9];
            int fullVerifier = 1;
            for (int i = 0; i < 9; i++) { counts[i] = 0; }
            for (int i = razaX; i >= 0; i--)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }


                }
                for (int j = source.Height - razaY; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }


            for (int i = source.Width - razaX; i < source.Width; i++)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }

                for (int j = source.Height - razaY; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }

            int maxBackgroundIndex = 0;
            for (int i = 1; i < 9; i++)
            {
                if (counts[i] > counts[maxBackgroundIndex]) { maxBackgroundIndex = i; }
            }
            int backgroundRed = backgroundColors[maxBackgroundIndex, 0];
            int backgroundGreen = backgroundColors[maxBackgroundIndex, 1];
            int backgroundBlue = backgroundColors[maxBackgroundIndex, 2];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (aprox(r, backgroundRed) && aprox(g, backgroundGreen) && aprox(b, backgroundBlue))
                    {
                        
                        
                            destination.SetPixel(i,j,Color.FromArgb(0,0,150));
                        
                        
                    }
                    else {
                        
                        destination.SetPixel(i,j,Color.FromArgb(255,255,255)); 
                    }
                }
            }


            pictureBox2.Image = destination;
        }
        #endregion

        #region button5_Click()    original function
        private void button5_Click(object sender, EventArgs e)
        {

            if (source == null) { return; }
            destination = new Bitmap(source.Width, source.Height);

            int razaX = source.Width / 6;
            int razaY = source.Width / 6;
            int[,] backgroundColors = new int[9, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    backgroundColors[i, j] = -1;
                }
            }
            int[] counts = new int[9];
            int fullVerifier = 1;
            for (int i = 0; i < 9; i++) { counts[i] = 0; }
            for (int i = razaX; i >= 0; i--)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }


                }
                for (int j = source.Height - razaY; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }

            
            for (int i = source.Width-razaX; i <source.Width; i++)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }

                for (int j = source.Height-razaY; j<source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }

                    
                    int maxBackgroundIndex = 0;
            for (int i = 1; i < 9; i++)
            {
                if (counts[i] > counts[maxBackgroundIndex]) { maxBackgroundIndex = i; }
            }
            int backgroundRed = backgroundColors[maxBackgroundIndex, 0];
            int backgroundGreen = backgroundColors[maxBackgroundIndex, 1];
            int backgroundBlue = backgroundColors[maxBackgroundIndex, 2];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (aprox(r, backgroundRed) && aprox(g, backgroundGreen) && aprox(b, backgroundBlue))
                    {
                        ; 
                        

                    }
                    else
                    {
                        destination.SetPixel(i,j,color);
                    }
                }
            }


            pictureBox2.Image = destination;
        }
        #endregion


        #region TO_ROYAL_OVERLOAD_OF:       button5_Click()         FUNCTION
        private void button5_Click(object sender, EventArgs e, bool inRoyal = false,bool dif1=false)
        {

            if (source == null) { return; }
            destination = new Bitmap(source.Width, source.Height);
            //purple is (102,51,153) in rgb
            Color purple = Color.FromArgb(102, 51, 153);
            //gold is rgb(255,215,0)
            Color gold = Color.FromArgb(255, 215, 0);


            int razaX = source.Width / 6;
            int razaY = source.Width / 6;
            int[,] backgroundColors = new int[9, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    backgroundColors[i, j] = -1;
                }
            }
            int[] counts = new int[9];
            int fullVerifier = 1;
            for (int i = 0; i < 9; i++) { counts[i] = 0; }
            for (int i = razaX; i >= 0; i--)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }


                }
                for (int j = source.Height - razaY; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }


            for (int i = source.Width - razaX; i < source.Width; i++)
            {
                for (int j = razaY; j >= 0; j--)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }

                for (int j = source.Height - razaY; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (fullVerifier < 9)
                    {
                        bool match = true;
                        for (int t = 0; t < 9; t++)
                        {

                            int oldRed = backgroundColors[t, 0];
                            int oldGreen = backgroundColors[t, 1];
                            int oldBlue = backgroundColors[t, 2];
                            if (aprox(r, oldRed) && aprox(g, oldGreen) && aprox(b, oldBlue))
                            {
                                match = false;
                                counts[t] += 1;
                                break;
                            }
                        }
                        if (match)
                        {
                            backgroundColors[fullVerifier, 0] = r;
                            backgroundColors[fullVerifier, 1] = g;
                            backgroundColors[fullVerifier, 2] = b;
                            counts[fullVerifier] += 1;
                            fullVerifier++;

                        }
                    }
                    else
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            int backgroundR = backgroundColors[t, 0], backgroundG = backgroundColors[t, 1], backgroundB = backgroundColors[t, 2];
                            if (aprox(r, backgroundR) && aprox(g, backgroundG) && aprox(b, backgroundB))
                            {
                                counts[t]++;
                                break;
                            }
                        }
                    }
                }
            }
            int maxBackgroundIndex = 0;
            for (int i = 1; i < 9; i++)
            {
                if (counts[i] > counts[maxBackgroundIndex]) { maxBackgroundIndex = i; }
            }
            int backgroundRed = backgroundColors[maxBackgroundIndex, 0];
            int backgroundGreen = backgroundColors[maxBackgroundIndex, 1];
            int backgroundBlue = backgroundColors[maxBackgroundIndex, 2];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int r = color.R, g = color.G, b = color.B;
                    if (aprox(r, backgroundRed) && aprox(g, backgroundGreen) && aprox(b, backgroundBlue))
                    {


                        destination.SetPixel(i, j, purple);


                    }
                    else
                    {

                        destination.SetPixel(i, j,gold);
                    }
                }
            }


            pictureBox2.Image = destination;
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            if (source == null) { return; }
            button5_Click(sender, e, true);
            
            
        }
    }
}
