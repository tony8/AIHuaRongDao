using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
//定义一个界面的状态

namespace AIHuaRongDao
{  
    public partial class AIHuaRongDao : Form
    {
        private Panel plSelected;//记录选中的控件ID
        iPanel mypanel;
        AIMachine myAI;
        List<state> result;
        public AIHuaRongDao()
        {
            InitializeComponent();
        }
      
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //先建一个界面类
            mypanel = new iPanel();
            myAI = new AIMachine(mypanel);
            result = new List<state>();
            // 显示初始化方格的位置    
            showState(mypanel.state0,1,0);            
            
        }

        private void btnMove_Click(object sender, EventArgs e)
        {//开始按照状态顺序刷新显示
            //-----------------
            //myAI.sucStateList = myAI.ClosedList;
            //---------------------
            byte sumcount = (byte)myAI.sucStateList.Count;
            showState(mypanel.state0, myAI.sucStateList[sumcount - 1].selectID,0);
            for (int i = sumcount - 1; i > 0; i--)
            {
                //int a = sumcount - i;
                //showStep.Text = a.ToString();
                showState(myAI.sucStateList[i], myAI.sucStateList[i - 1].selectID,sumcount - i);
            }
            showState(myAI.sucStateList[0], 1,sumcount);           
          
        }

        private void showBFSAndDFS(searchType flagtype) 
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool flag ;
            if (flagtype ==searchType.BFS) 
            {
                flag = myAI.BFS();
            } 
            else
            {
                flag = myAI.DFS();
            }
           

            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            textBoxtimeShow.Text = ts2.TotalSeconds.ToString();

