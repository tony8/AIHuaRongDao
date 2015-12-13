using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHuaRongDao
{
    internal class MyComboBoxPanel
    {
        //internal StartPanel selectPanel;  
       internal  List<StartPanel> list ;
     
        public MyComboBoxPanel() 
        { 
            list = new List<StartPanel>();       
        }
        public void initPanel(string Temptext) 
        { 
             CreateStartPanel(Temptext); 
        }

        internal  void CreateStartPanel(string level)
        {
            if(level == "简单")
            {
                list.Clear();
                list.Add(new StartPanel(SPanel.easy_1));
                list.Add(new StartPanel(SPanel.easy_2));
                list.Add(new StartPanel(SPanel.easy_3));          
            }
            else if(level =="中等")
            {
                list.Clear();
                list.Add(new StartPanel(SPanel.medial_1));
                list.Add(new StartPanel(SPanel.medial_2));
                list.Add(new StartPanel(SPanel.medial_3));
            }
            else
            {//困难
                list.Clear();
                list.Add(new StartPanel(SPanel.difficult_1));
                list.Add(new StartPanel(SPanel.difficult_2));
                list.Add(new StartPanel(SPanel.difficult_3));
            }
        }
    }
}
