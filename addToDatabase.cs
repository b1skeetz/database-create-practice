using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace database
{
    
    public partial class addToDatabase : Form
    {
        FirestoreDb Database;
        public addToDatabase()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addDoc();
            this.Close();
        }

        void addDoc()
        {
            DocumentReference doc = Database.Collection("Book").Document(textB_Name.Text);
            Dictionary<string, object> dict1 = new Dictionary<string, object>()
            {
                {"Material", textB_Material.Text },
                {"Address", textB_Address.Text },
                {"Age", textB_Age.Text },
                {"Country", textB_Country.Text },
                {"Education", textB_Education.Text },
            };
            doc.SetAsync(dict1);
        }

        private void addToDatabase_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "mynewdb-ae79c-firebase-adminsdk-qrv3p-df49d02dae.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            Database = FirestoreDb.Create("mynewdb-ae79c");
        }
    }
}
