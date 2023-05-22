using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Malaysia_Food_Restaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double NasiLemakP = 2.0d;
        const double RotiCanaiP = 1.0d;
        const double NasiAyamP = 4.0d;
        const double NasiBujangP = 2.0d;
        const double MeeGorengP = 2.0d;
        const double BihunP = 2.0d;
        const double NasiKandarP = 4.0d;
        const double CharKueyTeowP = 2.0d;
        const double NasiKariP = 4.0d;
        const double NasiTelurKicapP = 4.0d;
        const double KaripapP = 0.5d;
        const double KasturiP = 0.5d;
        const double PopiaP = 0.5d;
        const double MurukkuP = 0.5d;
        const double PauP = 2.5d;
        const double ABCP = 2.0d;
        const double AisKrimP = 2.0d;
        const double GulabJamunP = 2.0d;
        const double BuburChaChaP = 2.0d;
        const double CendolP = 2.0d;
        double KopiP = 1.7;
        double TehP = 1.7;
        double NescafeP = 2.0;
        double MiloP = 2.0;
        double HorlickP = 2.0;
        double AirKosongP = 0.5;
        double SirapP = 1.5;
        const double TaxRate = 0.08d;
        double Tax, Total, TotalAmount;

        
        private void ResetTextBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
              {
                  foreach (Control control in controls)
                      if (control is TextBox)
                          (control as TextBox).Text = "0";
                      else
                          func(control.Controls);
              };
            func(Controls);
        }

        private void EnableTextBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = false;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void ResetCheckBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void ResetComboBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is ComboBox)
                        (control as ComboBox).Text = "0";
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            ResetCheckBox();
            ResetComboBox();
            lblResult.Text = "        ";
            lblBDResult.Text = null;
            lblDResult.Text = null;
            lblTaxResult.Text = null;
            cmbKopiT.Text = null;
            cmbTehT.Text = null;
            cmbNescafeT.Text = null;
            cmbMiloT.Text = null;
            cmbHorlickT.Text = null;
            cmbAirKosongT.Text = null;
            cmbSirapT.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableTextBox();            
            cmbKopiT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTehT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSirapT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMiloT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNescafeT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAirKosongT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHorlickT.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKopiT.Enabled = false;
            cmbTehT.Enabled = false;
            cmbNescafeT.Enabled = false;
            cmbMiloT.Enabled = false;
            cmbHorlickT.Enabled = false;
            cmbSirapT.Enabled = false;
            cmbAirKosongT.Enabled = false;

            //=========Display the price from assigned variable to ease future changes===========//
            lblNasiLemakP.Text = Convert.ToString(String.Format("{0:0.00}", NasiLemakP));
            lblRotiCanaiP.Text = Convert.ToString(String.Format("{0:0.00}", RotiCanaiP));
            lblNasiAyamP.Text = Convert.ToString(String.Format("{0:0.00}", NasiAyamP));
            lblMeeGorengP.Text = Convert.ToString(String.Format("{0:0.00}", MeeGorengP));
            lblBihunP.Text = Convert.ToString(String.Format("{0:0.00}", BihunP));
            lblNasiBujangP.Text = Convert.ToString(String.Format("{0:0.00}", NasiBujangP));
            lblNasiKandarP.Text = Convert.ToString(String.Format("{0:0.00}", NasiKandarP));
            lblCKTP.Text = Convert.ToString(String.Format("{0:0.00}", CharKueyTeowP));
            lblNasiKariP.Text = Convert.ToString(String.Format("{0:0.00}", NasiKariP));
            lblNTKP.Text = Convert.ToString(String.Format("{0:0.00}", NasiTelurKicapP));
            lblKaripapP.Text = Convert.ToString(String.Format("{0:0.00}", KaripapP));
            lblKasturiP.Text = Convert.ToString(String.Format("{0:0.00}", KasturiP));
            lblPopiaP.Text = Convert.ToString(String.Format("{0:0.00}", PopiaP));
            lblMurukkuP.Text = Convert.ToString(String.Format("{0:0.00}", MurukkuP));
            lblPauP.Text = Convert.ToString(String.Format("{0:0.00}", PauP));
            lblABCP.Text = Convert.ToString(String.Format("{0:0.00}", ABCP));
            lblAisKrimP.Text = Convert.ToString(String.Format("{0:0.00}", AisKrimP));
            lblGulabJamunP.Text = Convert.ToString(String.Format("{0:0.00}", GulabJamunP));
            lblBuburChaChaP.Text = Convert.ToString(String.Format("{0:0.00}", BuburChaChaP));
            lblCendolP.Text = Convert.ToString(String.Format("{0:0.00}", CendolP));
            lblKopiP.Text = Convert.ToString(String.Format("{0:0.00}", KopiP));
            lblTehP.Text = Convert.ToString(String.Format("{0:0.00}", TehP));
            lblNescafeP.Text = Convert.ToString(String.Format("{0:0.00}", NescafeP));
            lblMilo.Text = Convert.ToString(String.Format("{0:0.00}", MiloP));
            lblHorlickP.Text = Convert.ToString(String.Format("{0:0.00}", HorlickP));
            lblAirKosongP.Text = Convert.ToString(String.Format("{0:0.00}", AirKosongP));
            lblSirapP.Text = Convert.ToString(String.Format("{0:0.00}", SirapP));
        }

        private void cbNasiLemak_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiLemak.Checked == true)
            {
                txtNasiLemakQ.Enabled = true;
                txtNasiLemakQ.Text = "";
                txtNasiLemakQ.Focus();
            }
            else
            {
                txtNasiLemakQ.Enabled = false;
                txtNasiLemakQ.Text = "0";
            }
        }

        private void cbRotiCanai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRotiCanai.Checked == true)
            {
                txtRotiCanaiQ.Enabled = true;
                txtRotiCanaiQ.Text = "";
                txtRotiCanaiQ.Focus();
            }
            else
            {
                txtRotiCanaiQ.Enabled = false;
                txtRotiCanaiQ.Text = "0";
            }
        }

        private void cbNasiAyam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiAyam.Checked == true)
            {
                txtNasiAyamQ.Enabled = true;
                txtNasiAyamQ.Text = "";
                txtNasiAyamQ.Focus();
            }
            else
            {
                txtNasiAyamQ.Enabled = false;
                txtNasiAyamQ.Text = "0";
            }
        }

        private void cbNasiBujang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiBujang.Checked == true)
            {
                txtNasiBujangQ.Enabled = true;
                txtNasiBujangQ.Text = "";
                txtNasiBujangQ.Focus();
            }
            else
            {
                txtNasiBujangQ.Enabled = false;
                txtNasiBujangQ.Text = "0";
            }
        }

        private void cbMeeGoreng_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMeeGoreng.Checked == true)
            {
                txtMeeGorengQ.Enabled = true;
                txtMeeGorengQ.Text = "";
                txtMeeGorengQ.Focus();
            }
            else
            {
                txtMeeGorengQ.Enabled = false;
                txtMeeGorengQ.Text = "0";
            }
        }

        private void cbBihun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBihun.Checked == true)
            {
                txtBihunQ.Enabled = true;
                txtBihunQ.Text = "";
                txtBihunQ.Focus();
            }
            else
            {
                txtBihunQ.Enabled = false;
                txtBihunQ.Text = "0";
            }
        }

        private void cbNasiKandar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiKandar.Checked == true)
            {
                txtNasiKandarQ.Enabled = true;
                txtNasiKandarQ.Text = "";
                txtNasiKandarQ.Focus();
            }
            else
            {
                txtNasiKandarQ.Enabled = false;
                txtNasiKandarQ.Text = "0";
            }
        }

        private void cbCharKuayTeow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCharKuayTeow.Checked == true)
            {
                txtCKTQ.Enabled = true;
                txtCKTQ.Text = "";
                txtCKTQ.Focus();
            }
            else
            {
                txtCKTQ.Enabled = false;
                txtCKTQ.Text = "0";
            }
        }

        private void cbNasiKari_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiKari.Checked == true)
            {
                txtNasiKariQ.Enabled = true;
                txtNasiKariQ.Text = "";
                txtNasiKariQ.Focus();
            }
            else
            {
                txtNasiKariQ.Enabled = false;
                txtNasiKariQ.Text = "0";
            }
        }

        private void cbNasiTelurKicap_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNasiTelurKicap.Checked == true)
            {
                txtNTKQ.Enabled = true;
                txtNTKQ.Text = "";
                txtNTKQ.Focus();
            }

            else
            {
                txtNTKQ.Enabled = false;
                txtNTKQ.Text = "0";
            }
        }

        private void cbKaripap_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKaripap.Checked == true)
            {
                txtKaripapQ.Enabled = true;
                txtKaripapQ.Text = "";
                txtKaripapQ.Focus();
            }

            else
            {
                txtKaripapQ.Enabled = false;
                txtKaripapQ.Text = "0";
            }
        }

        private void cbKasturi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKasturi.Checked == true)
            {
                txtKasturiQ.Enabled = true;
                txtKasturiQ.Text = "";
                txtKasturiQ.Focus();
            }

            else
            {
                txtKasturiQ.Enabled = false;
                txtKasturiQ.Text = "0";
            }
        }

        private void cbPopia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPopia.Checked == true)
            {
                txtPopiaQ.Enabled = true;
                txtPopiaQ.Text = "";
                txtPopiaQ.Focus();
            }

            else
            {
                txtPopiaQ.Enabled = false;
                txtPopiaQ.Text = "0";
            }
        }

        private void cbMurukku_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMurukku.Checked == true)
            {
                txtMurukkuQ.Enabled = true;
                txtMurukkuQ.Text = "";
                txtMurukkuQ.Focus();
            }

            else
            {
                txtMurukkuQ.Enabled = false;
                txtMurukkuQ.Text = "0";
            }
        }

        private void cbPau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPau.Checked == true)
            {
                txtPauQ.Enabled = true;
                txtPauQ.Text = "";
                txtPauQ.Focus();
            }

            else
            {
                txtPauQ.Enabled = false;
                txtPauQ.Text = "0";
            }
        }

        private void cbABC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbABC.Checked == true)
            {
                txtABCQ.Enabled = true;
                txtABCQ.Text = "";
                txtABCQ.Focus();
            }

            else
            {
                txtABCQ.Enabled = false;
                txtABCQ.Text = "0";
            }
        }

        private void cbAisKrim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAisKrim.Checked == true)
            {
                txtAisKrimQ.Enabled = true;
                txtAisKrimQ.Text = "";
                txtAisKrimQ.Focus();
            }

            else
            {
                txtAisKrimQ.Enabled = false;
                txtAisKrimQ.Text = "0";
            }
        }

        private void cbGulabJamun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGulabJamun.Checked == true)
            {
                txtGulabJamunQ.Enabled = true;
                txtGulabJamunQ.Text = "";
                txtGulabJamunQ.Focus();
            }

            else
            {
                txtGulabJamunQ.Enabled = false;
                txtGulabJamunQ.Text = "0";
            }
        }

        private void cbBuburChaCha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuburChaCha.Checked == true)
            {
                txtBuburChaChaQ.Enabled = true;
                txtBuburChaChaQ.Text = "";
                txtBuburChaChaQ.Focus();
            }

            else
            {
                txtBuburChaChaQ.Enabled = false;
                txtBuburChaChaQ.Text = "0";
            }
        }

        private void cbCendol_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCendol.Checked == true)
            {
                txtCendolQ.Enabled = true;
                txtCendolQ.Text = "";
                txtCendolQ.Focus();
            }

            else
            {
                txtCendolQ.Enabled = false;
                txtCendolQ.Text = "0";
            }
        }

        private void cbKopi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKopi.Checked == true)
            {
                txtKopiQ.Enabled = true;
                txtKopiQ.Text = "";
                txtKopiQ.Focus();
                cmbKopiT.Enabled = true;
            }

            else
            {
                txtKopiQ.Enabled = false;
                txtKopiQ.Text = "0";
                cmbKopiT.Enabled = false;
            }
        }

        private void cbTeh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTeh.Checked == true)
            {
                txtTehQ.Enabled = true;
                txtTehQ.Text = "";
                txtTehQ.Focus();
                cmbTehT.Enabled = true;
            }

            else
            {
                txtTehQ.Enabled = false;
                txtTehQ.Text = "0";
                cmbTehT.Enabled = false;
            }
        }

        private void cbNescafe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNescafe.Checked == true)
            {
                txtNescafeQ.Enabled = true;
                txtNescafeQ.Text = "";
                txtNescafeQ.Focus();
                cmbNescafeT.Enabled = true;
            }

            else
            {
                txtNescafeQ.Enabled = false;
                txtNescafeQ.Text = "0";
                cmbNescafeT.Enabled = false;
            }
        }

        private void cbMilo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMilo.Checked == true)
            {
                txtMiloQ.Enabled = true;
                txtMiloQ.Text = "";
                txtMiloQ.Focus();
                cmbMiloT.Enabled = true;
            }

            else
            {
                txtMiloQ.Enabled = false;
                txtMiloQ.Text = "0";
                cmbMiloT.Enabled = true;
            }
        }

        private void cbHorlick_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHorlick.Checked == true)
            {
                txtHorlickQ.Enabled = true;
                txtHorlickQ.Text = "";
                txtHorlickQ.Focus();
                cmbHorlickT.Enabled = true;
            }

            else
            {
                txtHorlickQ.Enabled = false;
                txtHorlickQ.Text = "0";
                cmbHorlickT.Enabled = true;
            }
        }

        private void cbAirKosong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAirKosong.Checked == true)
            {
                txtAirKosongQ.Enabled = true;
                txtAirKosongQ.Text = "";
                txtAirKosongQ.Focus();
                cmbAirKosongT.Enabled = true;
            }

            else
            {
                txtAirKosongQ.Enabled = false;
                txtAirKosongQ.Text = "0";
                cmbAirKosongT.Enabled = true;
            }
        }

        private void cbSirap_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSirap.Checked == true)
            {
                txtSirapQ.Enabled = true;
                txtSirapQ.Text = "";
                txtSirapQ.Focus();
                cmbSirapT.Enabled = true;
            }

            else
            {
                txtSirapQ.Enabled = false;
                txtSirapQ.Text = "0";
                cmbSirapT.Enabled = true;
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            int MainCourseQuantity = 0, AppertizerQuantity = 0, DessertQuantity = 0, BeverageQuantity = 0;
            double[] itemcost = new double[27];
            
            try
            {
                itemcost[0] = Convert.ToDouble(txtNasiLemakQ.Text) * NasiLemakP;
                itemcost[1] = Convert.ToDouble(txtRotiCanaiQ.Text) * RotiCanaiP;
                itemcost[2] = Convert.ToDouble(txtNasiAyamQ.Text) * NasiAyamP;
                itemcost[3] = Convert.ToDouble(txtNasiBujangQ.Text) * NasiBujangP;
                itemcost[4] = Convert.ToDouble(txtMeeGorengQ.Text) * MeeGorengP;
                itemcost[5] = Convert.ToDouble(txtBihunQ.Text) * BihunP;
                itemcost[6] = Convert.ToDouble(txtNasiKandarQ.Text) * NasiKandarP;
                itemcost[7] = Convert.ToDouble(txtCKTQ.Text) * CharKueyTeowP;
                itemcost[8] = Convert.ToDouble(txtNasiKariQ.Text) * NasiKariP;
                itemcost[9] = Convert.ToDouble(txtNTKQ.Text) * NasiTelurKicapP;
                itemcost[10] = Convert.ToDouble(txtKaripapQ.Text) * KaripapP;
                itemcost[11] = Convert.ToDouble(txtKasturiQ.Text) * KasturiP;
                itemcost[12] = Convert.ToDouble(txtPopiaQ.Text) * PopiaP;
                itemcost[13] = Convert.ToDouble(txtMurukkuQ.Text) * MurukkuP;
                itemcost[14] = Convert.ToDouble(txtPauQ.Text) * PauP;
                itemcost[15] = Convert.ToDouble(txtABCQ.Text) * ABCP;
                itemcost[16] = Convert.ToDouble(txtAisKrimQ.Text) * AisKrimP;
                itemcost[17] = Convert.ToDouble(txtGulabJamunQ.Text) * GulabJamunP;
                itemcost[18] = Convert.ToDouble(txtBuburChaChaQ.Text) * BuburChaChaP;
                itemcost[19] = Convert.ToDouble(txtCendolQ.Text) * CendolP;
                
                if (cmbKopiT.Text == "Cold")
                {
                    KopiP = 2.2;
                }
                else
                {
                    KopiP = 1.7;
                }
                itemcost[20] = Convert.ToDouble(txtKopiQ.Text) * KopiP;

                if (cmbTehT.Text == "Cold")
                {
                    TehP = 2.2;
                }
                else
                {
                    TehP = 1.7;
                }
                itemcost[21] = Convert.ToDouble(txtTehQ.Text) * TehP;

                if (cmbNescafeT.Text == "Cold")
                {
                    NescafeP = 2.5;
                }
                else
                {
                    NescafeP = 2.0;
                }
                itemcost[22] = Convert.ToDouble(txtNescafeQ.Text) * NescafeP;

                if (cmbMiloT.Text == "Cold")
                {
                    MiloP = 2.5;
                }
                else
                {
                    MiloP = 2.0;
                }
                itemcost[23] = Convert.ToDouble(txtMiloQ.Text) * MiloP;

                if (cmbHorlickT.Text == "Cold")
                {
                    HorlickP = 2.5;
                }
                else
                {
                    HorlickP = 2.0;
                }
                itemcost[24] = Convert.ToDouble(txtHorlickQ.Text) * HorlickP;

                if (cmbSirapT.Text == "Cold")
                {
                    AirKosongP = 1.0;
                }
                else
                {
                    AirKosongP = 0.5;
                }
                itemcost[25] = Convert.ToDouble(txtAirKosongQ.Text) * AirKosongP;

                if (cmbAirKosongT.Text == "Cold")
                {
                    SirapP = 2.0;
                }
                else
                {
                    SirapP = 1.5;
                }
                itemcost[26] = Convert.ToDouble(txtSirapQ.Text) * SirapP;
            }

            catch (FormatException fe)
            {
                DialogResult button;
                button = MessageBox.Show("Input must be in integer number only","Wrong Input", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                if (button == DialogResult.OK)
                {
                    Application.Restart();
                }
            }

            Total = itemcost[0] + itemcost[1] + itemcost[2] + itemcost[3] + itemcost[4] + itemcost[5] + itemcost[6] + itemcost[7] + itemcost[8] + itemcost[9] + itemcost[10] + itemcost[11] + itemcost[12] + itemcost[13] + itemcost[14] + itemcost[15] + itemcost[16] + itemcost[17] + itemcost[18] + itemcost[19] + itemcost[20] + itemcost[21] + itemcost[22] + itemcost[23] + itemcost[24] + itemcost[25] + itemcost[26];

            MainCourseQuantity = Convert.ToInt32(txtNasiLemakQ.Text) + Convert.ToInt32(txtRotiCanaiQ.Text) + Convert.ToInt32(txtNasiAyamQ.Text) + Convert.ToInt32(txtNasiBujangQ.Text) + Convert.ToInt32(txtMeeGorengQ.Text) + Convert.ToInt32(txtBihunQ.Text) + Convert.ToInt32(txtNasiKandarQ.Text) + Convert.ToInt32(txtCKTQ.Text) + Convert.ToInt32(txtNasiKariQ.Text) + Convert.ToInt32(txtNTKQ.Text); // Sum up all the main course items
            AppertizerQuantity = Convert.ToInt32(txtKaripapQ.Text) + Convert.ToInt32(txtKasturiQ.Text) + Convert.ToInt32(txtPopiaQ.Text) + Convert.ToInt32(txtMurukkuQ.Text) + Convert.ToInt32(txtPauQ.Text);
            DessertQuantity = Convert.ToInt32(txtABCQ.Text) + Convert.ToInt32(txtAisKrimQ.Text) + Convert.ToInt32(txtGulabJamunQ.Text) + Convert.ToInt32(txtBuburChaChaQ.Text) + Convert.ToInt32(txtCendolQ.Text);
            BeverageQuantity = Convert.ToInt32(txtKopiQ.Text) + Convert.ToInt32(txtTehQ.Text) + Convert.ToInt32(txtNescafeQ.Text) + Convert.ToInt32(txtMiloQ.Text) + Convert.ToInt32(txtHorlickQ.Text) + Convert.ToInt32(txtAirKosongQ.Text) + Convert.ToInt32(txtSirapQ.Text);
            //lblMainCourseQ.Text = Convert.ToString(MainCourseQuantity); //To see the result of main course quantity

            lblBDResult.Text = Convert.ToString(String.Format("{0:0.00}", Total));//Cost before discount
            lblDResult.Text = Convert.ToString(String.Format("{0:0.00}", Total));

            if ((MainCourseQuantity > 0) && (AppertizerQuantity > 0) && (DessertQuantity > 0))
            {
                Total = Total * 0.95;
                lblDResult.Text = Convert.ToString(String.Format("{0:0.00}", Total));//Price after discount
            }

            if((MainCourseQuantity+AppertizerQuantity+DessertQuantity+BeverageQuantity) >= 5)
            {
                Total = Total * 0.98;
                lblDResult.Text = Convert.ToString(String.Format("{0:0.00}", Total));//Price after discount
            }

            Tax = Total * TaxRate;
            lblTaxResult.Text = Convert.ToString(String.Format("{0:0.00}", Tax));//Tax price
            TotalAmount = Total + Tax;

            lblResult.Text = Convert.ToString(String.Format("{0:0.00}", TotalAmount));//Price after discount and tax

        }
    }
}