            if (flag)
            {
                result = myAI.sucStateList;
                txtShowCount.Text = myAI.searchCount.ToString();
                txtPath.Text = result.Count.ToString();
                int count = myAI.ClosedList.Count + myAI.OpenList.Count;
                txtShowCount.Text = count.ToString();
            }
            else
            {
                //输出找不到答案
            }
        }
        private void btnBFS_Click(object sender, EventArgs e)
        {//广度优先搜索
            showBFSAndDFS(searchType.BFS);
            //Stopwatch sw = new Stopwatch();
            //sw.Start(); 
            //bool flag = myAI.BFS();
            //sw.Stop();
            //TimeSpan ts2 = sw.Elapsed;
            //textBoxtimeShow.Text = ts2.TotalSeconds.ToString();
           
            //if (flag)
            //{
            //    result = myAI.sucStateList;
            //    txtShowCount.Text = myAI.searchCount.ToString();
            //    txtPath.Text = result.Count.ToString();
            //    int count = myAI.ClosedList.Count+myAI.OpenList.Count;
            //    txtShowCount.Text = count.ToString();
            //}
            //else
            //{
            //    //输出找不到答案
            //}
             

            //byte sumcount = (byte)myAI.sucStateList.Count;
            //showState(mypanel.state0, myAI.sucStateList[sumcount-1].selectID);
            //for (int i = sumcount-1; i > 0; i--)
            //{
            //    showState(myAI.sucStateList[i],myAI.sucStateList[i-1].selectID);
            //}
            //showState(myAI.sucStateList[0], 1);
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {//深度优先搜索
            showBFSAndDFS(searchType.DFS);                  
        }

        /* P1 = 0,//口
    P4 = 1,//田
    P2V = 2,//日
    P2H = 3,//口口
 * 1.曹操 田
 * 2.关羽 口口
 * 3.赵云  日
 * 4.张飞  日
 * 5.马超  日
 * 6.黄忠  日
 * 7.8.9.10 小兵 口
 */
        private Panel tranPanel(int id) 
        {//根据ID找到人物所在面板
            switch (id) 
            {
                case 1: return panelChaoC;
                case 2: return panelGuanyu;
                case 3: return panelZhaoyun;
                case 4: return panelzhangfei;
                case 5: return panelMachao;
                case 6: return panelHuangzhong;
                case 7: return  panelS1;
                case 8: return panelS2;
                case 9: return panelS3;
                case 10: return panelS4;
                default:
                    return panelChaoC;                  
            }
        }
        private Image tranResource(int id)
        {//根据ID找到人物所在面板
            switch (id)
            {
                case 1: return (Image)(Properties.Resources.R1);
                case 2: return (Image)(Properties.Resources.R2);
                case 3: return (Image)(Properties.Resources.R3);
                case 4: return (Image)(Properties.Resources.R4);
                case 5: return (Image)(Properties.Resources.R5);
                case 6: return (Image)(Properties.Resources.R6);
                case 7: return (Image)(Properties.Resources.R7);
                case 8: return (Image)(Properties.Resources.R8);
                case 9: return (Image)(Properties.Resources.R9);
                case 10: return (Image)(Properties.Resources.R10);
                default:
                    return (Image)(Properties.Resources.R1);
            }

        }
       
        private void setLocation(state S0) 
        {//对于7.8，9，10，直接赋值
        //对于其他，找到左上角点
            int[] NX = new int[10];
            int[] NY = new int[10];
            for (byte id = 0; id < 10; id++) 
            {
                //Point temp= getLocation(S0,i);
                //获得人物方格的左上角点坐标 [pox,poy]
                //得到有4个7的数表
                byte[,] S0state = state.Num2Plcomputer(S0.plstateNum);
                //将4个7按照顺序赋值，还原为7、8、9、10
                S0state = state.plComputer2show(S0state);
                Point temp = state.getLocation(S0state, (byte)(id + 1));
                NX[id] = temp.Y;
                NY[id] = temp.X;
            }
                 panelChaoC.Location = iPanel.position[NX[0], NY[0]];
                panelGuanyu.Location = iPanel.position[NX[1], NY[1]];
               panelZhaoyun.Location = iPanel.position[NX[2], NY[2]];
              panelzhangfei.Location = iPanel.position[NX[3], NY[3]];
                panelMachao.Location = iPanel.position[NX[4], NY[4]];
            panelHuangzhong.Location = iPanel.position[NX[5], NY[5]];
                    panelS1.Location = iPanel.position[NX[6], NY[6]];
                    panelS2.Location = iPanel.position[NX[7], NY[7]];
                    panelS3.Location = iPanel.position[NX[8], NY[8]];
                    panelS4.Location = iPanel.position[NX[9], NY[9]];
            //PlState[4, 0] = PlState[4, 3] = true;   //设置最后一行的首尾位置不可用
            //PlState[4, 1] = PlState[4, 2] = false;  //设置最后一行的中间两个位置可用
        }

       // private void showState(state S0,byte nextID) 
       private void showState(state S0,byte nextID,int stepID) 
        {
            //(s0,A) (S1,A)
            //设置各方格的初始图片
            panelChaoC.BackgroundImage = (Image)(Properties.Resources.B1);
            panelGuanyu.BackgroundImage = (Image)(Properties.Resources.B2);
            panelZhaoyun.BackgroundImage = (Image)(Properties.Resources.B3);
            panelzhangfei.BackgroundImage = (Image)(Properties.Resources.B4);
            panelMachao.BackgroundImage = (Image)(Properties.Resources.B5);
            panelHuangzhong.BackgroundImage = (Image)(Properties.Resources.B6);
            panelS1.BackgroundImage = (Image)(Properties.Resources.B7);
            panelS2.BackgroundImage = (Image)(Properties.Resources.B8);
            panelS3.BackgroundImage = (Image)(Properties.Resources.B9);
            panelS4.BackgroundImage = (Image)(Properties.Resources.B10);
            //将需要移动的人背景改为红色 
            tranPanel(S0.selectID).BackgroundImage = tranResource(S0.selectID);            
            //根据状态数表，设置各方格的位置
            setLocation( S0) ;
            Thread.Sleep(500);          

            panelChaoC.BackgroundImage = (Image)(Properties.Resources.B1);
            panelGuanyu.BackgroundImage = (Image)(Properties.Resources.B2);
            panelZhaoyun.BackgroundImage = (Image)(Properties.Resources.B3);
            panelzhangfei.BackgroundImage = (Image)(Properties.Resources.B4);
            panelMachao.BackgroundImage = (Image)(Properties.Resources.B5);
            panelHuangzhong.BackgroundImage = (Image)(Properties.Resources.B6);
            panelS1.BackgroundImage = (Image)(Properties.Resources.B7);
            panelS2.BackgroundImage = (Image)(Properties.Resources.B8);
            panelS3.BackgroundImage = (Image)(Properties.Resources.B9);
            panelS4.BackgroundImage = (Image)(Properties.Resources.B10);
            tranPanel(nextID).BackgroundImage = tranResource(nextID);
            Thread.Sleep(500);
        }

       private void button3_Click(object sender, EventArgs e)
       {

       }

    }
}
