using FamilyTreeApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree.form
{
    public partial class Visualization : Form
    {
        Person person = new Person();
        public Visualization(Person root)
        {
            person = root;
            InitializeComponent();
            this.Paint += MainForm_Paint;
        }

        // Hàm tính độ rộng cây gia phả
        private int CalculateFamilyTreeWidth(Person root, int boxWidth, int horizontalSpacing)
        {
            if (root == null) return 0;

            int totalWidth = boxWidth; // Width for the root person

            // If there is a partner, add the partner width plus spacing
            if (root.Partner != null)
            {
                totalWidth += boxWidth + horizontalSpacing;
            }

            // Add widths for all children, including horizontal spacing between them
            if (root.Children != null && root.Children.Count > 0)
            {
                // Calculate the total width of the children
                int childrenWidth = (root.Children.Count - 1) * (boxWidth + horizontalSpacing) + boxWidth;
                totalWidth += childrenWidth;
            }

            return totalWidth;
        }

        // Hàm vẽ cây gia phả
        private void DrawFamilyTree(Graphics g, Person root, Point position, int boxWidth, int boxHeight, int horizontalSpacing, int verticalSpacing)
        {
            if (root == null) return;

            // Tính độ rộng cây gia phả
            int treeWidth = CalculateFamilyTreeWidth(root, boxWidth, horizontalSpacing);

            // Vẽ chính người gốc (cha/mẹ)
            DrawBox(g, $"{root.Name}\n{root.Birthday:dd/MM/yyyy}", position, boxWidth, boxHeight);

            // Tính trung điểm cha mẹ
            Point parentCenter = new Point(position.X + boxWidth / 2, position.Y + boxHeight / 2);

            // Nếu có vợ/chồng, vẽ cạnh bên
            if (root.Partner != null)
            {
                Point partnerPosition = new Point(position.X + boxWidth + horizontalSpacing, position.Y);
                DrawBox(g, $"{root.Partner.Name}\n{root.Partner.Birthday:dd/MM/yyyy}", partnerPosition, boxWidth, boxHeight);

                // Nối cha mẹ với nhau
                Point partnerCenter = new Point(partnerPosition.X + boxWidth / 2, partnerPosition.Y + boxHeight / 2);

                // Đảm bảo đường nối giữa cha mẹ không bị ghi đè lên ô
                Point lineStart = new Point(parentCenter.X, position.Y + boxHeight);
                Point lineEnd = new Point(partnerCenter.X, partnerPosition.Y + boxHeight);
                g.DrawLine(Pens.Black, lineStart, lineEnd);

                // Tính trung điểm giữa cha và mẹ
                parentCenter = new Point((position.X + partnerPosition.X + boxWidth) / 2, position.Y + boxHeight);
            }

            // Nếu có con, vẽ đường thẳng xuống từ trung điểm cha mẹ
            if (root.Children != null && root.Children.Count > 0)
            {
                // Điểm cuối đường thẳng dọc
                Point verticalEnd = new Point(parentCenter.X, parentCenter.Y + verticalSpacing / 2);

                // Vẽ đường thẳng từ cha mẹ xuống điểm giữa
                g.DrawLine(Pens.Black, parentCenter, verticalEnd);

                // Vẽ đường ngang qua tất cả các con
                int totalWidth = (root.Children.Count) * (boxWidth * 3 + horizontalSpacing);
                int startX = verticalEnd.X - totalWidth / 2;
                int childY = verticalEnd.Y + verticalSpacing / 2;

                Point horizontalStart = new Point(startX, verticalEnd.Y);
                Point horizontalEnd = new Point(startX + totalWidth, verticalEnd.Y);

                g.DrawLine(Pens.Black, horizontalStart, horizontalEnd);

                // Vẽ danh sách con, đảm bảo chúng cách nhau 50px
                for (int i = 0; i < root.Children.Count; i++)
                {
                    int tmp = (totalWidth / root.Children.Count) * i + 25;
                    Point childPosition = new Point(tmp, childY);
                    DrawFamilyTree(g, root.Children[i], childPosition, boxWidth, boxHeight, horizontalSpacing, verticalSpacing);

                    // Nối từng con vào đường ngang theo góc 90 độ
                    Point childCenter = new Point(childPosition.X + boxWidth / 2, childPosition.Y);

                    // Vẽ một đường dọc từ trung điểm đường ngang tới từng con
                    Point verticalLineStart = new Point(childCenter.X, verticalEnd.Y);  // Đoạn đứng
                    Point verticalLineEnd = new Point(childCenter.X, childCenter.Y);    // Điểm cuối cùng của con
                    g.DrawLine(Pens.Black, verticalLineStart, verticalLineEnd);
                }
            }
        }


        // Hàm vẽ ô
        private void DrawBox(Graphics g, string text, Point position, int width, int height)
        {
            Rectangle rect = new Rectangle(position.X, position.Y, width, height);
            g.DrawRectangle(Pens.Black, rect);
            using (Font font = new Font("Arial", 10))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(text, font, Brushes.Black, rect, sf);
            }
        }

        // Hàm vẽ đường nối giữa các ô
        private void DrawLine(Graphics g, Point parentPosition, Point childPosition, int boxWidth, int boxHeight)
        {
            // Draw line between centers of the parent and child boxes
            Point parentCenter = new Point(parentPosition.X + boxWidth / 2, parentPosition.Y + boxHeight);
            Point childCenter = new Point(childPosition.X + boxWidth / 2, childPosition.Y);
            g.DrawLine(Pens.Black, parentCenter, childCenter);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Gọi hàm để vẽ cây gia phả
            DrawFamilyTree(g, person, new Point(300, 20), 100, 50, 50, 80);
        }
    }
}
