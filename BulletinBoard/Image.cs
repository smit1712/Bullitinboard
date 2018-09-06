using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class Image : Message
    {

        string[] IMcomputer = { ".--.", "|__| .-------.", "|=.| |.-----.|", "|--| || KCK ||", "|  | |'-----'|", "|__|~')_____('" };
        string[] IMsmiley = { "    _____  ", "  .'     '.", " /  o   o  \\ ", "|           |","|  \\     /  |", " \\  '---'  /", "  '._____.'" };
        public Image(string MsgName, string pstname, string IM, string tag) : base( MsgName, pstname, IM,  tag)
        {
            
                
        }
        public string[] GetImage()
        {
            switch (MessageText)
            {
                case "computer":
                    return IMcomputer;
                case "smiley":
                    return IMsmiley;
               
            }
            return null;
        }
       
    }
}
