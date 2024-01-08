using System.Text;

namespace SP8_Dz_02._09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void appendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    textBox2.Text += text;
                });
            }
            else
            {
                textBox2.Text += text;
            }
        }
        public void CountWords(string text)
        {
            string[] words = text.Split(' ', '\r');
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Count of words: {words.Length}");
            appendText(sb.ToString());
        }
        public void CountSymbols(string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Count of symbols: {text.Length}");
            appendText(sb.ToString());
        }
        public void CountSentences(string text)
        {
            string[] words = text.Split(' ', '\r');
            int sentencesCount = 0;
            int exclamationsCount = 0;
            int questionsCount = 0;

            foreach (string word in words)
            {
                switch (word[word.Length - 1])
                {
                    case '.':
                        sentencesCount++;
                        break;
                    case '!':
                        sentencesCount++;
                        exclamationsCount++;
                        break;
                    case '?':
                        sentencesCount++;
                        questionsCount++;
                        break;
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Count of sentences: {sentencesCount}");
            sb.AppendLine($"Count of questions: {questionsCount}");
            sb.AppendLine($"Count of exclamations: {exclamationsCount}");
            appendText(sb.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            textBox2.Text = "";
            //Task task = new Task((object? obj) =>
            //{
            //    string text = obj.ToString();
            //    string[] words = text.Split(' ', '\r');
            //    int sentencesCount = 0;
            //    int exclamationsCount = 0;
            //    int questionsCount = 0;

            //    foreach (string word in words)
            //    {
            //        switch (word[word.Length - 1])
            //        {
            //            case '.':
            //                sentencesCount++;
            //                break;
            //            case '!':
            //                sentencesCount++;
            //                exclamationsCount++;
            //                break;
            //            case '?':
            //                sentencesCount++;
            //                questionsCount++;
            //                break;
            //        }
            //    }
            //    int symbolsCount = text.Length;
            //    int wordsCount = words.Length;
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine($"Count of sentences: {sentencesCount}");
            //    sb.AppendLine($"Count of symbols: {symbolsCount}");
            //    sb.AppendLine($"Count of words: {wordsCount}");
            //    sb.AppendLine($"Count of questions: {questionsCount}");
            //    sb.AppendLine($"Count of exclamations: {exclamationsCount}");
            //    if (InvokeRequired)
            //    {
            //        Invoke(() =>
            //        {
            //            textBox2.Text = sb.ToString();
            //        });
            //    }
            //    else
            //    {
            //        textBox2.Text = sb.ToString();
            //    }

            //}, text);
            //task.Start();
            //task.Wait();
            
            
            if(text!=String.Empty)
            {
                if (checkBox1.Checked)
                {
                    Task task2 = new Task(() => CountWords(text));
                    task2.Start();

                }
                if (checkBox2.Checked)
                {
                    Task task = new Task(() => CountSymbols(text));
                    task.Start();
                }
                if (checkBox3.Checked)
                {
                    Task task3 = new Task(() => CountSentences(text));
                    task3.Start();
                }
            }
            
        }
    }
}
