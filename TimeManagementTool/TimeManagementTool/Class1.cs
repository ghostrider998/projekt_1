using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeManagementTool
{

    public class task                                //declares what variables a task has                                                           
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
    public class timeManagement                      // contains task-list 
    {
        protected List<task> tasks = new List<task>();
        //public List<task> Tasks
        //   {
        //    get { return tasks; }
        //    set { tasks = value; }
        //    }

        public void initialyse()                                        //Reads the infomation from a csv-file and saves it into a task-list
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
                    tasks.Add(new task(priority, urgency, splitSave[0], splitSave[1]));
                    
                }


            }
        }

    }                   
    public class input : timeManagement             // interface
    {
        public void sort(List<task> A, List<task> B, List<task> C, List<task> D)                        //sorts the task in the 4 sections and wirtes them
        {
            
            for (int i = 0; i < tasks.Count; i++)           //A
            {
                if (tasks[i].Priority == true)
                {
                    if (tasks[i].Urgency == true)
                    {
                        A.Add(tasks[i]);                
                    }
                }
            }

            for (int i = 0; i < tasks.Count; i++)           //B
            {
                if (tasks[i].Priority == true)
                {
                    if (tasks[i].Urgency == false)
                    {
                        B.Add(tasks[i]);                                                                             
                    }
                }
            }

            for (int i = 0; i < tasks.Count; i++)           //C
            {
                if (tasks[i].Priority == false)
                {
                    if (tasks[i].Urgency == true)
                    {
                        C.Add(tasks[i]); 
                    }
                }
            }

            for (int i = 0; i < tasks.Count; i++)           //D
            {
                if (tasks[i].Priority == false)
                {
                    if (tasks[i].Urgency == false)
                    {
                        D.Add(tasks[i]); 
                    }
                }
            }
        }                       

        public void mark_done(task tasktodone)                       //marks the selected task as done
        {
           tasktodone.Done = true;
        }

        public void clearList()                         //deletes everything in the list
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i] = null;
            }
        }

    }
}
