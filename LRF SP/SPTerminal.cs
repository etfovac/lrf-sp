/* Project:    LRF Serial RS-232 COM Port
 *  
 */

#region Using namespaces
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using SerialPortTerminal.Properties;
using System.Threading;
using System.IO;
#endregion

namespace SerialPortTerminal
{
  #region Public Enumerations
  public enum DataMode { Text, Hex }
  public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
  #endregion

  public partial class SPT : Form
  {
    #region Local Variables

    // The main control for communicating through the RS-232 port
    private readonly SerialPort comport = new SerialPort();
    // Various colors for logging info
    private readonly Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
	private readonly Settings settings = Settings.Default;
    private readonly byte[] LRF_ans = new byte[12];
    private int R_min = 81; // unset R_min returns 80, so 81 is min.

    #endregion

    #region Constructor
    public SPT()
    {
		// Load user settings
		settings.Reload();

        // Build the form
        InitializeComponent();

        // Restore the users settings
        InitializeControlValues();

        // Enable/disable controls based on the current state
        EnableControls();

        comport.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived); // When data is received, add new event
        comport.PinChanged += new SerialPinChangedEventHandler(Comport_PinChanged);
    }

	void Comport_PinChanged(object sender, SerialPinChangedEventArgs e)
		{
			// Show the state of the pins
			UpdatePinState();
		}

	private void UpdatePinState()
		{
			this.Invoke(new ThreadStart(() => {
				// Show the state of the pins
				chkCD.Checked = comport.CDHolding;
				chkCTS.Checked = comport.CtsHolding;
				chkDSR.Checked = comport.DsrHolding;
			}));
		}
    #endregion

    #region Local Methods
    
    /// <summary> Save the user's settings. </summary>
    private void SaveSettings()
    {
		settings.BaudRate = int.Parse(cmbBaudRate.Text);
		settings.DataBits = int.Parse(cmbDataBits.Text);
		settings.DataMode = CurrentDataMode;
		settings.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
		settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
		settings.PortName = cmbPortName.Text;
		settings.ClearOnOpen = chkClearOnOpen.Checked;
		settings.ClearWithDTR = chkClearWithDTR.Checked;

		settings.Save();
    }

