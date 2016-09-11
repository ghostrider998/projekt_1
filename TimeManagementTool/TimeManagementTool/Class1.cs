using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeManagementTool
{
    public class task
    {
        private bool priority, urgency, done;
        private string name, deskription;

        public task(bool priority,bool urgency,string name,string deskription)
        {
            this.priority = priority;
            this.deskription = deskription;
            this.name = name;
            this.urgency = urgency;
        }
        public bool Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public bool Urgency
        {
            get { return urgency; }
            set { urgency = value; }
        }
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Deskription
        {
            get { return deskription; }
            set { deskription = value; }
        }
    }
    public class timeManagement
    {
        List<task> tasks = new List<task>();

        public void initialyse()
        {

            StreamReader read = new StreamReader("Path to csv file");
            
            while(true)
            {
                
                if(read.ReadLine() != null)
                {
                    string[] splitSave = read.ReadLine().Split(';');        // Fix order of the file =name;deskription;high/low(priority);high/low(urgency)
                    bool urgency, priority;
                    if (splitSave[2].ToLower() == "high")
                        priority = true;
                    else
                        priority = false;

                    if (splitSave[3].ToLower() == "high")
                        urgency = true;
                    else
                        urgency = false;
                    
                }


            }
        }

    }
}
