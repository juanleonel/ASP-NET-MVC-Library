using Library.Domain.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Desk
{
    public partial class Form1 : Form
    {
        
        #region Dependencias

        private BookDA _bookDA;
        private BookDA BookDA
        {
            get { return _bookDA ?? (_bookDA = new BookDA()); }
        }

        #endregion 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BookDA.Inicialize();
        }
    }
}
