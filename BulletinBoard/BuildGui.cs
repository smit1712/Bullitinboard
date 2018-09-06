using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class BuildGui
    {        
        User Currentuser;

        
        public BuildGui(User usr)
        {
            Currentuser = usr;
        } 
        public void Updatescreen(string selboard, string curuser, string status)
        {
            Console.Clear();
            Console.WriteLine(Linebuider("//",""));
            Console.WriteLine(Linebuider("[]", curuser));
            Console.WriteLine(Linebuider("//", selboard));
        }
        
     
        
        public void Showboards(List<Board> brdlist)
        {
            foreach (Board brd in brdlist)
            {
                Board tempboard = brd;
                Console.WriteLine(Linebuider("<>", ""));
                Console.WriteLine(brd.GetName());
                Console.WriteLine(Linebuider("><", ""));
                foreach (string tag in tempboard.Gettags())
                {
                   
                    Console.WriteLine(Linebuider(")(", tag));

                }
            }
        }
        public void Showposts(Board brd)
        {
            foreach (Message msg in brd.GetMessages())
            {
                Message tempmsg = msg;
                Console.WriteLine(Linebuider("-=", ""));
                Console.WriteLine(msg.Getname());
                foreach (string tag in tempmsg.GetTags())
                {
                    Console.WriteLine(Linebuider("_", tag));
                }
                Console.WriteLine(Linebuider("-=", ""));

            }
        }
        public void Showimage(Board brd)
        {
            foreach (Image img in brd.Getimages())
            {
                Image tempimg = img;
                Console.WriteLine(Linebuider("-=", ""));
                Console.WriteLine(img.Getname());
                foreach (string tag in tempimg.GetTags())
                {           
                    Console.WriteLine(Linebuider("_", tag));
                }
                Console.WriteLine(Linebuider("-=", ""));

            }
        }
        private string Linebuider(string Chr,string linestring)
        {
            
            int WindowWidth = Console.WindowWidth;
            WindowWidth = WindowWidth / Chr.Length;
            string result = "";
            int Linesize = WindowWidth - (linestring.Length/2) -1;
            while (Linesize >= 0)
            {
                if(Linesize == WindowWidth / 2)
                {
                    result = result + linestring;
                }
                result = result + Chr;
                Linesize--;

            }
            return(result);
        }
    }
}
