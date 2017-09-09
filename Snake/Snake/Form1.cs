using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SnakePart()
        {
            X = 0;
            Y = 0;
        }
    }

    public partial class Form1 : Form
    {
        
        //public Form1()
        //{
        //    InitializeComponent();
        //}

        //private void Update(object sender, EventArgs e)
        //{
        //    //执行游戏逻辑代码
        //    pbCanvas.Invalidate();
        //}

        public Form1()
        {
            InitializeComponent();
            gameTimer.Interval = 1000 / 4; //指定间隔时间
            gameTimer.Tick += Update; //指定事件触发的方法
            gameTimer.Start();//启动计时器
            StartGame();//暂时不用考虑该方法
        }

        List<SnakePart> snake = new List<SnakePart>();

        const int width = 16;
        const int heigth = 16;

        const int row = 16;
        const int col = 16;

        bool GameOver = false;//游戏是否结束
        bool Reset = false;//是否重新开始游戏
        int score = 0;//得分
        Direction current = Direction.Right;//当前的行动方向
        SnakePart food = new SnakePart();//贪吃蛇的食物

        private void StartGame()
        {
            GameOver = false;
            Reset = false;
            score = 0;
            snake.Clear();//清空蛇的身体
            SnakePart head = new SnakePart();//定义蛇的头部
            head.X = row / 2 - 1;
            head.Y = row / 2 - 1;
            snake.Add(head);//添加头部到身体
            current = Direction.Right;//默认初始方向：→
            NextFood();//产生下一个食物
        }

        enum Direction
        {
            Down,
            Up,
            Left,
            Right
        }

        private void NextFood()
        {
            Random random = new Random();
            food = new SnakePart();
            do
            {
                food.X = random.Next(row);
                food.Y = random.Next(col);
                if (!IsInSnake(food.X, food.Y))//避免产生的食物在蛇身体上
                    break;
            } while (true);

        }

        private bool IsInSnake(int x, int y)//判断食物是否在蛇的身体上
        {
            for (int i = 0; i < snake.Count - 1; i++)
            {
                if (x == snake[i].X && y == snake[i].Y)
                    return true;
            }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameOver)//判断游戏是否结束
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Reset = true;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (current != Direction.Down)//防止蛇直接反方向运动
                            current = Direction.Up;
                        break;
                    case Keys.Down:
                        if (current != Direction.Up)
                            current = Direction.Down;
                        break;
                    case Keys.Left:
                        if (current != Direction.Right)
                            current = Direction.Left;
                        break;
                    case Keys.Right:
                        if (current != Direction.Left)
                            current = Direction.Right;
                        break;
                }
            }
        }

        private bool IsHitSelf()//判断是否撞击到自身
{
    SnakePart head = snake.First();
    for (int i = 1; i < snake.Count - 1; i++)
    {
        if (head.X == snake[i].X && head.Y == snake[i].Y)
            return true;
    }
    return false;
  }

        private void Update(object sender, EventArgs e)
        {
            if (GameOver)//判断游戏是否结束
            {
                if (Reset)
                {
                    StartGame();
                }
            }
            else
            {
                SnakePart head = snake.First();

                if (head.X < 0 || head.X >= col || head.Y < 0 || head.Y >= col || IsHitSelf())//是否超出边境或撞击到自身
                {
                    GameOver = true;
                    goto outside;//如果是，结束游戏并跳过剩余代码
                }
                if (head.X == food.X && head.Y == food.Y)//判断蛇是否吃的食物
                {
                    SnakePart part = new SnakePart();
                    part.X = snake[snake.Count - 1].X;
                    part.Y = snake[snake.Count - 1].Y;
                    snake.Add(part);//为蛇添加一节身体
                    NextFood();//产生下一个食物
                    score++;//得分加1
                }
                for (int i = snake.Count - 1; i > 0; i--)//整体移动蛇，蛇的后一节会跟随前一节行动，
                {                                        //因此只需将前一节的坐标赋给后一节即可
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }

                switch (current)//依据当前的方向，移动蛇的头部
                {
                    case Direction.Down:
                        head.Y++;
                        break;
                    case Direction.Up:
                        head.Y--;
                        break;
                    case Direction.Left:
                        head.X--;
                        break;
                    case Direction.Right:
                        head.X++;
                        break;
                }

            }
        outside:
            pbCanvas.Invalidate();//重新绘制画面
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 0, 0, width * col, heigth * row);
            if (GameOver)//判断游戏是否结束
            {
                Font font = this.Font;
                string gameover_msg = "Gameover";
                string score_msg = "得分: " + score.ToString();
                string newgame_msg = "按回车键重新开始";
                int center_width = pbCanvas.Width / 2;
                SizeF msg_size = g.MeasureString(gameover_msg, font);
                PointF msg_point = new PointF(center_width - msg_size.Width / 2, 16);
                g.DrawString(gameover_msg, font, Brushes.Black, msg_point);
                msg_size = g.MeasureString(score_msg, font);
                msg_point = new PointF(center_width - msg_size.Width / 2, 32);
                g.DrawString(score_msg, font, Brushes.Black, msg_point);
                msg_size = g.MeasureString(newgame_msg, font);
                msg_point = new PointF(center_width - msg_size.Width / 2, 48);
                g.DrawString(newgame_msg, font, Brushes.Black, msg_point);
            }
            else
            {
                g.FillRectangle(Brushes.Orange, new Rectangle(food.X * width, food.Y * heigth, width, heigth));//绘制食物
                for (int i = 0; i < snake.Count; i++)//绘制蛇的身体
                {
                    Brush snake_color = i == 0 ? Brushes.SeaGreen : Brushes.SkyBlue;//如果是头部就绘制成绿色
                    g.FillRectangle(snake_color, new Rectangle(snake[i].X * width, snake[i].Y * heigth, width, heigth));
                }
                g.DrawString("得分: " + score.ToString(), this.Font, Brushes.Black, new PointF(4, 4));//绘制得分
            }
        }
    }
}