using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoCoKu
{
    public partial class Form1 : Form
    {
        private IsoCoKuData toDisplay = new IsoCoKuData();

        public Form1()
        {
            new Thread(StartSolver).Start();

            InitializeComponent();
        }

        private void StartSolver()
        {
            BestFirstSolver.Solve(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

            toDisplay = BestFirstSolver.solution;

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font pinFont = new Font("Arial", 30);
            Brush pinBrush = new SolidBrush(Color.Black);

            for (int n = 0; n < 5; n++)
            {
                g.DrawString("1", pinFont, pinBrush, 140 + 200 * n, 40);
                g.DrawString(toDisplay.pins[10].ToString(), pinFont, pinBrush, 240 + 200 * n, 715);
            }

            for (int n = 0; n < 6; n++)
            {
                g.DrawString(toDisplay.pins[n % 5].ToString(), pinFont, pinBrush, 40 + 200 * n, 265);
                g.DrawString(toDisplay.pins[(n % 5) + 5].ToString(), pinFont, pinBrush, 140 + 200 * n, 490);
            }

            for (int n = 0; n < 10; n++)
            {
                DrawTriangle(n, g);
                DrawInvertedTriangle(n, g);
            }
        }

        private void DrawTriangle(int index, Graphics g)
        {
            int row = index / 5;

            int top = row * 225 + 80;

            int left = 65 + 200 * (index % 5) + row * 100;

            Pen trianglePen = new Pen(Color.Black, 5.0f);

            g.DrawLine(trianglePen, left, top + 190, left + 95, top);
            g.DrawLine(trianglePen, left + 95, top, left + 190, top + 190);
            g.DrawLine(trianglePen, left, top + 190, left + 190, top + 190);

            Triangle toDraw = toDisplay.triangles[index];

            DrawDots(g, left + 85, top + 30, toDraw.dots[0]);
            DrawDots(g, left + 20, top + 160, toDraw.dots[1]);
            DrawDots(g, left + 150, top + 160, toDraw.dots[2]);
        }

        private void DrawInvertedTriangle(int index, Graphics g)
        {
            int row = index / 5;

            int top = row * 225 + 305;
            int left = 65 + 200 * (index % 5) + (row % 2) * 100;

            Pen trianglePen = new Pen(Color.Black, 5.0f);

            g.DrawLine(trianglePen, left, top, left + 95, top + 190);
            g.DrawLine(trianglePen, left, top, left + 190, top);
            g.DrawLine(trianglePen, left + 190, top, left + 95, top + 190);

            Triangle toDraw = toDisplay.triangles[index + 10];

            DrawDots(g, left + 85, top + 145, toDraw.dots[0]);
            DrawDots(g, left + 150, top + 15, toDraw.dots[1]);
            DrawDots(g, left + 20, top + 15, toDraw.dots[2]);
        }

        private void DrawDots(Graphics g, int x, int y, int numDots)
        {
            Font dotFont = new Font("Arial", 16);
            Brush dotBrush = new SolidBrush(Color.Red);

            g.DrawString(numDots.ToString(), dotFont, dotBrush, x, y);
        }
    }
}