    /// <summary> Populate the form's controls with default settings. </summary>
    private void InitializeControlValues()
    {
      cmbParity.Items.Clear(); cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
      cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

	  cmbParity.Text = settings.Parity.ToString();
	  cmbStopBits.Text = settings.StopBits.ToString();
	  cmbDataBits.Text = settings.DataBits.ToString();
	  cmbParity.Text = settings.Parity.ToString();
	  cmbBaudRate.Text = settings.BaudRate.ToString();
	  CurrentDataMode = settings.DataMode;
      RefreshComPortList();
      chkClearOnOpen.Checked = settings.ClearOnOpen;
      chkClearWithDTR.Checked = settings.ClearWithDTR;

	  // select the last com port used
	  if (cmbPortName.Items.Contains(settings.PortName)) cmbPortName.Text = settings.PortName;
      else if (cmbPortName.Items.Count > 0) cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1;
      else
      {
        MessageBox.Show(this, "There are no COM Ports detected on this computer.\n", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
      }
    }

    /// <summary> Enable/disable controls based on the app's current state. </summary>
    private void EnableControls()
    {
      // Enable/disable controls based on whether the port is open or not
      gbPortSettings.Enabled = !comport.IsOpen;
      txtSendData.Enabled = btnSend.Enabled = comport.IsOpen;

      groupBoxLRF.Enabled = comport.IsOpen;
	  //chkDTR.Enabled = chkRTS.Enabled = comport.IsOpen;

      if (comport.IsOpen)
      {
          btnOpenPort.Text = "&Close Port";
      }
      else  
      {
          btnOpenPort.Text = "&Open Port";
      };
    }

    /// <summary> Send the user's data currently entered in the 'send' box.</summary>
    private void SendData()
    {
      if (CurrentDataMode == DataMode.Text)
      {
        // Send the user's text straight out the port
        comport.Write(txtSendData.Text);

        // Show in the terminal window the user's text
          
        DateTime dt = DateTime.Now;
        String dtn = dt.ToShortTimeString();
        Log(LogMsgType.Outgoing, "[" + dtn + "] " + "Send: " + txtSendData.Text + "\n");
      }
      else
      {
        try
        {
          // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
          byte[] data = HexStringToByteArray(txtSendData.Text);

          // Send the binary data out the port
          comport.Write(data, 0, data.Length);

          // Show the hex digits on in the terminal window
          Log(LogMsgType.Outgoing, ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
          // Inform the user if the hex string was not properly formatted
          Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
      }
      txtSendData.SelectAll();
    }

    /// <summary> Log data to the terminal window. </summary>
    /// <param name="msgtype"> The type of message to be written. </param>
    /// <param name="msg"> The string containing the message to be shown. </param>
    private void Log(LogMsgType msgtype, string msg)
    {
      rtfTerminal.Invoke(new EventHandler(delegate
      {
        rtfTerminal.SelectedText = string.Empty;
        rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
        rtfTerminal.SelectionColor = LogMsgTypeColor[(int)msgtype];
        rtfTerminal.AppendText(msg);
        rtfTerminal.ScrollToCaret();
      }));
    }

    /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
    /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
    /// <returns> Returns an array of bytes. </returns>
    private byte[] HexStringToByteArray(string s)
    {
      s = s.Replace(" ", "");
      byte[] buffer = new byte[s.Length / 2];
      for (int i = 0; i < s.Length; i += 2)
        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
      return buffer;
    }

    /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
    /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
    /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
    private string ByteArrayToHexString(byte[] data)
    {
      StringBuilder sb = new StringBuilder(data.Length * 3);
      foreach (byte b in data)
        sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
      return sb.ToString().ToUpper();
    }
    #endregion

    #region Local Properties
    private DataMode CurrentDataMode
    {
      get
      {
        if (rbHex.Checked) return DataMode.Hex;
        else return DataMode.Text;
      }
      set
      {
        if (value == DataMode.Text) rbText.Checked = true;
        else rbHex.Checked = true;
      }
    }
    #endregion

    #region Event Handlers; LRF Receive

    private void FrmTerminal_Shown(object sender, EventArgs e)
    {
      Log(LogMsgType.Normal, String.Format("Application Started at {0}\n", DateTime.Now));
    }

    private void FrmTerminal_FormClosing(object sender, FormClosingEventArgs e)
    {
      // The form is closing, save the user's preferences
      SaveSettings();
    }

    private void RbText_CheckedChanged(object sender, EventArgs e)
    { if (rbText.Checked) CurrentDataMode = DataMode.Text; }

    private void RbHex_CheckedChanged(object sender, EventArgs e)
    { if (rbHex.Checked) CurrentDataMode = DataMode.Hex; }

    private void CmbBaudRate_Validating(object sender, CancelEventArgs e)
    {
            e.Cancel = !int.TryParse(cmbBaudRate.Text, out _); }

    private void CmbDataBits_Validating(object sender, CancelEventArgs e)
    {
            e.Cancel = !int.TryParse(cmbDataBits.Text, out _); }

    private void BtnOpenPort_Click(object sender, EventArgs e)
    {
		bool error = false;

      // If the port is open, close it.
      if (comport.IsOpen) comport.Close();
      else
      {
        // Set the port's settings
        comport.BaudRate = int.Parse(cmbBaudRate.Text);
        comport.DataBits = int.Parse(cmbDataBits.Text);
        comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
        comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
        comport.PortName = cmbPortName.Text;

		try
		{
			// Open the port
			comport.Open();
		}
		catch (UnauthorizedAccessException) { error = true; }
		catch (IOException) { error = true; }
		catch (ArgumentException) { error = true; }

		if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or not available.", "COM Port not available", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		else
		{
			// Show the initial pin states
			UpdatePinState();
			chkDTR.Checked = comport.DtrEnable;
			chkRTS.Checked = comport.RtsEnable;
		}
      }

      // Change the state of the form's controls
      EnableControls();

      // If the port is open, send focus to /btnStatus/ --the send data box
      if (comport.IsOpen)
      {
          btnStatus.Focus();
          //txtSendData.Focus();
          if (chkClearOnOpen.Checked) ClearTerminal();

          DateTime dt = DateTime.Now;
          String dtn = dt.ToShortTimeString();
          Log(LogMsgType.Normal, "[" + dtn + "] " + "Connected\n");
      }
      else
      {
          DateTime dt = DateTime.Now;
          String dtn = dt.ToShortTimeString();
          Log(LogMsgType.Normal, "[" + dtn + "] " + "Disconnected\n");
      }
    }

    private void BtnSend_Click(object sender, EventArgs e)
    { SendData(); }

    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
		// If the com port has been closed, do nothing
		if (!comport.IsOpen) return;

      // This method will be called when there is data waiting in the port's buffer

      // 
      if (CurrentDataMode == DataMode.Text)
      {
        // Read all the data waiting in the buffer
        string data = comport.ReadExisting();
        WriteOutputToTextFile(data); // related to 'Sending Files'

        // Display the text to the user in the terminal
        DateTime dt = DateTime.Now;
        String dtn = dt.ToShortTimeString();
        Log(LogMsgType.Incoming, "[" + dtn + "] " + "Received: " + data + "\n");
      }
      else 
      {
        //HEX

        // Obtain the number of bytes waiting in the port's buffer
        int NumOfUnreadBytes = comport.BytesToRead;
        bool Received = false;

        // Read Format: 
        // SerialPort.Read(buffer, offset, length)

        if (NumOfUnreadBytes == 12)
        {
            byte[] MsgBuffer = new byte[NumOfUnreadBytes];
            comport.Read(MsgBuffer, 0, NumOfUnreadBytes); //wiped after if
            if (MsgBuffer[0] == 0x5A)
            {
                Array.Copy(MsgBuffer, 0, LRF_ans, 0, 12);
                Received = true;
                Log(LogMsgType.Normal, "Complete ans received. Unread bytes: " + comport.BytesToRead + "\n"); 
                btnReadStatus.Enabled = true;
                btnReadStatus.Focus();
            }
        }

        // Parse MsgBuffer, ie find a complete msg
        if (NumOfUnreadBytes > 12) // there's a problem if msg shorter than 12 is received
        {
            // Create a byte array buffer to hold the incoming data
            byte[] MsgBuffer = new byte[NumOfUnreadBytes];
            comport.Read(MsgBuffer, 0, NumOfUnreadBytes);

            int offset = Array.IndexOf(MsgBuffer, (byte)0x5A);
            if (offset >= 0) // if no 0x5a offset is -1
            {
                if ((offset + 11) <= (MsgBuffer.Length - 1))
                {
                    Array.Copy(MsgBuffer, offset, LRF_ans, 0, 12); // 12 bytes from MsgBuffer to LRF_ans
                    Received = true;
                    Log(LogMsgType.Normal, "Complete ans received. Unread bytes: " + comport.BytesToRead + "\n"); 
                    btnReadStatus.Enabled = true;
                    btnReadStatus.Focus();
                }
            }
        }

        if (Received == false)
        {
            Log(LogMsgType.Warning, "Incomplete ans! Unread bytes: " + comport.BytesToRead + "\n");         
        }

      }
    }

    private void TxtSendData_KeyDown(object sender, KeyEventArgs e)
    { 
      // If the user presses [ENTER], send the data now
      if (e.KeyCode == Keys.Enter) { e.Handled = true; SendData(); } 
    }
    #endregion

    #region SEND Text or Hex
        private void chkDTR_CheckedChanged(object sender, EventArgs e)
		{
			comport.DtrEnable = chkDTR.Checked;
			if (chkDTR.Checked && chkClearWithDTR.Checked) ClearTerminal();
		}

		private void chkRTS_CheckedChanged(object sender, EventArgs e)
		{
			comport.RtsEnable = chkRTS.Checked;
		}
    #endregion

    #region Clear LOG
        private void btnClear_Click(object sender, EventArgs e)
		{
			ClearTerminal();
		}

		private void ClearTerminal()
		{
			rtfTerminal.Clear();
		}
        #endregion

    #region Ports
    private void TmrCheckComPorts_Tick(object sender, EventArgs e)
	{
		// checks to see if COM ports have been added or removed
		RefreshComPortList();
	}

	private void RefreshComPortList()
	{
		// Has the list of com port names changed since last checked
		string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

		// If there was an update, then update the control showing the user the list of port names
		if (!String.IsNullOrEmpty(selected))
		{
			cmbPortName.Items.Clear();
			cmbPortName.Items.AddRange(OrderedPortNames());
			cmbPortName.SelectedItem = selected;
		}
	}

	private string[] OrderedPortNames()
	{
		// Just a placeholder for a successful parsing of a string to an integer
		int num;

		// Order the serial port names by their COM ordinals ("COM"+"ordinal")
		return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray(); 
	}
		
	private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
	{
		// Create a new return report to populate
		string selected = null;

		// Retrieve the list of ports currently mounted by the operating system (sorted by name)
		string[] ports = SerialPort.GetPortNames();

		// Check for changes (additions or removals)
		bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

		// If there was a change, then select an appropriate default port
		if (updated)
		{
			// Use the correctly ordered set of port names
			ports = OrderedPortNames();

			// Find newest port if one or more were added
			string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

			// Elect selected port
			if (PortOpen)
			{
				if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
				else if (!String.IsNullOrEmpty(newest)) selected = newest;
				else selected = ports.LastOrDefault();
			}
			else
			{
				if (!String.IsNullOrEmpty(newest)) selected = newest;
				else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
				else selected = ports.LastOrDefault();
			}
		}

		// If there was a change to the port list, return the recommended default selection
		return selected;
	}

    #endregion

    // Files ***********************************************************    

    #region Sending Files
    //Sending Files ------------------
    private static void SendTextFile(SerialPort port, string FilePathName)
    {
        //port.Write("\n" + "NEW_s_i_f_r_a_1" + "\n");
        //port.Write(FilePathName);
        port.Write("\n" + File.OpenText(FilePathName).ReadToEnd());
        //port.Write("\n" + "EOF_s_i_f_r_a_2" + "\n");
    }


    private static void SendBinaryFile(SerialPort port, string FilePathName)
    {
        using (FileStream fs = File.OpenRead(FilePathName)) port.Write((new BinaryReader(fs)).ReadBytes((int)fs.Length), 0, (int)fs.Length);
    }


    private void btnSendFile_Click(object sender, EventArgs e)
    {
        string FilePathName = @"D:\SPort-test.xml";
        SendTextFile(comport, FilePathName);
        // Show in the terminal window the user's text
        DateTime dt = DateTime.Now;
        String dtn = dt.ToShortTimeString();
        Log(LogMsgType.Outgoing, "[" + dtn + "] " + "Send File: " + FilePathName + "\n");
            
            
    }

    #endregion
        
    #region SAVE Received Files
        
    static void WriteOutputToTextFile(string _data)
    {
        string FolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        using (StreamWriter SW = new StreamWriter(FolderName + "\\test.txt", true))   //true >> appends, false>> overwrites
        {
            SW.WriteLine(_data);
            SW.Close();
        }
    }

    #endregion


    // Commands ***********************************************************

    #region LRF commands - SEND

    private void btnPuniC_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;
        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = HexStringToByteArray("FA 0A FA 5A 00 00 00 A6");

            // Send the binary data out the port
            comport.Write(data, 0, data.Length); //comport.Write("FA 0A FA 5A 00 00 00 A6");

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Outgoing, "LRF - Fill C:  " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
        btnFillC.Enabled = false;
        btnStatus.Focus();
    }

    private void btnFIRE_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;
        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = HexStringToByteArray("FA 0A FA 5A 01 00 00 A5");

            // Send the binary data out the port
            comport.Write(data, 0, data.Length);

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Warning, "ATTENTION - LRF - FIRING \n");
            Log(LogMsgType.Outgoing, "LRF - FIRING:  " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
        btnFIRE.Enabled = false;
        btnStatus.Focus();
    }

