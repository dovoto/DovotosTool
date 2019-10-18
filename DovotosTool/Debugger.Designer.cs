namespace DovotosTool
{
    partial class Debugger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbDissassemble = new System.Windows.Forms.TextBox();
            this.cmDissassembly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRunToCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.tbGoto = new System.Windows.Forms.TextBox();
            this.tbA = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbPC = new System.Windows.Forms.TextBox();
            this.tbSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbF = new System.Windows.Forms.TextBox();
            this.cbN = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbV = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbZ = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbI = new System.Windows.Forms.CheckBox();
            this.tbStack = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnOneLine = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnOneFrame = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.btnRunToVblank = new System.Windows.Forms.Button();
            this.lblVscroll = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblHscoll = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPPUAddress = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPPUStatus = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbPalette = new System.Windows.Forms.TextBox();
            this.lblOamAddress = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbOAM = new System.Windows.Forms.TextBox();
            this.tbOAMShadow = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCallStack = new System.Windows.Forms.TextBox();
            this.tbPCStack = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmDissassembly.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDissassemble
            // 
            this.tbDissassemble.ContextMenuStrip = this.cmDissassembly;
            this.tbDissassemble.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDissassemble.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDissassemble.Location = new System.Drawing.Point(0, 0);
            this.tbDissassemble.Multiline = true;
            this.tbDissassemble.Name = "tbDissassemble";
            this.tbDissassemble.Size = new System.Drawing.Size(732, 925);
            this.tbDissassemble.TabIndex = 0;
            this.tbDissassemble.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TbDissassemble_MouseMove);
            // 
            // cmDissassembly
            // 
            this.cmDissassembly.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmDissassembly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRunToCursor});
            this.cmDissassembly.Name = "cmDissassembly";
            this.cmDissassembly.Size = new System.Drawing.Size(192, 36);
            this.cmDissassembly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CmDissassembly_MouseClick);
            // 
            // menuRunToCursor
            // 
            this.menuRunToCursor.Name = "menuRunToCursor";
            this.menuRunToCursor.Size = new System.Drawing.Size(191, 32);
            this.menuRunToCursor.Text = "Run to cursor";
            // 
            // tbGoto
            // 
            this.tbGoto.Location = new System.Drawing.Point(740, 887);
            this.tbGoto.Name = "tbGoto";
            this.tbGoto.Size = new System.Drawing.Size(100, 26);
            this.tbGoto.TabIndex = 1;
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(1265, 15);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(100, 26);
            this.tbA.TabIndex = 2;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(1265, 47);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 26);
            this.tbX.TabIndex = 3;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(1265, 79);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 26);
            this.tbY.TabIndex = 4;
            // 
            // tbPC
            // 
            this.tbPC.Location = new System.Drawing.Point(1093, 15);
            this.tbPC.Name = "tbPC";
            this.tbPC.Size = new System.Drawing.Size(100, 26);
            this.tbPC.TabIndex = 5;
            // 
            // tbSP
            // 
            this.tbSP.Location = new System.Drawing.Point(1265, 111);
            this.tbSP.Name = "tbSP";
            this.tbSP.Size = new System.Drawing.Size(100, 26);
            this.tbSP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1228, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1228, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1228, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1228, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1056, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "PC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1229, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "F";
            // 
            // tbF
            // 
            this.tbF.Location = new System.Drawing.Point(1266, 143);
            this.tbF.Name = "tbF";
            this.tbF.Size = new System.Drawing.Size(100, 26);
            this.tbF.TabIndex = 12;
            // 
            // cbN
            // 
            this.cbN.AutoSize = true;
            this.cbN.Location = new System.Drawing.Point(1232, 184);
            this.cbN.Name = "cbN";
            this.cbN.Size = new System.Drawing.Size(22, 21);
            this.cbN.TabIndex = 14;
            this.cbN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbN.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1231, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1260, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "V";
            // 
            // cbV
            // 
            this.cbV.AutoSize = true;
            this.cbV.Location = new System.Drawing.Point(1260, 184);
            this.cbV.Name = "cbV";
            this.cbV.Size = new System.Drawing.Size(22, 21);
            this.cbV.TabIndex = 16;
            this.cbV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbV.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1289, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "C";
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Location = new System.Drawing.Point(1288, 184);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(22, 21);
            this.cbC.TabIndex = 18;
            this.cbC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbC.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1317, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Z";
            // 
            // cbZ
            // 
            this.cbZ.AutoSize = true;
            this.cbZ.Location = new System.Drawing.Point(1316, 184);
            this.cbZ.Name = "cbZ";
            this.cbZ.Size = new System.Drawing.Size(22, 21);
            this.cbZ.TabIndex = 20;
            this.cbZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbZ.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1345, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "I";
            // 
            // cbI
            // 
            this.cbI.AutoSize = true;
            this.cbI.Location = new System.Drawing.Point(1342, 184);
            this.cbI.Name = "cbI";
            this.cbI.Size = new System.Drawing.Size(22, 21);
            this.cbI.TabIndex = 22;
            this.cbI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbI.UseVisualStyleBackColor = true;
            // 
            // tbStack
            // 
            this.tbStack.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStack.Location = new System.Drawing.Point(1233, 252);
            this.tbStack.Multiline = true;
            this.tbStack.Name = "tbStack";
            this.tbStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStack.Size = new System.Drawing.Size(132, 661);
            this.tbStack.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1274, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Stack";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(819, 6);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 35);
            this.btnPause.TabIndex = 27;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(738, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 35);
            this.btnRun.TabIndex = 28;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(900, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 35);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(738, 79);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 35);
            this.btnStep.TabIndex = 30;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.BtnStep_Click);
            // 
            // btnOneLine
            // 
            this.btnOneLine.Location = new System.Drawing.Point(738, 120);
            this.btnOneLine.Name = "btnOneLine";
            this.btnOneLine.Size = new System.Drawing.Size(133, 35);
            this.btnOneLine.TabIndex = 31;
            this.btnOneLine.Text = "One Line";
            this.btnOneLine.UseVisualStyleBackColor = true;
            this.btnOneLine.Click += new System.EventHandler(this.BtnOneLine_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(863, 878);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 35);
            this.btnGoto.TabIndex = 32;
            this.btnGoto.Text = "Goto";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.BtnGoto_Click);
            // 
            // btnOneFrame
            // 
            this.btnOneFrame.Location = new System.Drawing.Point(740, 161);
            this.btnOneFrame.Name = "btnOneFrame";
            this.btnOneFrame.Size = new System.Drawing.Size(133, 35);
            this.btnOneFrame.TabIndex = 33;
            this.btnOneFrame.Text = "One Frame";
            this.btnOneFrame.UseVisualStyleBackColor = true;
            this.btnOneFrame.Click += new System.EventHandler(this.BtnOneFrame_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(774, 362);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "Line";
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.Location = new System.Drawing.Point(928, 362);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(18, 20);
            this.lblLineNumber.TabIndex = 41;
            this.lblLineNumber.Text = "0";
            // 
            // btnRunToVblank
            // 
            this.btnRunToVblank.Location = new System.Drawing.Point(738, 202);
            this.btnRunToVblank.Name = "btnRunToVblank";
            this.btnRunToVblank.Size = new System.Drawing.Size(187, 35);
            this.btnRunToVblank.TabIndex = 42;
            this.btnRunToVblank.Text = "Run to VBLANK";
            this.btnRunToVblank.UseVisualStyleBackColor = true;
            this.btnRunToVblank.Click += new System.EventHandler(this.BtnRunToVblank_Click);
            // 
            // lblVscroll
            // 
            this.lblVscroll.AutoSize = true;
            this.lblVscroll.Location = new System.Drawing.Point(928, 392);
            this.lblVscroll.Name = "lblVscroll";
            this.lblVscroll.Size = new System.Drawing.Size(18, 20);
            this.lblVscroll.TabIndex = 45;
            this.lblVscroll.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(774, 392);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 44;
            this.label14.Text = "V Scroll";
            // 
            // lblHscoll
            // 
            this.lblHscoll.AutoSize = true;
            this.lblHscoll.Location = new System.Drawing.Point(928, 422);
            this.lblHscoll.Name = "lblHscoll";
            this.lblHscoll.Size = new System.Drawing.Size(18, 20);
            this.lblHscoll.TabIndex = 47;
            this.lblHscoll.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(774, 422);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 46;
            this.label17.Text = "H Scroll";
            // 
            // lblPPUAddress
            // 
            this.lblPPUAddress.AutoSize = true;
            this.lblPPUAddress.Location = new System.Drawing.Point(927, 455);
            this.lblPPUAddress.Name = "lblPPUAddress";
            this.lblPPUAddress.Size = new System.Drawing.Size(18, 20);
            this.lblPPUAddress.TabIndex = 49;
            this.lblPPUAddress.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(774, 455);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 20);
            this.label19.TabIndex = 48;
            this.label19.Text = "PPU Address";
            // 
            // lblPPUStatus
            // 
            this.lblPPUStatus.AutoSize = true;
            this.lblPPUStatus.Location = new System.Drawing.Point(927, 487);
            this.lblPPUStatus.Name = "lblPPUStatus";
            this.lblPPUStatus.Size = new System.Drawing.Size(18, 20);
            this.lblPPUStatus.TabIndex = 51;
            this.lblPPUStatus.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(774, 487);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 20);
            this.label21.TabIndex = 50;
            this.label21.Text = "PPU Status";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1134, 226);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 20);
            this.label22.TabIndex = 53;
            this.label22.Text = "Palette";
            // 
            // tbPalette
            // 
            this.tbPalette.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalette.Location = new System.Drawing.Point(1093, 252);
            this.tbPalette.Multiline = true;
            this.tbPalette.Name = "tbPalette";
            this.tbPalette.Size = new System.Drawing.Size(132, 173);
            this.tbPalette.TabIndex = 52;
            // 
            // lblOamAddress
            // 
            this.lblOamAddress.AutoSize = true;
            this.lblOamAddress.Location = new System.Drawing.Point(927, 516);
            this.lblOamAddress.Name = "lblOamAddress";
            this.lblOamAddress.Size = new System.Drawing.Size(18, 20);
            this.lblOamAddress.TabIndex = 55;
            this.lblOamAddress.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(774, 516);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 20);
            this.label15.TabIndex = 54;
            this.label15.Text = "OAM Address";
            // 
            // tbOAM
            // 
            this.tbOAM.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOAM.Location = new System.Drawing.Point(1006, 455);
            this.tbOAM.Multiline = true;
            this.tbOAM.Name = "tbOAM";
            this.tbOAM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOAM.Size = new System.Drawing.Size(219, 248);
            this.tbOAM.TabIndex = 56;
            // 
            // tbOAMShadow
            // 
            this.tbOAMShadow.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOAMShadow.Location = new System.Drawing.Point(1006, 731);
            this.tbOAMShadow.Multiline = true;
            this.tbOAMShadow.Name = "tbOAMShadow";
            this.tbOAMShadow.Size = new System.Drawing.Size(219, 182);
            this.tbOAMShadow.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1089, 432);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 58;
            this.label13.Text = "OAM";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1051, 706);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 20);
            this.label18.TabIndex = 59;
            this.label18.Text = "OAM Shaddow";
            // 
            // tbCallStack
            // 
            this.tbCallStack.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCallStack.Location = new System.Drawing.Point(762, 602);
            this.tbCallStack.Multiline = true;
            this.tbCallStack.Name = "tbCallStack";
            this.tbCallStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCallStack.Size = new System.Drawing.Size(132, 101);
            this.tbCallStack.TabIndex = 60;
            // 
            // tbPCStack
            // 
            this.tbPCStack.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPCStack.Location = new System.Drawing.Point(762, 731);
            this.tbPCStack.Multiline = true;
            this.tbPCStack.Name = "tbPCStack";
            this.tbPCStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPCStack.Size = new System.Drawing.Size(132, 101);
            this.tbPCStack.TabIndex = 61;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(766, 706);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 20);
            this.label20.TabIndex = 62;
            this.label20.Text = "PC Stack";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(766, 579);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 20);
            this.label23.TabIndex = 63;
            this.label23.Text = "Call Stack";
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 925);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbPCStack);
            this.Controls.Add(this.tbCallStack);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbOAMShadow);
            this.Controls.Add(this.tbOAM);
            this.Controls.Add(this.lblOamAddress);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbPalette);
            this.Controls.Add(this.lblPPUStatus);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblPPUAddress);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblHscoll);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblVscroll);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnRunToVblank);
            this.Controls.Add(this.lblLineNumber);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnOneFrame);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnOneLine);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbStack);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbI);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbZ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSP);
            this.Controls.Add(this.tbPC);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.tbGoto);
            this.Controls.Add(this.tbDissassemble);
            this.Name = "Debugger";
            this.Text = "Debugger";
            this.cmDissassembly.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDissassemble;
        private System.Windows.Forms.TextBox tbGoto;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbPC;
        private System.Windows.Forms.TextBox tbSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.CheckBox cbN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbZ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbI;
        private System.Windows.Forms.TextBox tbStack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnOneLine;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnOneFrame;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblLineNumber;
        private System.Windows.Forms.Button btnRunToVblank;
        private System.Windows.Forms.ContextMenuStrip cmDissassembly;
        private System.Windows.Forms.ToolStripMenuItem menuRunToCursor;
        private System.Windows.Forms.Label lblVscroll;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblHscoll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblPPUAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPPUStatus;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbPalette;
        private System.Windows.Forms.Label lblOamAddress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbOAM;
        private System.Windows.Forms.TextBox tbOAMShadow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbCallStack;
        private System.Windows.Forms.TextBox tbPCStack;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
    }
}