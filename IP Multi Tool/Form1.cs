using HtmlAgilityPack;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Net.NetworkInformation;
using System.Diagnostics;
using IP_Multi_Tool.Class;
using RestSharp;
using Newtonsoft.Json.Linq;
using DiscordRPC;
using EvilKnightAIO.Miscs;

namespace IP_Multi_Tool
{
    
    public partial class Form1 : Form
    {
        HtmlWeb web = new HtmlWeb();

        private string ip;

        HttpRequest httpRequest = new HttpRequest();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RPC.rpctimestamp = Timestamps.Now;
            RPC.InitializeRPC();

            panel_lookup.Visible = true;
            panel_velocidad.Visible = false;
            panel_number.Visible = false;

        }

       
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if(panel_lookup.Visible == true)
                {
                    ip = guna2TextBox1.Text.ToString();
                    httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    httpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
                    httpRequest.AddHeader("Accept-Language", "es-ES,es;q=0.9");
                    httpRequest.AddHeader("Cache-Control", "max-age=0");
                    httpRequest.AddHeader("Connection", "keep-alive");
                    httpRequest.AddHeader("Host", "ip-api.com");
                    httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
                    httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36").ToString();
                    var source = httpRequest.Get($"http://ip-api.com/json/{ip}");
                    string source1 = source.ToString();
                    var status = this.Parse(source1, "\"status\":\"", "\",\"");
                    var country = this.Parse(source1, "\"country\":\"", "\",\"");
                    var countryCode = this.Parse(source1, "\"countryCode\":\"", "\",\"");
                    var region = this.Parse(source1, "\"region\":\"", "\",\"");
                    var regionName = this.Parse(source1, "\"regionName\":\"", "\",\"");
                    var city = this.Parse(source1, "\"city\":\"", "\",\"");
                    var zip = this.Parse(source1, ",\"zip\":\"", "\",\"");
                    var lat = this.Parse(source1, "\"lat\":", ",\"");
                    var lon = this.Parse(source1, "\"lon\":", ",\"");
                    var timeZone = this.Parse(source1, "\"timezone\":\"", "\",\"");
                    var isp = this.Parse(source1, "\"isp\":\"", "\",\"");
                    var org = this.Parse(source1, "\"org\":\"", "\",\"");
                    var _as = this.Parse(source1, "\"as\":\"", "\",\"");
                    var query = this.Parse(source1, "\"query\":\"", "\"}");
                    //TODO:
                    //Pendiente abajo
                    lb_CountryName.Text = "";
                    lb_status.Text = status.ToString();
                    lb_Country.Text = country.ToString();
                    lb_CountryCode.Text = countryCode.ToString();
                    lb_Region.Text = region.ToString();
                    lb_RegionName.Text = regionName.ToString();
                    lb_City.Text = city.ToString();
                    lb_Zip.Text = zip.ToString();
                    lb_Lat.Text = lat.ToString();
                    lb_Lon.Text = lon.ToString();
                    lb_TimeZone.Text = timeZone.ToString();
                    lb_ISP.Text = isp.ToString();
                    lb_Org.Text = org.ToString();
                    lb_As.Text = _as.ToString();
                    lb_Query.Text = query.ToString();
                }
                else if(panel_velocidad.Visible == true)
                {
                    Ping ping1 = new Ping();
                    PingReply reply = ping1.Send(txt_ip.Text, 1000);
                    lb_Ping.Text = reply.Status.ToString();
                }
                else if(panel_number.Visible == true)
                {
                    var client = new RestClient($"https://api.apilayer.com/number_verification/validate?number={txtNumber.Text}");
                    client.Timeout = -1;

                    var request = new RestRequest(Method.GET);
                    request.AddHeader("apikey", "qe2hX5I8Zx2XNvECyumHOqcs1QCT5P5v");

                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);

                    var status = JSON(response.Content, "valid").FirstOrDefault();
                    var number = JSON(response.Content, "number").FirstOrDefault();
                    var local_format = JSON(response.Content, "local_format").FirstOrDefault();
                    var international_format = JSON(response.Content, "international_format").FirstOrDefault();
                    var country_prefix = JSON(response.Content, "country_prefix").FirstOrDefault();
                    var country_code = JSON(response.Content, "country_code").FirstOrDefault();
                    var country_name = JSON(response.Content, "country_name").FirstOrDefault();
                    var location = JSON(response.Content, "location").FirstOrDefault();
                    var carrier = JSON(response.Content, "carrier").FirstOrDefault();
                    var line_type = JSON(response.Content, "line_type").FirstOrDefault();

                    lb_statusN.Text = status.ToString();
                    lb_Number.Text = number.ToString();
                    lb_LocalFormat.Text = local_format.ToString();
                    lb_InternationalFormat.Text = international_format.ToString();
                    lb_CountryPrefix.Text = country_prefix.ToString();
                    lb_CountryC0deA.Text = country_code.ToString();
                    lb_CountryName.Text = country_name.ToString();
                    lb_Location.Text = location.ToString();
                    lb_Carrier.Text = carrier.ToString();
                    lb_LineType.Text = line_type.ToString();
  
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show("Error 0 | Caracteres Incorrectos");
            }
        }

        private string Parse(string source, string left, string right)
        {
            return source.Split(new string[]
            {
                left
            }, StringSplitOptions.None)[1].Split(new string[]
            {
                right
            }, StringSplitOptions.None)[0];
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel_lookup.Visible = true;
            panel_velocidad.Visible = false;
            panel_number.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel_lookup.Visible = false;
            panel_velocidad.Visible = true;
            panel_number.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel_lookup.Visible = false;
            panel_velocidad.Visible = false;
            panel_number.Visible = true;
        }

        public static IEnumerable<string> JSON(string input, string field, bool recursive = false, bool useJToken = false)
        {
            var list = new List<string>();

            if (useJToken)
            {
                if (recursive)
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                }
                else
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                }
            }
            else
            {
                var jsonlist = new List<KeyValuePair<string, string>>();
                parseJSON("", input, jsonlist);
                foreach (var j in jsonlist)
                    if (j.Key == field)
                        list.Add(j.Value);

                if (!recursive && list.Count > 1) list = new List<string>() { list.First() };
            }

            return list;
        }

        internal static object LR(string text0, string v)
        {
            throw new NotImplementedException();
        }

        private static void parseJSON(string A, string B, List<KeyValuePair<string, string>> jsonlist)
        {
            jsonlist.Add(new KeyValuePair<string, string>(A, B));

            if (B.StartsWith("["))
            {
                JArray arr = null;
                try { arr = JArray.Parse(B); } catch { return; }

                foreach (var i in arr.Children())
                    parseJSON("", i.ToString(), jsonlist);
            }

            if (B.Contains("{"))
            {
                JObject obj = null;
                try { obj = JObject.Parse(B); } catch { return; }

                foreach (var o in obj)
                    parseJSON(o.Key, o.Value.ToString(), jsonlist);
            }
        }

        private void panel_number_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
