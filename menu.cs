﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TekMonts;
using System.Drawing;

namespace ROEPublicCheat
{

    public partial class menu : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        int[] MuzzleVelocityArray = new int[20];
        void update()
        {
            PLAYER_ESP_BUTTON.Text = (Settings.PlayerESP) ? "ON" : "OFF";
            ESP_LINES_BUTTON.Text = (Settings.PlayerLines) ? "ON" : "OFF";
            ESP_HEALTH_BUTTON.Text = (Settings.PlayerHealth) ? "ON" : "OFF";
            ESP_PLAYER_DISTANCE_BUTTON.Text = (Settings.PlayerDistance) ? "ON" : "OFF";
            ESP_BOT_BUTTON.Text = (Settings.BotESP) ? "ON" : "OFF";
            ESP_BOT_HEALTH_BUTTON.Text = (Settings.BotHealth) ? "ON" : "OFF";
            ESP_ITEM_BUTTON.Text = (Settings.ItemESP) ? "ON" : "OFF";
            ESP_ITEM_DISTANCE_BUTTON.Text = (Settings.ItemDistance) ? "ON" : "OFF";
            ESP_VEHICLE_BUTTON.Text = (Settings.VehicleESP) ? "ON" : "OFF";
            ESP_VEHICLE_DISTANCE_BUTTON.Text = (Settings.VehicleDistance) ? "ON" : "OFF";
            ESP_SUPPLY_BOX_BUTTON.Text = (Settings.SupplyESP) ? "ON" : "OFF";
            ESP_PLANE_BUTTON.Text = (Settings.PlaneESP) ? "ON" : "OFF";
            AIMBOT_BUTTON.Text = (Settings.Aimbot) ? "ON" : "OFF";
            SMARTAIM_BUTTON.Text = (Settings.SmartHeight) ? "ON" : "OFF";
            RANGE_AIMBOT.Value = Settings.Distance;
            FOV_BAR.Value = Settings.FOV;
            SCOPE_BUTTON.Text = (Settings.USESCOPE == false) ? "OFF" : (Settings.scope == 0) ? "ON" : (Settings.scope == 1) ? "X2" : (Settings.scope == 2) ? "X4" : "X8" ;
            HOLDKEY_BUTTON.Text = (Settings.holdkey) ? "ON" : "OFF";
            ScopeBar.Value = Settings.scope;
            SHOW_FOV_BUTTON.Text = (Settings.DEBUG) ? "ON" : "OFF";
            BOX_BUTTON.Text = (Settings.BOX) ? "ON" : "OFF";
            GOLD_ITEM_ESP_BUTTON.Text = (Settings.GOLD) ? "ON" : "OFF";
            this.PerformLayout();
            if (Settings.menu)
            {
                MethodInvoker ss = delegate
                {
                    Visible = true;
                    this.Show();
                    this.TopMost = true;
                    this.BringToFront();



                };
                this.Invoke(ss);
            }
            else
            {
                MethodInvoker sss = delegate
                {
                    this.Visible = false;
                    this.Hide();

                };
                this.Invoke(sss);
            }

        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show("Menu caught : bar is:\n"+Settings.wait+"\n\n" + e.Message + "\n\n" + "Stack:\n" + e.StackTrace);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            this.TopMost = true;
            this.TopLevel = true;

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            new Thread(new ThreadStart(this.thread)).Start();
            update();

        }

