using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace win_tuc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string StripText(string title)
        {
            string input = title.Trim().ToLower();
            string tmp = input.Replace("ą", "a");
            tmp = tmp.Replace("ć", "c");
            tmp = tmp.Replace("ę", "e");
            tmp = tmp.Replace("ł", "l");
            tmp = tmp.Replace("ń", "n");
            tmp = tmp.Replace("ó", "o");
            tmp = tmp.Replace("ś", "s");
            tmp = tmp.Replace("ź", "z");
            tmp = tmp.Replace("ż", "z");
            string output = tmp.Replace(" ", "-");
            return output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //a = int.Parse(Name.Text);
            //b = int.Parse(FName.Text);
            string lname = Name.Text;
            string fname = FName.Text;
            string login = lname + "." + fname;
            string loginnopl = StripText(login);
            string lowlogin = loginnopl.ToLower();

            LoginG.AppendText(lowlogin);

            string mailadr = loginnopl + "@taurus-ochrona.pl";

            Email.AppendText(mailadr);

            var chars = "abcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var stringchars = new Char[3];
            var stringnumbers = new Char[3];
            var random = new Random();

            for (int i = 0; i < stringchars.Length; i++)
            {
                stringchars[i] = chars[random.Next(chars.Length)];
            }
            var stringcharsfinal = new String(stringchars);

            for (int j = 0; j < stringnumbers.Length; j++)
            {
                stringnumbers[j] = numbers[random.Next(numbers.Length)];
            }
            var stringnumbersfinal = new String(stringnumbers);

            char zf = stringcharsfinal[0];
            char zs = stringcharsfinal[1];
            char zt = stringcharsfinal[2];
            char lf = stringnumbersfinal[0];
            char ls = stringnumbersfinal[1];
            char lt = stringnumbersfinal[2];
            string pass = zf.ToString() + lf.ToString() + zs.ToString() + ls.ToString() + zt.ToString() + lt.ToString();

            PassE.AppendText(pass);

            string sso = "'" + lowlogin + ":" + pass + "' => array(\n    'uid' => array('" + lowlogin + "'),\n    'eduPersonAffiliation' => array('" + lowlogin + "')\n),";

            SSO.AppendText(sso);

            string firstn = fname.Substring(0, 1);
            string firstl = lname.Substring(0, 2);
            string enovalogin = firstl.ToUpper() + firstn.ToUpper();

            LoginEn.AppendText(enovalogin);

            string enovapass = PassD.Text;

            PassEn.AppendText(enovapass);


            //MessageBox.Show(lowlogin);
        }

        
    }
    
}
