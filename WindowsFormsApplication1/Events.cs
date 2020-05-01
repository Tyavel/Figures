using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Events
    {
        public void EventControl() //Метод события 1
        {
            MessageBox.Show("Кофе готов", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