        public void thread()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            while (true)
            {
    
                MethodInvoker up = delegate
                {

                    update();


                };
                this.Invoke(up);
                Thread.Sleep(200);

               
            }
        }

        public menu()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }
        }

        private void Buttons_click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            switch (btn.Name)
            {

                case "PLAYER_ESP_BUTTON":
                    Settings.PlayerESP = !Settings.PlayerESP;
                    break;
                case "ESP_LINES_BUTTON":
                    Settings.PlayerLines = !Settings.PlayerLines;
                    break;
                case "ESP_HEALTH_BUTTON":
                    Settings.PlayerHealth = !Settings.PlayerHealth;
                    break;
                case "ESP_PLAYER_DISTANCE_BUTTON":
                    Settings.PlayerDistance = !Settings.PlayerDistance;
                    break;
                case "ESP_BOT_BUTTON":
                    Settings.BotESP = !Settings.BotESP;
                    break;
                case "ESP_BOT_HEALTH_BUTTON":
                    Settings.BotHealth = !Settings.BotHealth;
                    break;
                case "ESP_ITEM_BUTTON":
                    Settings.ItemESP = !Settings.ItemESP;
                    break;
                case "ESP_ITEM_DISTANCE_BUTTON":
                    Settings.ItemDistance = !Settings.ItemDistance;
                    break;
                case "ESP_VEHICLE_BUTTON":
                    Settings.VehicleESP = !Settings.VehicleESP;
                    break;
                case "ESP_VEHICLE_DISTANCE_BUTTON":
                    Settings.VehicleDistance = !Settings.VehicleDistance;
                    break;
                case "ESP_SUPPLY_BOX_BUTTON":
                    Settings.SupplyESP = !Settings.SupplyESP;
                    break;
                case "ESP_PLANE_BUTTON":
                    Settings.PlaneESP = !Settings.PlaneESP;
                    break;
                case "AIMBOT_BUTTON":
                    Settings.Aimbot = !Settings.Aimbot;
                    break;
                case "SMARTAIM_BUTTON":
                    Settings.SmartHeight = !Settings.SmartHeight;
                    break;
                case "HOLDKEY_BUTTON":
                    Settings.holdkey = !Settings.holdkey;
                    break;
                case "SHOW_FOV_BUTTON":
                    Settings.DEBUG = !Settings.DEBUG;
                    break;
                case "SCOPE_BUTTON":
                    Settings.USESCOPE = !Settings.USESCOPE;
                    break;
                case "NO_RECOIL_BUTTON":
                    Settings.NoRecoil = true;
                    this.NO_RECOIL_BUTTON.Enabled = false;
                    this.MUZZLE_VILOCITY.Enabled = true;
                    break;
                case "BOX_BUTTON":
                    Settings.BOX = !Settings.BOX;
                    break;
                case "NOGRASS_BUTTON":
                    Settings.NoGrass = !Settings.NoGrass;
                    break;
                case "GOLD_ITEM_ESP_BUTTON":
                    Settings.GOLD = !Settings.GOLD;
                    break;
               
                default:
                    break;
            }
            Thread.Sleep(100);

        }

        private void Scrolled(object sender, EventArgs e)
        {
            Settings.Distance = RANGE_AIMBOT.Value;
            RANGE_AIMBOT.PerformLayout();

        }

        private void FOV_BAR_Scroll(object sender, EventArgs e)
        {
            Settings.FOV = FOV_BAR.Value;
            FOV_BAR.PerformLayout();
        }


        private void ScopeBar_Scroll(object sender, EventArgs e)
        {
            Settings.scope = ScopeBar.Value;
            float newX, newnX, newY, newnY;
            if (Settings.scope == 0)
            {
                newnX = -0.857f;
                newX = 0.857f;
                newY = 0.453f;
                newnY = -0.453f;

                doScope(newX, newnX, newY, newnY);

            }

            //X2
            if (Settings.scope == 1)
            {
                newnX = -0.548f;
                newX = 0.548f;
                newY = 0.289f;
                newnY = -0.289f;

                doScope(newX, newnX, newY, newnY);

            }

            //X4
            if (Settings.scope == 2)
            {
                newnX = -0.246f;
                newX = 0.246f;
                newY = 0.130f;
                newnY = -0.130f;

                doScope(newX, newnX, newY, newnY);

            }

            //X8
            if (Settings.scope == 3)
            {
                newnX = -0.136f;
                newX = 0.136f;
                newY = 0.072f;
                newnY = -0.072f;

                doScope(newX, newnX, newY, newnY);

            }

            ScopeBar.PerformLayout();
        }

        private void MUZZLE_VILOCITY_Scroll(object sender, EventArgs e)
        {
            Settings.MuzzleVilocityValue = MUZZLE_VILOCITY.Value;
            doModifyWeapon(true, Settings.MuzzleVilocityValue, false);
            MUZZLE_VILOCITY.PerformLayout();
        }

        private void SCOPE_BUTTON_Click(object sender, EventArgs e)
        {
            Settings.USESCOPE = !Settings.USESCOPE;
            ScopeBar.Enabled = Settings.USESCOPE;
            SCOPE_BUTTON.PerformLayout();
        }

        private void NO_RECOIL_BUTTON_Click(object sender, EventArgs e)
        {
            Settings.NoRecoil = true;
            NO_RECOIL_BUTTON.Enabled = false;
            MUZZLE_VILOCITY.Enabled = true;
            doModifyWeapon(false, 0, true);
            NO_RECOIL_BUTTON.PerformLayout();
        }

        private void doModifyWeapon(bool isMuzzleVelocity, int MultypeValue, bool isFirstTimeInit)
        {
            IntPtr WeaponConfigTable = Mem.ReadMemory<IntPtr>(Mem.MainProcedure.ToInt32() + 0x60C);
            IntPtr Table = Mem.ReadMemory<IntPtr>(WeaponConfigTable.ToInt32() + 0x40);
            int EntrySize = 0x450;
            int RecoilOff = 0x50;
            int SpreadOff = 0x2EC;
            int MuzzleVelocityOff = 0x34;
            float NewF = 0.0f;
            for (int i = 0; i < 20; i++)
            {

                IntPtr weapon = Mem.ReadMemory<IntPtr>(Table.ToInt32() + (i * EntrySize));

                IntPtr recoilAddr = Mem.ReadMemory<IntPtr>(weapon.ToInt32() + RecoilOff);
                IntPtr spreadAddr = Mem.ReadMemory<IntPtr>(weapon.ToInt32() + SpreadOff);

                IntPtr MuzzleVelocityAddr = Mem.ReadMemory<IntPtr>(weapon.ToInt32() + MuzzleVelocityOff);

                if (isFirstTimeInit)
                {
                    MuzzleVelocityArray[i] = (int)MuzzleVelocityAddr;
                }
                if (isMuzzleVelocity)
                {
                    int valueToWrite = MuzzleVelocityArray[i] * MultypeValue;
                    Mem.WriteMemory<int>(MuzzleVelocityAddr.ToInt32(), valueToWrite);
                }
                else
                {
                    Mem.WriteMemory<int>(MuzzleVelocityAddr.ToInt32(), MuzzleVelocityArray[i]);
                    Mem.WriteMemory<float>(recoilAddr.ToInt32(), NewF);
                    Mem.WriteMemory<float>(spreadAddr.ToInt32(), NewF);
                }
            }
        }

        private void doScope(float newX, float newnX, float newY, float newnY)
        {
            IntPtr Zoom = Mem.ReadMemory<IntPtr>((int)Mem.QSCamera + 0x4);
            IntPtr ZoomDetail = Mem.ReadMemory<IntPtr>((int)Zoom + 0x10);
            int X = 0x8C;
            int nX = 0x88;
            int nY = 0x94;
            int Y = 0x90;
            //Read address
            IntPtr XAddr = Mem.ReadMemory<IntPtr>(ZoomDetail.ToInt32() + X);
            IntPtr nXAddr = Mem.ReadMemory<IntPtr>(ZoomDetail.ToInt32() + nX);
            IntPtr YAddr = Mem.ReadMemory<IntPtr>(ZoomDetail.ToInt32() + Y);
            IntPtr nYAddr = Mem.ReadMemory<IntPtr>(ZoomDetail.ToInt32() + nY);
            MessageBox.Show("Begin doScope: ZoomLevel" + Settings.scope + ", XAddrValue: " + XAddr + ", nXAddrValue: " + nXAddr + ", YAddrValue: " + YAddr + ", nYAddrValue: " + nYAddr);
            //Write to memory
            Mem.WriteMemory<float>(XAddr.ToInt32(), newnX);
            Mem.WriteMemory<float>(nXAddr.ToInt32(), newnX);
            Mem.WriteMemory<float>(nYAddr.ToInt32(), newnY);
            Mem.WriteMemory<float>(YAddr.ToInt32(), newY);
        }
    }
}
