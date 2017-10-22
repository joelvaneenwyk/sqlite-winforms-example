using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlite_winforms_example
{
    public partial class Form1 : Form
    {
        private SqLiteDatabase _database;

        public Form1()
        {
            InitializeComponent();

            this._database = new SqLiteDatabase();
        }
    }
}
