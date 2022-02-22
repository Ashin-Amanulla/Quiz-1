using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Library.Models
{
    public class QuestionViewDto
    {
        public int Id { get; set; }
        public string type { get; set; }
        public Image Image { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public string CurrentChoice { get; set; }
        public string CorrectChoice { get; set; }
        public int RadioButtonIndex { get; set; }
        public Bitmap ResultImage { get; set; }
    }
}
