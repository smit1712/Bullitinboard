using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class Program
    {
        public List<User> userlist = new List<User>();
        public List<Board> Boardlist = new List<Board>();
        Board selectedboard;
        User Currentuser = new User("admin", "root");
        Command Docommand;
        BuildGui Guibuilder;
        string selecboard = "";

        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.Docommand = new Command(prg.Currentuser, prg.Boardlist);
            prg.Guibuilder = new BuildGui(prg.Currentuser);
            prg.Currentuser.Isadmin = true;
            

            while (1 == 1)
            {
                prg.Guibuilder.Updatescreen(prg.selecboard,prg.Currentuser.GetUsername(),"STATUS");
                prg.Commands(Console.ReadLine());

            }
        }

        public void Commands(string Command)
        {
            switch (Command)
            {
                case "new board":
                    Boardlist.Add(Docommand.Newboard(Currentuser));
                    break;
                case "show board":
                    Docommand.showboard();                    
                    break;
                case "select board":
                    selectedboard = Docommand.selectboard(Boardlist);
                    selecboard = selectedboard.GetName();
                    break;
                case "new post":
                    selectedboard.Addmassage(Docommand.Newpost());
                    break;
                case "add tag":
                    Docommand.addtag(selectedboard);
                    break;
                case "show posts":
                    Docommand.showposts(selectedboard);
                    break;
                case "read post":
                    Docommand.readpost(selectedboard);
                    break;
                case "new user":
                    userlist.Add(Docommand.Newuser());
                        break;
                case "switch user":
                    userlist.Add(Currentuser);
                    Currentuser = Docommand.switchuser(userlist);
                    break;
                case "post image":
                    Docommand.PostImage(selectedboard);
                    break;
                case "show image":
                    Docommand.showimage(selectedboard);
                    break;
                case "read image":
                    Docommand.readimage(selectedboard);
                    break;
                case "help":
                    Docommand.help();
                    break;
                    
            };
            System.Threading.Thread.Sleep(100);
            
        }
    }
}
