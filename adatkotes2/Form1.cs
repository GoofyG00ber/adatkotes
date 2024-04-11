using System.ComponentModel;

namespace adatkotes2
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
        }

        private void buttonBE_Click(object sender, EventArgs e)
        {
            StreamReader be = new("european_countries.csv");
            string sor = be.ReadLine() ?? string.Empty;
            while (!be.EndOfStream)
            {
                sor = be.ReadLine() ?? string.Empty;
                string[] sortomb = sor.Split(',');

                CountryData c = new CountryData();
                c.Name = sortomb[0];
                c.Population = Convert.ToInt32(sortomb[1]);
                c.AreaInSquareKm = Convert.ToInt32(sortomb[2]);
                countryList.Add(c);
            }
            be.Close();
            buttonBE.Enabled = false;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            countryDataBindingSource.RemoveCurrent();
        }

        private void buttonEDIT_Click(object sender, EventArgs e)
        {
            FormCountryEdit fce = new FormCountryEdit();
            fce.CountryData = countryDataBindingSource.Current as CountryData;
            fce.ShowDialog();
        }

        private void buttonMentes_Click(object sender, EventArgs e)
        {
            StreamWriter ki = new("countries.csv");
            foreach (var item in countryList)
            {
                ki.WriteLine(item.Name+' '+item.Population+' '+item.AreaInSquareKm);
            }
            ki.Close();
        }
    }
}