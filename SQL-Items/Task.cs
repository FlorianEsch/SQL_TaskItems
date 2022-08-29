using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowSQL
{
    class Task
    {
       
       /* drink 
        eat
        work
        chill
        tired
        move*/
        public string Name { get; set; }
        public string Time { get; set; }
        public DateTime dateTime { get; set; }
        public string Image { get; set; }

        public Task(string name, string date, string image)
        {
            this.Name = name;
            this.Time = date;
            this.Image = image;


            this.dateTime = DateTime.Parse(date);
        }
        //public List<TaskView> Tasks { get; set; }


    }
}
