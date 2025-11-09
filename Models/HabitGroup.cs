using System.Windows.Media.Imaging;

namespace HabbitFlow.Models
{
    class HabitGroup
    {
       public int Group_Id { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public string Group_Status { get; set; }
         public IconBitmapDecoder IconBitmapDecoder { get; set; }




    }
}
