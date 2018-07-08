using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace LotteryForCESEGraduationParty
{
    public partial class Main : Form
    {
        ArrayList numList = new ArrayList(); // 票根编号
        ArrayList countList = new ArrayList(); // 每个编号抽中次数
        int chosenNum; // 目前选中的编号的角标
        bool isRefreshing = false; // 是否正在抽奖
        int refreshCount; // 抽奖次数
        Log log = new Log(); // 记录日志
        Random random; // 随机数
        System.Timers.Timer timer = new System.Timers.Timer(interval: 1); // 定时器
        public Main()
        {
            InitializeComponent();
            log.WriteLine("抽奖系统开启。");
            int width = Screen.PrimaryScreen.WorkingArea.Size.Width, height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            startButton.Left = width - startButton.Width - (int)(width * 0.01);
            startButton.Top = height - startButton.Height - exitButton.Height - (int)(height * 0.02);
            exitButton.Left = width - exitButton.Width - (int)(width * 0.01);
            exitButton.Top = height - exitButton.Height - (int)(height * 0.01);
            textLabel.Left = (int)(width * 0.2);
            textLabel.Top = (int)(height * 0.2);
            textLabel.Width = (int)(width * 0.6);
            textLabel.Height = (int)(height * 0.6);
            textLabel.Font = new System.Drawing.Font("Impact", (float)(height * 0.2));
            textLabel.BackColor = System.Drawing.Color.FromArgb(128, 255, 255, 255);
            timer.Elapsed += Timer_Elapsed;
            try
            {
                BackgroundImage = System.Drawing.Image.FromFile("background.jpg");
            }
            catch
            {

            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isRefreshing&&(random != null))
            {
                chosenNum = random.Next(numList.Count);
                countList[chosenNum] = (int)countList[chosenNum] + 1;
                Action action = delegate () {
                    textLabel.Text = ((int)numList[chosenNum]).ToString().PadLeft(3, '0');
                };
                Invoke(action);
                refreshCount++;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                log.WriteLine(String.Format("抽奖结果已确定，编号为 {0}。", numList[chosenNum]));
                log.WriteLine(String.Format("本次抽奖共滚动 {0} 次，每个编号的出现次数分别为：{1}。", refreshCount, String.Join(", ", countList.ToArray())));
                StreamWriter file = File.CreateText("item.txt");
                int i;
                for (i = 0; i < numList.Count; i++)
                {
                    if (i != chosenNum)
                    {
                        file.WriteLine(numList[i]);
                    }
                }
                file.Close();
                log.WriteLine(String.Format("已将 {0} 剔除出可抽中的列表。", numList[chosenNum]));
                startButton.Text = "开 始";
                exitButton.Enabled = true;
                timer.Stop();
            }
            else
            {
                numList.Clear();
                countList.Clear();
                try
                {
                    // 尝试打开 Item.txt 并读入所有票根
                    StreamReader file = File.OpenText("item.txt");
                    while (!file.EndOfStream)
                    {
                        int temp = Convert.ToInt32(file.ReadLine(), 10);
                        if (!numList.Contains(temp))
                        {
                            numList.Add(temp);
                            countList.Add(0);
                        }
                    }
                    file.Close();
                    log.WriteLine(String.Format("已读取全部票根，共有 {0} 张票根，编号分别为：{1}。", numList.Count, String.Join(", ", numList.ToArray())));
                }
                catch
                {
                    // 出现错误则使用默认数据
                    int i;
                    for (i = 1; i < 101; i++)
                    {
                        numList.Add(i);
                        countList.Add(i);
                    }
                    log.WriteLine(String.Format("票根数据不存在，使用默认数据，共有 {0} 张票根，编号分别为：{1}。", numList.Count, String.Join(", ", numList.ToArray())));
                }
                int seed = (int)DateTime.Now.ToFileTimeUtc();
                random = new Random(seed);
                log.WriteLine(String.Format("已选取随机数种子 {0}。", seed));
                // 保留随机数种子以供查证
                startButton.Text = "停 止";
                exitButton.Enabled = false;
                refreshCount = 0;
                timer.Start();
            }
            isRefreshing = !isRefreshing;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (!isRefreshing)
            {
                log.Close();
                Close();
            }
        }
    }
}
