using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml.Serialization;
using System.Timers;
using System.Diagnostics;

namespace LogNotifier
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer m_timer = new System.Timers.Timer(5000);
        private bool m_bRun = true;
        private Thread m_thread = null;
        private Dictionary<string, string> m_services = new Dictionary<string,string>();
        private AutoResetEvent m_finishedEvent = new AutoResetEvent(true);
        private string m_logfileName = string.Empty;
        string[] searchLinesInclude = null;
        string[] searchLinesExclude = null;
        int m_processed = 0;

        public Form1()
        {
            InitializeComponent();
            InitData();
            m_timer.AutoReset = false;
            m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
        }

        void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            labelProcessed.BackColor = SystemColors.Control;
            labelProcessed.ForeColor = SystemColors.ControlText;
        }

        private void InitData()
        {
            m_services.Add("AT&T", "cellnumber@txt.att.net");
            m_services.Add("Verizon", "cellnumber@vtext.com");
            m_services.Add("T-Mobile", "cellnumber@tmomail.net");
            m_services.Add("Sprint PCS", "cellnumber@messaging.sprintpcs.com");
            m_services.Add("Virgin Mobile", "cellnumber@vmobl.com");
            m_services.Add("US Cellular", "cellnumber@email.uscc.net");
            m_services.Add("Metro PCS", "cellnumber@mymetropcs.com");
            m_services.Add("Cricket", "cellnumber@sms.mycricket.com");
            m_services.Add("Nextel", "cellnumber@messaging.nextel.com");
            m_services.Add("Boost", "cellnumber@myboostmobile.com");
            m_services.Add("Alltel", "cellnumber@message.alltel.com");
            m_services.Add("Tracfone", "cellnumber@mmst5.tracfone.com");

            comboBoxService.Items.AddRange(m_services.Keys.ToArray());
            comboBoxService.SelectedItem = "Verizon";

            searchLinesInclude = GetTextBoxStringAsArray(ref textBoxFiltersInclude);
            searchLinesExclude = GetTextBoxStringAsArray(ref textBoxFiltersExclude);

            ColumnHeader dateHeader = new ColumnHeader 
            {
                Text = "Time",
                Width = 60
            };
            listViewSent.Columns.Add(dateHeader);
            ColumnHeader sentHeader = new ColumnHeader
            {
                Text = "Sent",
                Width = 40
            };
            listViewSent.Columns.Add(sentHeader);
            ColumnHeader matchHeader = new ColumnHeader
            {
                Text = "Subject",
                Width = 150
            };
            listViewSent.Columns.Add(matchHeader);
            ColumnHeader dataHeader = new ColumnHeader
            {
                Text = "Message",
                Width = 1000
            };
            listViewSent.Columns.Add(dataHeader);
            listViewSent.View = View.Details;

            checkBoxEnabled.Checked = true;
            checkBoxStopNotifications.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStatus("Stopped");
            SetProcessed();

            ReadConfigData();
        }

        private void SetProcessed(Color? colorBack = null, Color? colorText = null)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                labelProcessed.Text = "Processed: " + m_processed.ToString();
                labelProcessed.BackColor = colorBack.HasValue ? colorBack.Value : SystemColors.Control;
                labelProcessed.ForeColor = colorText.HasValue ? colorText.Value : SystemColors.ControlText;
            });
        }

        private void SetStatus(string status, Color? colorBack = null, Color? colorText = null)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                labelStatus.Text = "Status: " + status;
                labelStatus.BackColor = colorBack.HasValue ? colorBack.Value : SystemColors.Control;
                labelStatus.ForeColor = colorText.HasValue ? colorText.Value : SystemColors.ControlText;
            });
        }

        private void SetTitle(string fileName = default(string))
        {
            string title = "LogNotifier";
            if (m_processed > 0)
            {
                title += "(" + m_processed + ")";
            }

            this.Invoke((MethodInvoker)delegate()
            {
                Text = title + (!string.IsNullOrEmpty(fileName) ? (" - " + fileName) : String.Empty);
            });
        }

        private void SetButtonText(string text)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                buttonLogfile.Text = text;
            });
        }

        private bool CheckTextBox(ref TextBox textBox, bool numericOnly = false, int requiredLength = 0)
        {
            if ((textBox.Text == string.Empty) ||
                (numericOnly && !textBox.Text.All(Char.IsDigit)) ||
                ((requiredLength > 0) && (textBox.Text.Length != requiredLength)))
            {
                textBox.BackColor = Color.Yellow;
                return false;
            }

            textBox.BackColor = Color.White;
            return true;
        }

        private bool ValidateData()
        {
            if (!CheckTextBox(ref textBoxFiltersInclude))
            {
                return false;
            }

            if (checkBoxEnabled.Checked &&
                (!CheckTextBox(ref textBoxAccount) ||
                !CheckTextBox(ref textBoxPort) ||
                !CheckTextBox(ref textBoxServer) ||
                !CheckTextBox(ref textBoxPass) ||
                !CheckTextBox(ref textBoxCell, true, 10)))
            {
                tabControl.SelectTab("tabPageConfig");
                return false;
            }

            return true;
        }

        public void StartWatcher()
        {
            m_bRun = true;
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = m_logfileName;
            fsw.Changed += (s, e) => wh.Set();

            try
            {
                var fs = new FileStream(m_logfileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                fs.Seek(0, SeekOrigin.End);
                using (var sr = new StreamReader(fs))
                {
                    var s = "";
                    while (m_bRun == true)
                    {
                        s = sr.ReadLine();
                        if (s != null)
                        {
                            //Debug.WriteLine(s);
                            
                            foreach (string search in searchLinesInclude)
                            {
                                if (s.Contains(search) && !searchLinesExclude.Any(s.Contains))
                                {
                                    if (SendEmail(search, s))
                                    {
                                        m_processed++;
                                        SetProcessed(Color.Blue, Color.White);
                                        SetTitle(System.IO.Path.GetFileName(m_logfileName));
                                        m_timer.Enabled = true;
                                    }

                                    break;
                                }
                            }
                        }
                        else
                        {
                            wh.WaitOne(1000);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                SetStatus("Error processing file");
            }

            wh.Close();
            m_finishedEvent.Set();
        }

        public bool SendEmail(string textSubject, string textMessage)
        {
            Debug.WriteLine("Sending email:" + textMessage);
            string address = string.Empty;
            string fromPassword = string.Empty;
            string host = string.Empty;
            MailAddress fromAddress = null;
            bool enabled = true;
            bool stopNotifications = true;
            bool ret = true;
            int port = 0;

            this.Invoke((MethodInvoker)delegate()
            {
                address = m_services[comboBoxService.SelectedItem.ToString()];
                address = address.Replace("cellnumber", textBoxCell.Text);
                fromAddress = new MailAddress(textBoxAccount.Text, "LogNotifier");
                fromPassword = textBoxPass.Text;
                port = Convert.ToInt16(textBoxPort.Text);
                host = textBoxServer.Text;
                enabled = checkBoxEnabled.Checked;
                stopNotifications = checkBoxStopNotifications.Checked;
            });

            var toAddress = new MailAddress(address, address);

            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = textSubject;
            message.Body = textMessage.Length > 160 ? textMessage.Substring(0, 160) : textMessage;

            ListViewItem item = new ListViewItem(DateTime.Now.ToShortTimeString());

            try
            {
                if (enabled)
                {
                    smtp.Send(message);

                    if (stopNotifications)
                    {
                        ShutdownThread();
                    }

                    item.SubItems.Add("Yes");
                }
                else
                {
                    item.SubItems.Add("No");
                }

                item.SubItems.Add(textSubject);
                item.SubItems.Add(textMessage);
            }
            catch (System.Net.Mail.SmtpException e)
            {
                Debug.WriteLine(e.Message);
                ShutdownThread("Error sending message", Color.Maroon, Color.White);
                item.SubItems.Add("Err");
                item.SubItems.Add("Error sending message");
                item.SubItems.Add(e.Message);
                ret = false;
            }

            this.Invoke((MethodInvoker)delegate()
            {
                listViewSent.Items.Add(item);
                listViewSent.Items[listViewSent.Items.Count - 1].EnsureVisible();

                this.WindowState = FormWindowState.Normal;
                this.Activate();
            });

            return ret;
        }

        private bool LogfileSelection(ref string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Log Files (*.log)|*.log|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        private void ShutdownThread(string status = "Stopped", Color? backColor = null, Color? textColor = null)
        {
            m_bRun = false;
            if (!m_finishedEvent.WaitOne(10000))
            {
                m_thread.Abort();
            }
            m_thread = null;

            SetStatus(status, backColor, textColor);
            SetTitle();
            SetButtonText("<Select logfile>");
        }

        private void buttonLogfile_Click(object sender, EventArgs e)
        {
            if (m_thread == null)
            {
                if (!ValidateData())
                {
                    return;
                }

                if (!LogfileSelection(ref m_logfileName))
                {
                    return;
                }

                m_thread = new Thread(new ThreadStart(StartWatcher));
                m_thread.Start();
                
                SetStatus("Running", Color.YellowGreen, Color.Black);
                SetTitle(System.IO.Path.GetFileName(m_logfileName));
                SetButtonText("<Click to Stop>");
            }
            else
            {
                ShutdownThread();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutdownThread();
            WriteConfigData();
        }

        private string[] GetTextBoxStringAsArray(ref TextBox textBox)
        {
            return textBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void textBoxFilters_TextChanged(object sender, EventArgs e)
        {
            searchLinesInclude = GetTextBoxStringAsArray(ref textBoxFiltersInclude);
        }

        private void textBoxFiltersExclude_TextChanged(object sender, EventArgs e)
        {
            searchLinesExclude = GetTextBoxStringAsArray(ref textBoxFiltersExclude);
        }

        private void SetConfigData(LogNotifierDataSet dataSet)
        {
            if (dataSet == null)
            {
                return;
            }

            textBoxFiltersInclude.Text = String.Join(Environment.NewLine, dataSet.IncludeItems);
            textBoxFiltersExclude.Text = String.Join(Environment.NewLine, dataSet.ExcludeItems);

            textBoxAccount.Text = dataSet.EmailAccount;
            textBoxServer.Text = dataSet.EmailServer;
            textBoxPort.Text = dataSet.EmailPort;

            textBoxCell.Text = dataSet.CellNumber;
            comboBoxService.SelectedItem = dataSet.CellProvider;

            checkBoxEnabled.Checked = dataSet.Enabled;
            checkBoxStopNotifications.Checked = dataSet.StopNotifications;
        }

        LogNotifierDataSet GetConfigData()
        {
            LogNotifierDataSet dataSet = new LogNotifierDataSet();

            dataSet.IncludeItems = Enumerable.ToList(GetTextBoxStringAsArray(ref textBoxFiltersInclude));
            dataSet.ExcludeItems = Enumerable.ToList(GetTextBoxStringAsArray(ref textBoxFiltersExclude));

            dataSet.EmailAccount = textBoxAccount.Text;
            dataSet.EmailServer = textBoxServer.Text;
            dataSet.EmailPort = textBoxPort.Text;

            dataSet.CellNumber = textBoxCell.Text;
            dataSet.CellProvider = comboBoxService.SelectedItem.ToString();

            dataSet.Enabled = checkBoxEnabled.Checked;
            dataSet.StopNotifications = checkBoxStopNotifications.Checked;

            return dataSet;
        }

        private string GetConfigPath()
        {
            string path = "LogNotifier\\userSettings.xml";
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), path);
        }

        private void ReadConfigData()
        {
            string fileName = GetConfigPath();

            try
            {
                FileStream ReadFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlSerializer SerializerObj = new XmlSerializer(typeof(LogNotifierDataSet));
                LogNotifierDataSet loadedData = (LogNotifierDataSet)SerializerObj.Deserialize(ReadFileStream);

                SetConfigData(loadedData);

                ReadFileStream.Close();
            }
            catch (Exception e)
            {
                SetConfigData(null);
                System.Diagnostics.Trace.WriteLine(e.ToString());
            }
        }

        private void WriteConfigData()
        {
            string fileName = GetConfigPath();

            try
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileName));
                TextWriter WriteFileStream = new StreamWriter(fileName, false);
                XmlSerializer SerializerObj = new XmlSerializer(typeof(LogNotifierDataSet));

                LogNotifierDataSet set = GetConfigData();
                SerializerObj.Serialize(WriteFileStream, set);

                WriteFileStream.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.ToString());
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewSent.Items.Clear();
            m_processed=0;
            SetProcessed();

            if (m_bRun)
            {
                SetTitle(System.IO.Path.GetFileName(m_logfileName));
            }
            else
            {
                SetTitle();
            }
        }
    }
}