    private void txtRmin_TextChanged(object sender, EventArgs e)
    {
        if (txtRmin.Text.Length != 0)
        {
            int min_distance = int.Parse(txtRmin.Text);
            if (min_distance < 81)
            {
                R_min = 81;
            }
            if (min_distance > 7999)
            {
                R_min = 7999;
            }

            if (min_distance > 80 & min_distance < 8000) // valid ranges/distances
            {
                R_min = min_distance;
            }
            btnSetRmin.Enabled = true;
        }
    }

    private void btnSetRmin_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;
        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = new byte[8];

            Array.Copy(HexStringToByteArray("FA 0A FA 5B 00"), 0, data, 0, 5); // bytes 0-4
            data[5] = (byte)(R_min / 256);
            data[6] = (byte)(R_min % 256);
            // check byte:
            data[7] = (byte)(0x00
                            - data[3]
                            - data[4]
                            - data[5]
                            - data[6]);

            // Send the binary data out the port
            comport.Write(data, 0, data.Length);

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Outgoing, "LRF - Set R_min [m] = " + R_min + " => hex " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
        btnSetRmin.Enabled = false;
        btnStatus.Focus();
    }

    private void btnCancelR_min_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;
        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = HexStringToByteArray("FA 0A FA 5B 00 00 05 A0"); // to Cancel R_min send R_min = 5;
            
            // Send the binary data out the port
            comport.Write(data, 0, data.Length);

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Outgoing, "LRF - Cancel R_min:  " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
        btnStatus.Focus();
    }
          

    private void btnOFF_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;
        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = HexStringToByteArray("FA 0A FA 5D 00 00 00 A3");

            // Send the binary data out the port
            comport.Write(data, 0, data.Length);

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Outgoing, "LRF - OFF:  " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
    }

    private void btnStatus_Click(object sender, EventArgs e)
    {
        rbHex.Checked = true;

        // Empty the COM port buffer so that LRF reply gets stored in an empty buffer
        byte[] MsgBuffer = new byte[comport.BytesToRead];
        comport.Read(MsgBuffer, 0, comport.BytesToRead);
        //
        Log(LogMsgType.Normal, "Emptied Read buffer. Unread bytes: " + comport.BytesToRead + "\n"); 

        try
        {
            // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
            byte[] data = HexStringToByteArray("FA 0A FA 5C 00 00 00 A4");
            // -- check the last time distance value
            // -- the shortest check time gap is 50ms

            // Send the binary data out the port
            comport.Write(data, 0, data.Length);

            // Show the hex digits on in the terminal window
            Log(LogMsgType.Outgoing, "LRF - Return status:  " + ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
            // Inform the user if the hex string was not properly formatted
            Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
        btnReadStatus.Focus();
    }

    #endregion

    #region Parse received LRF reply

    private void BtnReadStatus_Click(object sender, EventArgs e)
    {
        // Checksum for LRF_ans, byte 0 not included in the sum
        byte checksum = (byte)(   LRF_ans[1]
                                + LRF_ans[2]
                                + LRF_ans[3]
                                + LRF_ans[4]
                                + LRF_ans[5]
                                + LRF_ans[6]
                                + LRF_ans[7]
                                + LRF_ans[8]
                                + LRF_ans[9]
                                + LRF_ans[10]
                                + LRF_ans[11]);

            // LRF reply always starts the same and has to have checksum = 0x00
            if (LRF_ans[0] == 0x5A & checksum == (byte)0x00) 
        {
            Log(LogMsgType.Normal, "correct checksum of LRF reply." + "\n");

            if (LRF_ans[1] != 0xAA) // Measured 1. distance
            {
                int R1 = LRF_ans[1] * 256 + LRF_ans[2];
                txtBxR1.Text = R1.ToString();
                txtBxR1.BackColor = Color.PaleGreen;
            }
            else { txtBxR1.Text = "No echo"; }

            if (LRF_ans[3] != 0xAA) // Measured 2. distance
                {
                int R2 = LRF_ans[3] * 256 + LRF_ans[4];
                txtBxR2.Text = R2.ToString();
                txtBxR2.BackColor = Color.PaleGreen;
            }
            else { txtBxR2.Text = "No echo"; }

            if (LRF_ans[5] != 0xAA) // Measured 3. distance
                {
                int R3 = LRF_ans[5] * 256 + LRF_ans[6];
                txtBxR3.Text = R3.ToString();
                txtBxR3.BackColor = Color.PaleGreen;
            }
            else { txtBxR3.Text = "No echo"; }

            switch (LRF_ans[7])
            {
                case 0x00: // No target or no echo
                    txtBxDistanceStatus.Text = "No target/echo"; break;
                case 0x01: // One target
                    txtBxDistanceStatus.Text = "1 target"; break;
                case 0x02: // Two targets
                    txtBxDistanceStatus.Text = "2 targets"; break;
                case 0x03: // Three targets
                    txtBxDistanceStatus.Text = "3 targets"; break;
            }


            if ((LRF_ans[8] & (1 << 1 - 1)) != 0) // bit 0 - power ON/OFF
            { 
                txtBxLRFStatus.AppendText("LRF ON \n");
                btnOFF.Enabled = true;
            }
            else 
            { 
                txtBxLRFStatus.AppendText("OFF in 0.5 s \n");
                btnOFF.Enabled = false;
            }

            if ((LRF_ans[8] & (1 << 2 - 1)) != 0) // bit 1 - charging/standby
            { 
                txtBxLRFStatus.AppendText("charging \n");
                btnFillC.Enabled = false;
                btnFIRE.Enabled = false;
            }
            else 
            { 
                txtBxLRFStatus.AppendText("standby \n"); // FIRE to standby (???) , unclear
                btnFillC.Enabled = false;
                btnFIRE.Enabled = false;
            }

            if ((LRF_ans[8] & (1 << 3 - 1)) != 0) // bit 2 - fully/not charged
            {
                txtBxLRFStatus.AppendText("full - can FIRE \n");
                btnFillC.Enabled = false;
                btnFIRE.Enabled = true;
                btnFIRE.Focus();
            }
            else 
            { 
                txtBxLRFStatus.AppendText("not charged \n");
                btnFillC.Enabled = true;
                btnFillC.Focus();
                btnFIRE.Enabled = false;
            }

            if ((LRF_ans[8] & (1 << 4 - 1)) != 0) // bit 3 - unsuccessful/normal measurement
            { txtBxLRFStatus.AppendText("unsuccessful meas. \n"); }
            else { txtBxLRFStatus.AppendText("normal measurement \n"); }

            if (LRF_ans[9] == 0x00 & LRF_ans[10] == 0x50) 
                // R_min not set, returns R_min = 80; so min range is 80, not 50 as advertised (!!!)
            {
                txtBxRminStatus.Text = "R_min not set";
                txtBxRminStatus.BackColor = Color.BlanchedAlmond;

            }
            else
            {
                int Rmin = LRF_ans[9] * 256 + LRF_ans[10];
                txtBxRminStatus.Text = "R_min: " + Rmin.ToString();
                txtBxRminStatus.BackColor = Color.Silver;
            }

        }

        Log(LogMsgType.Normal, "LRF reply stored." + "\n"); 

        // Empty the COM port buffer so that LRF reply gets stored in an empty buffer
        byte[] MsgBuffer = new byte[comport.BytesToRead];
        comport.Read(MsgBuffer, 0, comport.BytesToRead);
        //
        Log(LogMsgType.Normal, "Read buffer cleared. Unread bytes: " + comport.BytesToRead + "\n"); 

        btnReadStatus.Enabled = false;
    }

        #endregion

    } 
}