using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIHuaRongDao
{
    struct state
    {
        private ulong PlstateNum;
        public ulong plstateNum
        {
            get { return PlstateNum; }
            set { PlstateNum = value; }
        }
        //public byte[,] PlState;  //状态表 5*4
        public byte selectID;    //该状态下，被选中的人 
        private uint stateID;//状态的唯一编号
        private uint fatherID; //状态的唯一父节点标号
        
        //public uint StateID { set; get; }     
        //public uint FatherID { set; get; }   
            //PlState = new byte[5, 4];
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        PlState[i, j] = NumState[i, j];
            //    }
            //}
        public state(byte[,] NumState) 
        {   
            selectID = 0;
            fatherID = 1;
            stateID = 1;
            //更新被选中的人物序号
            selectID = correctSelectID(NumState, selectID);
            PlstateNum = Plcomputer2Num(NumState);
        }

        public static ulong Plcomputer2Num(byte[,] pl)
        { //将一个数字表转化为一个数字
            //1.将数字表的小兵改为7
            //2.将对应的selectedID同时改掉，看小兵所在的顺序改
            //3.然后转化为数字
            // public static byte[,] stateNum7(byte[,] plstate,byte selectID,out byte newID) 

            byte[,] pltemp = new byte[5, 4];
            pltemp = pl;

            ulong numS = 0;
            ulong tempNum = 0;           
            for (int i = 0; i < pl.GetLength(0);i++ )
            {
                for (int j = 0; j < pl.GetLength(1); j++)
                {
                    tempNum = (ulong)pl[i, j];                    
                    numS = numS | tempNum;
                    numS = numS << 3;                 
                }
            }
            return numS;
        }

        public static byte correctSelectID(byte[,] pl,byte  selectID) 
        {//将小兵序号都变成7时，同时修改被选中的小兵序号，按照先后排
            //1.找到选中小兵的按顺序序号
            if (selectID < 7) 
                return selectID;
             byte count = 0;
            for (int i = 0; i < pl.GetLength(0); i++)
            {
                for (int j = 0; j < pl.GetLength(1); j++)
                {
                    if (pl[i, j] >= 7 && pl[i, j]<11)
                    {
                        count++;                        
                    }
                    if (pl[i, j] == selectID)
                    {
                        return (byte)(selectID + count-1);                      
                    }
                }
            }
            return selectID;
        }
        public static  byte[,]  Num2Plcomputer(ulong numState) 
        {
            //将一个数字转化为一个数字表
            byte[,] myPlState = new byte[5, 4];
            ulong standNum = 7;
            ulong temp = 0;
            numState = numState >> 3;
            for (int i = 4; i >= 0;i-- )
            {
                for (int j = 3; j >= 0; j--)
                {                   
                    temp = standNum & numState;                 
                    myPlState[i, j] = Convert.ToByte(temp); 
                    numState = numState >> 3;
                }
            }
            return myPlState;
        }
       

        public uint sID
        {
            get { return stateID; }
            set { stateID = value; }
        }
       
        public uint FatherID
        {
            get { return fatherID; }
            set { fatherID = value; }
        }
        public static Point getLocation(byte[,] S0state, byte PersonID)
        {//输入数表和人物ID，输出人物左上角点坐标
            int tempX = 11, tempY = 11;
            ////得到有4个7的数表
            //S0state = state.BinNum2PlState(S0.plstateNum);
            ////将4个7按照顺序赋值，还原为7、8、9、10
            //S0state = state.stateNum78910(S0state);
            for (int i = 0; i < S0state.GetLength(0); i++)
            {
                for (int j = 0; j < S0state.GetLength(1); j++)
                {
                    if (S0state[i, j] == PersonID)
                    {
                        if (tempX > i) { tempX = i; }
                        if (tempY > j) { tempY = j; }
                    }
                }
            }
            return new Point(tempY, tempX);
        }

        public static Point[] getZero(byte[,] plshow) 
        {//输入数表plshow，输出2个0的位置
            Point[] zeroL = new Point[2];
            int k = 0;
            //byte[,] S0state = new byte[5, 4];
            //S0state = state.BinNum2PlState(S0.plstateNum);
            for (int i = 0; i < plshow.GetLength(0); i++)
            {
                for (int j = 0; j < plshow.GetLength(1); j++)
                {
                    if (plshow[i, j] == 0)
                    {
                        zeroL[k].X = j;
                        zeroL[k].Y = i;
                        if (k == 0) k = 1;
                    }
                }
            }
            return zeroL;
        }
        //public static bool calculateState(state S0, operate op, out state nextS)
        public static bool calculateState(byte[,] S0state, operate op, out byte[,] nextStste)
        {//判断某个操作是否可行,可以就返回执行后的状态，否则false
            //输入plshow数表1，和操作，输出是否可行，out 下一个数表plshow
             nextStste = new byte[5, 4];
             byte[,] temps0 = new byte[5, 4];
             temps0 = S0state;
             nextStste = S0state;
            //byte[,] S0state = new byte[5, 4];
            ////将数字转化为数表，并将4个7还原为7、8、9、10
            //S0state = state.BinNum2PlState(S0.plstateNum);
            //S0state = state.stateNum78910(S0state);
             Point LocP = getLocation(temps0, op.PersonID);
            Point[] zero = new Point[2];
            zero = getZero(temps0);
            Point size = findPersonLSize(op.PersonID);           
            //nextS = S0;//赋初值   
            //nextS.selectID = op.PersonID;
            //找到移动人物的方格种类
            int style = findStyle(op.PersonID);
            Point zero1 = new Point(zero[0].Y,zero[0].X);
            Point zero2 = new Point(zero[1].Y, zero[1].X);
            //人物方块在数表中的位置 pox为第几行poy为第几列
            int pRow = LocP.Y;
            int pCol = LocP.X;
 
            switch (op.dir)
            {
                case Direction.UP:
                    if (pRow - 1 < 0 )//边界控制 
                        return false;    
                    switch (style)
                    {//向上时
                        case 1://直接换
                            if (new Point( pRow - 1,pCol) == zero1 || new Point( pRow - 1,pCol) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow-1, pCol] = op.PersonID;
                                return true;
                            }
                            else 
                                return false;                               
                        case 2: //日
                            if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow - 1, pCol) == zero1 || new Point(pRow - 1,pCol) == zero2)
                            {
                                nextStste[pRow+ 1, pCol ] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;                                 
                        case 3: //口口
                             if (pCol+ 1 > 3) return false;//-------------
                            if (new Point(pRow- 1, pCol ) == zero1 && new Point(pRow - 1, pCol+ 1 ) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                nextStste[pRow - 1, pCol+ 1 ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;  
                        case 4: //田
                             if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow- 1, pCol ) == zero1 || new Point(pRow- 1, pCol ) == zero2)
                            {
                                nextStste[pRow + 1, pCol ] = 0;
                                nextStste[pRow + 1, pCol + 1] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                nextStste[pRow- 1 , pCol+ 1 ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;  
                    }
                    break;
                case Direction.down:
                    if (pRow + 1 > 4) //边界控制
                        return false;
                    switch (style)
                    {       //向下时
                        case 1://直接换
                            if (new Point(pRow+ 1, pCol ) == zero1 || new Point(pRow + 1, pCol) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 1, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;  
                        case 2: //日
                            if (pRow + 2 > 4) //边界控制
                                return false;
                            if (new Point(pRow+ 2, pCol ) == zero1 || new Point(pRow+ 2, pCol) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 2, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 3: //口口
                             if (pCol + 1 > 3) return false;//-------------
                            if (new Point(pRow+ 1, pCol ) == zero1 && new Point(pRow+1, pCol + 1) == zero2)
                            {  
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol + 1] = 0;
                                nextStste[pRow+ 1, pCol ] = op.PersonID;
                                nextStste[pRow+ 1, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 4: //田
                            if (pRow + 2 > 4 || pCol + 1 > 3) //边界控制
                                return false;
                            if (new Point(pRow+ 2, pCol ) == zero1 && new Point(pRow+2, pCol + 1) == zero2)
                            {  
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow+ 2, pCol] = op.PersonID;
                                nextStste[pRow + 2, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
                case Direction.left:
                    if (pCol -1 < 0) //边界控制
                        return false;
                    switch (style)
                    {           //向左时
                        case 1://直接换
                            if (new Point(pRow, pCol-1) == zero1 || new Point(pRow, pCol-1 ) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 2: //日
                             if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow, pCol-1) == zero1 && new Point(pRow+1, pCol-1) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 1, pCol ] = 0;
                                nextStste[pRow , pCol - 1] = op.PersonID;
                                nextStste[pRow +1, pCol - 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 3: //口口           
                            if (pCol+ 1 > 3) return false;//-------------
                            if (new Point(pRow, pCol-1) == zero1 || new Point(pRow, pCol -1) == zero2)
                            { 
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 4: //田
                             if (pCol+ 1 > 3||pRow+ 1>4) return false;//-------------
                            if (new Point(pRow, pCol-1 ) == zero1 && new Point(pRow + 1, pCol - 1) == zero2)
                            {
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow+ 1, pCol + 1] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                nextStste[pRow + 1, pCol - 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
                case Direction.right:
                    if (pCol + 1 > 3) //边界控制
                        return false;
                    switch (style)
                    {           //向右时
                        case 1://直接换
                            if (new Point(pRow, pCol+1) == zero1 || new Point(pRow , pCol+ 1) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol+ 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 2: //日
                             if (pRow + 1>4) return false;//-------------
                            if (new Point(pRow, pCol+1) == zero1 && new Point(pRow + 1, pCol + 1) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+1,pCol] = 0;
                                nextStste[pRow , pCol+ 1] = op.PersonID;
                                nextStste[pRow + 1, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 3: //口口
                            if (pCol + 2 > 3) //边界控制
                                return false;
                            if (new Point(pRow, pCol+2) == zero1 || new Point(pRow , pCol+ 2) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol + 2] = (byte)op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                        case 4: //田
                            if (pCol + 2 > 3) //边界控制
                                return false;
                            if (new Point(pRow, pCol+2) == zero1 && new Point(pRow + 1, pCol + 2) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+1, pCol ] = 0;
                                nextStste[pRow , pCol+ 2] = op.PersonID;
                                nextStste[pRow+1,pCol +2] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
            }

            return true;
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
        public static Point findPersonLSize(int ID)
        {
            switch (ID)
            {
                case 1: return new Point(2, 2);
                case 2: return new Point(2, 1);
                case 3: return new Point(1, 2);
                case 4: return new Point(1, 2);
                case 5: return new Point(1, 2);
                case 6: return new Point(1, 2);
                case 7: return new Point(1, 1);
                case 8: return new Point(1, 1);
                case 9: return new Point(1, 1);
                case 10: return new Point(1, 1);
                default: return new Point(0, 0);
            }
        }
        public static int findStyle(int ID) 
        {
            int squreNum ;
            switch (ID)
            {
                case 1: squreNum = 4; break;
                case 2: squreNum = 3; break;
                case 3: squreNum = 2; break;
                case 4: squreNum = 2; break;
                case 5: squreNum = 2; break;
                case 6: squreNum = 2; break;
                case 7: squreNum = 1; break;
                case 8: squreNum = 1; break;
                case 9: squreNum = 1; break;
                case 10: squreNum = 1; break;
                default: squreNum = 0; break;
            }
            return squreNum;
        }
      

        public static byte[,] plShow2computer(byte[,] plstate) 
        {//由于4个小兵样子一样，所以位置可以对调，所以共有11-3=8种可能性
            //将小兵的序号全部变成7
            //同时考虑修改selectedID 
            byte[,] temp = new byte[5, 4];
            for (int i = 0; i < plstate.GetLength(0); i++)
            {
                for (int j = 0; j < plstate.GetLength(1); j++)
                {
                    if (plstate[i, j] > 7) 
                        plstate[i, j] = 7;
                   
                    temp[i, j] = plstate[i, j];
                }
            }
            return temp;
        }
        //public static byte[,] plShow2Same(byte[,] plstate)
        //{//由于4个小兵样子一样，所以位置可以对调，所以共有11-3=8种可能性
        //    //将小兵的序号全部变成7
        //    //同时考虑修改selectedID 
        //    byte[,] temp = new byte[5, 4];
        //    for (int i = 0; i < plstate.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < plstate.GetLength(1); j++)
        //        {
        //            if (plstate[i, j] > 7)
        //                plstate[i, j] = 7;
        //            else if (plstate[i, j] > 2)
        //                plstate[i, j] = 3;
        //            temp[i, j] = plstate[i, j];
        //        }
        //    }
        //    return temp;
        //}

        public static byte[,] plComputer2show(byte[,] plstate)
        {//由于4个小兵样子一样，所以位置可以对调，所以共有11-3=8种可能性
            //将小兵的序号按顺序变成7、 8、9、10
            byte[,] newplState = new byte[5, 4];
            newplState = plstate;
            byte[,] temp = new byte[5, 4];
            byte count = 0;
            for (byte i = 0; i < newplState.GetLength(0); i++)
            {
                for (byte j = 0; j < newplState.GetLength(1); j++)
                {
                    if (newplState[i, j] == 7)
                    {
                        temp[i, j] = (byte)(newplState[i, j] + count);
                        count++;
                    }
                    else 
                    {
                        temp[i, j] = newplState[i, j];
                    }
                }
            }
            return temp;
        }

        public static bool istheSameState(ulong a,ulong b) 
        {//判断2个状态是否相同            
            ulong stand = 7;
            ulong tempa = 0;
            ulong tempb = 0;
            a = a >> 3;
            b = b >> 3;
           
            for (int j = 0; j < 20; j++)
            {
                tempa = stand & a;
                tempb = stand & b;
                if (tempa != tempb) 
                {
                    if (tempa < 7 && tempa > 2 && tempb > 2 && tempb < 7)
                    { }
                    else
                        return false;
                }                   
                a = a >> 3;
                b = b >> 3;
            }
            
             return true;             
        }
    }
     
   

}
