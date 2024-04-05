using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ValutaHTTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] currencies = { "USD", "EUR", "BIT" };
            comboBox1.Items.AddRange(currencies);

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string selectedCurrency = comboBox1.SelectedItem as string;
            if (selectedCurrency == null)
            {
                MessageBox.Show("Выберите валюту");
                return;
            }
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage message = new HttpRequestMessage())
                {
                    message.Method = HttpMethod.Get;
                    message.RequestUri = new Uri("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
                    HttpResponseMessage resp = await httpClient.SendAsync(message);
                    string body = await resp.Content.ReadAsStringAsync();
                    List<CurrencyItem> items = JsonSerializer.Deserialize<List<CurrencyItem>>(body);
                    List<CurrencyItem> filteredItems = items.Where(items => items.Ccy == selectedCurrency).ToList();
                    listBox1.DataSource = null;
                    listBox1.DataSource = filteredItems;
                    listBox1.DisplayMember = nameof(CurrencyItem.Description);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
        }
    }
}