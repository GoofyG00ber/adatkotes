using System.ComponentModel;

namespace adatkotes
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            countryDataBindingSource.DataSource = countryList;

            CountryData mo = new CountryData();
            mo.Name = "Magyarország";
            mo.Population = 9500000;

            countryList.Add(mo);
            //   countryList.Add();
        }
    }
}