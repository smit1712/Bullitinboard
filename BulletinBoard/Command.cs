using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class Command
    {
        User currentuser;
        BuildGui Guibuilder;
        List<Board> boardslist;
        public Command(User crtuser, List<Board> brdlist)
        {
            currentuser = crtuser;
            Guibuilder = new BuildGui(currentuser);
            boardslist = brdlist;
        }

        public Board Newboard(User Currentuser)
        {
            if (Currentuser.Isadmin)
            {
                Console.Write("BoardName:");
                string boardname = Console.ReadLine();
                return Currentuser.NewBoard(boardname);

            }
            else
            {
                Console.WriteLine("No Permission to make a new board");
                return null;
            }

        }
        public void showboard()
        {
            Guibuilder.Showboards(boardslist);
            Console.ReadLine();
        }
        public Board selectboard(List<Board> brdlist)
        {
            Guibuilder.Showboards(brdlist);
            Console.WriteLine("Select board: ");
            currentuser.Selectboard(Console.ReadLine(), brdlist);
            return currentuser.Getselectedboard();


        }
        public Message Newpost()
        {
            if (currentuser.Getselectedboard() != null)
            {
                Console.WriteLine("Write Postname:");
                string msgname = Console.ReadLine();
                Console.WriteLine("Write Message to post on:" + currentuser.Getselectedboard().GetName());
                string msgttext = Console.ReadLine();
                Console.WriteLine("Write Tag to add to post");
                string msgtag = Console.ReadLine();
                return currentuser.Getselectedboard().Newmessage(msgname, currentuser.GetUsername(), msgttext, msgtag);

            }
            else return null;

        }
        public void addtag(Board selectedboard)
        {
            Guibuilder.Showposts(selectedboard);
            Console.WriteLine("Choose message to add tag:");
            string selectedmessage = Console.ReadLine();
            foreach(Message msg in selectedboard.GetMessages())
            {
                if (msg.Getname() == selectedmessage)
                {
                    Console.WriteLine("Write tag to add to:" + msg.Getname());
                    msg.AddTag(Console.ReadLine());
                }
            }
        }
        public void showposts(Board selectedboard)
        {
            Guibuilder.Showposts(selectedboard);
            Console.ReadKey();
        }
        public void PostImage(Board selectedboard)
        {
            Console.WriteLine("Write Image name:"); 
            string imagename = Console.ReadLine();
            int count = 0;
            foreach(string[] img in selectedboard.GetAllImages())
            {
                Console.WriteLine(selectedboard.GetImageNames()[count]);
                count++;
                foreach (string str in img)
                {
                    Console.WriteLine(str);
                }

            }
            Console.WriteLine("Select Image:");
            string IM = Console.ReadLine();
            Console.WriteLine("Write Tag to add to the image:");
            string tag = Console.ReadLine();
            Image newimage = new Image(imagename, currentuser.GetUsername(), IM, tag);
            selectedboard.AddImage(newimage);
            Console.WriteLine("The Image has been posted");
        }
        public void showimage(Board selectedboard)
        {
            Guibuilder.Showimage(selectedboard);
            Console.ReadKey();
        }
        public void readimage(Board selectedboard)
        {
            foreach (Image img in selectedboard.Getimages())
            {
                Console.WriteLine(img.Getname());
            }
            Console.WriteLine("Select image to show:");
            string imgname = Console.ReadLine();
            foreach(Image img in selectedboard.Getimages())
            {
                if(imgname == img.Getname())
                {
                    int count = 0;
                    foreach(string str in img.GetImage())
                    {
                        Console.WriteLine(img.GetImage()[count]);
                        count++;
                    }
                }

            }
            Console.ReadKey();
        }
        public void readpost(Board selectedboard)
        {
            showposts(selectedboard);
            Console.WriteLine("Select post to read:");
            string selectpost = Console.ReadLine();
            foreach (Message msg in selectedboard.GetMessages())
            {
                if (msg.Getname() == selectpost)
                {
                    Console.WriteLine(msg.GetMessage());
                    Console.ReadKey();
                }
            }
        }
        public User Newuser()
        {
            if (currentuser.Isadmin)
            {
                Console.WriteLine("New username:");
                string username = Console.ReadLine();
                Console.WriteLine("New password");
                string password = Console.ReadLine();
                User newuser = new User(username, password);

                Console.WriteLine("User has been created");
                Console.ReadKey();
                return newuser;
            }
            else
            {
                Console.WriteLine("No permission to make new user");
                Console.ReadKey();
                return null;
            }

        }
        public User switchuser(List<User> userlist)
        {
            Console.WriteLine("Choose other user");
            string nextuser = Console.ReadLine();
            foreach (User usr in userlist)
            {
                if (usr.GetUsername() == nextuser)
                {
                    Console.WriteLine("What is the password");
                    string password = Console.ReadLine();
                    if (usr.GetUsername() == nextuser && usr.GetPassword() == password)
                    {
                        Console.WriteLine("Switched to:" + currentuser.GetUsername());
                        currentuser = usr;
                        return currentuser;
                    }
                    else
                    {
                        Console.WriteLine("wrong password!");
                        return currentuser;
                    }

                }

            }

            Console.WriteLine("That user doen't exist!");
            return currentuser;
        }
        public void help()
        {
            Console.WriteLine("new board: ADMIN ONLY");
            Console.WriteLine("show board: Shows all boards");
            Console.WriteLine("select board: select the board you want to join");
            Console.WriteLine("new post: Post a message to the selected board");
            Console.WriteLine("add tag: adds an additional tag to an existing message");
            Console.WriteLine("show posts: show all posted posts");
            Console.WriteLine("read post: select and read that post");
            Console.WriteLine("new user: ADMIN ONLY");
            Console.WriteLine("switch user: used to switch users");
            Console.WriteLine("post image: post one of the availible images");
            Console.WriteLine("show image: show all posted images");
            Console.WriteLine("read image: open selected image");
            Console.WriteLine("help: shows all commands");
            Console.ReadKey();
        }
    }
}
